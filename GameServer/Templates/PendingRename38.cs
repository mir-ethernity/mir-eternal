using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace GameServer.Templates
{
	// Token: 0x02000289 RID: 649
	public sealed class 地形数据
	{
		// Token: 0x0600068D RID: 1677 RVA: 0x00030DAC File Offset: 0x0002EFAC
		private static void 载入文件(FileSystemInfo 当前文件)
		{
			地形数据 地形数据 = new 地形数据
			{
				地图名字 = 当前文件.Name.Split(new char[]
				{
					'.'
				})[0].Split(new char[]
				{
					'-'
				})[1],
				地图编号 = Convert.ToByte(当前文件.Name.Split(new char[]
				{
					'.'
				})[0].Split(new char[]
				{
					'-'
				})[0])
			};
			using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(当前文件.FullName)))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					地形数据.地图起点 = new Point(binaryReader.ReadInt32(), binaryReader.ReadInt32());
					地形数据.地图终点 = new Point(binaryReader.ReadInt32(), binaryReader.ReadInt32());
					地形数据.地图大小 = new Point(地形数据.地图终点.X - 地形数据.地图起点.X, 地形数据.地图终点.Y - 地形数据.地图起点.Y);
					地形数据.地图高度 = new Point(binaryReader.ReadInt32(), binaryReader.ReadInt32());
					地形数据.点阵数据 = new uint[地形数据.地图大小.X, 地形数据.地图大小.Y];
					for (int i = 0; i < 地形数据.地图大小.X; i++)
					{
						for (int j = 0; j < 地形数据.地图大小.Y; j++)
						{
							地形数据.点阵数据[i, j] = binaryReader.ReadUInt32();
						}
					}
				}
			}
			地形数据.数据列表.Enqueue(地形数据);
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00030F64 File Offset: 0x0002F164
		public static void LoadData()
		{
			地形数据.DataSheet = new Dictionary<byte, 地形数据>();
			地形数据.数据列表 = new ConcurrentQueue<地形数据>();
			string path = CustomClass.GameData目录 + "\\System\\GameMap\\Terrains\\";
			if (Directory.Exists(path))
			{
				Parallel.ForEach<FileInfo>(new DirectoryInfo(path).GetFiles("*.terrain"), delegate(FileInfo x)
				{
					地形数据.载入文件(x);
				});
				foreach (地形数据 地形数据 in 地形数据.数据列表)
				{
					地形数据.DataSheet.Add(地形数据.地图编号, 地形数据);
				}
			}
		}

		// Token: 0x170000BE RID: 190
		public uint this[Point 坐标]
		{
			get
			{
				return this.点阵数据[坐标.X - this.地图起点.X, 坐标.Y - this.地图起点.Y];
			}
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x000027D8 File Offset: 0x000009D8
		public 地形数据()
		{
			
			
		}

		// Token: 0x0400099E RID: 2462
		private static ConcurrentQueue<地形数据> 数据列表;

		// Token: 0x0400099F RID: 2463
		public static Dictionary<byte, 地形数据> DataSheet;

		// Token: 0x040009A0 RID: 2464
		public byte 地图编号;

		// Token: 0x040009A1 RID: 2465
		public string 地图名字;

		// Token: 0x040009A2 RID: 2466
		public Point 地图起点;

		// Token: 0x040009A3 RID: 2467
		public Point 地图终点;

		// Token: 0x040009A4 RID: 2468
		public Point 地图大小;

		// Token: 0x040009A5 RID: 2469
		public Point 地图高度;

		// Token: 0x040009A6 RID: 2470
		public uint[,] 点阵数据;
	}
}
