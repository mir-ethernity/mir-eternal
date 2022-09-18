using ClientPacketSniffer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientPacketSnifferApp
{
    public struct PacketInfo
    {
        public DateTime Date;
        public bool PacketFromClient;
        public byte[] Data;
    }

    public class PacketParsed
    {
        public DateTime Date;
        public byte[] Data = Array.Empty<byte>();
        public GamePacketInfo PacketInfo;

        public override string ToString()
        {
            return $"{PacketInfo} - {{{(PacketInfo.Length == 0 ? string.Join(",", BitConverter.GetBytes((ushort)Data.Length).Select(x => x.ToString()).ToArray()) : "")}}} {{{string.Join(",", Data.Select(x => x.ToString()).ToArray())}}}";
        }
    }

    public class ParseGamePacketException : ApplicationException
    {
        public bool PacketFromclient { get; set; }
        public ushort PacketId { get; set; }
        public byte[] PacketRaw { get; set; }

        public ParseGamePacketException(bool packetFromClient, ushort id, byte[] raw) : base($"FALTAL!! PACKET ID NOT FOUND {id} IN SOURCE: {(packetFromClient ? 0 : 1)}")
        {
            PacketId = id;
            PacketFromclient = packetFromClient;
            PacketRaw = raw;
        }
    }

    public partial class FRawFile : Form
    {
        public FRawFile()
        {
            InitializeComponent();
        }

        public void LoadBuffer(byte[] buffer)
        {
            var rawPackets = GetRawPackets(buffer);

            var packets = ParseRawPackets(rawPackets, out bool fullReaded);

            foreach (var packet in packets)
            {
                
            }
        }

        private static PacketInfo[] GetRawPackets(byte[] buffer)
        {
            var packets = new List<PacketInfo>();

            using (var br = new BinaryReader(new MemoryStream(buffer)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    packets.Add(new PacketInfo
                    {
                        Date = DateTime.FromFileTimeUtc(br.ReadInt64()),
                        PacketFromClient = br.ReadBoolean(),
                        Data = br.ReadBytes(br.ReadInt32())
                    });
                }
            }

            return packets.ToArray();
        }

        public static PacketParsed[] ParseRawPackets(PacketInfo[] rawPackets, out bool fullReaded)
        {
            var output = new List<PacketParsed>();

            var extraBuffers = new Dictionary<int, byte[]>() {
                { 0, Array.Empty<byte>() },
                { 1, Array.Empty<byte>() }
            };

            for (var i = 0; i < rawPackets.Length; i++)
            {
                var rawPacket = rawPackets[i];
                if (rawPacket.Data.Length == 0) continue;

                var extraBuffer = extraBuffers[rawPacket.PacketFromClient ? 0 : 1];
                extraBuffers[rawPacket.PacketFromClient ? 0 : 1] = Array.Empty<byte>();

                var fullBuffer = new byte[extraBuffer.Length + rawPacket.Data.Length];
                Array.Copy(extraBuffer, 0, fullBuffer, 0, extraBuffer.Length);
                Array.Copy(rawPacket.Data, 0, fullBuffer, extraBuffer.Length, rawPacket.Data.Length);

                var p = 0;
                do
                {
                    var buffer = new byte[fullBuffer.Length - p];
                    Array.Copy(fullBuffer, p, buffer, 0, fullBuffer.Length - p);

                    if (buffer.Length == 1 && buffer[0] == 0)
                    {
                        p++;
                        continue;
                    }

                    var packetId = BitConverter.ToUInt16(buffer, 0);
                    if (packetId == 0) continue;

                    var packets = rawPacket.PacketFromClient ? GamePacketInfoRepository.Instance.ClientPackets : GamePacketInfoRepository.Instance.ServerPackets;

                    if (!packets.TryGetValue(packetId, out var packetType))
                        throw new ParseGamePacketException(rawPacket.PacketFromClient, packetId, buffer);

                    if (packetType.Length == 0 && buffer.Length < 4)
                    {
                        extraBuffers[rawPacket.PacketFromClient ? 0 : 1] = buffer;
                        break;
                    }

                    var length = packetType.Length == 0
                        ? BitConverter.ToUInt16(buffer, 2)
                        : packetType.Length;

                    if (length > buffer.Length)
                    {
                        extraBuffers[rawPacket.PacketFromClient ? 0 : 1] = buffer;
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
                        Date = rawPacket.Date,
                        PacketInfo = packetType
                    });

                    p += length;
                } while (p < fullBuffer.Length);
            }

            fullReaded = extraBuffers.All(x => x.Value.Length == 0);

            var sb = new StringBuilder();

            foreach (var packet in output)
            {
                sb.AppendLine($"// [{packet.Date.ToString("HH:mm:ss")}] Packet ID: {packet.PacketInfo.Id}, Name: {packet.PacketInfo.Name} ({(packet.PacketInfo.Source == 0 ? "Client" : "Server")})");
                sb.AppendLine($"网络连接.SendRaw({packet.PacketInfo.Id}, {packet.PacketInfo.Length}, new byte[] {{{ string.Join(", ", packet.Data.Select(x => x.ToString()).ToArray()) }}});");
            }

            var raw = sb.ToString();

            return output.ToArray();
        }
    }
}
