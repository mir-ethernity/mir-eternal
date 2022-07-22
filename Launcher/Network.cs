using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
	// Token: 0x02000005 RID: 5
	public sealed class Network
	{
		// Token: 0x0600001D RID: 29 RVA: 0x0000726C File Offset: 0x0000546C
		public static void 开始通信()
		{
			Network.通信实例 = new UdpClient(new IPEndPoint(IPAddress.Any, 0));
			Network.接收队列 = new ConcurrentQueue<byte[]>();
			Task.Run(delegate()
			{
				while (Network.通信实例 != null)
				{
					try
					{
						IPEndPoint ipendPoint = null;
						byte[] item = Network.通信实例.Receive(ref ipendPoint);
						Network.接收队列.Enqueue(item);
					}
					catch (Exception ex)
					{
                        if (ex is SocketException ex2 && ex2.ErrorCode == 10054)
                        {
                            MessageBox.Show("服务器连接失败");
                        }
                        Environment.Exit(Environment.ExitCode);
					}
				}
			});
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000072BD File Offset: 0x000054BD
		public static void 停止通信()
		{
			Network.通信实例.Close();
			Network.通信实例 = null;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000072D0 File Offset: 0x000054D0
		public static bool 发送数据(byte[] 数据)
		{
			if (Network.通信实例 != null)
			{
				try
				{
					Network.通信实例.Send(数据, 数据.Length, Network.ServerAddress);
					return true;
				}
				catch
				{
					MessageBox.Show("连接服务器失败");
					return false;
				}
			}
			return false;
		}

		// Token: 0x04000037 RID: 55
		public static UdpClient 通信实例;

		// Token: 0x04000038 RID: 56
		public static IPEndPoint ServerAddress;

		// Token: 0x04000039 RID: 57
		public static ConcurrentQueue<byte[]> 接收队列;
	}
}
