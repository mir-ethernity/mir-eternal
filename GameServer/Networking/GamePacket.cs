using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GameServer.Networking
{
	
	public abstract class GamePacket
	{
		
		static GamePacket()
		{
			
			GamePacket.加密字节 = 129;
			GamePacket.封包处理方法表 = new Dictionary<Type, MethodInfo>();
			Dictionary<Type, Func<BinaryReader, WrappingFieldAttribute, object>> dictionary = new Dictionary<Type, Func<BinaryReader, WrappingFieldAttribute, object>>();
			Type typeFromHandle = typeof(bool);
			dictionary[typeFromHandle] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				return Convert.ToBoolean(读取流.ReadByte());
			};
			Type typeFromHandle2 = typeof(byte);
			dictionary[typeFromHandle2] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				return 读取流.ReadByte();
			};
			Type typeFromHandle3 = typeof(sbyte);
			dictionary[typeFromHandle3] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				return 读取流.ReadSByte();
			};
			Type typeFromHandle4 = typeof(byte[]);
			dictionary[typeFromHandle4] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				int num = (int)((描述符.长度 != 0) ? 描述符.长度 : (读取流.ReadUInt16() - 4));
				if (num > 0)
				{
					return 读取流.ReadBytes(num);
				}
				return new byte[0];
			};
			Type typeFromHandle5 = typeof(short);
			dictionary[typeFromHandle5] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				return 读取流.ReadInt16();
			};
			Type typeFromHandle6 = typeof(ushort);
			dictionary[typeFromHandle6] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				return 读取流.ReadUInt16();
			};
			Type typeFromHandle7 = typeof(int);
			dictionary[typeFromHandle7] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				return 读取流.ReadInt32();
			};
			Type typeFromHandle8 = typeof(uint);
			dictionary[typeFromHandle8] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				return 读取流.ReadUInt32();
			};
			Type typeFromHandle9 = typeof(string);
			dictionary[typeFromHandle9] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				byte[] bytes = 读取流.ReadBytes((int)描述符.长度);
				return Encoding.UTF8.GetString(bytes).Split(new char[1], StringSplitOptions.RemoveEmptyEntries)[0];
			};
			Type typeFromHandle10 = typeof(Point);
			dictionary[typeFromHandle10] = delegate(BinaryReader 读取流, WrappingFieldAttribute 描述符)
			{
				读取流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				Point point = new Point((int)读取流.ReadUInt16(), (int)读取流.ReadUInt16());
				return ComputingClass.协议坐标转点阵坐标(描述符.反向 ? new Point(point.Y, point.X) : point);
			};
			GamePacket.封包字段读取表 = dictionary;
			Dictionary<Type, Action<BinaryWriter, WrappingFieldAttribute, object>> dictionary2 = new Dictionary<Type, Action<BinaryWriter, WrappingFieldAttribute, object>>();
			typeFromHandle10 = typeof(bool);
			dictionary2[typeFromHandle10] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				写入流.Write((bool)对象);
			};
			typeFromHandle9 = typeof(byte);
			dictionary2[typeFromHandle9] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				写入流.Write((byte)对象);
			};
			typeFromHandle8 = typeof(sbyte);
			dictionary2[typeFromHandle8] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				写入流.Write((sbyte)对象);
			};
			typeFromHandle7 = typeof(byte[]);
			dictionary2[typeFromHandle7] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				写入流.Write(对象 as byte[]);
			};
			typeFromHandle6 = typeof(short);
			dictionary2[typeFromHandle6] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				写入流.Write((short)对象);
			};
			typeFromHandle5 = typeof(ushort);
			dictionary2[typeFromHandle5] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				写入流.Write((ushort)对象);
			};
			typeFromHandle4 = typeof(int);
			dictionary2[typeFromHandle4] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				写入流.Write((int)对象);
			};
			typeFromHandle3 = typeof(uint);
			dictionary2[typeFromHandle3] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				写入流.Write((uint)对象);
			};
			typeFromHandle2 = typeof(string);
			dictionary2[typeFromHandle2] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				string text3 = 对象 as string;
				if (text3 != null)
				{
					写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
					写入流.Write(Encoding.UTF8.GetBytes(text3));
				}
			};
			typeFromHandle = typeof(Point);
			dictionary2[typeFromHandle] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				Point point = ComputingClass.点阵坐标转协议坐标((Point)对象);
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				if (描述符.反向)
				{
					写入流.Write((ushort)point.Y);
					写入流.Write((ushort)point.X);
					return;
				}
				写入流.Write((ushort)point.X);
				写入流.Write((ushort)point.Y);
			};
			Type typeFromHandle11 = typeof(DateTime);
			dictionary2[typeFromHandle11] = delegate(BinaryWriter 写入流, WrappingFieldAttribute 描述符, object 对象)
			{
				写入流.BaseStream.Seek((long)((ulong)描述符.下标), SeekOrigin.Begin);
				写入流.Write(ComputingClass.时间转换((DateTime)对象));
			};
			GamePacket.封包字段写入表 = dictionary2;
			GamePacket.服务器封包类型表 = new Dictionary<ushort, Type>();
			GamePacket.服务器封包编号表 = new Dictionary<Type, ushort>();
			GamePacket.服务器封包长度表 = new Dictionary<ushort, ushort>();
			GamePacket.客户端封包类型表 = new Dictionary<ushort, Type>();
			GamePacket.客户端封包编号表 = new Dictionary<Type, ushort>();
			GamePacket.客户端封包长度表 = new Dictionary<ushort, ushort>();
			foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.IsSubclassOf(typeof(GamePacket)))
				{
					PacketInfoAttribute customAttribute = type.GetCustomAttribute<PacketInfoAttribute>();
					if (customAttribute != null)
					{
						if (customAttribute.来源 == PacketSource.客户端)
						{
							GamePacket.客户端封包类型表[customAttribute.编号] = type;
							GamePacket.客户端封包编号表[type] = customAttribute.编号;
							GamePacket.客户端封包长度表[customAttribute.编号] = customAttribute.长度;
							GamePacket.封包处理方法表[type] = typeof(客户网络).GetMethod("处理封包", new Type[]
							{
								type
							});
						}
						else
						{
							GamePacket.服务器封包类型表[customAttribute.编号] = type;
							GamePacket.服务器封包编号表[type] = customAttribute.编号;
							GamePacket.服务器封包长度表[customAttribute.编号] = customAttribute.长度;
						}
					}
				}
			}
			string text = "";
			foreach (KeyValuePair<ushort, Type> keyValuePair in GamePacket.服务器封包类型表)
			{
				text += string.Format("{0}\t{1}\t{2}\r\n", keyValuePair.Value.Name, keyValuePair.Key, GamePacket.服务器封包长度表[keyValuePair.Key]);
			}
			string text2 = "";
			foreach (KeyValuePair<ushort, Type> keyValuePair2 in GamePacket.客户端封包类型表)
			{
				text2 += string.Format("{0}\t{1}\t{2}\r\n", keyValuePair2.Value.Name, keyValuePair2.Key, GamePacket.客户端封包长度表[keyValuePair2.Key]);
			}
			File.WriteAllText("./ServerPackRule.txt", text);
			File.WriteAllText("./ClientPackRule.txt", text2);
		}

		
		// (get) Token: 0x06000338 RID: 824 RVA: 0x0000357A File Offset: 0x0000177A
		// (set) Token: 0x06000339 RID: 825 RVA: 0x00003582 File Offset: 0x00001782
		public virtual bool 是否加密 { get; set; }

		
		public GamePacket()
		{
			
			this.是否加密 = true;
			
			this.封包类型 = base.GetType();
			if (this.封包类型.GetCustomAttribute<PacketInfoAttribute>().来源 == PacketSource.服务器)
			{
				this.封包编号 = GamePacket.服务器封包编号表[this.封包类型];
				this.封包长度 = GamePacket.服务器封包长度表[this.封包编号];
				return;
			}
			this.封包编号 = GamePacket.客户端封包编号表[this.封包类型];
			this.封包长度 = GamePacket.客户端封包长度表[this.封包编号];
		}

		
		public byte[] 取字节()
		{
			byte[] result;
			using (MemoryStream memoryStream = (this.封包长度 == 0) ? new MemoryStream() : new MemoryStream(new byte[(int)this.封包长度]))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					foreach (FieldInfo fieldInfo in this.封包类型.GetFields())
					{
						WrappingFieldAttribute customAttribute = fieldInfo.GetCustomAttribute<WrappingFieldAttribute>();
						if (customAttribute != null)
						{
							Type fieldType = fieldInfo.FieldType;
							object value = fieldInfo.GetValue(this);
							Action<BinaryWriter, WrappingFieldAttribute, object> action;
							if (GamePacket.封包字段写入表.TryGetValue(fieldType, out action))
							{
								action(binaryWriter, customAttribute, value);
							}
						}
					}
					binaryWriter.Seek(0, SeekOrigin.Begin);
					binaryWriter.Write(this.封包编号);
					if (this.封包长度 == 0)
					{
						binaryWriter.Write((ushort)memoryStream.Length);
					}
					byte[] array = memoryStream.ToArray();
					if (this.是否加密)
					{
						result = GamePacket.加解密(array);
					}
					else
					{
						result = array;
					}
				}
			}
			return result;
		}

		
		private void 填封包(byte[] 原始数据)
		{
			using (MemoryStream memoryStream = new MemoryStream(原始数据))
			{
				using (BinaryReader binaryReader = new BinaryReader(memoryStream))
				{
					foreach (FieldInfo fieldInfo in this.封包类型.GetFields())
					{
						WrappingFieldAttribute customAttribute = fieldInfo.GetCustomAttribute<WrappingFieldAttribute>();
						if (customAttribute != null)
						{
							Type fieldType = fieldInfo.FieldType;
							Func<BinaryReader, WrappingFieldAttribute, object> func;
							if (GamePacket.封包字段读取表.TryGetValue(fieldType, out func))
							{
								fieldInfo.SetValue(this, func(binaryReader, customAttribute));
							}
						}
					}
				}
			}
		}

		
		public static GamePacket 取封包(客户网络 网络连接, byte[] 原始数据, out byte[] 剩余数据)
		{
			剩余数据 = 原始数据;
			if (原始数据.Length < 2)
			{
				return null;
			}
			ushort num = BitConverter.ToUInt16(原始数据, 0);
			Type type;
			
			if (!客户端封包类型表.TryGetValue(num, out type))
			{
				网络连接.尝试断开连接(new Exception(string.Format("封包组包失败! 封包编号:{0:X4}", num)));
				return null;
			}
			ushort num2;
			if (!客户端封包长度表.TryGetValue(num, out num2))
			{
				网络连接.尝试断开连接(new Exception(string.Format("获取封包长度失败! 封包编号:{0:X4}", num)));
				return null;
			}
			if (num2 == 0 && 原始数据.Length < 4)
			{
				return null;
			}
			num2 = ((num2 == 0) ? BitConverter.ToUInt16(原始数据, 2) : num2);
			if (原始数据.Length < (int)num2)
			{
				return null;
			}
			GamePacket GamePacket = (GamePacket)Activator.CreateInstance(type);
			byte[] 原始数据2 = 原始数据.Take((int)num2).ToArray<byte>();
			if (GamePacket.是否加密)
			{
				GamePacket.加解密(原始数据2);
			}
			GamePacket.填封包(原始数据2);
			剩余数据 = 原始数据.Skip((int)num2).ToArray<byte>();
			return GamePacket;
		}

		
		private static byte[] 加解密(byte[] 原始数据)
		{
			for (int i = 4; i < 原始数据.Length; i++)
			{
				原始数据[i] ^= GamePacket.加密字节;
			}
			return (byte[])原始数据;
		}

		
		public static byte 加密字节;

		
		public static Dictionary<Type, MethodInfo> 封包处理方法表;

		
		public static Dictionary<ushort, Type> 服务器封包类型表;

		
		public static Dictionary<ushort, Type> 客户端封包类型表;

		
		public static Dictionary<Type, ushort> 服务器封包编号表;

		
		public static Dictionary<Type, ushort> 客户端封包编号表;

		
		public static Dictionary<ushort, ushort> 服务器封包长度表;

		
		public static Dictionary<ushort, ushort> 客户端封包长度表;

		
		public static Dictionary<Type, Func<BinaryReader, WrappingFieldAttribute, object>> 封包字段读取表;

		
		public static Dictionary<Type, Action<BinaryWriter, WrappingFieldAttribute, object>> 封包字段写入表;

		
		public readonly Type 封包类型;

		
		private readonly ushort 封包编号;

		
		private readonly ushort 封包长度;
	}
}
