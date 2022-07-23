using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AccountServer
{
    public sealed class Network
    {
        public static bool Start()
        {
            bool result;
            try
            {
                Network.LocalServer = new UdpClient(new IPEndPoint(IPAddress.Any, (int)((ushort)MainForm.Singleton.txtServerPort.Value)));
                Network.IncomingQueue = new ConcurrentQueue<Network.PacketData>();
                Task.Run(delegate ()
                {
                    while (Network.LocalServer != null)
                    {
                        try
                        {
                            UdpClient udpClient2 = Network.LocalServer;
                            if (udpClient2 != null && udpClient2.Available == 0)
                            {
                                Thread.Sleep(1);
                            }
                            else
                            {
                                Network.PacketData packet = default(Network.PacketData);
                                packet.ReceivedData = Network.LocalServer.Receive(ref packet.ClientAddress);
                                if (packet.ReceivedData.Length > 1024)
                                {
                                    MainForm.AddLog(string.Format("Excessively long packet received Address: {0}, Length: {1}", packet.ClientAddress, packet.ReceivedData.Length));
                                }
                                else
                                {
                                    Network.IncomingQueue.Enqueue(packet);
                                    MainForm.TotalBytesReceived += (long)packet.ReceivedData.Length;
                                    MainForm.UpdateTotalBytesReceived();
                                }
                            }
                        }
                        catch (Exception ex2)
                        {
                            MainForm.AddLog("An error ocurred receiving data: " + ex2.Message);
                        }
                    }
                });
                Task.Run(delegate ()
                {
                    MainForm.AddLog("Starting to process client requests.");
                    while (Network.LocalServer != null)
                    {
                        try
                        {
                            Network.PacketData packet;
                            if (Network.IncomingQueue.IsEmpty || !Network.IncomingQueue.TryDequeue(out packet))
                            {
                                Thread.Sleep(1);
                            }
                            else
                            {
                                string[] array = Encoding.UTF8.GetString(packet.ReceivedData, 0, packet.ReceivedData.Length).Split(new char[]
                                {
                                    ' '
                                }, StringSplitOptions.RemoveEmptyEntries);
                                int num;
                                if (array.Length <= 3 || !int.TryParse(array[0], out num))
                                {
                                    MainForm.AddLog(string.Format("Bad packet received Address: {0}, Length: {1}", packet.ClientAddress, packet.ReceivedData.Length));
                                }
                                else
                                {
                                    string a = array[1];
                                    if (!(a == "0"))
                                    {
                                        if (!(a == "1"))
                                        {
                                            if (!(a == "2"))
                                            {
                                                if (!(a == "3"))
                                                {
                                                    MainForm.AddLog(string.Format("Undefined packet received address: {0}, length: {1}", packet.ClientAddress, packet.ReceivedData.Length));
                                                }
                                                else if (array.Length == 6)
                                                {
                                                    AccountData accountData;
                                                    IPEndPoint address;
                                                    if (!MainForm.AccountData.TryGetValue(array[2], out accountData) || array[3] != accountData.Password)
                                                    {
                                                        Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 7 wrong user name or password"));
                                                    }
                                                    else if (!MainForm.ServerData.TryGetValue(array[4], out address))
                                                    {
                                                        Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 7 server not found"));
                                                    }
                                                    else
                                                    {
                                                        string text = AccountData.GenerateTickets();
                                                        Network.SendTicket(address, text, array[2]);
                                                        Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(string.Concat(new string[]
                                                        {
                                                            array[0],
                                                            " 6 ",
                                                            array[2],
                                                            " ",
                                                            array[3],
                                                            " ",
                                                            text
                                                        })));
                                                        MainForm.AddLog("Successfully generated tickets! Account: " + array[2] + " - " + text);
                                                        MainForm.TotalTickets += 1U;
                                                        MainForm.UpdateTotalTickets();
                                                    }
                                                }
                                            }
                                            else if (array.Length == 6)
                                            {
                                                AccountData accountData;
                                                if (array[3].Length <= 1 || array[3].Length > 18)
                                                {
                                                    Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 5 wrong password length"));
                                                }
                                                else if (!MainForm.AccountData.TryGetValue(array[2], out accountData))
                                                {
                                                    Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 5 Account does not exist"));
                                                }
                                                else if (array[4] != accountData.Question)
                                                {
                                                    Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 5 Wrong question"));
                                                }
                                                else if (array[5] != accountData.Answer)
                                                {
                                                    Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 5 Wrong answer"));
                                                }
                                                else
                                                {
                                                    accountData.Password = array[3];
                                                    MainForm.SaveAccount(accountData);
                                                    Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(string.Concat(new string[]
                                                    {
                                                        array[0],
                                                        " 4 ",
                                                        array[1],
                                                        " ",
                                                        array[2]
                                                    })));
                                                    MainForm.AddLog("Password changed successfully! Account: " + array[1]);
                                                }
                                            }
                                        }
                                        else if (array.Length == 6)
                                        {
                                            if (array[2].Length <= 5 || array[2].Length > 12)
                                            {
                                                Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Username length is wrong"));
                                            }
                                            else if (array[3].Length <= 5 || array[3].Length > 18)
                                            {
                                                Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Wrong password length"));
                                            }
                                            else if (array[4].Length <= 1 || array[4].Length > 18)
                                            {
                                                Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Question length is wrong"));
                                            }
                                            else if (array[5].Length <= 1 || array[5].Length > 18)
                                            {
                                                Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Answer length is wrong"));
                                            }
                                            else if (!Regex.IsMatch(array[2], "^[a-zA-Z]+.*$"))
                                            {
                                                Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Username format error"));
                                            }
                                            else if (!Regex.IsMatch(array[2], "^[a-zA-Z_][A-Za-z0-9_]*$"))
                                            {
                                                Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Username format error"));
                                            }
                                            else if (MainForm.AccountData.ContainsKey(array[2]))
                                            {
                                                Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes("3 Username already exists"));
                                            }
                                            else
                                            {
                                                MainForm.AddAccount(new AccountData(array[2], array[3], array[4], array[5]));
                                                Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(string.Concat(new string[]
                                                {
                                                    array[0],
                                                    " 2 ",
                                                    array[2],
                                                    " ",
                                                    array[3]
                                                })));
                                                MainForm.AddLog("Account registration is successful! Account: " + array[2]);
                                                MainForm.TotalNewAccounts += 1U;
                                                MainForm.UpdateTotalNewAccounts();
                                            }
                                        }
                                    }
                                    else if (array.Length == 4)
                                    {
                                        AccountData AccountData3;
                                        if (!MainForm.AccountData.TryGetValue(array[2], out AccountData3) || array[3] != AccountData3.Password)
                                        {
                                            Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 1 wrong user name or password"));
                                        }
                                        else
                                        {
                                            Network.SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(string.Concat(new string[]
                                            {
                                                array[0],
                                                " 0 ",
                                                array[2],
                                                " ",
                                                array[3],
                                                " ",
                                                MainForm.GameServerArea
                                            })));
                                            MainForm.AddLog("Account login successful! Account: " + array[2]);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex2)
                        {
                            MainForm.AddLog("Packet processing error: " + ex2.Message);
                        }
                    }
                    MainForm.AddLog("Stop processing client requests.");
                });
                result = true;
            }
            catch (Exception ex)
            {
                MainForm.AddLog(ex.Message);
                UdpClient udpClient = Network.LocalServer;
                if (udpClient != null)
                {
                    udpClient.Close();
                }
                Network.LocalServer = null;
                result = false;
            }
            return result;
        }


        public static void Stop()
        {
            UdpClient udpClient = Network.LocalServer;
            if (udpClient != null)
            {
                udpClient.Close();
            }
            Network.LocalServer = null;
        }


        public static void SendData(IPEndPoint address, byte[] data)
        {
            MainForm.TotalBytesSended += (long)data.Length;
            MainForm.UpdateTotalBytesSended();

            if (Network.LocalServer != null)
            {
                try
                {
                    Network.LocalServer.Send(data, data.Length, address);
                }
                catch (Exception ex)
                {
                    MainForm.AddLog("Error sending data: " + ex.Message);
                }
            }
        }


        public static void SendTicket(IPEndPoint address, string packet, string account)
        {
            MainForm.TotalTickets += 1U;
            byte[] bytes = Encoding.UTF8.GetBytes(packet + ";" + account);
            if (Network.LocalServer != null)
            {
                try
                {
                    Network.LocalServer.Send(bytes, bytes.Length, new IPEndPoint(address.Address, (int)((ushort)MainForm.Singleton.txtTicketPort.Value)));
                }
                catch (Exception ex)
                {
                    MainForm.AddLog("Error sending packet: " + ex.Message);
                }
            }
        }


        public static UdpClient LocalServer;


        public static ConcurrentQueue<Network.PacketData> IncomingQueue;


        public struct PacketData
        {

            public IPEndPoint ClientAddress;


            public byte[] ReceivedData;
        }
    }
}
