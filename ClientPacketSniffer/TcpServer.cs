using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientPacketSniffer
{
    internal class TcpServer
    {
        private TcpListener? _listener = null;
        public List<TcpProxyConnection> Connections { get; } = new List<TcpProxyConnection>();

        public void Start()
        {
            if (_listener != null) return;
            _listener = new TcpListener(IPAddress.Any, Config.TcpLocalPort);
            _listener.Start();
            _listener.BeginAcceptTcpClient(OnAcceptTcpClient, null);
        }

        private void OnAcceptTcpClient(IAsyncResult ar)
        {
            if (_listener == null) return;
            var client = _listener.EndAcceptTcpClient(ar);
            var proxy = new TcpProxyConnection(client);
            proxy.ConnectionClose += Proxy_OnConnectionClose;
            Connections.Add(proxy);
        }

        private void Proxy_OnConnectionClose(object? sender, EventArgs e)
        {
            if (sender == null) return;
            var conn = (TcpProxyConnection)sender;
            Connections.Remove(conn);
        }
    }
}
