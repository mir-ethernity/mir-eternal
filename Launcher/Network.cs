using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
  public sealed class Network
  {
    public static UdpClient UDPClient;
    public static IPEndPoint ASAddress;
    public static ConcurrentQueue<byte[]> Packets;

    public static void MainSocket()
    {
      Network.UDPClient = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
      Network.Packets = new ConcurrentQueue<byte[]>();
      Task.Run((Action) (() =>
      {
        while (Network.UDPClient != null)
        {
          try
          {
            IPEndPoint remoteEP = (IPEndPoint) null;
            byte[] numArray = Network.UDPClient.Receive(ref remoteEP);
            Network.Packets.Enqueue(numArray);
          }
          catch (Exception ex)
          {
            if (ex is SocketException socketException2 && socketException2.ErrorCode == 10054)
            {
              int num = (int) MessageBox.Show("Connection failed...");
            }
            Environment.Exit(Environment.ExitCode);
          }
        }
      }));
    }

    public static void CloseSocket()
    {
      Network.UDPClient.Close();
      Network.UDPClient = (UdpClient) null;
    }

    public static bool SendPacket(byte[] data)
    {
      if (Network.UDPClient == null)
        return false;
      try
      {
        Network.UDPClient.Send(data, data.Length, Network.ASAddress);
        return true;
      }
      catch
      {
        int num = (int) MessageBox.Show("Socket is not connected. Check firewall settings.");
        return false;
      }
    }
  }
}
