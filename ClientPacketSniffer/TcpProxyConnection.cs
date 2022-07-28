using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientPacketSniffer
{
    internal class TcpProxyConnection
    {
        private readonly TcpClient _sourceClient;
        private readonly TcpClient _targetClient;

        private byte[] _sourceData = new byte[Config.BufferSize];
        private byte[] _targetData = new byte[Config.BufferSize];

        public event EventHandler<EventArgs>? ConnectionClose;

        public TcpProxyConnection(TcpClient client)
        {
            _sourceClient = client;
            _targetClient = new TcpClient();
            ConnectToServer();
        }

        private void ConnectToServer()
        {
            try
            {
                _targetClient.Connect(Config.TcpRemoteIP, Config.TcpRemotePort);
                Console.Write("[tcp] Connected client & server");
                ListenSourceData();
                ListenTargetData();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Cant connect to server: {e}");
                Disconnect();
            }
        }

        private void ListenSourceData()
        {
            _sourceClient.Client.BeginReceive(_sourceData, 0, Config.BufferSize, SocketFlags.None, OnSourceReceiveData, null);
        }

        private void ListenTargetData()
        {
            _targetClient.Client.BeginReceive(_targetData, 0, Config.BufferSize, SocketFlags.None, OnTargetReceiveData, null);
        }

        private void OnSourceReceiveData(IAsyncResult ar)
        {
            var length = _sourceClient.Client.EndReceive(ar);
            var buffer = new byte[length];
            Array.Copy(_sourceData, buffer, length);
            Console.WriteLine($"[tcp][C->S] Len: {length}, Buff: {Convert.ToBase64String(buffer)}");
            _targetClient.Client.Send(buffer);
            ListenSourceData();
        }

        private void OnTargetReceiveData(IAsyncResult ar)
        {
            var length = _sourceClient.Client.EndReceive(ar);
            var buffer = new byte[length];
            Array.Copy(_sourceData, buffer, length);
            Console.WriteLine($"[tcp][S->C] Len: {length}, Buff: {Convert.ToBase64String(buffer)}");
            _sourceClient.Client.Send(buffer);
            ListenTargetData();
        }

        private void Disconnect()
        {
            try
            {
                Console.WriteLine("[tcp] Disconnected");
                _sourceClient?.Dispose();
            }
            catch (Exception)
            {
            }
            RaiseConnectionClose();
        }

        private void RaiseConnectionClose() => ConnectionClose?.Invoke(this, EventArgs.Empty);
    }
}
