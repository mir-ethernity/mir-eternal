using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientPacketSniffer
{
    internal class UdpServer
    {
        private UdpClient? _listener = null;
        private IPEndPoint? _targetIP;
        private UdpClient? _target = null;
        private IPEndPoint? _remoteAddress;

        public void Start()
        {
            if (_listener != null) return;
            _listener = new UdpClient(new IPEndPoint(IPAddress.Any, Config.TcpLocalPort));
            _target = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
            _targetIP = new IPEndPoint(IPAddress.Parse(Config.UdpRemoteIP), Config.UdpRemotePort);
            StartSourceListening();
            StartTargetListening();
        }

        private void StartSourceListening()
        {
            Task.Run(delegate ()
            {
                while (_listener != null)
                {
                    if (_listener.Available == 0) Thread.Sleep(100);
                    var buffer = _listener.Receive(ref _remoteAddress);
                    Console.WriteLine($"[udp][C->S] Len: {buffer.Length}, Buff: {Convert.ToBase64String(buffer)}");
                    _target?.Send(buffer, buffer.Length, _targetIP);
                }
            });
        }

        private void StartTargetListening()
        {
            Task.Run(delegate ()
            {
                while (_target != null)
                {
                    if (_target.Available == 0) Thread.Sleep(100);
                    IPEndPoint? srvAddress = null;
                    var buffer = _target.Receive(ref srvAddress);
                    Console.WriteLine($"[udp][S->C] Len: {buffer.Length}, Buff: {Convert.ToBase64String(buffer)}");
                    _listener?.Send(buffer, buffer.Length, _remoteAddress);
                }
            });
        }
    }
}
