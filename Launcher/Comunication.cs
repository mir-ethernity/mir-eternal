using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
  public sealed class Comunication
  {
    public static UdpClient udpClient;
    public static IPEndPoint ip;
    public static ConcurrentQueue<byte[]> Packets;

    public static void MainSocket()
    {
      Comunication.udpClient = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
      Comunication.Packets = new ConcurrentQueue<byte[]>();
      Task.Run((Action) (() =>
      {
        while (Comunication.udpClient != null)
        {
          try
          {
            IPEndPoint remoteEP = (IPEndPoint) null;
            byte[] numArray = Comunication.udpClient.Receive(ref remoteEP);
            Comunication.Packets.Enqueue(numArray);
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
      Comunication.udpClient.Close();
      Comunication.udpClient = (UdpClient) null;
    }

    public static bool SendPacket(byte[] data)
    {
      if (Comunication.udpClient == null)
        return false;
      try
      {
        Comunication.udpClient.Send(data, data.Length, Comunication.ip);
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
