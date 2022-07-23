using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using GameServer.Maps;
using GameServer.Data;
using GameServer.Networking;

namespace GameServer
{
	// Token: 0x0200003F RID: 63
	public static class MainProcess
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00003085 File Offset: 0x00001285
		public static void 启动服务()
		{
			if (!MainProcess.已经启动)
			{
                Thread thread = new(new ThreadStart(服务循环))
                {
                    IsBackground = true
                };
                MainProcess.主线程 = thread;
				thread.Start();
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000030C0 File Offset: 0x000012C0
		public static void 停止服务()
		{
			MainProcess.已经启动 = false;
			NetworkServiceGateway.结束服务();
		}

		// Token: 0x06000112 RID: 274 RVA: 0x000030CD File Offset: 0x000012CD
		public static void 添加系统日志(string 文本)
		{
			MainForm.AddSystemLog(文本);
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000030D5 File Offset: 0x000012D5
		public static void 添加聊天日志(string 前缀, byte[] 文本)
		{
			MainForm.添加聊天日志(前缀, 文本);
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0001C2BC File Offset: 0x0001A4BC
		private static void 服务循环()
		{
			MainProcess.外部命令 = new ConcurrentQueue<GMCommand>();
			MainForm.AddSystemLog("Map elements are being generated...");
			MapGatewayProcess.开启地图();
			MainForm.AddSystemLog("Network services are being started...");
			NetworkServiceGateway.启动服务();
			MainForm.AddSystemLog("The server has been successfully opened");
			MainProcess.已经启动 = true;
			MainForm.服务启动回调();
			for (;;)
			{
				if (!MainProcess.已经启动)
				{
					goto IL_1E8;
				}
				IL_47:
				MainProcess.当前时间 = DateTime.Now;
				try
				{
					if (MainProcess.当前时间 > MainProcess.每秒计时)
					{
						GameDataGateway.保存数据();
						MainForm.更新连接总数((uint)NetworkServiceGateway.网络连接表.Count);
						MainForm.更新已经登录(NetworkServiceGateway.已登录连接数);
						MainForm.更新已经上线(NetworkServiceGateway.已上线连接数);
						MainForm.更新发送字节(NetworkServiceGateway.已发送字节数);
						MainForm.更新接收字节(NetworkServiceGateway.已接收字节数);
						MainForm.更新对象统计(MapGatewayProcess.激活对象表.Count, MapGatewayProcess.次要对象表.Count, MapGatewayProcess.MapObject表.Count);
						MainForm.更新后台帧数(MainProcess.循环计数);
						MainProcess.循环计数 = 0U;
						MainProcess.每秒计时 = MainProcess.当前时间.AddSeconds(1.0);
					}
					else
					{
						MainProcess.循环计数 += 1U;
					}
                    while (MainProcess.外部命令.TryDequeue(out GMCommand GMCommand))
                    {
                        GMCommand.执行命令();
                    }
                    NetworkServiceGateway.处理数据();
					MapGatewayProcess.处理数据();
					continue;
				}
				catch (Exception ex)
				{
					MainForm.AddSystemLog("A fatal error has occurred and the server is about to stop");
					if (!Directory.Exists(".\\Log\\Error"))
					{
						Directory.CreateDirectory(".\\Log\\Error");
					}
					File.WriteAllText(string.Format(".\\Log\\Error\\{0:yyyy-MM-dd--HH-mm-ss}.txt", DateTime.Now), "Error message:\r\n" + ex.Message + "\r\nStack information:\r\n" + ex.StackTrace);
					MainForm.AddSystemLog("Error has been saved to the log, please note");
					foreach (客户网络 客户网络 in NetworkServiceGateway.网络连接表)
					{
						try
						{
							TcpClient 当前连接 = 客户网络.当前连接;
							if (当前连接 != null)
							{
								Socket client = 当前连接.Client;
								if (client != null)
								{
									client.Shutdown(SocketShutdown.Both);
								}
							}
							TcpClient 当前连接2 = 客户网络.当前连接;
							if (当前连接2 != null)
							{
								当前连接2.Close();
							}
						}
						catch
						{
						}
					}
					break;
				}
				IL_1E8:
				if (NetworkServiceGateway.网络连接表.Count == 0)
				{
					break;
				}
				goto IL_47;
			}
			MainForm.AddSystemLog("ItemData is being cleaned up...");
			MapGatewayProcess.清理物品();
			MainForm.AddSystemLog("Customer data is being saved...");
			GameDataGateway.导出数据();
			MainForm.服务停止回调();
			MainProcess.主线程 = null;
			MainForm.AddSystemLog("The server has been successfully shut down");
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0001C51C File Offset: 0x0001A71C
		static MainProcess()
		{
			
			MainProcess.当前时间 = DateTime.Now;
			MainProcess.每秒计时 = DateTime.Now.AddSeconds(1.0);
			MainProcess.随机数 = new Random();
		}

		// Token: 0x04000114 RID: 276
		public static DateTime 当前时间;

		// Token: 0x04000115 RID: 277
		public static DateTime 每秒计时;

		// Token: 0x04000116 RID: 278
		public static ConcurrentQueue<GMCommand> 外部命令;

		// Token: 0x04000117 RID: 279
		public static uint 循环计数;

		// Token: 0x04000118 RID: 280
		public static bool 已经启动;

		// Token: 0x04000119 RID: 281
		public static bool 正在保存;

		// Token: 0x0400011A RID: 282
		public static Thread 主线程;

		// Token: 0x0400011B RID: 283
		public static Random 随机数;
	}
}
