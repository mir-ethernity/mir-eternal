using ClientPacketSniffer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientPacketSniffer.Services
{
    public class PacketServerEmulator
    {
        public static PacketServerEmulator Instance { get; } = new PacketServerEmulator();

        private TcpListener? _tcp = null;

        public Action<PacketServerEmulatorAnswer>? EstablishConnectionAnswers = null;
        public readonly Dictionary<ushort, Action<PacketServerEmulatorAnswer>> ReceivePacketAnswers = new Dictionary<ushort, Action<PacketServerEmulatorAnswer>>();
        public List<ConnectionManager> Connections { get; } = new List<ConnectionManager>();

        public PacketServerEmulator OnReceivePacket(ushort type, Action<PacketServerEmulatorAnswer> answerCallback)
        {
            if (!GamePacketInfoRepository.Instance.ClientPackets.TryGetValue(type, out GamePacketInfo packetInfo))
                throw new ApplicationException($"Unknown packet type: {type}");

            if (ReceivePacketAnswers.ContainsKey(type))
                throw new ApplicationException($"Answer for {type} already registered");

            ReceivePacketAnswers.Add(type, answerCallback);

            return this;
        }

        public PacketServerEmulator OnEstablishConnection(Action<PacketServerEmulatorAnswer> answerCallback)
        {
            if (EstablishConnectionAnswers != null)
                throw new ApplicationException("Answer on establish connection already registered");

            EstablishConnectionAnswers = answerCallback;

            return this;
        }

        public void Start()
        {
            _tcp = new TcpListener(System.Net.IPAddress.Any, 8701);
            _tcp.Start();
            _tcp.BeginAcceptTcpClient(EstablishConnection, null);
            Console.ReadKey();
            _tcp.Stop();
        }

        private void EstablishConnection(IAsyncResult ar)
        {
            var connection = _tcp?.EndAcceptTcpClient(ar);
            if (connection == null) return;
            Connections.Add(new ConnectionManager(connection));
        }
    }

    public class ConnectionManager
    {
        private int PID = 0;
        private PacketInfo[] _extraPackets = Array.Empty<PacketInfo>();

        public TcpClient Connection { get; }

        public ConnectionManager(TcpClient connection)
        {
            Connection = connection;
            WaitToData();
        }

        public void WaitToData()
        {
            var rawBuffer = new byte[1024 * 8];
            Connection.Client.BeginReceive(rawBuffer, 0, rawBuffer.Length, SocketFlags.None, ReceiveData, rawBuffer);
        }

        private void ReceiveData(IAsyncResult ar)
        {
            var length = Connection.Client.EndReceive(ar);
            if (length == 0) return;
            var buffer = (byte[]?)ar.AsyncState ?? new byte[0];
            var data = new byte[length];
            Array.Copy(buffer, 0, data, 0, length);

            var packetInfo = new PacketInfo { PID = PID, Data = data, Source = 0 };
            var packetsInfo = new PacketInfo[_extraPackets.Length + 1];
            Array.Copy(_extraPackets, 0, packetsInfo, 0, _extraPackets.Length);
            packetsInfo[packetsInfo.Length - 1] = packetInfo;

            var parsedPackets = PacketInspectorService.ParseRawPackets(packetsInfo, out bool fullReaded);

            if (!fullReaded)
            {
                _extraPackets = packetsInfo;
                WaitToData();
                return;
            }

            _extraPackets = Array.Empty<PacketInfo>();

            foreach (var packet in parsedPackets)
            {
                if (!PacketServerEmulator.Instance.ReceivePacketAnswers.TryGetValue(packet.PacketInfo.Id, out var answerCallback))
                    continue;

                var answer = new PacketServerEmulatorAnswer(packet);
                answerCallback(answer);

                foreach (var reply in answer.Replies)
                {
                    if (!GamePacketInfoRepository.Instance.ServerPackets.TryGetValue(reply.Item1, out GamePacketInfo info))
                        continue;

                    var replyBuffer = new byte[info.Length == 0 ? (reply.Item2.Length + 4) : info.Length];
                    using (var ms = new MemoryStream(replyBuffer))
                    using (var bw = new BinaryWriter(ms))
                    {
                        bw.Write(info.Id);
                        if (info.Length == 0) bw.Write((ushort)(reply.Item2.Length + 4));
                        ms.Write(reply.Item2);
                    }

                    var isMasked = info.Id != 1002 && info.Id != 1001;

                    if (isMasked)
                        for (var b = 4; b < replyBuffer.Length; b++)
                            replyBuffer[b] ^= 129;

                    Connection.Client.Send(replyBuffer);
                }
            }

            PID++;

            WaitToData();
        }
    }


    public class PacketServerEmulatorAnswer
    {
        public PacketParsed Answer { get; }
        public List<Tuple<ushort, byte[]>> Replies = new List<Tuple<ushort, byte[]>>();

        public PacketServerEmulatorAnswer(PacketParsed packet)
        {
            Answer = packet;
        }

        public PacketServerEmulatorAnswer ReplyWith(ushort typeId, byte[] data)
        {
            Replies.Add(new Tuple<ushort, byte[]>(typeId, data));
            return this;
        }
    }
}
