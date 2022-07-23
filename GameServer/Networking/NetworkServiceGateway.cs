using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using GameServer.Data;

namespace GameServer.Networking
{
	// Token: 0x02000250 RID: 592
	public static class NetworkServiceGateway
	{
		// Token: 0x0600041E RID: 1054 RVA: 0x0002002C File Offset: 0x0001E22C
		public static void Start()
		{
			NetworkServiceGateway.网络服务停止 = false;
			NetworkServiceGateway.Connections = new HashSet<客户网络>();
			NetworkServiceGateway.等待添加表 = new ConcurrentQueue<客户网络>();
			NetworkServiceGateway.等待移除表 = new ConcurrentQueue<客户网络>();
			NetworkServiceGateway.全服公告表 = new ConcurrentQueue<GamePacket>();
			NetworkServiceGateway.网络监听器 = new TcpListener(IPAddress.Any, (int)CustomClass.客户连接端口);
			NetworkServiceGateway.网络监听器.Start();
			NetworkServiceGateway.网络监听器.BeginAcceptTcpClient(new AsyncCallback(NetworkServiceGateway.异步连接), null);
			NetworkServiceGateway.门票DataSheet = new Dictionary<string, TicketInformation>();
			NetworkServiceGateway.门票接收器 = new UdpClient(new IPEndPoint(IPAddress.Any, (int)CustomClass.门票接收端口));
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00004219 File Offset: 0x00002419
		public static void Stop()
		{
			NetworkServiceGateway.网络服务停止 = true;
			TcpListener tcpListener = NetworkServiceGateway.网络监听器;
			if (tcpListener != null)
			{
				tcpListener.Stop();
			}
			NetworkServiceGateway.网络监听器 = null;
			UdpClient udpClient = NetworkServiceGateway.门票接收器;
			if (udpClient != null)
			{
				udpClient.Close();
			}
			NetworkServiceGateway.门票接收器 = null;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x000200C0 File Offset: 0x0001E2C0
		public static void Process()
		{
			try
			{
				for (;;)
				{
					UdpClient udpClient = NetworkServiceGateway.门票接收器;
					if (udpClient == null || udpClient.Available == 0)
					{
						break;
					}
					byte[] bytes = NetworkServiceGateway.门票接收器.Receive(ref NetworkServiceGateway.门票发送端);
					string[] array = Encoding.UTF8.GetString(bytes).Split(new char[]
					{
						';'
					});
					if (array.Length == 2)
					{
						NetworkServiceGateway.门票DataSheet[array[0]] = new TicketInformation
						{
							登录账号 = array[1],
							有效时间 = MainProcess.CurrentTime.AddMinutes(5.0)
						};
					}
				}
			}
			catch (Exception ex)
			{
				MainProcess.AddSystemLog("接收登录门票时发生错误. " + ex.Message);
			}
			using (HashSet<客户网络>.Enumerator enumerator = NetworkServiceGateway.Connections.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					客户网络 客户网络 = enumerator.Current;
					if (!客户网络.正在断开 && 客户网络.绑定账号 == null && MainProcess.CurrentTime.Subtract(客户网络.接入时间).TotalSeconds > 30.0)
					{
						客户网络.尝试断开连接(new Exception("登录超时, 断开连接!"));
					}
					else
					{
						客户网络.处理数据();
					}
				}
				goto IL_13E;
			}
			IL_123:
			客户网络 item;
			if (NetworkServiceGateway.等待移除表.TryDequeue(out item))
			{
				NetworkServiceGateway.Connections.Remove(item);
			}
			IL_13E:
			if (NetworkServiceGateway.等待移除表.IsEmpty)
			{
				while (!NetworkServiceGateway.等待添加表.IsEmpty)
				{
                    if (NetworkServiceGateway.等待添加表.TryDequeue(out 客户网络 item2))
                    {
                        NetworkServiceGateway.Connections.Add(item2);
                    }
                }
				while (!NetworkServiceGateway.全服公告表.IsEmpty)
				{
                    if (NetworkServiceGateway.全服公告表.TryDequeue(out GamePacket 封包))
                    {
                        foreach (客户网络 客户网络2 in NetworkServiceGateway.Connections)
                        {
                            if (客户网络2.绑定角色 != null)
                            {
                                客户网络2.发送封包(封包);
                            }
                        }
                    }
                }
				return;
			}
			goto IL_123;
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x000202C8 File Offset: 0x0001E4C8
		public static void 异步连接(IAsyncResult 异步参数)
		{
			try
			{
				if (NetworkServiceGateway.网络服务停止)
				{
					return;
				}
				TcpClient tcpClient = NetworkServiceGateway.网络监听器.EndAcceptTcpClient(异步参数);
				string text = tcpClient.Client.RemoteEndPoint.ToString().Split(new char[]
				{
					':'
				})[0];
				if (SystemData.数据.网络封禁.ContainsKey(text) && !(SystemData.数据.网络封禁[text] < MainProcess.CurrentTime))
				{
					tcpClient.Client.Close();
				}
				else if (NetworkServiceGateway.Connections.Count < 10000)
				{
					ConcurrentQueue<客户网络> concurrentQueue = NetworkServiceGateway.等待添加表;
					if (concurrentQueue != null)
					{
						concurrentQueue.Enqueue(new 客户网络(tcpClient));
					}
				}
				goto IL_CA;
			}
			catch (Exception ex)
			{
				MainProcess.AddSystemLog("异步连接异常: " + ex.ToString());
				goto IL_CA;
			}
			IL_B6:
			if (NetworkServiceGateway.Connections.Count <= 100)
			{
				goto IL_D1;
			}
			Thread.Sleep(1);
			IL_CA:
			if (!NetworkServiceGateway.网络服务停止)
			{
				goto IL_B6;
			}
			IL_D1:
			if (!NetworkServiceGateway.网络服务停止)
			{
				NetworkServiceGateway.网络监听器.BeginAcceptTcpClient(new AsyncCallback(NetworkServiceGateway.异步连接), null);
			}
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000203D8 File Offset: 0x0001E5D8
		public static void 断网回调(object sender, Exception e)
		{
			客户网络 客户网络 = sender as 客户网络;
			string text = "IP: " + 客户网络.网络地址;
			if (客户网络.绑定账号 != null)
			{
				text = text + " Account: " + 客户网络.绑定账号.账号名字.V;
			}
			if (客户网络.绑定角色 != null)
			{
				text = text + " Character: " + 客户网络.绑定角色.对象名字;
			}
			text = text + " Info: " + e.Message;
			MainProcess.AddSystemLog(text);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000424D File Offset: 0x0000244D
		public static void 屏蔽网络(string 地址)
		{
			SystemData.数据.BanIPCommand(地址, MainProcess.CurrentTime.AddMinutes((double)CustomClass.异常屏蔽时间));
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00020458 File Offset: 0x0001E658
		public static void 发送公告(string 内容, bool 滚动播报 = false)
		{
			using (MemoryStream memoryStream = new())
			{
                using BinaryWriter binaryWriter = new(memoryStream);
                binaryWriter.Write(0);
                binaryWriter.Write(滚动播报 ? 2415919106U : 2415919107U);
                binaryWriter.Write(滚动播报 ? 2 : 3);
                binaryWriter.Write(0);
                binaryWriter.Write(Encoding.UTF8.GetBytes(内容 + "\0"));
                NetworkServiceGateway.发送封包(new ReceiveChatMessagesPacket
                {
                    字节描述 = memoryStream.ToArray()
                });
            }
			MainForm.AddSystemLog(内容);
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000426A File Offset: 0x0000246A
		public static void 发送封包(GamePacket 封包)
		{
			if (封包 != null)
			{
				ConcurrentQueue<GamePacket> concurrentQueue = NetworkServiceGateway.全服公告表;
				if (concurrentQueue == null)
				{
					return;
				}
				concurrentQueue.Enqueue(封包);
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000427F File Offset: 0x0000247F
		public static void 添加网络(客户网络 网络)
		{
			if (网络 != null)
			{
				NetworkServiceGateway.等待添加表.Enqueue(网络);
			}
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0000428F File Offset: 0x0000248F
		public static void 移除网络(客户网络 网络)
		{
			if (网络 != null)
			{
				NetworkServiceGateway.等待移除表.Enqueue(网络);
			}
		}

		// Token: 0x040007C4 RID: 1988
		private static IPEndPoint 门票发送端;

		// Token: 0x040007C5 RID: 1989
		private static UdpClient 门票接收器;

		// Token: 0x040007C6 RID: 1990
		private static TcpListener 网络监听器;

		// Token: 0x040007C7 RID: 1991
		public static bool 网络服务停止;

		// Token: 0x040007C8 RID: 1992
		public static bool 未登录连接数;

		// Token: 0x040007C9 RID: 1993
		public static uint ActiveConnections;

		// Token: 0x040007CA RID: 1994
		public static uint ConnectionsOnline;

		// Token: 0x040007CB RID: 1995
		public static long SendedBytes;

		// Token: 0x040007CC RID: 1996
		public static long ReceivedBytes;

		// Token: 0x040007CD RID: 1997
		public static HashSet<客户网络> Connections;

		// Token: 0x040007CE RID: 1998
		public static ConcurrentQueue<客户网络> 等待移除表;

		// Token: 0x040007CF RID: 1999
		public static ConcurrentQueue<客户网络> 等待添加表;

		// Token: 0x040007D0 RID: 2000
		public static ConcurrentQueue<GamePacket> 全服公告表;

		// Token: 0x040007D1 RID: 2001
		public static Dictionary<string, TicketInformation> 门票DataSheet;
	}
}
