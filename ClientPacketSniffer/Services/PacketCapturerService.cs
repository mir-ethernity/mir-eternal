using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPacketSniffer
{
    public class PacketCapturerService
    {
        private static PcapDevice? _device = null;
        private static Thread? _thread;
        private static Dictionary<byte, PacketInfo[]> _extraTmpPackets = new Dictionary<byte, PacketInfo[]>();
        public static bool Working { get; set; }

        public static void Stop()
        {
            if (!Working) return;

            Working = false;

            while (_thread != null && _thread.IsAlive)
                Thread.Sleep(100);

            _device?.Close();
            _device?.Dispose();
            _device = null;
        }

        public static void Start()
        {
            if (Working) return;

            _extraTmpPackets.Clear();

            Console.WriteLine("What type of device do you want to use?");
            Console.WriteLine("[0] Network device");
            Console.WriteLine("[1] File device");
            Console.Write("Write index: ");
            var methodType = Console.ReadLine();

            switch (methodType)
            {
                case "0":
                    var devices = CaptureDeviceList.Instance
                .OfType<LibPcapLiveDevice>()
                .ToList();

                    if (devices.Count == 0)
                    {
                        Console.WriteLine($"No devices were found on this machine.");
                        Environment.Exit(1);
                    }

                    Console.WriteLine($"Please, select interface: ");

                    for (var i = 0; i < devices.Count; i++)
                    {
                        Console.WriteLine($" [{i}] {devices[i].Description} {string.Join(", ", devices[i].Addresses.Select(x => x.Addr.ipAddress))}");
                    }

                    Console.Write("Type device index: ");

                    var deviceIndex = int.Parse(Console.ReadLine() ?? "0");

                    if (deviceIndex < 0 || deviceIndex >= devices.Count)
                    {
                        Console.WriteLine("Device index out of range.");
                        Environment.Exit(1);
                    }

                    _device = devices[deviceIndex];
                    break;
                case "1":
                    _device = new CaptureFileReaderDevice(@"D:\Mir3D\caca.pcap");
                    break;
                default:
                    throw new ApplicationException();
            }

            Console.WriteLine("Opening device...");

            _device.Open(new DeviceConfiguration
            {
                Mode = DeviceModes.Promiscuous,
                ReadTimeout = 10000,
            });


            var time = DateTime.Now.ToString("yyyyMMddHHmmss");

            var packetsFolderPath = Path.Combine(Environment.CurrentDirectory, "packets");

            if (!Directory.Exists(packetsFolderPath)) Directory.CreateDirectory(packetsFolderPath);

            using var fileStream = File.Create(Path.Combine(packetsFolderPath, $"{time}.raw"));
            using var binaryWriter = new BinaryWriter(fileStream);

            Console.WriteLine("Ready! Listening packets");

            Working = true;

            var running = true;

            _thread = new Thread(() =>
            {
                try
                {
                    var tcpClientCounter = 0;
                    var tcpServerCounter = 0;
                    var udpClientCounter = 0;
                    var udpServerCounter = 0;
                    var pid = 0;

                    var updateTitle = () =>
                    {
                        Console.Title = $"Packet Analizer (TCC:{tcpClientCounter}, TSC:{tcpServerCounter}, UCC:{udpClientCounter}, USC:{udpServerCounter})";
                    };

                    var writePacket = (byte type, byte[] packet) =>
                    {
                        binaryWriter.Write(type);
                        binaryWriter.Write(packet.Length);
                        binaryWriter.Write(packet, 0, packet.Length);
                    };

                    updateTitle();

                    while (Working && _device.Opened)
                    {
                        var status = _device.GetNextPacket(out PacketCapture packet);
                        if (!Working) break;
                        if (status != GetPacketStatus.PacketRead) continue;

                        var rawCapture = packet.GetPacket();
                        var p = Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data);
                        if (p.PayloadPacket is not IPv4Packet ipv4packet) continue;

                        if (
                            ipv4packet.PayloadPacket is not TransportPacket transportPacket
                            || transportPacket.PayloadData == null
                            || transportPacket.PayloadData.Length == 0
                        ) continue;

                        var isGame = transportPacket.SourcePort == 8701 || transportPacket.DestinationPort == 8701;
                        if (!isGame) continue;

                        var packetFromClient = transportPacket.DestinationPort == 8701;

                        if (transportPacket is TcpPacket && packetFromClient)
                        {
                            writePacket(0, transportPacket.PayloadData);
                            DisplayPacketInfo(new PacketInfo
                            {
                                PID = pid,
                                Source = 0,
                                Data = transportPacket.PayloadData
                            });
                            tcpClientCounter++;
                        }
                        if (transportPacket is TcpPacket && !packetFromClient)
                        {
                            writePacket(1, transportPacket.PayloadData);
                            DisplayPacketInfo(new PacketInfo
                            {
                                PID = pid,
                                Source = 1,
                                Data = transportPacket.PayloadData
                            });
                            tcpServerCounter++;
                        }
                        if (transportPacket is UdpPacket && packetFromClient)
                        {
                            writePacket(2, transportPacket.PayloadData);
                            DisplayPacketInfo(new PacketInfo
                            {
                                PID = pid,
                                Source = 2,
                                Data = transportPacket.PayloadData
                            });
                            udpClientCounter++;
                        }
                        if (transportPacket is UdpPacket && !packetFromClient)
                        {
                            writePacket(3, transportPacket.PayloadData);
                            DisplayPacketInfo(new PacketInfo
                            {
                                PID = pid,
                                Source = 3,
                                Data = transportPacket.PayloadData
                            });
                            udpServerCounter++;
                        }

                        updateTitle();
                        pid++;
                    }
                }
                finally
                {
                    running = false;
                }
            })
            {
                IsBackground = true
            };

            _thread.Start();

            while (running) Thread.Sleep(100);
        }

        private static void DisplayPacketInfo(PacketInfo packet)
        {
            if (!_extraTmpPackets.ContainsKey(packet.Source)) _extraTmpPackets.Add(packet.Source, new PacketInfo[0]);

            var packets = _extraTmpPackets[packet.Source].Concat(new PacketInfo[] { packet }).ToArray();
            try
            {
                var parsed = PacketInspectorService.ParseRawPackets(packets, out bool fullReaded);
                if (!fullReaded)
                {
                    _extraTmpPackets[packet.Source] = packets;
                }
                else
                {
                    _extraTmpPackets[packet.Source] = Array.Empty<PacketInfo>();
                    foreach (var gamePacket in parsed)
                    {
                        Console.WriteLine($"#{gamePacket.PID} - SRC: {(gamePacket.PacketInfo.Source == 0 ? "C->S" : "S-C")}, ID: {gamePacket.PacketInfo.Id} ({gamePacket.PacketInfo.Name})");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error parsing packet, ignoring and try to continue...");
                Console.WriteLine(ex.Message);
                _extraTmpPackets[packet.Source] = Array.Empty<PacketInfo>();
            }
        }
    }
}
