// See https://aka.ms/new-console-template for more information
using ClientPacketSniffer;

Console.WriteLine("Hello, World!");

Config.TcpLocalPort = 8701;
Config.TcpRemotePort = 8701;
Config.TcpRemoteIP = "175.24.251.29";

Config.UdpLocalPort = 8701;
Config.UdpRemotePort = 8701;
Config.UdpRemoteIP = "175.24.251.29";

var tcp = new TcpServer();
var udp = new UdpServer();

tcp.Start();
udp.Start();

Console.ReadLine();