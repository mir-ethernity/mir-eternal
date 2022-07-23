using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace GameServer.Templates
{
	
	public sealed class 地形数据
	{
		
		private static void 载入文件(FileSystemInfo 当前文件)
		{
			地形数据 地形数据 = new 地形数据
			{
				MapName = 当前文件.Name.Split(new char[]
				{
					'.'
				})[0].Split(new char[]
				{
					'-'
				})[1],
				MapId = Convert.ToByte(当前文件.Name.Split(new char[]
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

		
		public static void LoadData()
		{
			地形数据.DataSheet = new Dictionary<byte, 地形数据>();
			地形数据.数据列表 = new ConcurrentQueue<地形数据>();
			string path = CustomClass.GameDataPath + "\\System\\GameMap\\Terrains\\";
			if (Directory.Exists(path))
			{
				Parallel.ForEach<FileInfo>(new DirectoryInfo(path).GetFiles("*.terrain"), delegate(FileInfo x)
				{
					地形数据.载入文件(x);
				});
				foreach (地形数据 地形数据 in 地形数据.数据列表)
				{
					地形数据.DataSheet.Add(地形数据.MapId, 地形数据);
				}
			}
		}

		
		public uint this[Point 坐标]
		{
			get
			{
				return this.点阵数据[坐标.X - this.地图起点.X, 坐标.Y - this.地图起点.Y];
			}
		}

		
		public 地形数据()
		{
			
			
		}

		
		private static ConcurrentQueue<地形数据> 数据列表;

		
		public static Dictionary<byte, 地形数据> DataSheet;

		
		public byte MapId;

		
		public string MapName;

		
		public Point 地图起点;

		
		public Point 地图终点;

		
		public Point 地图大小;

		
		public Point 地图高度;

		
		public uint[,] 点阵数据;
	}
}
