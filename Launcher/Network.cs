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
      UDPClient = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
      Packets = new ConcurrentQueue<byte[]>();
      Task.Run(() =>
      {
        while (UDPClient != null)
        {
          try
          {
            IPEndPoint remoteEP = (IPEndPoint) null;
            byte[] numArray = UDPClient.Receive(ref remoteEP);
            Packets.Enqueue(numArray);
          }
          catch (Exception ex)
          {
            if (ex is SocketException socketException2 && socketException2.ErrorCode == 10054)
            {
              MessageBox.Show("Connection Failed");
            }
            Environment.Exit(Environment.ExitCode);
          }
        }
      });
    }
    public static void CloseSocket()
    {
      UDPClient.Close();
      UDPClient = null;
    }
    public static bool SendPacket(byte[] data)
    {
      if (UDPClient == null)
        return false;
      try
      {
        UDPClient.Send(data, data.Length, ASAddress);
        return true;
      }
      catch
      {
        MessageBox.Show("Socket is not connected. Check firewall settings.");
        return false;
      }
    }
  }
}
