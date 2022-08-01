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
        public static void Config(Type connectionType)
        {
            GamePacket.EncryptionKey = 129;
            GamePacket.PacketMethods = new Dictionary<Type, MethodInfo>();

            #region Reader

            Dictionary<Type, Func<BinaryReader, WrappingFieldAttribute, object>> ReaderDictionary = new Dictionary<Type, Func<BinaryReader, WrappingFieldAttribute, object>>();
            
            ReaderDictionary[typeof(bool)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return Convert.ToBoolean(br.ReadByte());
            };

            ReaderDictionary[typeof(byte)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadByte();
            };
            
            ReaderDictionary[typeof(sbyte)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadSByte();
            };
            
            ReaderDictionary[typeof(byte[])] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                int num = (int)((wfa.Length != 0) ? wfa.Length : (br.ReadUInt16() - 4));
                if (num > 0)
                {
                    return br.ReadBytes(num);
                }
                return new byte[0];
            };
            
            ReaderDictionary[typeof(short)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadInt16();
            };
            
            ReaderDictionary[typeof(ushort)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadUInt16();
            };
            
            ReaderDictionary[typeof(int)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadInt32();
            };
            
            ReaderDictionary[typeof(uint)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                return br.ReadUInt32();
            };
            
            ReaderDictionary[typeof(string)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                byte[] bytes = br.ReadBytes((int)wfa.Length);
                return Encoding.UTF8.GetString(bytes).Split(new char[1], StringSplitOptions.RemoveEmptyEntries)[0];
            };
            
            ReaderDictionary[typeof(Point)] = delegate (BinaryReader br, WrappingFieldAttribute wfa)
            {
                br.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                Point point = new Point((int)br.ReadUInt16(), (int)br.ReadUInt16());
                return ComputingClass.协议坐标转点阵坐标(wfa.Reverse ? new Point(point.Y, point.X) : point);
            };
            GamePacket.TypeRead = ReaderDictionary;
            #endregion

            #region Writer

            Dictionary<Type, Action<BinaryWriter, WrappingFieldAttribute, object>> WriterDictionary = new Dictionary<Type, Action<BinaryWriter, WrappingFieldAttribute, object>>();
            
            WriterDictionary[typeof(bool)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((bool)obj);
            };
            
            WriterDictionary[typeof(byte)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((byte)obj);
            };
            
            WriterDictionary[typeof(sbyte)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((sbyte)obj);
            };
            
            WriterDictionary[typeof(byte[])] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write(obj as byte[]);
            };
            
            WriterDictionary[typeof(short)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((short)obj);
            };
            
            WriterDictionary[typeof(ushort)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((ushort)obj);
            };
            
            WriterDictionary[typeof(int)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((int)obj);
            };
            
            WriterDictionary[typeof(uint)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write((uint)obj);
            };
            
            WriterDictionary[typeof(string)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                string text3 = obj as string;
                if (text3 != null)
                {
                    bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                    bw.Write(Encoding.UTF8.GetBytes(text3));
                }
            };
            
            WriterDictionary[typeof(Point)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                Point point = ComputingClass.点阵坐标转协议坐标((Point)obj);
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                if (wfa.Reverse)
                {
                    bw.Write((ushort)point.Y);
                    bw.Write((ushort)point.X);
                    return;
                }
                bw.Write((ushort)point.X);
                bw.Write((ushort)point.Y);
            };
            
            WriterDictionary[typeof(DateTime)] = delegate (BinaryWriter bw, WrappingFieldAttribute wfa, object obj)
            {
                bw.BaseStream.Seek((long)((ulong)wfa.SubScript), SeekOrigin.Begin);
                bw.Write(ComputingClass.TimeShift((DateTime)obj));
            };
            GamePacket.TypeWrite = WriterDictionary;
            #endregion

            GamePacket.ServerPackets = new Dictionary<ushort, Type>();
            GamePacket.ServerPacketNumberTable = new Dictionary<Type, ushort>();
            GamePacket.ServerPacketLengthTable = new Dictionary<ushort, ushort>();
            GamePacket.ClientPackets = new Dictionary<ushort, Type>();
            GamePacket.ClientPacketNumberTable = new Dictionary<Type, ushort>();
            GamePacket.ClientPacketLengthTable = new Dictionary<ushort, ushort>();
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsSubclassOf(typeof(GamePacket)))
                {
                    PacketInfoAttribute customAttribute = type.GetCustomAttribute<PacketInfoAttribute>();
                    if (customAttribute != null)
                    {
                        if (customAttribute.来源 == PacketSource.Client)
                        {
                            GamePacket.ClientPackets[customAttribute.编号] = type;
                            GamePacket.ClientPacketNumberTable[type] = customAttribute.编号;
                            GamePacket.ClientPacketLengthTable[customAttribute.编号] = customAttribute.长度;
                            GamePacket.PacketMethods[type] = connectionType.GetMethod("处理封包", new Type[]
                            {
                                type
                            });
                        }
                        else
                        {
                            GamePacket.ServerPackets[customAttribute.编号] = type;
                            GamePacket.ServerPacketNumberTable[type] = customAttribute.编号;
                            GamePacket.ServerPacketLengthTable[customAttribute.编号] = customAttribute.长度;
                        }
                    }
                }
            }
            string text = "";
            foreach (KeyValuePair<ushort, Type> keyValuePair in GamePacket.ServerPackets)
            {
                text += string.Format("{0}\t{1}\t{2}\r\n", keyValuePair.Value.Name, keyValuePair.Key, GamePacket.ServerPacketLengthTable[keyValuePair.Key]);
            }
            string text2 = "";
            foreach (KeyValuePair<ushort, Type> keyValuePair2 in GamePacket.ClientPackets)
            {
                text2 += string.Format("{0}\t{1}\t{2}\r\n", keyValuePair2.Value.Name, keyValuePair2.Key, GamePacket.ClientPacketLengthTable[keyValuePair2.Key]);
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

            this.PacketType = base.GetType();
            this.PacketInfo = this.PacketType.GetCustomAttribute<PacketInfoAttribute>();

            if (this.PacketInfo.来源 == PacketSource.Server)
            {
                this.PacketID = GamePacket.ServerPacketNumberTable[this.PacketType];
                this.PacketLength = GamePacket.ServerPacketLengthTable[this.PacketID];
                return;
            }
            this.PacketID = GamePacket.ClientPacketNumberTable[this.PacketType];
            this.PacketLength = GamePacket.ClientPacketLengthTable[this.PacketID];
        }


        public byte[] 取字节()
        {
            byte[] result;
            using (MemoryStream memoryStream = (this.PacketLength == 0) ? new MemoryStream() : new MemoryStream(new byte[(int)this.PacketLength]))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    foreach (FieldInfo fieldInfo in this.PacketType.GetFields())
                    {
                        WrappingFieldAttribute customAttribute = fieldInfo.GetCustomAttribute<WrappingFieldAttribute>();
                        if (customAttribute != null)
                        {
                            Type fieldType = fieldInfo.FieldType;
                            object value = fieldInfo.GetValue(this);
                            Action<BinaryWriter, WrappingFieldAttribute, object> action;
                            if (GamePacket.TypeWrite.TryGetValue(fieldType, out action))
                            {
                                action(binaryWriter, customAttribute, value);
                            }
                        }
                    }
                    binaryWriter.Seek(0, SeekOrigin.Begin);
                    binaryWriter.Write(this.PacketID);
                    if (this.PacketLength == 0)
                    {
                        binaryWriter.Write((ushort)memoryStream.Length);
                    }
                    byte[] array = memoryStream.ToArray();
                    if (this.是否加密)
                    {
                        result = GamePacket.EncodeData(array);
                    }
                    else
                    {
                        result = array;
                    }
                }
            }
            return result;
        }


        private void 填封包(byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream))
                {
                    foreach (FieldInfo fieldInfo in this.PacketType.GetFields())
                    {
                        WrappingFieldAttribute customAttribute = fieldInfo.GetCustomAttribute<WrappingFieldAttribute>();
                        if (customAttribute != null)
                        {
                            Type fieldType = fieldInfo.FieldType;
                            Func<BinaryReader, WrappingFieldAttribute, object> func;
                            if (GamePacket.TypeRead.TryGetValue(fieldType, out func))
                            {
                                fieldInfo.SetValue(this, func(binaryReader, customAttribute));
                            }
                        }
                    }
                }
            }
        }


        public static GamePacket GetPacket(byte[] inData, out byte[] restOfBytes)
        {
            restOfBytes = inData;
            if (inData.Length < 2)
            {
                return null;
            }
            ushort packetID = BitConverter.ToUInt16(inData, 0);
            Type type;

            if (!ClientPackets.TryGetValue(packetID, out type))
            {
                throw new Exception(string.Format("封包组包失败! 封包编号:{0:X4}", packetID));
                return null;
            }
            ushort num2;
            if (!ClientPacketLengthTable.TryGetValue(packetID, out num2))
            {
                throw new Exception(string.Format("获取封包长度失败! 封包编号:{0:X4}", packetID));
                return null;
            }
            if (num2 == 0 && inData.Length < 4)
            {
                return null;
            }
            num2 = ((num2 == 0) ? BitConverter.ToUInt16(inData, 2) : num2);
            if (inData.Length < (int)num2)
            {
                return null;
            }
            GamePacket GamePacket = (GamePacket)Activator.CreateInstance(type);
            byte[] dataPacket = inData.Take((int)num2).ToArray<byte>();
            if (GamePacket.是否加密)
            {
                GamePacket.EncodeData(dataPacket);
            }
            GamePacket.填封包(dataPacket);
            restOfBytes = inData.Skip((int)num2).ToArray<byte>();
            return GamePacket;
        }


        public static byte[] EncodeData(byte[] data)
        {
            for (int i = 4; i < data.Length; i++)
            {
                data[i] ^= GamePacket.EncryptionKey;
            }
            return (byte[])data;
        }


        public static byte EncryptionKey;


        public static Dictionary<Type, MethodInfo> PacketMethods;


        public static Dictionary<ushort, Type> ServerPackets;


        public static Dictionary<ushort, Type> ClientPackets;


        public static Dictionary<Type, ushort> ServerPacketNumberTable;


        public static Dictionary<Type, ushort> ClientPacketNumberTable;


        public static Dictionary<ushort, ushort> ServerPacketLengthTable;


        public static Dictionary<ushort, ushort> ClientPacketLengthTable;


        public static Dictionary<Type, Func<BinaryReader, WrappingFieldAttribute, object>> TypeRead;


        public static Dictionary<Type, Action<BinaryWriter, WrappingFieldAttribute, object>> TypeWrite;


        public readonly Type PacketType;

        public readonly PacketInfoAttribute PacketInfo;

        private readonly ushort PacketID;


        private readonly ushort PacketLength;

        public override string ToString()
        {
            var fields = PacketType.GetFields(BindingFlags.Public);
            var validFieldTypes = new string[] { "string", "int", "uint", "ushort", "short" };

            var sb = new StringBuilder();

            sb.Append($"[{PacketType.Name}] {{");

            foreach (var field in fields)
            {
                if (validFieldTypes.Contains(field.FieldType.Name))
                    sb.Append($"{field.Name}:{field.GetValue(this)}");
            }

            sb.Append('}');

            return sb.ToString();
        }
    }
}
