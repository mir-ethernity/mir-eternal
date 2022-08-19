using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using GameServer.Templates;

namespace GameServer.Data
{
	
	public sealed class DataField
	{
		
		static DataField()
		{
			
			Dictionary<Type, Func<BinaryReader, GameData, DataField, object>> dictionary = new Dictionary<Type, Func<BinaryReader, GameData, DataField, object>>();
			Type typeFromHandle = typeof(DataMonitor<int>);
			dictionary[typeFromHandle] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<int> DataMonitor = new DataMonitor<int>(o);
				DataMonitor.QuietlySetValue(r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle2 = typeof(DataMonitor<uint>);
			dictionary[typeFromHandle2] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<uint> DataMonitor = new DataMonitor<uint>(o);
				DataMonitor.QuietlySetValue(r.ReadUInt32());
				return DataMonitor;
			};
			Type typeFromHandle3 = typeof(DataMonitor<long>);
			dictionary[typeFromHandle3] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<long> DataMonitor = new DataMonitor<long>(o);
				DataMonitor.QuietlySetValue(r.ReadInt64());
				return DataMonitor;
			};
			Type typeFromHandle4 = typeof(DataMonitor<bool>);
			dictionary[typeFromHandle4] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<bool> DataMonitor = new DataMonitor<bool>(o);
				DataMonitor.QuietlySetValue(r.ReadBoolean());
				return DataMonitor;
			};
			Type typeFromHandle5 = typeof(DataMonitor<byte>);
			dictionary[typeFromHandle5] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<byte> DataMonitor = new DataMonitor<byte>(o);
				DataMonitor.QuietlySetValue(r.ReadByte());
				return DataMonitor;
			};
			Type typeFromHandle6 = typeof(DataMonitor<sbyte>);
			dictionary[typeFromHandle6] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<sbyte> DataMonitor = new DataMonitor<sbyte>(o);
				DataMonitor.QuietlySetValue(r.ReadSByte());
				return DataMonitor;
			};
			Type typeFromHandle7 = typeof(DataMonitor<string>);
			dictionary[typeFromHandle7] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<string> DataMonitor = new DataMonitor<string>(o);
				DataMonitor.QuietlySetValue(r.ReadString());
				return DataMonitor;
			};
			Type typeFromHandle8 = typeof(DataMonitor<ushort>);
			dictionary[typeFromHandle8] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<ushort> DataMonitor = new DataMonitor<ushort>(o);
				DataMonitor.QuietlySetValue(r.ReadUInt16());
				return DataMonitor;
			};
			Type typeFromHandle9 = typeof(DataMonitor<Point>);
			dictionary[typeFromHandle9] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<Point> DataMonitor = new DataMonitor<Point>(o);
				DataMonitor.QuietlySetValue(new Point(r.ReadInt32(), r.ReadInt32()));
				return DataMonitor;
			};
			Type typeFromHandle10 = typeof(DataMonitor<TimeSpan>);
			dictionary[typeFromHandle10] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<TimeSpan> DataMonitor = new DataMonitor<TimeSpan>(o);
				DataMonitor.QuietlySetValue(TimeSpan.FromTicks(r.ReadInt64()));
				return DataMonitor;
			};
			Type typeFromHandle11 = typeof(DataMonitor<DateTime>);
			dictionary[typeFromHandle11] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<DateTime> DataMonitor = new DataMonitor<DateTime>(o);
				DataMonitor.QuietlySetValue(DateTime.FromBinary(r.ReadInt64()));
				return DataMonitor;
			};
			Type typeFromHandle12 = typeof(DataMonitor<RandomStats>);
			dictionary[typeFromHandle12] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<RandomStats> DataMonitor = new DataMonitor<RandomStats>(o);
				RandomStats 随机Stat;
				DataMonitor.QuietlySetValue(RandomStats.DataSheet.TryGetValue(r.ReadInt32(), out 随机Stat) ? 随机Stat : null);
				return DataMonitor;
			};
			Type typeFromHandle13 = typeof(DataMonitor<InscriptionSkill>);
			dictionary[typeFromHandle13] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<InscriptionSkill> DataMonitor = new DataMonitor<InscriptionSkill>(o);
				InscriptionSkill 铭文技能;
				DataMonitor.QuietlySetValue(InscriptionSkill.DataSheet.TryGetValue(r.ReadUInt16(), out 铭文技能) ? 铭文技能 : null);
				return DataMonitor;
			};
			Type typeFromHandle14 = typeof(DataMonitor<GameItems>);
			dictionary[typeFromHandle14] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<GameItems> DataMonitor = new DataMonitor<GameItems>(o);
				GameItems 游戏物品;
				DataMonitor.QuietlySetValue(GameItems.DataSheet.TryGetValue(r.ReadInt32(), out 游戏物品) ? 游戏物品 : null);
				return DataMonitor;
			};
			Type typeFromHandle15 = typeof(DataMonitor<PetMode>);
			dictionary[typeFromHandle15] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<PetMode> DataMonitor = new DataMonitor<PetMode>(o);
				DataMonitor.QuietlySetValue((PetMode)r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle16 = typeof(DataMonitor<AttackMode>);
			dictionary[typeFromHandle16] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<AttackMode> DataMonitor = new DataMonitor<AttackMode>(o);
				DataMonitor.QuietlySetValue((AttackMode)r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle17 = typeof(DataMonitor<GameDirection>);
			dictionary[typeFromHandle17] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<GameDirection> DataMonitor = new DataMonitor<GameDirection>(o);
				DataMonitor.QuietlySetValue((GameDirection)r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle18 = typeof(DataMonitor<ObjectHairType>);
			dictionary[typeFromHandle18] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<ObjectHairType> DataMonitor = new DataMonitor<ObjectHairType>(o);
				DataMonitor.QuietlySetValue((ObjectHairType)r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle19 = typeof(DataMonitor<ObjectHairColorType>);
			dictionary[typeFromHandle19] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<ObjectHairColorType> DataMonitor = new DataMonitor<ObjectHairColorType>(o);
				DataMonitor.QuietlySetValue((ObjectHairColorType)r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle20 = typeof(DataMonitor<ObjectFaceType>);
			dictionary[typeFromHandle20] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<ObjectFaceType> DataMonitor = new DataMonitor<ObjectFaceType>(o);
				DataMonitor.QuietlySetValue((ObjectFaceType)r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle21 = typeof(DataMonitor<GameObjectGender>);
			dictionary[typeFromHandle21] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<GameObjectGender> DataMonitor = new DataMonitor<GameObjectGender>(o);
				DataMonitor.QuietlySetValue((GameObjectGender)r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle22 = typeof(DataMonitor<GameObjectRace>);
			dictionary[typeFromHandle22] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<GameObjectRace> DataMonitor = new DataMonitor<GameObjectRace>(o);
				DataMonitor.QuietlySetValue((GameObjectRace)r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle23 = typeof(DataMonitor<TeacherData>);
			dictionary[typeFromHandle23] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<TeacherData> DataMonitor = new DataMonitor<TeacherData>(o);
				DataLinkTable.添加任务(o, f, DataMonitor, typeof(TeacherData), r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle24 = typeof(DataMonitor<GuildData>);
			dictionary[typeFromHandle24] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<GuildData> DataMonitor = new DataMonitor<GuildData>(o);
				DataLinkTable.添加任务(o, f, DataMonitor, typeof(GuildData), r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle25 = typeof(DataMonitor<TeamData>);
			dictionary[typeFromHandle25] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<TeamData> DataMonitor = new DataMonitor<TeamData>(o);
				DataLinkTable.添加任务(o, f, DataMonitor, typeof(TeamData), r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle26 = typeof(DataMonitor<BuffData>);
			dictionary[typeFromHandle26] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<BuffData> DataMonitor = new DataMonitor<BuffData>(o);
				DataLinkTable.添加任务(o, f, DataMonitor, typeof(BuffData), r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle27 = typeof(DataMonitor<MailData>);
			dictionary[typeFromHandle27] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<MailData> DataMonitor = new DataMonitor<MailData>(o);
				DataLinkTable.添加任务(o, f, DataMonitor, typeof(MailData), r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle28 = typeof(DataMonitor<AccountData>);
			dictionary[typeFromHandle28] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<AccountData> DataMonitor = new DataMonitor<AccountData>(o);
				DataLinkTable.添加任务(o, f, DataMonitor, typeof(AccountData), r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle29 = typeof(DataMonitor<CharacterData>);
			dictionary[typeFromHandle29] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<CharacterData> DataMonitor = new DataMonitor<CharacterData>(o);
				DataLinkTable.添加任务(o, f, DataMonitor, typeof(CharacterData), r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle30 = typeof(DataMonitor<EquipmentData>);
			dictionary[typeFromHandle30] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<EquipmentData> DataMonitor = new DataMonitor<EquipmentData>(o);
				DataLinkTable.添加任务(o, f, DataMonitor, typeof(EquipmentData), r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle31 = typeof(DataMonitor<ItemData>);
			dictionary[typeFromHandle31] = delegate(BinaryReader r, GameData o, DataField f)
			{
				DataMonitor<ItemData> DataMonitor = new DataMonitor<ItemData>(o);
				DataLinkTable.添加任务(o, f, DataMonitor, r.ReadBoolean() ? typeof(EquipmentData) : typeof(ItemData), r.ReadInt32());
				return DataMonitor;
			};
			Type typeFromHandle32 = typeof(ListMonitor<int>);
			dictionary[typeFromHandle32] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<int> ListMonitor = new ListMonitor<int>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					ListMonitor.QuietlyAdd(r.ReadInt32());
				}
				return ListMonitor;
			};
			Type typeFromHandle33 = typeof(ListMonitor<uint>);
			dictionary[typeFromHandle33] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<uint> ListMonitor = new ListMonitor<uint>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					ListMonitor.QuietlyAdd(r.ReadUInt32());
				}
				return ListMonitor;
			};
			Type typeFromHandle34 = typeof(ListMonitor<bool>);
			dictionary[typeFromHandle34] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<bool> ListMonitor = new ListMonitor<bool>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					ListMonitor.QuietlyAdd(r.ReadBoolean());
				}
				return ListMonitor;
			};
			Type typeFromHandle35 = typeof(ListMonitor<byte>);
			dictionary[typeFromHandle35] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<byte> ListMonitor = new ListMonitor<byte>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					ListMonitor.QuietlyAdd(r.ReadByte());
				}
				return ListMonitor;
			};
			Type typeFromHandle36 = typeof(ListMonitor<CharacterData>);
			dictionary[typeFromHandle36] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<CharacterData> ListMonitor = new ListMonitor<CharacterData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					DataLinkTable.添加任务(o, f, ListMonitor.IList, typeof(CharacterData), r.ReadInt32());
				}
				return ListMonitor;
			};
			Type typeFromHandle37 = typeof(ListMonitor<PetData>);
			dictionary[typeFromHandle37] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<PetData> ListMonitor = new ListMonitor<PetData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					DataLinkTable.添加任务(o, f, ListMonitor.IList, typeof(PetData), r.ReadInt32());
				}
				return ListMonitor;
			};
			Type typeFromHandle38 = typeof(ListMonitor<GuildData>);
			dictionary[typeFromHandle38] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<GuildData> ListMonitor = new ListMonitor<GuildData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					DataLinkTable.添加任务(o, f, ListMonitor.IList, typeof(GuildData), r.ReadInt32());
				}
				return ListMonitor;
			};
			Type typeFromHandle39 = typeof(ListMonitor<GuildEvents>);
			dictionary[typeFromHandle39] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<GuildEvents> ListMonitor = new ListMonitor<GuildEvents>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					ListMonitor.QuietlyAdd(new GuildEvents
					{
						MemorandumType = (MemorandumType)r.ReadByte(),
						第一参数 = r.ReadInt32(),
						第二参数 = r.ReadInt32(),
						第三参数 = r.ReadInt32(),
						第四参数 = r.ReadInt32(),
						事记时间 = r.ReadInt32()
					});
				}
				return ListMonitor;
			};
			Type typeFromHandle40 = typeof(ListMonitor<RandomStats>);
			dictionary[typeFromHandle40] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<RandomStats> ListMonitor = new ListMonitor<RandomStats>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					RandomStats tv;
					if (RandomStats.DataSheet.TryGetValue(r.ReadInt32(), out tv))
					{
						ListMonitor.QuietlyAdd(tv);
					}
				}
				return ListMonitor;
			};
			Type typeFromHandle41 = typeof(ListMonitor<EquipHoleColor>);
			dictionary[typeFromHandle41] = delegate(BinaryReader r, GameData o, DataField f)
			{
				ListMonitor<EquipHoleColor> ListMonitor = new ListMonitor<EquipHoleColor>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					ListMonitor.QuietlyAdd((EquipHoleColor)r.ReadInt32());
				}
				return ListMonitor;
			};
			Type typeFromHandle42 = typeof(HashMonitor<PetData>);
			dictionary[typeFromHandle42] = delegate(BinaryReader r, GameData o, DataField f)
			{
				HashMonitor<PetData> HashMonitor = new HashMonitor<PetData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					DataLinkTable.添加任务<PetData>(o, f, HashMonitor.ISet, r.ReadInt32());
				}
				return HashMonitor;
			};
			Type typeFromHandle43 = typeof(HashMonitor<CharacterData>);
			dictionary[typeFromHandle43] = delegate(BinaryReader r, GameData o, DataField f)
			{
				HashMonitor<CharacterData> HashMonitor = new HashMonitor<CharacterData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					DataLinkTable.添加任务<CharacterData>(o, f, HashMonitor.ISet, r.ReadInt32());
				}
				return HashMonitor;
			};
			Type typeFromHandle44 = typeof(HashMonitor<MailData>);
			dictionary[typeFromHandle44] = delegate(BinaryReader r, GameData o, DataField f)
			{
				HashMonitor<MailData> HashMonitor = new HashMonitor<MailData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					DataLinkTable.添加任务<MailData>(o, f, HashMonitor.ISet, r.ReadInt32());
				}
				return HashMonitor;
			};
			Type typeFromHandle45 = typeof(MonitorDictionary<byte, int>);
			dictionary[typeFromHandle45] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<byte, int> MonitorDictionary = new MonitorDictionary<byte, int>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte key = r.ReadByte();
					int value = r.ReadInt32();
					MonitorDictionary.QuietlyAdd(key, value);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle46 = typeof(MonitorDictionary<int, int>);
			dictionary[typeFromHandle46] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<int, int> MonitorDictionary = new MonitorDictionary<int, int>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					int key = r.ReadInt32();
					int value = r.ReadInt32();
					MonitorDictionary.QuietlyAdd(key, value);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle47 = typeof(MonitorDictionary<int, DateTime>);
			dictionary[typeFromHandle47] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<int, DateTime> MonitorDictionary = new MonitorDictionary<int, DateTime>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					int key = r.ReadInt32();
					long dateData = r.ReadInt64();
					MonitorDictionary.QuietlyAdd(key, DateTime.FromBinary(dateData));
				}
				return MonitorDictionary;
			};
			Type typeFromHandle48 = typeof(MonitorDictionary<byte, DateTime>);
			dictionary[typeFromHandle48] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<byte, DateTime> MonitorDictionary = new MonitorDictionary<byte, DateTime>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte key = r.ReadByte();
					long dateData = r.ReadInt64();
					MonitorDictionary.QuietlyAdd(key, DateTime.FromBinary(dateData));
				}
				return MonitorDictionary;
			};
			Type typeFromHandle49 = typeof(MonitorDictionary<string, DateTime>);
			dictionary[typeFromHandle49] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<string, DateTime> MonitorDictionary = new MonitorDictionary<string, DateTime>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					string key = r.ReadString();
					long dateData = r.ReadInt64();
					MonitorDictionary.QuietlyAdd(key, DateTime.FromBinary(dateData));
				}
				return MonitorDictionary;
			};
			Type typeFromHandle50 = typeof(MonitorDictionary<byte, GameItems>);
			dictionary[typeFromHandle50] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<byte, GameItems> MonitorDictionary = new MonitorDictionary<byte, GameItems>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte key = r.ReadByte();
					int key2 = r.ReadInt32();
					GameItems value;
					if (GameItems.DataSheet.TryGetValue(key2, out value))
					{
						MonitorDictionary.QuietlyAdd(key, value);
					}
				}
				return MonitorDictionary;
			};
			Type typeFromHandle51 = typeof(MonitorDictionary<byte, InscriptionSkill>);
			dictionary[typeFromHandle51] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<byte, InscriptionSkill> MonitorDictionary = new MonitorDictionary<byte, InscriptionSkill>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte key = r.ReadByte();
					ushort key2 = r.ReadUInt16();
					InscriptionSkill value;
					if (InscriptionSkill.DataSheet.TryGetValue(key2, out value))
					{
						MonitorDictionary.QuietlyAdd(key, value);
					}
				}
				return MonitorDictionary;
			};
			Type typeFromHandle52 = typeof(MonitorDictionary<ushort, BuffData>);
			dictionary[typeFromHandle52] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<ushort, BuffData> MonitorDictionary = new MonitorDictionary<ushort, BuffData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					ushort num2 = r.ReadUInt16();
					int 值索引 = r.ReadInt32();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, num2, null, typeof(ushort), typeof(BuffData), 0, 值索引);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle53 = typeof(MonitorDictionary<ushort, SkillData>);
			dictionary[typeFromHandle53] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<ushort, SkillData> MonitorDictionary = new MonitorDictionary<ushort, SkillData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					ushort num2 = r.ReadUInt16();
					int 值索引 = r.ReadInt32();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, num2, null, typeof(ushort), typeof(SkillData), 0, 值索引);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle54 = typeof(MonitorDictionary<byte, SkillData>);
			dictionary[typeFromHandle54] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<byte, SkillData> MonitorDictionary = new MonitorDictionary<byte, SkillData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte b = r.ReadByte();
					int 值索引 = r.ReadInt32();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, b, null, typeof(byte), typeof(SkillData), 0, 值索引);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle55 = typeof(MonitorDictionary<byte, EquipmentData>);
			dictionary[typeFromHandle55] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<byte, EquipmentData> MonitorDictionary = new MonitorDictionary<byte, EquipmentData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte b = r.ReadByte();
					int 值索引 = r.ReadInt32();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, b, null, typeof(byte), typeof(EquipmentData), 0, 值索引);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle56 = typeof(MonitorDictionary<byte, ItemData>);
			dictionary[typeFromHandle56] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<byte, ItemData> MonitorDictionary = new MonitorDictionary<byte, ItemData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					byte b = r.ReadByte();
					bool flag = r.ReadBoolean();
					int 值索引 = r.ReadInt32();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, b, null, typeof(byte), flag ? typeof(EquipmentData) : typeof(ItemData), 0, 值索引);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle57 = typeof(MonitorDictionary<int, CharacterData>);
			dictionary[typeFromHandle57] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<int, CharacterData> MonitorDictionary = new MonitorDictionary<int, CharacterData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					int num2 = r.ReadInt32();
					int 值索引 = r.ReadInt32();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, num2, null, typeof(int), typeof(CharacterData), 0, 值索引);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle58 = typeof(MonitorDictionary<int, MailData>);
			dictionary[typeFromHandle58] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<int, MailData> MonitorDictionary = new MonitorDictionary<int, MailData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					int num2 = r.ReadInt32();
					int 值索引 = r.ReadInt32();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, num2, null, typeof(int), typeof(MailData), 0, 值索引);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle59 = typeof(MonitorDictionary<GameCurrency, int>);
			dictionary[typeFromHandle59] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<GameCurrency, int> MonitorDictionary = new MonitorDictionary<GameCurrency, int>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					int key = r.ReadInt32();
					int value = r.ReadInt32();
					MonitorDictionary.QuietlyAdd((GameCurrency)key, value);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle60 = typeof(MonitorDictionary<GuildData, DateTime>);
			dictionary[typeFromHandle60] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<GuildData, DateTime> MonitorDictionary = new MonitorDictionary<GuildData, DateTime>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					int 键索引 = r.ReadInt32();
					long dateData = r.ReadInt64();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, null, DateTime.FromBinary(dateData), typeof(GuildData), typeof(DateTime), 键索引, 0);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle61 = typeof(MonitorDictionary<CharacterData, DateTime>);
			dictionary[typeFromHandle61] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<CharacterData, DateTime> MonitorDictionary = new MonitorDictionary<CharacterData, DateTime>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					int 键索引 = r.ReadInt32();
					long dateData = r.ReadInt64();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, null, DateTime.FromBinary(dateData), typeof(CharacterData), typeof(DateTime), 键索引, 0);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle62 = typeof(MonitorDictionary<CharacterData, GuildJobs>);
			dictionary[typeFromHandle62] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<CharacterData, GuildJobs> MonitorDictionary = new MonitorDictionary<CharacterData, GuildJobs>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					int 键索引 = r.ReadInt32();
					int num2 = r.ReadInt32();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, null, (GuildJobs)num2, typeof(CharacterData), typeof(GuildJobs), 键索引, 0);
				}
				return MonitorDictionary;
			};
			Type typeFromHandle63 = typeof(MonitorDictionary<DateTime, GuildData>);
			dictionary[typeFromHandle63] = delegate(BinaryReader r, GameData o, DataField f)
			{
				MonitorDictionary<DateTime, GuildData> MonitorDictionary = new MonitorDictionary<DateTime, GuildData>(o);
				int num = r.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					long dateData = r.ReadInt64();
					int 值索引 = r.ReadInt32();
					DataLinkTable.添加任务(o, f, MonitorDictionary.IDictionary_0, DateTime.FromBinary(dateData), null, typeof(DateTime), typeof(GuildData), 0, 值索引);
				}
				return MonitorDictionary;
			};
			DataField.字段读取方法表 = dictionary;
			Dictionary<Type, Action<BinaryWriter, object>> dictionary2 = new Dictionary<Type, Action<BinaryWriter, object>>();
			typeFromHandle63 = typeof(DataMonitor<int>);
			dictionary2[typeFromHandle63] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<int>)o).V);
			};
			typeFromHandle62 = typeof(DataMonitor<uint>);
			dictionary2[typeFromHandle62] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<uint>)o).V);
			};
			typeFromHandle61 = typeof(DataMonitor<long>);
			dictionary2[typeFromHandle61] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<long>)o).V);
			};
			typeFromHandle60 = typeof(DataMonitor<bool>);
			dictionary2[typeFromHandle60] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<bool>)o).V);
			};
			typeFromHandle59 = typeof(DataMonitor<byte>);
			dictionary2[typeFromHandle59] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<byte>)o).V);
			};
			typeFromHandle58 = typeof(DataMonitor<sbyte>);
			dictionary2[typeFromHandle58] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<sbyte>)o).V);
			};
			typeFromHandle57 = typeof(DataMonitor<string>);
			dictionary2[typeFromHandle57] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<string>)o).V ?? "");
			};
			typeFromHandle56 = typeof(DataMonitor<ushort>);
			dictionary2[typeFromHandle56] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<ushort>)o).V);
			};
			typeFromHandle55 = typeof(DataMonitor<Point>);
			dictionary2[typeFromHandle55] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<Point>)o).V.X);
				b.Write(((DataMonitor<Point>)o).V.Y);
			};
			typeFromHandle54 = typeof(DataMonitor<TimeSpan>);
			dictionary2[typeFromHandle54] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<TimeSpan>)o).V.Ticks);
			};
			typeFromHandle53 = typeof(DataMonitor<DateTime>);
			dictionary2[typeFromHandle53] = delegate(BinaryWriter b, object o)
			{
				b.Write(((DataMonitor<DateTime>)o).V.ToBinary());
			};
			typeFromHandle52 = typeof(DataMonitor<RandomStats>);
			dictionary2[typeFromHandle52] = delegate(BinaryWriter b, object o)
			{
				RandomStats v = ((DataMonitor<RandomStats>)o).V;
				b.Write((v != null) ? v.StatId : 0);
			};
			typeFromHandle51 = typeof(DataMonitor<InscriptionSkill>);
			dictionary2[typeFromHandle51] = delegate(BinaryWriter b, object o)
			{
				InscriptionSkill v = ((DataMonitor<InscriptionSkill>)o).V;
				b.Write((v != null) ? v.Index : 0);
			};
			typeFromHandle50 = typeof(DataMonitor<GameItems>);
			dictionary2[typeFromHandle50] = delegate(BinaryWriter b, object o)
			{
				GameItems v = ((DataMonitor<GameItems>)o).V;
				b.Write((v != null) ? v.Id : 0);
			};
			typeFromHandle49 = typeof(DataMonitor<PetMode>);
			dictionary2[typeFromHandle49] = delegate(BinaryWriter b, object o)
			{
				b.Write((int)((DataMonitor<PetMode>)o).V);
			};
			typeFromHandle48 = typeof(DataMonitor<AttackMode>);
			dictionary2[typeFromHandle48] = delegate(BinaryWriter b, object o)
			{
				b.Write((int)((DataMonitor<AttackMode>)o).V);
			};
			typeFromHandle47 = typeof(DataMonitor<GameDirection>);
			dictionary2[typeFromHandle47] = delegate(BinaryWriter b, object o)
			{
				b.Write((int)((DataMonitor<GameDirection>)o).V);
			};
			typeFromHandle46 = typeof(DataMonitor<ObjectHairType>);
			dictionary2[typeFromHandle46] = delegate(BinaryWriter b, object o)
			{
				b.Write((int)((DataMonitor<ObjectHairType>)o).V);
			};
			typeFromHandle45 = typeof(DataMonitor<ObjectHairColorType>);
			dictionary2[typeFromHandle45] = delegate(BinaryWriter b, object o)
			{
				b.Write((int)((DataMonitor<ObjectHairColorType>)o).V);
			};
			typeFromHandle44 = typeof(DataMonitor<ObjectFaceType>);
			dictionary2[typeFromHandle44] = delegate(BinaryWriter b, object o)
			{
				b.Write((int)((DataMonitor<ObjectFaceType>)o).V);
			};
			typeFromHandle43 = typeof(DataMonitor<GameObjectGender>);
			dictionary2[typeFromHandle43] = delegate(BinaryWriter b, object o)
			{
				b.Write((int)((DataMonitor<GameObjectGender>)o).V);
			};
			typeFromHandle42 = typeof(DataMonitor<GameObjectRace>);
			dictionary2[typeFromHandle42] = delegate(BinaryWriter b, object o)
			{
				b.Write((int)((DataMonitor<GameObjectRace>)o).V);
			};
			typeFromHandle41 = typeof(DataMonitor<TeacherData>);
			dictionary2[typeFromHandle41] = delegate(BinaryWriter b, object o)
			{
				TeacherData v = ((DataMonitor<TeacherData>)o).V;
				b.Write((v != null) ? v.Index.V : 0);
			};
			typeFromHandle40 = typeof(DataMonitor<GuildData>);
			dictionary2[typeFromHandle40] = delegate(BinaryWriter b, object o)
			{
				GuildData v = ((DataMonitor<GuildData>)o).V;
				b.Write((v != null) ? v.Index.V : 0);
			};
			typeFromHandle39 = typeof(DataMonitor<TeamData>);
			dictionary2[typeFromHandle39] = delegate(BinaryWriter b, object o)
			{
				TeamData v = ((DataMonitor<TeamData>)o).V;
				b.Write((v != null) ? v.Index.V : 0);
			};
			typeFromHandle38 = typeof(DataMonitor<BuffData>);
			dictionary2[typeFromHandle38] = delegate(BinaryWriter b, object o)
			{
				BuffData v = ((DataMonitor<BuffData>)o).V;
				b.Write((v != null) ? v.Index.V : 0);
			};
			typeFromHandle37 = typeof(DataMonitor<MailData>);
			dictionary2[typeFromHandle37] = delegate(BinaryWriter b, object o)
			{
				MailData v = ((DataMonitor<MailData>)o).V;
				b.Write((v != null) ? v.Index.V : 0);
			};
			typeFromHandle36 = typeof(DataMonitor<AccountData>);
			dictionary2[typeFromHandle36] = delegate(BinaryWriter b, object o)
			{
				AccountData v = ((DataMonitor<AccountData>)o).V;
				b.Write((v != null) ? v.Index.V : 0);
			};
			typeFromHandle35 = typeof(DataMonitor<CharacterData>);
			dictionary2[typeFromHandle35] = delegate(BinaryWriter b, object o)
			{
				CharacterData v = ((DataMonitor<CharacterData>)o).V;
				b.Write((v != null) ? v.Index.V : 0);
			};
			typeFromHandle34 = typeof(DataMonitor<EquipmentData>);
			dictionary2[typeFromHandle34] = delegate(BinaryWriter b, object o)
			{
				EquipmentData v = ((DataMonitor<EquipmentData>)o).V;
				b.Write((v != null) ? v.Index.V : 0);
			};
			typeFromHandle33 = typeof(DataMonitor<ItemData>);
			dictionary2[typeFromHandle33] = delegate(BinaryWriter b, object o)
			{
				DataMonitor<ItemData> DataMonitor = (DataMonitor<ItemData>)o;
				b.Write(DataMonitor.V is EquipmentData);
				ItemData v = DataMonitor.V;
				b.Write((v != null) ? v.Index.V : 0);
			};
			typeFromHandle32 = typeof(ListMonitor<int>);
			dictionary2[typeFromHandle32] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<int> ListMonitor = (ListMonitor<int>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (int value in ListMonitor)
				{
					b.Write(value);
				}
			};
			typeFromHandle31 = typeof(ListMonitor<uint>);
			dictionary2[typeFromHandle31] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<uint> ListMonitor = (ListMonitor<uint>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (uint value in ListMonitor)
				{
					b.Write(value);
				}
			};
			typeFromHandle30 = typeof(ListMonitor<bool>);
			dictionary2[typeFromHandle30] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<bool> ListMonitor = (ListMonitor<bool>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (bool value in ListMonitor)
				{
					b.Write(value);
				}
			};
			typeFromHandle29 = typeof(ListMonitor<byte>);
			dictionary2[typeFromHandle29] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<byte> ListMonitor = (ListMonitor<byte>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (byte value in ListMonitor)
				{
					b.Write(value);
				}
			};
			typeFromHandle28 = typeof(ListMonitor<CharacterData>);
			dictionary2[typeFromHandle28] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<CharacterData> ListMonitor = (ListMonitor<CharacterData>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (CharacterData CharacterData in ListMonitor)
				{
					b.Write(CharacterData.Index.V);
				}
			};
			typeFromHandle27 = typeof(ListMonitor<PetData>);
			dictionary2[typeFromHandle27] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<PetData> ListMonitor = (ListMonitor<PetData>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (PetData PetData in ListMonitor)
				{
					b.Write(PetData.Index.V);
				}
			};
			typeFromHandle26 = typeof(ListMonitor<GuildData>);
			dictionary2[typeFromHandle26] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<GuildData> ListMonitor = (ListMonitor<GuildData>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (GuildData GuildData in ListMonitor)
				{
					b.Write(GuildData.Index.V);
				}
			};
			typeFromHandle25 = typeof(ListMonitor<GuildEvents>);
			dictionary2[typeFromHandle25] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<GuildEvents> ListMonitor = (ListMonitor<GuildEvents>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (GuildEvents GuildEvents in ListMonitor)
				{
					b.Write((byte)GuildEvents.MemorandumType);
					b.Write(GuildEvents.第一参数);
					b.Write(GuildEvents.第二参数);
					b.Write(GuildEvents.第三参数);
					b.Write(GuildEvents.第四参数);
					b.Write(GuildEvents.事记时间);
				}
			};
			typeFromHandle24 = typeof(ListMonitor<RandomStats>);
			dictionary2[typeFromHandle24] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<RandomStats> ListMonitor = (ListMonitor<RandomStats>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (RandomStats 随机Stat in ListMonitor)
				{
					b.Write(随机Stat.StatId);
				}
			};
			typeFromHandle23 = typeof(ListMonitor<EquipHoleColor>);
			dictionary2[typeFromHandle23] = delegate(BinaryWriter b, object o)
			{
				ListMonitor<EquipHoleColor> ListMonitor = (ListMonitor<EquipHoleColor>)o;
				b.Write((ListMonitor != null) ? ListMonitor.Count : 0);
				foreach (EquipHoleColor value in ListMonitor)
				{
					b.Write((int)value);
				}
			};
			typeFromHandle22 = typeof(HashMonitor<PetData>);
			dictionary2[typeFromHandle22] = delegate(BinaryWriter b, object o)
			{
				HashMonitor<PetData> HashMonitor = (HashMonitor<PetData>)o;
				b.Write((HashMonitor != null) ? HashMonitor.Count : 0);
				foreach (PetData PetData in HashMonitor)
				{
					b.Write(PetData.Index.V);
				}
			};
			typeFromHandle21 = typeof(HashMonitor<CharacterData>);
			dictionary2[typeFromHandle21] = delegate(BinaryWriter b, object o)
			{
				HashMonitor<CharacterData> HashMonitor = (HashMonitor<CharacterData>)o;
				b.Write((HashMonitor != null) ? HashMonitor.Count : 0);
				foreach (CharacterData CharacterData in HashMonitor)
				{
					b.Write(CharacterData.Index.V);
				}
			};
			typeFromHandle20 = typeof(HashMonitor<MailData>);
			dictionary2[typeFromHandle20] = delegate(BinaryWriter b, object o)
			{
				HashMonitor<MailData> HashMonitor = (HashMonitor<MailData>)o;
				b.Write((HashMonitor != null) ? HashMonitor.Count : 0);
				foreach (MailData MailData in HashMonitor)
				{
					b.Write(MailData.Index.V);
				}
			};
			typeFromHandle19 = typeof(MonitorDictionary<byte, int>);
			dictionary2[typeFromHandle19] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<byte, int> MonitorDictionary = (MonitorDictionary<byte, int>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<byte, int> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value);
				}
			};
			typeFromHandle18 = typeof(MonitorDictionary<int, int>);
			dictionary2[typeFromHandle18] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<int, int> MonitorDictionary = (MonitorDictionary<int, int>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<int, int> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value);
				}
			};
			typeFromHandle17 = typeof(MonitorDictionary<int, DateTime>);
			dictionary2[typeFromHandle17] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<int, DateTime> MonitorDictionary = (MonitorDictionary<int, DateTime>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<int, DateTime> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.ToBinary());
				}
			};
			typeFromHandle16 = typeof(MonitorDictionary<byte, DateTime>);
			dictionary2[typeFromHandle16] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<byte, DateTime> MonitorDictionary = (MonitorDictionary<byte, DateTime>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<byte, DateTime> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.ToBinary());
				}
			};
			typeFromHandle15 = typeof(MonitorDictionary<string, DateTime>);
			dictionary2[typeFromHandle15] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<string, DateTime> MonitorDictionary = (MonitorDictionary<string, DateTime>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<string, DateTime> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.ToBinary());
				}
			};
			typeFromHandle14 = typeof(MonitorDictionary<byte, GameItems>);
			dictionary2[typeFromHandle14] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<byte, GameItems> MonitorDictionary = (MonitorDictionary<byte, GameItems>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<byte, GameItems> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.Id);
				}
			};
			typeFromHandle13 = typeof(MonitorDictionary<byte, InscriptionSkill>);
			dictionary2[typeFromHandle13] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<byte, InscriptionSkill> MonitorDictionary = (MonitorDictionary<byte, InscriptionSkill>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<byte, InscriptionSkill> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.Index);
				}
			};
			typeFromHandle12 = typeof(MonitorDictionary<ushort, BuffData>);
			dictionary2[typeFromHandle12] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<ushort, BuffData> MonitorDictionary = (MonitorDictionary<ushort, BuffData>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<ushort, BuffData> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.Index.V);
				}
			};
			typeFromHandle11 = typeof(MonitorDictionary<ushort, SkillData>);
			dictionary2[typeFromHandle11] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<ushort, SkillData> MonitorDictionary = (MonitorDictionary<ushort, SkillData>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<ushort, SkillData> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.Index.V);
				}
			};
			typeFromHandle10 = typeof(MonitorDictionary<byte, SkillData>);
			dictionary2[typeFromHandle10] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<byte, SkillData> MonitorDictionary = (MonitorDictionary<byte, SkillData>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<byte, SkillData> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.Index.V);
				}
			};
			typeFromHandle9 = typeof(MonitorDictionary<byte, EquipmentData>);
			dictionary2[typeFromHandle9] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<byte, EquipmentData> MonitorDictionary = (MonitorDictionary<byte, EquipmentData>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<byte, EquipmentData> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.Index.V);
				}
			};
			typeFromHandle8 = typeof(MonitorDictionary<byte, ItemData>);
			dictionary2[typeFromHandle8] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<byte, ItemData> MonitorDictionary = (MonitorDictionary<byte, ItemData>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<byte, ItemData> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value is EquipmentData);
					b.Write(keyValuePair.Value.Index.V);
				}
			};
			typeFromHandle7 = typeof(MonitorDictionary<int, CharacterData>);
			dictionary2[typeFromHandle7] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<int, CharacterData> MonitorDictionary = (MonitorDictionary<int, CharacterData>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<int, CharacterData> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.Index.V);
				}
			};
			typeFromHandle6 = typeof(MonitorDictionary<int, MailData>);
			dictionary2[typeFromHandle6] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<int, MailData> MonitorDictionary = (MonitorDictionary<int, MailData>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<int, MailData> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key);
					b.Write(keyValuePair.Value.Index.V);
				}
			};
			typeFromHandle5 = typeof(MonitorDictionary<GameCurrency, int>);
			dictionary2[typeFromHandle5] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<GameCurrency, int> MonitorDictionary = (MonitorDictionary<GameCurrency, int>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<GameCurrency, int> keyValuePair in MonitorDictionary)
				{
					b.Write((int)keyValuePair.Key);
					b.Write(keyValuePair.Value);
				}
			};
			typeFromHandle4 = typeof(MonitorDictionary<GuildData, DateTime>);
			dictionary2[typeFromHandle4] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<GuildData, DateTime> MonitorDictionary = (MonitorDictionary<GuildData, DateTime>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<GuildData, DateTime> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key.Index.V);
					b.Write(keyValuePair.Value.ToBinary());
				}
			};
			typeFromHandle3 = typeof(MonitorDictionary<CharacterData, DateTime>);
			dictionary2[typeFromHandle3] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<CharacterData, DateTime> MonitorDictionary = (MonitorDictionary<CharacterData, DateTime>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<CharacterData, DateTime> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key.Index.V);
					b.Write(keyValuePair.Value.ToBinary());
				}
			};
			typeFromHandle2 = typeof(MonitorDictionary<CharacterData, GuildJobs>);
			dictionary2[typeFromHandle2] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<CharacterData, GuildJobs> MonitorDictionary = (MonitorDictionary<CharacterData, GuildJobs>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<CharacterData, GuildJobs> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key.Index.V);
					b.Write((int)keyValuePair.Value);
				}
			};
			typeFromHandle = typeof(MonitorDictionary<DateTime, GuildData>);
			dictionary2[typeFromHandle] = delegate(BinaryWriter b, object o)
			{
				MonitorDictionary<DateTime, GuildData> MonitorDictionary = (MonitorDictionary<DateTime, GuildData>)o;
				b.Write((MonitorDictionary != null) ? MonitorDictionary.Count : 0);
				foreach (KeyValuePair<DateTime, GuildData> keyValuePair in MonitorDictionary)
				{
					b.Write(keyValuePair.Key.ToBinary());
					b.Write(keyValuePair.Value.Index.V);
				}
			};
			DataField.字段写入方法表 = dictionary2;
		}

		
		public string 字段名字 { get; }

		
		public Type 字段类型 { get; }

		
		public FieldInfo 字段详情 { get; }

		
		public override string ToString()
		{
			return this.字段名字;
		}

		
		public DataField(BinaryReader 读取流, Type Data型)
		{
			this.字段名字 = 读取流.ReadString();
			var typeName = 读取流.ReadString();
			this.字段类型 = Type.GetType(typeName);
			this.字段详情 = ((Data型 != null) ? Data型.GetField(this.字段名字) : null);
		}

		
		public DataField(FieldInfo 当前字段)
		{
			
			
			this.字段详情 = 当前字段;
			this.字段名字 = 当前字段.Name;
			this.字段类型 = 当前字段.FieldType;
		}

		
		public bool 检查字段版本(DataField 对比字段)
		{
			return string.Compare(this.字段名字, 对比字段.字段名字, StringComparison.Ordinal) == 0 && this.字段类型 == 对比字段.字段类型;
		}

		
		public void SaveFieldAttribute(BinaryWriter 写入流)
		{
			写入流.Write(this.字段名字);
			写入流.Write(this.字段类型.FullName);
		}

		
		public void 保存字段内容(BinaryWriter 写入流, object 数据)
		{
			DataField.字段写入方法表[this.字段类型](写入流, 数据);
		}

		
		public object 读取字段内容(BinaryReader 读取流, object 数据, DataField 字段)
		{
			return DataField.字段读取方法表[this.字段类型](读取流, (GameData)数据, 字段);
		}

		
		internal static readonly Dictionary<Type, Func<BinaryReader, GameData, DataField, object>> 字段读取方法表;

		
		internal static readonly Dictionary<Type, Action<BinaryWriter, object>> 字段写入方法表;
	}
}
