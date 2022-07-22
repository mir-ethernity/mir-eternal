using System;
using System.Collections.Generic;
using System.Drawing;
using GameServer.Maps;
using GameServer.Templates;

namespace GameServer
{
	// Token: 0x02000021 RID: 33
	public static class ComputingClass
	{
		// Token: 0x06000066 RID: 102 RVA: 0x00009148 File Offset: 0x00007348
		public static int 扩展背包(int 扩展次数, int 当前消耗 = 0, int 当前位置 = 1, int 累计消耗 = 0)
		{
			if (当前位置 > 扩展次数)
			{
				return 累计消耗;
			}
			if (当前位置 <= 1)
			{
				int num = 累计消耗;
				int num2 = 2000;
				当前消耗 = 2000;
				累计消耗 = num + num2;
			}
			else if (当前位置 <= 16)
			{
				累计消耗 += (当前消耗 += 1000);
			}
			else if (当前位置 == 17)
			{
				int num3 = 累计消耗;
				int num4 = 20000;
				当前消耗 = 20000;
				累计消耗 = num3 + num4;
			}
			else
			{
				累计消耗 += (当前消耗 += 10000);
			}
			return ComputingClass.扩展背包(扩展次数, 当前消耗, 当前位置 + 1, 累计消耗);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000091B8 File Offset: 0x000073B8
		public static int 扩展仓库(int 扩展次数, int 当前消耗 = 0, int 当前位置 = 1, int 累计消耗 = 0)
		{
			if (当前位置 > 扩展次数)
			{
				return 累计消耗;
			}
			if (当前位置 <= 1)
			{
				int num = 累计消耗;
				int num2 = 2000;
				当前消耗 = 2000;
				累计消耗 = num + num2;
			}
			else if (当前位置 <= 24)
			{
				累计消耗 += (当前消耗 += 1000);
			}
			else if (当前位置 == 25)
			{
				int num3 = 累计消耗;
				int num4 = 30000;
				当前消耗 = 30000;
				累计消耗 = num3 + num4;
			}
			else
			{
				累计消耗 += (当前消耗 += 10000);
			}
			return ComputingClass.扩展仓库(扩展次数, 当前消耗, 当前位置 + 1, 累计消耗);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000029A9 File Offset: 0x00000BA9
		public static int 数值限制(int 下限, int 数值, int 上限)
		{
			if (数值 > 上限)
			{
				return 上限;
			}
			if (数值 < 下限)
			{
				return 下限;
			}
			return 数值;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00009228 File Offset: 0x00007428
		public static int 网格距离(Point 原点, Point 终点)
		{
			int val = Math.Abs(终点.X - 原点.X);
			int val2 = Math.Abs(终点.Y - 原点.Y);
			return Math.Max(val, val2);
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00009264 File Offset: 0x00007464
		public static int 时间转换(DateTime 时间)
		{
			return (int)(时间 - ComputingClass.系统相对时间).TotalSeconds;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00009288 File Offset: 0x00007488
		public static bool 日期同周(DateTime 日期一, DateTime 日期二)
		{
			DateTime d = (日期二 > 日期一) ? 日期二 : 日期一;
			DateTime d2 = (日期二 > 日期一) ? 日期一 : 日期二;
			if ((d - d2).TotalDays > 7.0)
			{
				return false;
			}
			int num = Convert.ToInt32(d.DayOfWeek);
			if (num == 0)
			{
				num = 7;
			}
			int num2 = Convert.ToInt32(d2.DayOfWeek);
			if (num2 == 0)
			{
				num2 = 7;
			}
			return num2 <= num;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00009304 File Offset: 0x00007504
		public static float 收益衰减(int 玩家等级, int 怪物等级)
		{
			decimal val = Math.Max(0, 玩家等级 - 怪物等级 - (int)CustomClass.减收益等级差) * CustomClass.收益减少比率;
			return (float)Math.Max(0m, val);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000029B8 File Offset: 0x00000BB8
		public static bool 计算概率(float 概率)
		{
			return 概率 >= 1f || (概率 > 0f && 概率 * 100000000f > (float)MainProcess.随机数.Next(100000000));
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00009344 File Offset: 0x00007544
		public static Point 螺旋坐标(Point 原点, int 步数)
		{
			if (--步数 >= 0)
			{
				int num = (int)Math.Floor(Math.Sqrt((double)步数 + 0.25) - 0.5);
				int num2 = num * (num + 1);
				int num3 = num2 + num + 1;
				int num4 = ((num & 1) << 1) - 1;
				int num5 = num4 * (num + 1 >> 1);
				int num6 = num5;
				if (步数 < num3)
				{
					num5 -= num4 * (步数 - num2 + 1);
				}
				else
				{
					num5 -= num4 * (num + 1);
					num6 -= num4 * (步数 - num3 + 1);
				}
				return new Point(原点.X + num5, 原点.Y + num6);
			}
			return 原点;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000093E0 File Offset: 0x000075E0
		public static Point 前方坐标(Point 原点, Point 终点, int 步数)
		{
			if (原点 == 终点)
			{
				return 原点;
			}
			float num = (float)步数 / (float)ComputingClass.网格距离(原点, 终点);
			int num2 = (int)Math.Round((double)((float)(终点.X - 原点.X) * num));
			int num3 = (int)Math.Round((double)((float)(终点.Y - 原点.Y) * num));
			return new Point(原点.X + num2, 原点.Y + num3);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00009450 File Offset: 0x00007650
		public static Point 前方坐标(Point 原点, GameDirection 方向, int 步数)
		{
			if (方向 <= GameDirection.上方)
			{
				if (方向 == GameDirection.左方)
				{
					return new Point(原点.X + 步数, 原点.Y);
				}
				if (方向 == GameDirection.左上)
				{
					return new Point(原点.X + 步数, 原点.Y + 步数);
				}
				if (方向 == GameDirection.上方)
				{
					return new Point(原点.X, 原点.Y + 步数);
				}
			}
			else if (方向 <= GameDirection.右方)
			{
				if (方向 == GameDirection.右上)
				{
					return new Point(原点.X - 步数, 原点.Y + 步数);
				}
				if (方向 == GameDirection.右方)
				{
					return new Point(原点.X - 步数, 原点.Y);
				}
			}
			else
			{
				if (方向 == GameDirection.右下)
				{
					return new Point(原点.X - 步数, 原点.Y - 步数);
				}
				if (方向 == GameDirection.下方)
				{
					return new Point(原点.X, 原点.Y - 步数);
				}
			}
			return new Point(原点.X + 步数, 原点.Y - 步数);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000029E7 File Offset: 0x00000BE7
		public static GameDirection 随机方向()
		{
			return (GameDirection)(MainProcess.随机数.Next(8) * 1024);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00009560 File Offset: 0x00007760
		public static GameDirection 计算方向(Point 原点, Point 终点)
		{
			int num = 终点.X - 原点.X;
			return (GameDirection)((Math.Round((Math.Atan2((double)(终点.Y - 原点.Y), (double)num) * 180.0 / 3.141592653589793 + 360.0) % 360.0 / 45.0) * 1024.0) % 8192);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000095DC File Offset: 0x000077DC
		public static GameDirection 正向方向(Point 原点, Point 终点)
		{
			if (原点 == 终点)
			{
				return GameDirection.左方;
			}
			GameDirection 方向 = ComputingClass.计算方向(终点, 原点);
			int 步数 = Math.Max(Math.Abs(终点.X - 原点.X), Math.Abs(终点.Y - 原点.Y)) - 1;
			Point 终点2 = ComputingClass.前方坐标(终点, 方向, 步数);
			return ComputingClass.计算方向(原点, 终点2);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000029FA File Offset: 0x00000BFA
		public static GameDirection 旋转方向(GameDirection 当前方向, int 旋转向量)
		{
			return 当前方向 + 旋转向量 % 8 * 1024 + 8192 % 8192;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00002A13 File Offset: 0x00000C13
		public static Point 点阵坐标转协议坐标(Point 点阵坐标)
		{
			return new Point(点阵坐标.X * 32 - 16, 点阵坐标.Y * 32 - 16);
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00002A34 File Offset: 0x00000C34
		public static Point 协议坐标转点阵坐标(Point 协议坐标)
		{
			return new Point((int)Math.Round((double)(((float)协议坐标.X + 16f) / 32f)), (int)Math.Round((double)(((float)协议坐标.Y + 16f) / 32f)));
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000963C File Offset: 0x0000783C
		public static Point 游戏坐标转点阵坐标(PointF 游戏坐标)
		{
			PointF pointF = default(PointF);
			pointF.Y = (游戏坐标.X + 游戏坐标.Y) / 0.707107f / 0.000976562f / 2f / 4096f;
			pointF.X = (游戏坐标.X / 0.707107f / 0.000976562f + 134217730f) / 4096f - pointF.Y;
			return new Point((int)((double)(pointF.X / 32f) + 0.5), (int)((double)(pointF.Y / 32f) + 0.5));
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000096E4 File Offset: 0x000078E4
		public static PointF 点阵坐标转游戏坐标(Point 点阵坐标)
		{
			PointF pointF = new PointF(((float)点阵坐标.X - 0.5f) * 32f, ((float)点阵坐标.Y - 0.5f) * 32f);
			return new PointF
			{
				X = ((pointF.Y + pointF.X) * 4096f - 134217730f) * 0.707107f * 0.000976562f,
				Y = ((pointF.Y - pointF.X) * 4096f + 134217730f) * 0.707107f * 0.000976562f
			};
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00002A71 File Offset: 0x00000C71
		public static int 计算攻速(int 攻速)
		{
			return ComputingClass.数值限制(-5, 攻速, 5) * 50;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00009788 File Offset: 0x00007988
		public static float 计算幸运(int 幸运)
		{
			switch (幸运)
			{
			case 0:
				return 0.1f;
			case 1:
				return 0.11f;
			case 2:
				return 0.13f;
			case 3:
				return 0.14f;
			case 4:
				return 0.17f;
			case 5:
				return 0.2f;
			case 6:
				return 0.25f;
			case 7:
				return 0.33f;
			case 8:
				return 0.5f;
			default:
				if (幸运 >= 9)
				{
					return 1f;
				}
				return 0f;
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00009808 File Offset: 0x00007A08
		public static int 计算攻击(int 下限, int 上限, int 幸运)
		{
			int result = (幸运 >= 0) ? 上限 : 下限;
			if (ComputingClass.计算概率(ComputingClass.计算幸运(Math.Abs(幸运))))
			{
				return result;
			}
			return MainProcess.随机数.Next(Math.Min(下限, 上限), Math.Max(下限, 上限) + 1);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002A7F File Offset: 0x00000C7F
		public static int 计算防御(int 下限, int 上限)
		{
			if (上限 >= 下限)
			{
				return MainProcess.随机数.Next(下限, 上限 + 1);
			}
			return MainProcess.随机数.Next(上限, 下限 + 1);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000984C File Offset: 0x00007A4C
		public static bool 直线方向(Point 原点, Point 锚点)
		{
			int num = 原点.X - 锚点.X;
			int num2 = 原点.Y - 锚点.Y;
			return num == 0 || num2 == 0 || Math.Abs(num) == Math.Abs(num2);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00009890 File Offset: 0x00007A90
		public static bool 计算命中(float 命中基数, float 闪避基数, float 命中系数, float 闪避系数)
		{
			float 概率 = (闪避基数 == 0f) ? 1f : (命中基数 / 闪避基数);
			float num = 命中系数 - 闪避系数;
			if (num == 0f)
			{
				return ComputingClass.计算概率(概率);
			}
			if (num >= 0f)
			{
				return ComputingClass.计算概率(概率) || ComputingClass.计算概率(num);
			}
			return ComputingClass.计算概率(概率) && !ComputingClass.计算概率(-num);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002AA2 File Offset: 0x00000CA2
		public static bool 计算位移(MapInstance 地图, MapObject 来源, GameDirection 方向, int 力度, out List<MapObject> 目标)
		{
			目标 = new List<MapObject>();
			return false;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000098F0 File Offset: 0x00007AF0
		public static Point[] 技能范围(Point 锚点, GameDirection 方向, 技能范围类型 范围)
		{
			switch (范围)
			{
			case 技能范围类型.单体1x1:
				return new Point[]
				{
					锚点
				};
			case 技能范围类型.半月3x1:
				if (方向 <= GameDirection.上方)
				{
					if (方向 == GameDirection.左方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.左上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 2),
							new Point(锚点.X - 2, 锚点.Y)
						};
					}
					if (方向 == GameDirection.上方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y - 1)
						};
					}
				}
				else if (方向 <= GameDirection.右方)
				{
					if (方向 == GameDirection.右上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 2, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 2)
						};
					}
					if (方向 == GameDirection.右方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1)
						};
					}
				}
				else
				{
					if (方向 == GameDirection.下方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.左下)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 2, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 2)
						};
					}
				}
				return new Point[]
				{
					锚点,
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X, 锚点.Y + 2),
					new Point(锚点.X + 2, 锚点.Y)
				};
			case 技能范围类型.半月3x2:
				if (方向 <= GameDirection.上方)
				{
					if (方向 == GameDirection.左方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.左上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.上方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y + 1)
						};
					}
				}
				else if (方向 <= GameDirection.右方)
				{
					if (方向 == GameDirection.右上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1)
						};
					}
					if (方向 == GameDirection.右方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1)
						};
					}
				}
				else
				{
					if (方向 == GameDirection.下方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y - 1)
						};
					}
					if (方向 == GameDirection.左下)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1)
						};
					}
				}
				return new Point[]
				{
					锚点,
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y - 1)
				};
			case 技能范围类型.半月3x3:
				if (方向 <= GameDirection.上方)
				{
					if (方向 == GameDirection.左方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 2),
							new Point(锚点.X, 锚点.Y + 2),
							new Point(锚点.X - 1, 锚点.Y - 2),
							new Point(锚点.X - 1, 锚点.Y + 2)
						};
					}
					if (方向 == GameDirection.左上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 2),
							new Point(锚点.X - 2, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 2),
							new Point(锚点.X - 2, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.上方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X + 2, 锚点.Y),
							new Point(锚点.X - 2, 锚点.Y),
							new Point(锚点.X + 2, 锚点.Y - 1),
							new Point(锚点.X - 2, 锚点.Y - 1)
						};
					}
				}
				else if (方向 <= GameDirection.右方)
				{
					if (方向 == GameDirection.右上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 2, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 2),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X + 2, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 2)
						};
					}
					if (方向 == GameDirection.右方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 2),
							new Point(锚点.X, 锚点.Y - 2),
							new Point(锚点.X + 1, 锚点.Y + 2),
							new Point(锚点.X + 1, 锚点.Y - 2)
						};
					}
				}
				else
				{
					if (方向 == GameDirection.下方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X - 2, 锚点.Y),
							new Point(锚点.X + 2, 锚点.Y),
							new Point(锚点.X - 2, 锚点.Y + 1),
							new Point(锚点.X + 2, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.左下)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 2, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 2),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X - 2, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 2)
						};
					}
				}
				return new Point[]
				{
					锚点,
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X, 锚点.Y + 2),
					new Point(锚点.X + 2, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y + 2),
					new Point(锚点.X + 2, 锚点.Y - 1)
				};
			case 技能范围类型.空心3x3:
				return new Point[]
				{
					ComputingClass.前方坐标(锚点, GameDirection.上方, 1),
					ComputingClass.前方坐标(锚点, GameDirection.下方, 1),
					ComputingClass.前方坐标(锚点, GameDirection.左方, 1),
					ComputingClass.前方坐标(锚点, GameDirection.右方, 1),
					ComputingClass.前方坐标(锚点, GameDirection.左上, 1),
					ComputingClass.前方坐标(锚点, GameDirection.左下, 1),
					ComputingClass.前方坐标(锚点, GameDirection.右上, 1),
					ComputingClass.前方坐标(锚点, GameDirection.右下, 1)
				};
			case 技能范围类型.实心3x3:
				return new Point[]
				{
					锚点,
					ComputingClass.前方坐标(锚点, GameDirection.上方, 1),
					ComputingClass.前方坐标(锚点, GameDirection.下方, 1),
					ComputingClass.前方坐标(锚点, GameDirection.左方, 1),
					ComputingClass.前方坐标(锚点, GameDirection.右方, 1),
					ComputingClass.前方坐标(锚点, GameDirection.左上, 1),
					ComputingClass.前方坐标(锚点, GameDirection.左下, 1),
					ComputingClass.前方坐标(锚点, GameDirection.右上, 1),
					ComputingClass.前方坐标(锚点, GameDirection.右下, 1)
				};
			case 技能范围类型.实心5x5:
				return new Point[]
				{
					锚点,
					new Point(锚点.X + 1, 锚点.Y + 1),
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X - 1, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X + 1, 锚点.Y - 1),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X + 2, 锚点.Y),
					new Point(锚点.X + 2, 锚点.Y + 1),
					new Point(锚点.X + 2, 锚点.Y + 2),
					new Point(锚点.X + 1, 锚点.Y + 2),
					new Point(锚点.X, 锚点.Y + 2),
					new Point(锚点.X - 1, 锚点.Y + 2),
					new Point(锚点.X - 2, 锚点.Y + 2),
					new Point(锚点.X - 2, 锚点.Y + 1),
					new Point(锚点.X - 2, 锚点.Y),
					new Point(锚点.X - 2, 锚点.Y - 1),
					new Point(锚点.X - 2, 锚点.Y - 2),
					new Point(锚点.X - 1, 锚点.Y - 2),
					new Point(锚点.X, 锚点.Y - 2),
					new Point(锚点.X + 1, 锚点.Y - 2),
					new Point(锚点.X + 2, 锚点.Y - 2),
					new Point(锚点.X + 2, 锚点.Y - 1)
				};
			case 技能范围类型.斩月1x3:
				return new Point[]
				{
					锚点,
					ComputingClass.前方坐标(锚点, 方向, 1),
					ComputingClass.前方坐标(锚点, 方向, 2)
				};
			case 技能范围类型.斩月3x3:
				if (方向 <= GameDirection.上方)
				{
					if (方向 == GameDirection.左方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X + 2, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 2, 锚点.Y - 1),
							new Point(锚点.X + 2, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.左上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 2, 锚点.Y + 2),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y + 2),
							new Point(锚点.X + 2, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.上方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y + 2),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 2),
							new Point(锚点.X - 1, 锚点.Y + 2)
						};
					}
				}
				else if (方向 <= GameDirection.右方)
				{
					if (方向 == GameDirection.右上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X - 2, 锚点.Y + 2),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y + 2),
							new Point(锚点.X - 2, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.右方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X - 2, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X - 2, 锚点.Y + 1),
							new Point(锚点.X - 2, 锚点.Y - 1)
						};
					}
				}
				else
				{
					if (方向 == GameDirection.下方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y - 2),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y - 2),
							new Point(锚点.X + 1, 锚点.Y - 2)
						};
					}
					if (方向 == GameDirection.左下)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X + 2, 锚点.Y - 2),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y - 2),
							new Point(锚点.X + 2, 锚点.Y - 1)
						};
					}
				}
				return new Point[]
				{
					锚点,
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X - 2, 锚点.Y - 2),
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X - 2, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y - 2)
				};
			case 技能范围类型.线型1x5:
				return new Point[]
				{
					锚点,
					ComputingClass.前方坐标(锚点, 方向, 1),
					ComputingClass.前方坐标(锚点, 方向, 2),
					ComputingClass.前方坐标(锚点, 方向, 3),
					ComputingClass.前方坐标(锚点, 方向, 4)
				};
			case 技能范围类型.线型1x8:
				return new Point[]
				{
					锚点,
					ComputingClass.前方坐标(锚点, 方向, 1),
					ComputingClass.前方坐标(锚点, 方向, 2),
					ComputingClass.前方坐标(锚点, 方向, 3),
					ComputingClass.前方坐标(锚点, 方向, 4),
					ComputingClass.前方坐标(锚点, 方向, 5),
					ComputingClass.前方坐标(锚点, 方向, 6),
					ComputingClass.前方坐标(锚点, 方向, 7)
				};
			case 技能范围类型.线型3x8:
				if (方向 <= GameDirection.上方)
				{
					if (方向 == GameDirection.左方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 2, 锚点.Y),
							new Point(锚点.X + 2, 锚点.Y - 1),
							new Point(锚点.X + 2, 锚点.Y + 1),
							new Point(锚点.X + 3, 锚点.Y),
							new Point(锚点.X + 3, 锚点.Y - 1),
							new Point(锚点.X + 3, 锚点.Y + 1),
							new Point(锚点.X + 4, 锚点.Y),
							new Point(锚点.X + 4, 锚点.Y - 1),
							new Point(锚点.X + 4, 锚点.Y + 1),
							new Point(锚点.X + 5, 锚点.Y),
							new Point(锚点.X + 5, 锚点.Y - 1),
							new Point(锚点.X + 5, 锚点.Y + 1),
							new Point(锚点.X + 6, 锚点.Y),
							new Point(锚点.X + 6, 锚点.Y - 1),
							new Point(锚点.X + 6, 锚点.Y + 1),
							new Point(锚点.X + 7, 锚点.Y),
							new Point(锚点.X + 7, 锚点.Y - 1),
							new Point(锚点.X + 7, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.左上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 2, 锚点.Y + 2),
							new Point(锚点.X + 2, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 2),
							new Point(锚点.X + 3, 锚点.Y + 3),
							new Point(锚点.X + 3, 锚点.Y + 2),
							new Point(锚点.X + 2, 锚点.Y + 3),
							new Point(锚点.X + 4, 锚点.Y + 4),
							new Point(锚点.X + 4, 锚点.Y + 3),
							new Point(锚点.X + 3, 锚点.Y + 4),
							new Point(锚点.X + 5, 锚点.Y + 5),
							new Point(锚点.X + 5, 锚点.Y + 4),
							new Point(锚点.X + 4, 锚点.Y + 5),
							new Point(锚点.X + 6, 锚点.Y + 6),
							new Point(锚点.X + 6, 锚点.Y + 5),
							new Point(锚点.X + 5, 锚点.Y + 6),
							new Point(锚点.X + 7, 锚点.Y + 7),
							new Point(锚点.X + 7, 锚点.Y + 6),
							new Point(锚点.X + 6, 锚点.Y + 7)
						};
					}
					if (方向 == GameDirection.上方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y + 2),
							new Point(锚点.X + 1, 锚点.Y + 2),
							new Point(锚点.X - 1, 锚点.Y + 2),
							new Point(锚点.X, 锚点.Y + 3),
							new Point(锚点.X + 1, 锚点.Y + 3),
							new Point(锚点.X - 1, 锚点.Y + 3),
							new Point(锚点.X, 锚点.Y + 4),
							new Point(锚点.X + 1, 锚点.Y + 4),
							new Point(锚点.X - 1, 锚点.Y + 4),
							new Point(锚点.X, 锚点.Y + 5),
							new Point(锚点.X + 1, 锚点.Y + 5),
							new Point(锚点.X - 1, 锚点.Y + 5),
							new Point(锚点.X, 锚点.Y + 6),
							new Point(锚点.X + 1, 锚点.Y + 6),
							new Point(锚点.X - 1, 锚点.Y + 6),
							new Point(锚点.X, 锚点.Y + 7),
							new Point(锚点.X + 1, 锚点.Y + 7),
							new Point(锚点.X - 1, 锚点.Y + 7)
						};
					}
				}
				else if (方向 <= GameDirection.右方)
				{
					if (方向 == GameDirection.右上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X - 2, 锚点.Y + 2),
							new Point(锚点.X - 1, 锚点.Y + 2),
							new Point(锚点.X - 2, 锚点.Y + 1),
							new Point(锚点.X - 3, 锚点.Y + 3),
							new Point(锚点.X - 2, 锚点.Y + 3),
							new Point(锚点.X - 3, 锚点.Y + 2),
							new Point(锚点.X - 4, 锚点.Y + 4),
							new Point(锚点.X - 3, 锚点.Y + 4),
							new Point(锚点.X - 4, 锚点.Y + 3),
							new Point(锚点.X - 5, 锚点.Y + 5),
							new Point(锚点.X - 4, 锚点.Y + 5),
							new Point(锚点.X - 5, 锚点.Y + 4),
							new Point(锚点.X - 6, 锚点.Y + 6),
							new Point(锚点.X - 5, 锚点.Y + 6),
							new Point(锚点.X - 6, 锚点.Y + 5),
							new Point(锚点.X - 7, 锚点.Y + 7),
							new Point(锚点.X - 6, 锚点.Y + 7),
							new Point(锚点.X - 7, 锚点.Y + 6)
						};
					}
					if (方向 == GameDirection.右方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X - 2, 锚点.Y),
							new Point(锚点.X - 2, 锚点.Y + 1),
							new Point(锚点.X - 2, 锚点.Y - 1),
							new Point(锚点.X - 3, 锚点.Y),
							new Point(锚点.X - 3, 锚点.Y + 1),
							new Point(锚点.X - 3, 锚点.Y - 1),
							new Point(锚点.X - 4, 锚点.Y),
							new Point(锚点.X - 4, 锚点.Y + 1),
							new Point(锚点.X - 4, 锚点.Y - 1),
							new Point(锚点.X - 5, 锚点.Y),
							new Point(锚点.X - 5, 锚点.Y + 1),
							new Point(锚点.X - 5, 锚点.Y - 1),
							new Point(锚点.X - 6, 锚点.Y),
							new Point(锚点.X - 6, 锚点.Y + 1),
							new Point(锚点.X - 6, 锚点.Y - 1),
							new Point(锚点.X - 7, 锚点.Y),
							new Point(锚点.X - 7, 锚点.Y + 1),
							new Point(锚点.X - 7, 锚点.Y - 1)
						};
					}
				}
				else
				{
					if (方向 == GameDirection.下方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y - 2),
							new Point(锚点.X - 1, 锚点.Y - 2),
							new Point(锚点.X + 1, 锚点.Y - 2),
							new Point(锚点.X, 锚点.Y - 3),
							new Point(锚点.X - 1, 锚点.Y - 3),
							new Point(锚点.X + 1, 锚点.Y - 3),
							new Point(锚点.X, 锚点.Y - 4),
							new Point(锚点.X - 1, 锚点.Y - 4),
							new Point(锚点.X + 1, 锚点.Y - 4),
							new Point(锚点.X, 锚点.Y - 5),
							new Point(锚点.X - 1, 锚点.Y - 5),
							new Point(锚点.X + 1, 锚点.Y - 5),
							new Point(锚点.X, 锚点.Y - 6),
							new Point(锚点.X - 1, 锚点.Y - 6),
							new Point(锚点.X + 1, 锚点.Y - 6),
							new Point(锚点.X, 锚点.Y - 7),
							new Point(锚点.X - 1, 锚点.Y - 7),
							new Point(锚点.X + 1, 锚点.Y - 7)
						};
					}
					if (方向 == GameDirection.左下)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X + 2, 锚点.Y - 2),
							new Point(锚点.X + 1, 锚点.Y - 2),
							new Point(锚点.X + 2, 锚点.Y - 1),
							new Point(锚点.X + 3, 锚点.Y - 3),
							new Point(锚点.X + 2, 锚点.Y - 3),
							new Point(锚点.X + 3, 锚点.Y - 2),
							new Point(锚点.X + 4, 锚点.Y - 4),
							new Point(锚点.X + 3, 锚点.Y - 4),
							new Point(锚点.X + 4, 锚点.Y - 3),
							new Point(锚点.X + 5, 锚点.Y - 5),
							new Point(锚点.X + 4, 锚点.Y - 5),
							new Point(锚点.X + 5, 锚点.Y - 4),
							new Point(锚点.X + 6, 锚点.Y - 6),
							new Point(锚点.X + 5, 锚点.Y - 6),
							new Point(锚点.X + 6, 锚点.Y - 5),
							new Point(锚点.X + 7, 锚点.Y - 7),
							new Point(锚点.X + 6, 锚点.Y - 7),
							new Point(锚点.X + 7, 锚点.Y - 6)
						};
					}
				}
				return new Point[]
				{
					锚点,
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X - 2, 锚点.Y - 2),
					new Point(锚点.X - 2, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y - 2),
					new Point(锚点.X - 3, 锚点.Y - 3),
					new Point(锚点.X - 3, 锚点.Y - 2),
					new Point(锚点.X - 2, 锚点.Y - 3),
					new Point(锚点.X - 4, 锚点.Y - 4),
					new Point(锚点.X - 4, 锚点.Y - 3),
					new Point(锚点.X - 3, 锚点.Y - 4),
					new Point(锚点.X - 5, 锚点.Y - 5),
					new Point(锚点.X - 5, 锚点.Y - 4),
					new Point(锚点.X - 4, 锚点.Y - 5),
					new Point(锚点.X - 6, 锚点.Y - 6),
					new Point(锚点.X - 6, 锚点.Y - 5),
					new Point(锚点.X - 5, 锚点.Y - 6),
					new Point(锚点.X - 7, 锚点.Y - 7),
					new Point(锚点.X - 7, 锚点.Y - 6),
					new Point(锚点.X - 6, 锚点.Y - 7)
				};
			case 技能范围类型.菱形3x3:
				return new Point[]
				{
					锚点,
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y)
				};
			case 技能范围类型.线型3x7:
				if (方向 <= GameDirection.上方)
				{
					if (方向 == GameDirection.左方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 2, 锚点.Y),
							new Point(锚点.X + 2, 锚点.Y - 1),
							new Point(锚点.X + 2, 锚点.Y + 1),
							new Point(锚点.X + 3, 锚点.Y),
							new Point(锚点.X + 3, 锚点.Y - 1),
							new Point(锚点.X + 3, 锚点.Y + 1),
							new Point(锚点.X + 4, 锚点.Y),
							new Point(锚点.X + 4, 锚点.Y - 1),
							new Point(锚点.X + 4, 锚点.Y + 1),
							new Point(锚点.X + 5, 锚点.Y),
							new Point(锚点.X + 5, 锚点.Y - 1),
							new Point(锚点.X + 5, 锚点.Y + 1),
							new Point(锚点.X + 6, 锚点.Y),
							new Point(锚点.X + 6, 锚点.Y - 1),
							new Point(锚点.X + 6, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.左上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 2, 锚点.Y + 2),
							new Point(锚点.X + 2, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 2),
							new Point(锚点.X + 3, 锚点.Y + 3),
							new Point(锚点.X + 3, 锚点.Y + 2),
							new Point(锚点.X + 2, 锚点.Y + 3),
							new Point(锚点.X + 4, 锚点.Y + 4),
							new Point(锚点.X + 4, 锚点.Y + 3),
							new Point(锚点.X + 3, 锚点.Y + 4),
							new Point(锚点.X + 5, 锚点.Y + 5),
							new Point(锚点.X + 5, 锚点.Y + 4),
							new Point(锚点.X + 4, 锚点.Y + 5),
							new Point(锚点.X + 6, 锚点.Y + 6),
							new Point(锚点.X + 6, 锚点.Y + 5),
							new Point(锚点.X + 5, 锚点.Y + 6)
						};
					}
					if (方向 == GameDirection.上方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y + 2),
							new Point(锚点.X + 1, 锚点.Y + 2),
							new Point(锚点.X - 1, 锚点.Y + 2),
							new Point(锚点.X, 锚点.Y + 3),
							new Point(锚点.X + 1, 锚点.Y + 3),
							new Point(锚点.X - 1, 锚点.Y + 3),
							new Point(锚点.X, 锚点.Y + 4),
							new Point(锚点.X + 1, 锚点.Y + 4),
							new Point(锚点.X - 1, 锚点.Y + 4),
							new Point(锚点.X, 锚点.Y + 5),
							new Point(锚点.X + 1, 锚点.Y + 5),
							new Point(锚点.X - 1, 锚点.Y + 5),
							new Point(锚点.X, 锚点.Y + 6),
							new Point(锚点.X + 1, 锚点.Y + 6),
							new Point(锚点.X - 1, 锚点.Y + 6)
						};
					}
				}
				else if (方向 <= GameDirection.右方)
				{
					if (方向 == GameDirection.右上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X - 2, 锚点.Y + 2),
							new Point(锚点.X - 1, 锚点.Y + 2),
							new Point(锚点.X - 2, 锚点.Y + 1),
							new Point(锚点.X - 3, 锚点.Y + 3),
							new Point(锚点.X - 2, 锚点.Y + 3),
							new Point(锚点.X - 3, 锚点.Y + 2),
							new Point(锚点.X - 4, 锚点.Y + 4),
							new Point(锚点.X - 3, 锚点.Y + 4),
							new Point(锚点.X - 4, 锚点.Y + 3),
							new Point(锚点.X - 5, 锚点.Y + 5),
							new Point(锚点.X - 4, 锚点.Y + 5),
							new Point(锚点.X - 5, 锚点.Y + 4),
							new Point(锚点.X - 6, 锚点.Y + 6),
							new Point(锚点.X - 5, 锚点.Y + 6),
							new Point(锚点.X - 6, 锚点.Y + 5)
						};
					}
					if (方向 == GameDirection.右方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X - 2, 锚点.Y),
							new Point(锚点.X - 2, 锚点.Y + 1),
							new Point(锚点.X - 2, 锚点.Y - 1),
							new Point(锚点.X - 3, 锚点.Y),
							new Point(锚点.X - 3, 锚点.Y + 1),
							new Point(锚点.X - 3, 锚点.Y - 1),
							new Point(锚点.X - 4, 锚点.Y),
							new Point(锚点.X - 4, 锚点.Y + 1),
							new Point(锚点.X - 4, 锚点.Y - 1),
							new Point(锚点.X - 5, 锚点.Y),
							new Point(锚点.X - 5, 锚点.Y + 1),
							new Point(锚点.X - 5, 锚点.Y - 1),
							new Point(锚点.X - 6, 锚点.Y),
							new Point(锚点.X - 6, 锚点.Y + 1),
							new Point(锚点.X - 6, 锚点.Y - 1)
						};
					}
				}
				else
				{
					if (方向 == GameDirection.下方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y - 2),
							new Point(锚点.X - 1, 锚点.Y - 2),
							new Point(锚点.X + 1, 锚点.Y - 2),
							new Point(锚点.X, 锚点.Y - 3),
							new Point(锚点.X - 1, 锚点.Y - 3),
							new Point(锚点.X + 1, 锚点.Y - 3),
							new Point(锚点.X, 锚点.Y - 4),
							new Point(锚点.X - 1, 锚点.Y - 4),
							new Point(锚点.X + 1, 锚点.Y - 4),
							new Point(锚点.X, 锚点.Y - 5),
							new Point(锚点.X - 1, 锚点.Y - 5),
							new Point(锚点.X + 1, 锚点.Y - 5),
							new Point(锚点.X, 锚点.Y - 6),
							new Point(锚点.X - 1, 锚点.Y - 6),
							new Point(锚点.X + 1, 锚点.Y - 6)
						};
					}
					if (方向 == GameDirection.左下)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X + 2, 锚点.Y - 2),
							new Point(锚点.X + 1, 锚点.Y - 2),
							new Point(锚点.X + 2, 锚点.Y - 1),
							new Point(锚点.X + 3, 锚点.Y - 3),
							new Point(锚点.X + 2, 锚点.Y - 3),
							new Point(锚点.X + 3, 锚点.Y - 2),
							new Point(锚点.X + 4, 锚点.Y - 4),
							new Point(锚点.X + 3, 锚点.Y - 4),
							new Point(锚点.X + 4, 锚点.Y - 3),
							new Point(锚点.X + 5, 锚点.Y - 5),
							new Point(锚点.X + 4, 锚点.Y - 5),
							new Point(锚点.X + 5, 锚点.Y - 4),
							new Point(锚点.X + 6, 锚点.Y - 6),
							new Point(锚点.X + 5, 锚点.Y - 6),
							new Point(锚点.X + 6, 锚点.Y - 5)
						};
					}
				}
				return new Point[]
				{
					锚点,
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X - 2, 锚点.Y - 2),
					new Point(锚点.X - 2, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y - 2),
					new Point(锚点.X - 3, 锚点.Y - 3),
					new Point(锚点.X - 3, 锚点.Y - 2),
					new Point(锚点.X - 2, 锚点.Y - 3),
					new Point(锚点.X - 4, 锚点.Y - 4),
					new Point(锚点.X - 4, 锚点.Y - 3),
					new Point(锚点.X - 3, 锚点.Y - 4),
					new Point(锚点.X - 5, 锚点.Y - 5),
					new Point(锚点.X - 5, 锚点.Y - 4),
					new Point(锚点.X - 4, 锚点.Y - 5),
					new Point(锚点.X - 6, 锚点.Y - 6),
					new Point(锚点.X - 6, 锚点.Y - 5),
					new Point(锚点.X - 5, 锚点.Y - 6)
				};
			case 技能范围类型.叉型3x3:
				return new Point[]
				{
					锚点,
					new Point(锚点.X + 1, 锚点.Y + 1),
					new Point(锚点.X - 1, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y - 1)
				};
			case 技能范围类型.空心5x5:
				return new Point[]
				{
					new Point(锚点.X + 1, 锚点.Y + 1),
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X - 1, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X + 1, 锚点.Y - 1),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X + 2, 锚点.Y),
					new Point(锚点.X + 2, 锚点.Y + 1),
					new Point(锚点.X + 2, 锚点.Y + 2),
					new Point(锚点.X + 1, 锚点.Y + 2),
					new Point(锚点.X, 锚点.Y + 2),
					new Point(锚点.X - 1, 锚点.Y + 2),
					new Point(锚点.X - 2, 锚点.Y + 2),
					new Point(锚点.X - 2, 锚点.Y + 1),
					new Point(锚点.X - 2, 锚点.Y),
					new Point(锚点.X - 2, 锚点.Y - 1),
					new Point(锚点.X - 2, 锚点.Y - 2),
					new Point(锚点.X - 1, 锚点.Y - 2),
					new Point(锚点.X, 锚点.Y - 2),
					new Point(锚点.X + 1, 锚点.Y - 2),
					new Point(锚点.X + 2, 锚点.Y - 2),
					new Point(锚点.X + 2, 锚点.Y - 1)
				};
			case 技能范围类型.线型1x2:
				return new Point[]
				{
					锚点,
					ComputingClass.前方坐标(锚点, 方向, 1)
				};
			case 技能范围类型.前方3x1:
				if (方向 <= GameDirection.上方)
				{
					if (方向 == GameDirection.左方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.左上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y)
						};
					}
					if (方向 == GameDirection.上方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y)
						};
					}
				}
				else if (方向 <= GameDirection.右方)
				{
					if (方向 == GameDirection.右上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y - 1)
						};
					}
					if (方向 == GameDirection.右方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1)
						};
					}
				}
				else
				{
					if (方向 == GameDirection.下方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y)
						};
					}
					if (方向 == GameDirection.左下)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1)
						};
					}
				}
				return new Point[]
				{
					锚点,
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X + 1, 锚点.Y)
				};
			case 技能范围类型.螺旋7x7:
				return new Point[]
				{
					锚点,
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X + 1, 锚点.Y - 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X + 1, 锚点.Y + 1),
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X - 1, 锚点.Y + 1),
					new Point(锚点.X - 2, 锚点.Y + 1),
					new Point(锚点.X - 2, 锚点.Y),
					new Point(锚点.X - 2, 锚点.Y - 1),
					new Point(锚点.X - 2, 锚点.Y - 2),
					new Point(锚点.X - 1, 锚点.Y - 2),
					new Point(锚点.X, 锚点.Y - 2),
					new Point(锚点.X + 1, 锚点.Y - 2),
					new Point(锚点.X + 2, 锚点.Y - 2),
					new Point(锚点.X + 2, 锚点.Y - 1),
					new Point(锚点.X + 2, 锚点.Y),
					new Point(锚点.X + 2, 锚点.Y + 1),
					new Point(锚点.X + 2, 锚点.Y + 2),
					new Point(锚点.X + 1, 锚点.Y + 2),
					new Point(锚点.X, 锚点.Y + 2),
					new Point(锚点.X - 1, 锚点.Y + 2),
					new Point(锚点.X - 2, 锚点.Y + 2),
					new Point(锚点.X - 3, 锚点.Y + 2),
					new Point(锚点.X - 3, 锚点.Y + 1),
					new Point(锚点.X - 3, 锚点.Y),
					new Point(锚点.X - 3, 锚点.Y - 1),
					new Point(锚点.X - 3, 锚点.Y - 2),
					new Point(锚点.X - 3, 锚点.Y - 3),
					new Point(锚点.X - 2, 锚点.Y - 3),
					new Point(锚点.X - 1, 锚点.Y - 3),
					new Point(锚点.X, 锚点.Y - 3),
					new Point(锚点.X + 1, 锚点.Y - 3),
					new Point(锚点.X + 2, 锚点.Y - 3),
					new Point(锚点.X + 3, 锚点.Y - 3),
					new Point(锚点.X + 3, 锚点.Y - 2),
					new Point(锚点.X + 3, 锚点.Y - 1),
					new Point(锚点.X + 3, 锚点.Y),
					new Point(锚点.X + 3, 锚点.Y + 1),
					new Point(锚点.X + 3, 锚点.Y + 2),
					new Point(锚点.X + 3, 锚点.Y + 3),
					new Point(锚点.X + 2, 锚点.Y + 3),
					new Point(锚点.X + 1, 锚点.Y + 3),
					new Point(锚点.X, 锚点.Y + 3),
					new Point(锚点.X - 1, 锚点.Y + 3),
					new Point(锚点.X - 2, 锚点.Y + 3),
					new Point(锚点.X - 3, 锚点.Y + 3)
				};
			case 技能范围类型.炎龙1x2:
				if (方向 <= GameDirection.上方)
				{
					if (方向 == GameDirection.左方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y - 1)
						};
					}
					if (方向 == GameDirection.左上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1)
						};
					}
					if (方向 == GameDirection.上方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X + 1, 锚点.Y + 1)
						};
					}
				}
				else if (方向 <= GameDirection.右方)
				{
					if (方向 == GameDirection.右上)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y)
						};
					}
					if (方向 == GameDirection.右方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X, 锚点.Y + 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y + 1),
							new Point(锚点.X - 1, 锚点.Y - 1)
						};
					}
				}
				else
				{
					if (方向 == GameDirection.下方)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X - 1, 锚点.Y),
							new Point(锚点.X + 1, 锚点.Y),
							new Point(锚点.X - 1, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y - 1)
						};
					}
					if (方向 == GameDirection.左下)
					{
						return new Point[]
						{
							锚点,
							new Point(锚点.X + 1, 锚点.Y - 1),
							new Point(锚点.X, 锚点.Y - 1),
							new Point(锚点.X + 1, 锚点.Y)
						};
					}
				}
				return new Point[]
				{
					锚点,
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X, 锚点.Y - 1)
				};
			case 技能范围类型.线型1x7:
				return new Point[]
				{
					锚点,
					ComputingClass.前方坐标(锚点, 方向, 1),
					ComputingClass.前方坐标(锚点, 方向, 2),
					ComputingClass.前方坐标(锚点, 方向, 3),
					ComputingClass.前方坐标(锚点, 方向, 4),
					ComputingClass.前方坐标(锚点, 方向, 5),
					ComputingClass.前方坐标(锚点, 方向, 6)
				};
			case 技能范围类型.螺旋15x15:
				return new Point[]
				{
					new Point(锚点.X - 1, 锚点.Y),
					new Point(锚点.X - 1, 锚点.Y - 1),
					new Point(锚点.X, 锚点.Y - 1),
					new Point(锚点.X + 1, 锚点.Y - 1),
					new Point(锚点.X + 1, 锚点.Y),
					new Point(锚点.X + 1, 锚点.Y + 1),
					new Point(锚点.X, 锚点.Y + 1),
					new Point(锚点.X - 1, 锚点.Y + 1),
					new Point(锚点.X - 2, 锚点.Y + 1),
					new Point(锚点.X - 2, 锚点.Y),
					new Point(锚点.X - 2, 锚点.Y - 1),
					new Point(锚点.X - 2, 锚点.Y - 2),
					new Point(锚点.X - 1, 锚点.Y - 2),
					new Point(锚点.X, 锚点.Y - 2),
					new Point(锚点.X + 1, 锚点.Y - 2),
					new Point(锚点.X + 2, 锚点.Y - 2),
					new Point(锚点.X + 2, 锚点.Y - 1),
					new Point(锚点.X + 2, 锚点.Y),
					new Point(锚点.X + 2, 锚点.Y + 1),
					new Point(锚点.X + 2, 锚点.Y + 2),
					new Point(锚点.X + 1, 锚点.Y + 2),
					new Point(锚点.X, 锚点.Y + 2),
					new Point(锚点.X - 1, 锚点.Y + 2),
					new Point(锚点.X - 2, 锚点.Y + 2),
					new Point(锚点.X - 3, 锚点.Y + 2),
					new Point(锚点.X - 3, 锚点.Y + 1),
					new Point(锚点.X - 3, 锚点.Y),
					new Point(锚点.X - 3, 锚点.Y - 1),
					new Point(锚点.X - 3, 锚点.Y - 2),
					new Point(锚点.X - 3, 锚点.Y - 3),
					new Point(锚点.X - 2, 锚点.Y - 3),
					new Point(锚点.X - 1, 锚点.Y - 3),
					new Point(锚点.X, 锚点.Y - 3),
					new Point(锚点.X + 1, 锚点.Y - 3),
					new Point(锚点.X + 2, 锚点.Y - 3),
					new Point(锚点.X + 3, 锚点.Y - 3),
					new Point(锚点.X + 3, 锚点.Y - 2),
					new Point(锚点.X + 3, 锚点.Y - 1),
					new Point(锚点.X + 3, 锚点.Y),
					new Point(锚点.X + 3, 锚点.Y + 1),
					new Point(锚点.X + 3, 锚点.Y + 2),
					new Point(锚点.X + 3, 锚点.Y + 3),
					new Point(锚点.X + 2, 锚点.Y + 3),
					new Point(锚点.X + 1, 锚点.Y + 3),
					new Point(锚点.X, 锚点.Y + 3),
					new Point(锚点.X - 1, 锚点.Y + 3),
					new Point(锚点.X - 2, 锚点.Y + 3),
					new Point(锚点.X - 3, 锚点.Y + 3),
					new Point(锚点.X - 4, 锚点.Y + 3),
					new Point(锚点.X - 4, 锚点.Y + 2),
					new Point(锚点.X - 4, 锚点.Y + 1),
					new Point(锚点.X - 4, 锚点.Y),
					new Point(锚点.X - 4, 锚点.Y - 1),
					new Point(锚点.X - 4, 锚点.Y - 2),
					new Point(锚点.X - 4, 锚点.Y - 3),
					new Point(锚点.X - 4, 锚点.Y - 4),
					new Point(锚点.X - 3, 锚点.Y - 4),
					new Point(锚点.X - 2, 锚点.Y - 4),
					new Point(锚点.X - 1, 锚点.Y - 4),
					new Point(锚点.X, 锚点.Y - 4),
					new Point(锚点.X + 1, 锚点.Y - 4),
					new Point(锚点.X + 2, 锚点.Y - 4),
					new Point(锚点.X + 3, 锚点.Y - 4),
					new Point(锚点.X + 4, 锚点.Y - 4),
					new Point(锚点.X + 4, 锚点.Y - 3),
					new Point(锚点.X + 4, 锚点.Y - 2),
					new Point(锚点.X + 4, 锚点.Y - 1),
					new Point(锚点.X + 4, 锚点.Y),
					new Point(锚点.X + 4, 锚点.Y + 1),
					new Point(锚点.X + 4, 锚点.Y + 2),
					new Point(锚点.X + 4, 锚点.Y + 3),
					new Point(锚点.X + 4, 锚点.Y + 4),
					new Point(锚点.X + 3, 锚点.Y + 4),
					new Point(锚点.X + 2, 锚点.Y + 4),
					new Point(锚点.X + 1, 锚点.Y + 4),
					new Point(锚点.X, 锚点.Y + 4),
					new Point(锚点.X - 1, 锚点.Y + 4),
					new Point(锚点.X - 2, 锚点.Y + 4),
					new Point(锚点.X - 3, 锚点.Y + 4),
					new Point(锚点.X - 4, 锚点.Y + 4),
					new Point(锚点.X - 5, 锚点.Y + 4),
					new Point(锚点.X - 5, 锚点.Y + 3),
					new Point(锚点.X - 5, 锚点.Y + 2),
					new Point(锚点.X - 5, 锚点.Y + 1),
					new Point(锚点.X - 5, 锚点.Y),
					new Point(锚点.X - 5, 锚点.Y - 1),
					new Point(锚点.X - 5, 锚点.Y - 2),
					new Point(锚点.X - 5, 锚点.Y - 3),
					new Point(锚点.X - 5, 锚点.Y - 4),
					new Point(锚点.X - 5, 锚点.Y - 5),
					new Point(锚点.X - 4, 锚点.Y - 5),
					new Point(锚点.X - 3, 锚点.Y - 5),
					new Point(锚点.X - 2, 锚点.Y - 5),
					new Point(锚点.X - 1, 锚点.Y - 5),
					new Point(锚点.X, 锚点.Y - 5),
					new Point(锚点.X + 1, 锚点.Y - 5),
					new Point(锚点.X + 2, 锚点.Y - 5),
					new Point(锚点.X + 3, 锚点.Y - 5),
					new Point(锚点.X + 4, 锚点.Y - 5),
					new Point(锚点.X + 5, 锚点.Y - 5),
					new Point(锚点.X + 5, 锚点.Y - 4),
					new Point(锚点.X + 5, 锚点.Y - 3),
					new Point(锚点.X + 5, 锚点.Y - 2),
					new Point(锚点.X + 5, 锚点.Y - 1),
					new Point(锚点.X + 5, 锚点.Y),
					new Point(锚点.X + 5, 锚点.Y + 1),
					new Point(锚点.X + 5, 锚点.Y + 2),
					new Point(锚点.X + 5, 锚点.Y + 3),
					new Point(锚点.X + 5, 锚点.Y + 4),
					new Point(锚点.X + 5, 锚点.Y + 5),
					new Point(锚点.X + 4, 锚点.Y + 5),
					new Point(锚点.X + 3, 锚点.Y + 5),
					new Point(锚点.X + 2, 锚点.Y + 5),
					new Point(锚点.X + 1, 锚点.Y + 5),
					new Point(锚点.X, 锚点.Y + 5),
					new Point(锚点.X - 1, 锚点.Y + 5),
					new Point(锚点.X - 2, 锚点.Y + 5),
					new Point(锚点.X - 3, 锚点.Y + 5),
					new Point(锚点.X - 4, 锚点.Y + 5),
					new Point(锚点.X - 5, 锚点.Y + 5),
					new Point(锚点.X - 6, 锚点.Y + 5),
					new Point(锚点.X - 6, 锚点.Y + 4),
					new Point(锚点.X - 6, 锚点.Y + 3),
					new Point(锚点.X - 6, 锚点.Y + 2),
					new Point(锚点.X - 6, 锚点.Y + 1),
					new Point(锚点.X - 6, 锚点.Y),
					new Point(锚点.X - 6, 锚点.Y - 1),
					new Point(锚点.X - 6, 锚点.Y - 2),
					new Point(锚点.X - 6, 锚点.Y - 3),
					new Point(锚点.X - 6, 锚点.Y - 4),
					new Point(锚点.X - 6, 锚点.Y - 5),
					new Point(锚点.X - 6, 锚点.Y - 6),
					new Point(锚点.X - 5, 锚点.Y - 6),
					new Point(锚点.X - 4, 锚点.Y - 6),
					new Point(锚点.X - 3, 锚点.Y - 6),
					new Point(锚点.X - 2, 锚点.Y - 6),
					new Point(锚点.X - 1, 锚点.Y - 6),
					new Point(锚点.X, 锚点.Y - 6),
					new Point(锚点.X + 1, 锚点.Y - 6),
					new Point(锚点.X + 2, 锚点.Y - 6),
					new Point(锚点.X + 3, 锚点.Y - 6),
					new Point(锚点.X + 4, 锚点.Y - 6),
					new Point(锚点.X + 5, 锚点.Y - 6),
					new Point(锚点.X + 6, 锚点.Y - 6),
					new Point(锚点.X + 6, 锚点.Y - 5),
					new Point(锚点.X + 6, 锚点.Y - 4),
					new Point(锚点.X + 6, 锚点.Y - 3),
					new Point(锚点.X + 6, 锚点.Y - 2),
					new Point(锚点.X + 6, 锚点.Y - 1),
					new Point(锚点.X + 6, 锚点.Y),
					new Point(锚点.X + 6, 锚点.Y + 1),
					new Point(锚点.X + 6, 锚点.Y + 2),
					new Point(锚点.X + 6, 锚点.Y + 3),
					new Point(锚点.X + 6, 锚点.Y + 4),
					new Point(锚点.X + 6, 锚点.Y + 5),
					new Point(锚点.X + 6, 锚点.Y + 6),
					new Point(锚点.X + 5, 锚点.Y + 6),
					new Point(锚点.X + 4, 锚点.Y + 6),
					new Point(锚点.X + 3, 锚点.Y + 6),
					new Point(锚点.X + 2, 锚点.Y + 6),
					new Point(锚点.X + 1, 锚点.Y + 6),
					new Point(锚点.X, 锚点.Y + 6),
					new Point(锚点.X - 1, 锚点.Y + 6),
					new Point(锚点.X - 2, 锚点.Y + 6),
					new Point(锚点.X - 3, 锚点.Y + 6),
					new Point(锚点.X - 4, 锚点.Y + 6),
					new Point(锚点.X - 5, 锚点.Y + 6),
					new Point(锚点.X - 6, 锚点.Y + 6),
					new Point(锚点.X - 7, 锚点.Y + 6),
					new Point(锚点.X - 7, 锚点.Y + 5),
					new Point(锚点.X - 7, 锚点.Y + 4),
					new Point(锚点.X - 7, 锚点.Y + 3),
					new Point(锚点.X - 7, 锚点.Y + 2),
					new Point(锚点.X - 7, 锚点.Y + 1),
					new Point(锚点.X - 7, 锚点.Y),
					new Point(锚点.X - 7, 锚点.Y - 1),
					new Point(锚点.X - 7, 锚点.Y - 2),
					new Point(锚点.X - 7, 锚点.Y - 3),
					new Point(锚点.X - 7, 锚点.Y - 4),
					new Point(锚点.X - 7, 锚点.Y - 5),
					new Point(锚点.X - 7, 锚点.Y - 6),
					new Point(锚点.X - 7, 锚点.Y - 7),
					new Point(锚点.X - 6, 锚点.Y - 7),
					new Point(锚点.X - 5, 锚点.Y - 7),
					new Point(锚点.X - 4, 锚点.Y - 7),
					new Point(锚点.X - 3, 锚点.Y - 7),
					new Point(锚点.X - 2, 锚点.Y - 7),
					new Point(锚点.X - 1, 锚点.Y - 7),
					new Point(锚点.X, 锚点.Y - 7),
					new Point(锚点.X + 1, 锚点.Y - 7),
					new Point(锚点.X + 2, 锚点.Y - 7),
					new Point(锚点.X + 3, 锚点.Y - 7),
					new Point(锚点.X + 4, 锚点.Y - 7),
					new Point(锚点.X + 5, 锚点.Y - 7),
					new Point(锚点.X + 6, 锚点.Y - 7),
					new Point(锚点.X + 7, 锚点.Y - 7),
					new Point(锚点.X + 7, 锚点.Y - 6),
					new Point(锚点.X + 7, 锚点.Y - 5),
					new Point(锚点.X + 7, 锚点.Y - 4),
					new Point(锚点.X + 7, 锚点.Y - 3),
					new Point(锚点.X + 7, 锚点.Y - 2),
					new Point(锚点.X + 7, 锚点.Y - 1),
					new Point(锚点.X + 7, 锚点.Y),
					new Point(锚点.X + 7, 锚点.Y + 1),
					new Point(锚点.X + 7, 锚点.Y + 2),
					new Point(锚点.X + 7, 锚点.Y + 3),
					new Point(锚点.X + 7, 锚点.Y + 4),
					new Point(锚点.X + 7, 锚点.Y + 5),
					new Point(锚点.X + 7, 锚点.Y + 6),
					new Point(锚点.X + 7, 锚点.Y + 7),
					new Point(锚点.X + 6, 锚点.Y + 7),
					new Point(锚点.X + 5, 锚点.Y + 7),
					new Point(锚点.X + 4, 锚点.Y + 7),
					new Point(锚点.X + 3, 锚点.Y + 7),
					new Point(锚点.X + 2, 锚点.Y + 7),
					new Point(锚点.X + 1, 锚点.Y + 7),
					new Point(锚点.X, 锚点.Y + 7),
					new Point(锚点.X - 1, 锚点.Y + 7),
					new Point(锚点.X - 2, 锚点.Y + 7),
					new Point(锚点.X - 3, 锚点.Y + 7),
					new Point(锚点.X - 4, 锚点.Y + 7),
					new Point(锚点.X - 5, 锚点.Y + 7),
					new Point(锚点.X - 6, 锚点.Y + 7),
					new Point(锚点.X - 7, 锚点.Y + 7),
					new Point(锚点.X - 8, 锚点.Y + 7),
					new Point(锚点.X - 8, 锚点.Y + 6),
					new Point(锚点.X - 8, 锚点.Y + 5),
					new Point(锚点.X - 8, 锚点.Y + 4),
					new Point(锚点.X - 8, 锚点.Y + 3),
					new Point(锚点.X - 8, 锚点.Y + 2),
					new Point(锚点.X - 8, 锚点.Y + 1),
					new Point(锚点.X - 8, 锚点.Y),
					new Point(锚点.X - 8, 锚点.Y - 1),
					new Point(锚点.X - 8, 锚点.Y - 2),
					new Point(锚点.X - 8, 锚点.Y - 3),
					new Point(锚点.X - 8, 锚点.Y - 4),
					new Point(锚点.X - 8, 锚点.Y - 5),
					new Point(锚点.X - 8, 锚点.Y - 6),
					new Point(锚点.X - 8, 锚点.Y - 7),
					new Point(锚点.X - 8, 锚点.Y - 8),
					new Point(锚点.X - 7, 锚点.Y - 8),
					new Point(锚点.X - 6, 锚点.Y - 8),
					new Point(锚点.X - 5, 锚点.Y - 8),
					new Point(锚点.X - 4, 锚点.Y - 8),
					new Point(锚点.X - 3, 锚点.Y - 8),
					new Point(锚点.X - 2, 锚点.Y - 8),
					new Point(锚点.X - 1, 锚点.Y - 8),
					new Point(锚点.X, 锚点.Y - 8),
					new Point(锚点.X + 1, 锚点.Y - 8),
					new Point(锚点.X + 2, 锚点.Y - 8),
					new Point(锚点.X + 3, 锚点.Y - 8),
					new Point(锚点.X + 4, 锚点.Y - 8),
					new Point(锚点.X + 5, 锚点.Y - 8),
					new Point(锚点.X + 6, 锚点.Y - 8),
					new Point(锚点.X + 7, 锚点.Y - 8),
					new Point(锚点.X + 8, 锚点.Y - 8),
					new Point(锚点.X + 8, 锚点.Y - 7),
					new Point(锚点.X + 8, 锚点.Y - 6),
					new Point(锚点.X + 8, 锚点.Y - 5),
					new Point(锚点.X + 8, 锚点.Y - 4),
					new Point(锚点.X + 8, 锚点.Y - 3),
					new Point(锚点.X + 8, 锚点.Y - 2),
					new Point(锚点.X + 8, 锚点.Y - 1),
					new Point(锚点.X + 8, 锚点.Y),
					new Point(锚点.X + 8, 锚点.Y + 1),
					new Point(锚点.X + 8, 锚点.Y + 2),
					new Point(锚点.X + 8, 锚点.Y + 3),
					new Point(锚点.X + 8, 锚点.Y + 4),
					new Point(锚点.X + 8, 锚点.Y + 5),
					new Point(锚点.X + 8, 锚点.Y + 6),
					new Point(锚点.X + 8, 锚点.Y + 7),
					new Point(锚点.X + 8, 锚点.Y + 8),
					new Point(锚点.X + 7, 锚点.Y + 8),
					new Point(锚点.X + 6, 锚点.Y + 8),
					new Point(锚点.X + 5, 锚点.Y + 8),
					new Point(锚点.X + 4, 锚点.Y + 8),
					new Point(锚点.X + 3, 锚点.Y + 8),
					new Point(锚点.X + 2, 锚点.Y + 8),
					new Point(锚点.X + 1, 锚点.Y + 8),
					new Point(锚点.X, 锚点.Y + 8),
					new Point(锚点.X - 1, 锚点.Y + 8),
					new Point(锚点.X - 2, 锚点.Y + 8),
					new Point(锚点.X - 3, 锚点.Y + 8),
					new Point(锚点.X - 4, 锚点.Y + 8),
					new Point(锚点.X - 5, 锚点.Y + 8),
					new Point(锚点.X - 6, 锚点.Y + 8),
					new Point(锚点.X - 7, 锚点.Y + 8),
					new Point(锚点.X - 8, 锚点.Y + 8)
				};
			case 技能范围类型.线型1x6:
				return new Point[]
				{
					锚点,
					ComputingClass.前方坐标(锚点, 方向, 1),
					ComputingClass.前方坐标(锚点, 方向, 2),
					ComputingClass.前方坐标(锚点, 方向, 3),
					ComputingClass.前方坐标(锚点, 方向, 4),
					ComputingClass.前方坐标(锚点, 方向, 5)
				};
			default:
				return new Point[0];
			}
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002AAD File Offset: 0x00000CAD
		static ComputingClass()
		{
			
			ComputingClass.系统相对时间 = Convert.ToDateTime("1970-01-01 08:00:00");
		}

		// Token: 0x04000034 RID: 52
		public static readonly DateTime 系统相对时间;
	}
}
