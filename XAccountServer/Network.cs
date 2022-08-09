using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using XAccountServer;

namespace AccountServer
{
    public sealed partial class Network
    {
        public static UdpClient LocalServer;
        public static ConcurrentQueue<PacketData> IncomingQueue;
        public static bool Start()
        {
            bool result;
            try
            {
                LocalServer = new UdpClient(new IPEndPoint(IPAddress.Any, (int)((ushort)Config.LoginGatePort)));
                IncomingQueue = new ConcurrentQueue<PacketData>();
                Task.Run(delegate ()
                {
                    while (LocalServer != null)
                    {
                        try
                        {
                            if (LocalServer.Available == 0)
                            {
                                Thread.Sleep(1);
                                continue;
                            }

                            var packet = default(PacketData);
                            packet.ReceivedData = LocalServer.Receive(ref packet.ClientAddress);
                            if (packet.ReceivedData.Length > 1024)
                            {
                                Console.WriteLine(string.Format("Excessively long packet received Address: {0}, Length: {1}", packet.ClientAddress, packet.ReceivedData.Length));
                            }
                            else
                            {
                                IncomingQueue.Enqueue(packet);
                            }
                        }
                        catch (Exception ex2)
                        {
                            Console.Error.WriteLine("An error ocurred receiving data: " + ex2.Message);
                        }
                    }
                });

                Task.Run(delegate ()
                {
                    Console.WriteLine("--- [ Ready to Process Client Requests ] ---");
                    while (LocalServer != null)
                    {
                        try
                        {
                            if (IncomingQueue.IsEmpty || !IncomingQueue.TryDequeue(out PacketData packet))
                            {
                                Thread.Sleep(1);
                                continue;
                            }

                            string[] array = Encoding.UTF8.GetString(packet.ReceivedData, 0, packet.ReceivedData.Length).Split(new char[]
                               {
                                    ' '
                               }, StringSplitOptions.RemoveEmptyEntries);
                            int num;
                            if (array.Length <= 3 || !int.TryParse(array[0], out num))
                            {
                                Console.Error.WriteLine(string.Format("Bad Packet Received, Address: {0}, Length: {1}", packet.ClientAddress, packet.ReceivedData.Length));
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
                                                Console.Error.WriteLine(string.Format("Undefined packet received address: {0}, length: {1}", packet.ClientAddress, packet.ReceivedData.Length));
                                            }
                                            else if (array.Length == 6)
                                            {
                                                if (!SEnvir.Accounts.Login(array[2], array[3]))
                                                {
                                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 7 wrong user name or password"));
                                                }
                                                else if (!SEnvir.TryGetServerConfig(array[4], out var serverConfig))
                                                {
                                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 7 server not found"));
                                                }
                                                else
                                                {
                                                    string text = AccountData.GenerateTickets();
                                                    SendTicket(IPEndPoint.Parse(serverConfig.PrivateIP), text, array[2]);
                                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(string.Concat(new string[]
                                                    {
                                                            array[0],
                                                            " 6 ",
                                                            array[2],
                                                            " ",
                                                            array[3],
                                                            " ",
                                                            text
                                                    })));
                                                    Console.WriteLine("Successfully Generated Tickets! Account: " + array[2] + " - " + text);
                                                    SEnvir.TotalTickets += 1U;
                                                }
                                            }
                                        }
                                        else if (array.Length == 6)
                                        {
                                            AccountData accountData;
                                            if (array[3].Length <= 1 || array[3].Length > 18)
                                            {
                                                SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 5 wrong password length"));
                                            }
                                            else
                                            {
                                                var account = SEnvir.Accounts.GetByUsername(array[2]);
                                                if (account == null)
                                                {
                                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 5 Account does not exist"));
                                                }
                                                else if (array[4] != account.Question)
                                                {
                                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 5 Wrong question"));
                                                }
                                                else if (array[5] != account.Answer)
                                                {
                                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 5 Wrong answer"));
                                                }
                                                else
                                                {
                                                    SEnvir.Accounts.ChangePassword(array[2], array[3]);
                                                    SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(string.Concat(new string[]
                                                    {
                                                        array[0],
                                                        " 4 ",
                                                        array[1],
                                                        " ",
                                                        array[2]
                                                    })));
                                                    Console.WriteLine("Password Changed on Account: " + array[1]);
                                                }
                                            }
                                        }
                                    }
                                    else if (array.Length == 6)
                                    {
                                        if (array[2].Length <= 5 || array[2].Length > 12)
                                        {
                                            SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Username length is wrong"));
                                        }
                                        else if (array[3].Length <= 5 || array[3].Length > 18)
                                        {
                                            SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Wrong password length"));
                                        }
                                        else if (array[4].Length <= 1 || array[4].Length > 18)
                                        {
                                            SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Question length is wrong"));
                                        }
                                        else if (array[5].Length <= 1 || array[5].Length > 18)
                                        {
                                            SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Answer length is wrong"));
                                        }
                                        else if (!Regex.IsMatch(array[2], "^[a-zA-Z]+.*$"))
                                        {
                                            SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Username format error"));
                                        }
                                        else if (!Regex.IsMatch(array[2], "^[a-zA-Z_][A-Za-z0-9_]*$"))
                                        {
                                            SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 3 Username format error"));
                                        }
                                        else if (SEnvir.Accounts.Exists(array[2]))
                                        {
                                            SendData(packet.ClientAddress, Encoding.UTF8.GetBytes("3 Username already exists"));
                                        }
                                        else
                                        {
                                            SEnvir.Accounts.Register(new AccountData(array[2], array[3], array[4], array[5]));
                                            SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(string.Concat(new string[]
                                            {
                                                    array[0],
                                                    " 2 ",
                                                    array[2],
                                                    " ",
                                                    array[3]
                                            })));
                                            Console.WriteLine("New Account Created: " + array[2]);
                                            SEnvir.TotalNewAccounts += 1U;
                                        }
                                    }
                                }
                                else if (array.Length == 4)
                                {
                                    if (!SEnvir.Accounts.Login(array[2], array[3]))
                                    {
                                        SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(array[0] + " 1 wrong user name or password"));
                                    }
                                    else
                                    {
                                        SendData(packet.ClientAddress, Encoding.UTF8.GetBytes(string.Concat(new string[]
                                        {
                                                array[0],
                                                " 0 ",
                                                array[2],
                                                " ",
                                                array[3],
                                                " ",
                                                Config.GameServerArea
                                        })));
                                        Console.WriteLine("Account login successful! Account: " + array[2]);
                                    }
                                }
                            }
                        }
                        catch (Exception ex2)
                        {
                            Console.WriteLine("Packet processing error: " + ex2.Message);
                        }
                    }
                    Console.WriteLine("Stopped Processing Client Requests.");
                });
                result = true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                UdpClient udpClient = LocalServer;
                if (udpClient != null)
                {
                    udpClient.Close();
                }
                LocalServer = null;
                result = false;
            }
            return result;
        }
        public static void Stop()
        {
            UdpClient udpClient = LocalServer;
            if (udpClient != null)
            {
                udpClient.Close();
            }
            LocalServer = null;
        }
        public static void SendData(IPEndPoint address, byte[] data)
        {
            SEnvir.TotalBytesSended += (long)data.Length;

            if (LocalServer != null)
            {
                try
                {
                    LocalServer.Send(data, data.Length, address);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error sending data: " + ex.Message);
                }
            }
        }
        public static void SendTicket(IPEndPoint address, string packet, string account)
        {
            SEnvir.TotalTickets += 1U;
            byte[] bytes = Encoding.UTF8.GetBytes(packet + ";" + account);
            if (LocalServer != null)
            {
                try
                {
                    LocalServer.Send(bytes, bytes.Length, new IPEndPoint(address.Address, (int)((ushort)Config.LoginServerPort)));
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error sending packet: " + ex.Message);
                }
            }
        }
    }
}
