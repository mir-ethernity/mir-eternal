using GameServer.Data;
using GameServer.Maps;
using GameServer.Networking;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace GameServer
{
    public static class MainProcess
    {
        public static DateTime CurrentTime;
        public static DateTime NextUpdateLoopCountsTime;
        public static DateTime NextSaveDataTime;
        public static ConcurrentQueue<GMCommand> CommandsQueue;
        public static uint LoopCount;
        public static bool Running;
        public static bool Saving;
        public static Thread MainThread;
        public static Random RandomNumber;

        public static ConcurrentQueue<Action> ReloadTasks = new ConcurrentQueue<Action>();
        public static DateTime NextReloadTaskTime;

        static MainProcess()
        {
            CurrentTime = DateTime.Now;
            NextUpdateLoopCountsTime = DateTime.Now.AddSeconds(1.0);
            RandomNumber = new Random();
        }

        public static void Start()
        {
            if (!Running)
            {
                Thread thread = new(new ThreadStart(MainLoop))
                {
                    IsBackground = true
                };
                MainThread = thread;
                thread.Start();
            }
        }

        public static void Stop()
        {
            Running = false;
            NetworkServiceGateway.Stop();
        }

        public static void AddSystemLog(string text)
        {
            MainForm.AddSystemLog(text);
        }

        public static void AddChatLog(string preffix, byte[] text)
        {
            MainForm.AddChatLog(preffix, text);
        }

        private static void MainLoop()
        {
            CommandsQueue = new ConcurrentQueue<GMCommand>();
            MainForm.AddSystemLog("Map elements are being generated...");
            MapGatewayProcess.Start();
            MainForm.AddSystemLog("Network services are being started...");
            NetworkServiceGateway.Start();
            MainForm.AddSystemLog("The server has been successfully opened");
            Running = true;
            MainForm.ServerStartedCallback();
            var sw = new Stopwatch();

            while (true)
            {
                if (!Running)
                {
                    if (NetworkServiceGateway.Connections.Count == 0)
                        break;
                }
                try
                {
                    sw.Reset();

                    CurrentTime = DateTime.Now;
                    ProcessSaveData();
                    ProcessServerStats();
                    ProcessGMCommands();
                    NetworkServiceGateway.Process();
                    MapGatewayProcess.Process();
                    ProcessReloadTasks();
                    sw.Stop();

                    if (sw.ElapsedMilliseconds <= 2)
                        Thread.Sleep(1);
                }
                catch (Exception ex)
                {
                    GameDataGateway.SaveData();
                    GameDataGateway.PersistData();
                    GameDataGateway.CleanUp();
                    MainForm.AddSystemLog("A fatal error has occurred and the server is about to stop");
                    if (!Directory.Exists(".\\Log\\Error"))
                        Directory.CreateDirectory(".\\Log\\Error");
                    File.WriteAllText(string.Format(".\\Log\\Error\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), "Error message:\r\n" + ex.Message + "\r\nStack information:\r\n" + ex.StackTrace);
                    MainForm.AddSystemLog("Error has been saved to the log, please note");
                    ClearConnections();
                    break;
                }
            }

            MainForm.AddSystemLog("ItemData is being cleaned up...");
            MapGatewayProcess.CleanUp();
            MainForm.AddSystemLog("Customer data is being saved...");
            GameDataGateway.SaveData();
            GameDataGateway.PersistData();
            GameDataGateway.CleanUp();
            MainForm.Stop();
            MainThread = null;
            MainForm.AddSystemLog("The server has been successfully shut down");
        }

        private static void ProcessReloadTasks()
        {
            if (CurrentTime > NextReloadTaskTime && ReloadTasks.TryDequeue(out var action))
            {
                action();

                if (ReloadTasks.Count == 0)
                {
                    NetworkServiceGateway.SendAnnouncement(Config.GetTranslation("content", "reload_success", "服务器数据重载成功！！！"), true);
                }
                else
                {
                    NextReloadTaskTime = CurrentTime.AddMilliseconds(500);
                }
            }
        }

        private static void ClearConnections()
        {
            foreach (SConnection connection in NetworkServiceGateway.Connections)
            {
                try
                {
                    TcpClient tcpClient = connection.Connection;
                    if (tcpClient != null)
                    {
                        Socket client = tcpClient.Client;
                        if (client != null)
                        {
                            client.Shutdown(SocketShutdown.Both);
                        }
                        tcpClient.Close();
                    }
                }
                catch
                {
                }
            }
        }

        private static void ProcessGMCommands()
        {
            while (CommandsQueue.TryDequeue(out GMCommand GMCommand))
                GMCommand.Execute();
        }

        private static void ProcessServerStats()
        {
            if (CurrentTime > NextUpdateLoopCountsTime)
            {
                MainForm.UpdateTotalConnections((uint)NetworkServiceGateway.Connections.Count);
                MainForm.UpdateAlreadyLogged(NetworkServiceGateway.ActiveConnections);
                MainForm.UpdateConnectionsOnline(NetworkServiceGateway.ConnectionsOnline);
                MainForm.UpdateSendedBytes(NetworkServiceGateway.SendedBytes);
                MainForm.UpdateReceivedBytes(NetworkServiceGateway.ReceivedBytes);
                MainForm.UpdateObjectStatistics(MapGatewayProcess.ActiveObjects.Count, MapGatewayProcess.SecondaryObjects.Count, MapGatewayProcess.Objects.Count);
                MainForm.UpdateLoopCount(LoopCount);
                LoopCount = 0U;
                NextUpdateLoopCountsTime = CurrentTime.AddSeconds(1.0);
            }
            else
            {
                LoopCount += 1U;
            }
        }

        private static void ProcessSaveData()
        {
            if (NextSaveDataTime > CurrentTime) return;
            GameDataGateway.SaveData();
            GameDataGateway.PersistData();
            GameDataGateway.CleanUp();
            NextSaveDataTime = CurrentTime.AddSeconds(60);
            MainForm.AddSystemLog("玩家数据保存成功!");
        }
    }
}
