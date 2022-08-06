using ClientPacketSniffer.Repositories;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPacketSniffer
{

    public class PacketInspectorService
    {
        public static void DisplaySession()
        {
            var sessionsPath = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "packets"), "*.raw");

            Console.WriteLine("Please, select session: ");

            for (var i = 0; i < sessionsPath.Length; i++)
            {
                var sessionPath = sessionsPath[i];
                var fileName = Path.GetFileNameWithoutExtension(sessionPath);
                Console.WriteLine($"[{i}] {fileName}");
            }

            Console.Write("Session: ");
            var sessionIdx = sessionsPath.Length == 1 ? 0 : int.Parse(Console.ReadLine() ?? "0");
            var sessionFile = sessionsPath[sessionIdx];
            var buffer = File.ReadAllBytes(sessionFile);
            var rawPackets = GetRawPackets(buffer);

            try
            {
                var packets = ParseRawPackets(rawPackets, out bool fullReaded);
                Console.WriteLine($"Parsed successfully {packets.Length} packets!");
                foreach (var packet in packets)
                {
                    Console.WriteLine($"#{packet.PID} - SRC: {(packet.PacketInfo.Source == 0 ? "C->S" : "S-C")}, ID: {packet.PacketInfo.Id} ({packet.PacketInfo.Name})");
                }
            }
            catch (ParseGamePacketException ex)
            {
                Console.WriteLine("Parse GamePacket ERROR!");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Data: ");
                for (var i = 0; i < ex.PacketRaw.Length; i++)
                {
                    Console.WriteLine($"[{i}] Byte: {ex.PacketRaw[i].ToString().PadLeft(3, ' ')} Hex: 0x{BitConverter.ToString(new byte[] { ex.PacketRaw[i] })}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private static GamePacketInfo[] ReadGamePacketInfo(byte source, string content)
        {
            var output = new List<GamePacketInfo>();
            var packets = content.Trim().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var packet in packets)
            {
                var data = packet.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (data[0].StartsWith('#')) continue;

                output.Add(new GamePacketInfo
                {
                    Name = data[0],
                    Source = source,
                    Id = ushort.Parse(data[1]),
                    Length = ushort.Parse(data[2])
                });
            }
            return output.ToArray();
        }

        private static PacketInfo[] GetRawPackets(byte[] buffer)
        {
            var pid = 0;

            var packets = new List<PacketInfo>();

            using (var br = new BinaryReader(new MemoryStream(buffer)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    var source = br.ReadByte();
                    var length = br.ReadInt32();
                    var data = br.ReadBytes(length);

                    packets.Add(new PacketInfo
                    {
                        PID = pid,
                        Source = source,
                        Data = data
                    });

                    pid++;
                }
            }

            return packets.ToArray();
        }

        public static PacketParsed[] ParseRawPackets(PacketInfo[] rawPackets, out bool fullReaded)
        {
            var output = new List<PacketParsed>();

            var extraBuffers = new Dictionary<byte, byte[]>() {
                { 0, Array.Empty<byte>() },
                { 1, Array.Empty<byte>() }
            };

            for (var i = 0; i < rawPackets.Length; i++)
            {
                var rawPacket = rawPackets[i];
                if (rawPacket.Source != 0 && rawPacket.Source != 1) continue;
                if (rawPacket.Data.Length == 0) continue;

                var extraBuffer = extraBuffers[rawPacket.Source];
                extraBuffers[rawPacket.Source] = Array.Empty<byte>();

                var fullBuffer = new byte[extraBuffer.Length + rawPacket.Data.Length];
                Array.Copy(extraBuffer, 0, fullBuffer, 0, extraBuffer.Length);
                Array.Copy(rawPacket.Data, 0, fullBuffer, extraBuffer.Length, rawPacket.Data.Length);

                var p = 0;
                do
                {
                    var buffer = new byte[fullBuffer.Length - p];
                    Array.Copy(fullBuffer, p, buffer, 0, fullBuffer.Length - p);

                    var packetId = BitConverter.ToUInt16(buffer, 0);
                    if (packetId == 0) continue;

                    var packets = rawPacket.Source == 0 ? GamePacketInfoRepository.Instance.ClientPackets : GamePacketInfoRepository.Instance.ServerPackets;

                    if (!packets.TryGetValue(packetId, out var packetType))
                        throw new ParseGamePacketException(rawPacket.Source, packetId, buffer);

                    if (packetType.Length == 0 && buffer.Length < 4)
                    {
                        extraBuffers[rawPacket.Source] = buffer;
                        break;
                    }

                    var length = packetType.Length == 0
                        ? BitConverter.ToUInt16(buffer, 2)
                        : packetType.Length;

                    if (length > buffer.Length)
                    {
                        extraBuffers[rawPacket.Source] = buffer;
                        break;
                    }

                    var isMasked = packetId != 1002 && packetId != 1001;

                    byte[] data = Array.Empty<byte>();

                    var headerLength = packetType.Length == 0 ? 4 : 2;

                    if (length > headerLength)
                    {
                        data = new byte[length - headerLength];
                        Array.Copy(buffer, headerLength, data, 0, length - headerLength);

                        if (isMasked)
                            for (var b = packetType.Length == 0 ? 0 : 2; b < data.Length; b++)
                                data[b] ^= 129;
                    }

                    output.Add(new PacketParsed
                    {
                        Data = data,
                        PID = rawPacket.PID,
                        PacketInfo = packetType
                    });

                    p += length;
                } while (p < fullBuffer.Length);
            }

            fullReaded = extraBuffers.All(x => x.Value.Length == 0);

            var sb = new StringBuilder();

            foreach (var packet in output)
            {
                if (packet.PacketInfo.Source == 0) continue;
                sb.AppendLine($"// Packet ID: {packet.PacketInfo.Id}, Name: {packet.PacketInfo.Name}");
                // sb.AppendLine(string.Join(", ", BitConverter.GetBytes(packet.PacketInfo.Id).Select(x => x.ToString()).ToArray()) + ", " + string.Join(", ", packet.Data.Select(x => x.ToString()).ToArray()));
                sb.AppendLine($"网络连接.SendRaw({packet.PacketInfo.Id}, {packet.PacketInfo.Length}, new byte[] {{{ string.Join(", ", packet.Data.Select(x => x.ToString()).ToArray()) }}});");
            }

            var raw = sb.ToString();

            var shopBuffer = output.Where(x => x.PacketInfo.Id == 142 && x.PacketInfo.Source == 1).First();

            MemoryStream memoryStream = new MemoryStream();
            DeflaterOutputStream deflaterOutputStream = new DeflaterOutputStream(memoryStream);
            deflaterOutputStream.Write(shopBuffer.Data, 0, shopBuffer.Data.Length);
            deflaterOutputStream.Close();

            var decompressedData = memoryStream.ToArray();

            var querico = string.Join(", ", decompressedData.Select(x => x.ToString()).ToArray());

            var caca = output.Skip(3050).Take(100).ToArray();
            var test = output.Select((x, i) => new { i = i, packet = x }).Where((x) => x.packet.PacketInfo.Id == 150).ToList();

            return output.ToArray();
        }
    }
}
