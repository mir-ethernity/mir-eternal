using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GameServer.Data
{
	// Token: 0x02000277 RID: 631
	public static class DataLinkTable
	{
		// Token: 0x06000654 RID: 1620 RVA: 0x00005BEE File Offset: 0x00003DEE
		public static void 添加任务(GameData 数据, DataField 字段, object 监视器, Type Data型, int 数据索引)
		{
			DataLinkTable.数据任务表.Enqueue(new DataLinkTable.数据关联参数(数据, 字段, 监视器, Data型, 数据索引));
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00005C05 File Offset: 0x00003E05
		public static void 添加任务(GameData 数据, DataField 字段, IList 内部列表, Type Data型, int 数据索引)
		{
			DataLinkTable.列表任务表.Enqueue(new DataLinkTable.列表关联参数(数据, 字段, 内部列表, Data型, 数据索引));
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0002EA8C File Offset: 0x0002CC8C
		public static void 添加任务<T>(GameData 数据, DataField 字段, ISet<T> 内部列表, int 数据索引)
		{
			ISet<PetData> set = 内部列表 as ISet<PetData>;
			if (set != null)
			{
				DataLinkTable.哈希宠物表.Enqueue(new DataLinkTable.哈希关联参数<PetData>(数据, 字段, set, 数据索引));
				return;
			}
			ISet<CharacterData> set2 = 内部列表 as ISet<CharacterData>;
			if (set2 != null)
			{
				DataLinkTable.哈希角色表.Enqueue(new DataLinkTable.哈希关联参数<CharacterData>(数据, 字段, set2, 数据索引));
				return;
			}
			ISet<MailData> set3 = 内部列表 as ISet<MailData>;
			if (set3 != null)
			{
				DataLinkTable.哈希邮件表.Enqueue(new DataLinkTable.哈希关联参数<MailData>(数据, 字段, set3, 数据索引));
				return;
			}
			MessageBox.Show("添加哈希关联任务失败");
		}

		// Token: 0x06000657 RID: 1623 RVA: 0x0002EB00 File Offset: 0x0002CD00
		public static void 添加任务(GameData 数据, DataField 字段, IDictionary 内部字典, object 字典键, object 字典值, Type 键类型, Type 值类型, int 键索引, int 值索引)
		{
			DataLinkTable.字典任务表.Enqueue(new DataLinkTable.字典关联参数(数据, 字段, 内部字典, 字典键, 字典值, 键类型, 值类型, 键索引, 值索引));
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0002EB2C File Offset: 0x0002CD2C
		public static void 处理任务()
		{
			int num = 0;
			Dictionary<Type, Dictionary<string, int>> dictionary = new Dictionary<Type, Dictionary<string, int>>();
			MainForm.AddSystemLog("开始处理数据关联任务...");
			while (!DataLinkTable.数据任务表.IsEmpty)
			{
				DataLinkTable.数据关联参数 数据关联参数;
				if (DataLinkTable.数据任务表.TryDequeue(out 数据关联参数) && 数据关联参数.数据索引 != 0)
				{
					GameData GameData = GameDataGateway.Data型表[数据关联参数.Data型][数据关联参数.数据索引];
					if (GameData == null)
					{
						if (!dictionary.ContainsKey(数据关联参数.数据.Data型))
						{
							dictionary[数据关联参数.数据.Data型] = new Dictionary<string, int>();
						}
						if (!dictionary[数据关联参数.数据.Data型].ContainsKey(数据关联参数.字段.字段名字))
						{
							dictionary[数据关联参数.数据.Data型][数据关联参数.字段.字段名字] = 0;
						}
						Dictionary<string, int> dictionary2 = dictionary[数据关联参数.数据.Data型];
						string 字段名字 = 数据关联参数.字段.字段名字;
						int num2 = dictionary2[字段名字];
						dictionary2[字段名字] = num2 + 1;
					}
					else
					{
						数据关联参数.监视器.GetType().GetField("v", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(数据关联参数.监视器, GameData);
						num++;
					}
				}
			}
			while (!DataLinkTable.列表任务表.IsEmpty)
			{
				DataLinkTable.列表关联参数 列表关联参数;
				if (DataLinkTable.列表任务表.TryDequeue(out 列表关联参数) && 列表关联参数.数据索引 != 0)
				{
					GameData GameData2 = GameDataGateway.Data型表[列表关联参数.Data型][列表关联参数.数据索引];
					if (GameData2 == null)
					{
						if (!dictionary.ContainsKey(列表关联参数.数据.Data型))
						{
							dictionary[列表关联参数.数据.Data型] = new Dictionary<string, int>();
						}
						if (!dictionary[列表关联参数.数据.Data型].ContainsKey(列表关联参数.字段.字段名字))
						{
							dictionary[列表关联参数.数据.Data型][列表关联参数.字段.字段名字] = 0;
						}
						Dictionary<string, int> dictionary3 = dictionary[列表关联参数.数据.Data型];
						string 字段名字 = 列表关联参数.字段.字段名字;
						int num2 = dictionary3[字段名字];
						dictionary3[字段名字] = num2 + 1;
					}
					else
					{
						列表关联参数.内部列表.Add(GameData2);
						num++;
					}
				}
			}
			while (!DataLinkTable.字典任务表.IsEmpty)
			{
				DataLinkTable.字典关联参数 字典关联参数;
				if (DataLinkTable.字典任务表.TryDequeue(out 字典关联参数) && (字典关联参数.字典键 != null || 字典关联参数.键索引 != 0) && (字典关联参数.字典值 != null || 字典关联参数.值索引 != 0))
				{
					object obj = 字典关联参数.字典键 ?? GameDataGateway.Data型表[字典关联参数.键类型][字典关联参数.键索引];
					object obj2 = 字典关联参数.字典值 ?? GameDataGateway.Data型表[字典关联参数.值类型][字典关联参数.值索引];
					if (obj != null && obj2 != null)
					{
						字典关联参数.内部字典[obj] = obj2;
						num++;
					}
					else
					{
						if (!dictionary.ContainsKey(字典关联参数.数据.Data型))
						{
							dictionary[字典关联参数.数据.Data型] = new Dictionary<string, int>();
						}
						if (!dictionary[字典关联参数.数据.Data型].ContainsKey(字典关联参数.字段.字段名字))
						{
							dictionary[字典关联参数.数据.Data型][字典关联参数.字段.字段名字] = 0;
						}
						Dictionary<string, int> dictionary4 = dictionary[字典关联参数.数据.Data型];
						string 字段名字 = 字典关联参数.字段.字段名字;
						int num2 = dictionary4[字段名字];
						dictionary4[字段名字] = num2 + 1;
					}
				}
			}
			while (!DataLinkTable.哈希宠物表.IsEmpty)
			{
				DataLinkTable.哈希关联参数<PetData> 哈希关联参数;
				if (DataLinkTable.哈希宠物表.TryDequeue(out 哈希关联参数) && 哈希关联参数.数据索引 != 0)
				{
					PetData PetData = GameDataGateway.Data型表[typeof(PetData)][哈希关联参数.数据索引] as PetData;
					if (PetData == null)
					{
						if (!dictionary.ContainsKey(哈希关联参数.数据.Data型))
						{
							dictionary[哈希关联参数.数据.Data型] = new Dictionary<string, int>();
						}
						if (!dictionary[哈希关联参数.数据.Data型].ContainsKey(哈希关联参数.字段.字段名字))
						{
							dictionary[哈希关联参数.数据.Data型][哈希关联参数.字段.字段名字] = 0;
						}
						Dictionary<string, int> dictionary5 = dictionary[哈希关联参数.数据.Data型];
						string 字段名字 = 哈希关联参数.字段.字段名字;
						int num2 = dictionary5[字段名字];
						dictionary5[字段名字] = num2 + 1;
					}
					else
					{
						哈希关联参数.内部列表.Add(PetData);
						num++;
					}
				}
			}
			while (!DataLinkTable.哈希角色表.IsEmpty)
			{
				DataLinkTable.哈希关联参数<CharacterData> 哈希关联参数2;
				if (DataLinkTable.哈希角色表.TryDequeue(out 哈希关联参数2) && 哈希关联参数2.数据索引 != 0)
				{
					CharacterData CharacterData = GameDataGateway.Data型表[typeof(CharacterData)][哈希关联参数2.数据索引] as CharacterData;
					if (CharacterData == null)
					{
						if (!dictionary.ContainsKey(哈希关联参数2.数据.Data型))
						{
							dictionary[哈希关联参数2.数据.Data型] = new Dictionary<string, int>();
						}
						if (!dictionary[哈希关联参数2.数据.Data型].ContainsKey(哈希关联参数2.字段.字段名字))
						{
							dictionary[哈希关联参数2.数据.Data型][哈希关联参数2.字段.字段名字] = 0;
						}
						Dictionary<string, int> dictionary6 = dictionary[哈希关联参数2.数据.Data型];
						string 字段名字 = 哈希关联参数2.字段.字段名字;
						int num2 = dictionary6[字段名字];
						dictionary6[字段名字] = num2 + 1;
					}
					else
					{
						哈希关联参数2.内部列表.Add(CharacterData);
						num++;
					}
				}
			}
			while (!DataLinkTable.哈希邮件表.IsEmpty)
			{
				DataLinkTable.哈希关联参数<MailData> 哈希关联参数3;
				if (DataLinkTable.哈希邮件表.TryDequeue(out 哈希关联参数3) && 哈希关联参数3.数据索引 != 0)
				{
					MailData MailData = GameDataGateway.Data型表[typeof(MailData)][哈希关联参数3.数据索引] as MailData;
					if (MailData == null)
					{
						if (!dictionary.ContainsKey(哈希关联参数3.数据.Data型))
						{
							dictionary[哈希关联参数3.数据.Data型] = new Dictionary<string, int>();
						}
						if (!dictionary[哈希关联参数3.数据.Data型].ContainsKey(哈希关联参数3.字段.字段名字))
						{
							dictionary[哈希关联参数3.数据.Data型][哈希关联参数3.字段.字段名字] = 0;
						}
						Dictionary<string, int> dictionary7 = dictionary[哈希关联参数3.数据.Data型];
						string 字段名字 = 哈希关联参数3.字段.字段名字;
						int num2 = dictionary7[字段名字];
						dictionary7[字段名字] = num2 + 1;
					}
					else
					{
						哈希关联参数3.内部列表.Add(MailData);
						num++;
					}
				}
			}
			MainForm.AddSystemLog(string.Format("数据关联任务处理完成, 任务总数:{0}", num));
			dictionary.Sum((KeyValuePair<Type, Dictionary<string, int>> x) => x.Value.Sum((KeyValuePair<string, int> o) => o.Value));
			foreach (KeyValuePair<Type, Dictionary<string, int>> keyValuePair in dictionary)
			{
				foreach (KeyValuePair<string, int> keyValuePair2 in keyValuePair.Value)
				{
					MainForm.AddSystemLog(string.Format("Data型:[{0}], 内部字段:[{1}], 共[{2}]条数据关联失败", keyValuePair.Key.Name, keyValuePair2.Key, keyValuePair2.Value));
				}
			}
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0002F320 File Offset: 0x0002D520
		static DataLinkTable()
		{
			
			DataLinkTable.数据任务表 = new ConcurrentQueue<DataLinkTable.数据关联参数>();
			DataLinkTable.列表任务表 = new ConcurrentQueue<DataLinkTable.列表关联参数>();
			DataLinkTable.字典任务表 = new ConcurrentQueue<DataLinkTable.字典关联参数>();
			DataLinkTable.哈希宠物表 = new ConcurrentQueue<DataLinkTable.哈希关联参数<PetData>>();
			DataLinkTable.哈希角色表 = new ConcurrentQueue<DataLinkTable.哈希关联参数<CharacterData>>();
			DataLinkTable.哈希邮件表 = new ConcurrentQueue<DataLinkTable.哈希关联参数<MailData>>();
		}

		// Token: 0x040008F5 RID: 2293
		private static readonly ConcurrentQueue<DataLinkTable.数据关联参数> 数据任务表;

		// Token: 0x040008F6 RID: 2294
		private static readonly ConcurrentQueue<DataLinkTable.列表关联参数> 列表任务表;

		// Token: 0x040008F7 RID: 2295
		private static readonly ConcurrentQueue<DataLinkTable.字典关联参数> 字典任务表;

		// Token: 0x040008F8 RID: 2296
		private static readonly ConcurrentQueue<DataLinkTable.哈希关联参数<PetData>> 哈希宠物表;

		// Token: 0x040008F9 RID: 2297
		private static readonly ConcurrentQueue<DataLinkTable.哈希关联参数<CharacterData>> 哈希角色表;

		// Token: 0x040008FA RID: 2298
		private static readonly ConcurrentQueue<DataLinkTable.哈希关联参数<MailData>> 哈希邮件表;

		// Token: 0x02000278 RID: 632
		private struct 数据关联参数
		{
			// Token: 0x0600065A RID: 1626 RVA: 0x00005C1C File Offset: 0x00003E1C
			public 数据关联参数(GameData 数据, DataField 字段, object 监视器, Type Data型, int 数据索引)
			{
				
				this.数据 = 数据;
				this.字段 = 字段;
				this.监视器 = 监视器;
				this.Data型 = Data型;
				this.数据索引 = 数据索引;
			}

			// Token: 0x040008FB RID: 2299
			public GameData 数据;

			// Token: 0x040008FC RID: 2300
			public DataField 字段;

			// Token: 0x040008FD RID: 2301
			public object 监视器;

			// Token: 0x040008FE RID: 2302
			public Type Data型;

			// Token: 0x040008FF RID: 2303
			public int 数据索引;
		}

		// Token: 0x02000279 RID: 633
		private struct 列表关联参数
		{
			// Token: 0x0600065B RID: 1627 RVA: 0x00005C48 File Offset: 0x00003E48
			public 列表关联参数(GameData 数据, DataField 字段, IList 内部列表, Type Data型, int 数据索引)
			{
				
				this.数据 = 数据;
				this.字段 = 字段;
				this.内部列表 = 内部列表;
				this.Data型 = Data型;
				this.数据索引 = 数据索引;
			}

			// Token: 0x04000900 RID: 2304
			public GameData 数据;

			// Token: 0x04000901 RID: 2305
			public DataField 字段;

			// Token: 0x04000902 RID: 2306
			public IList 内部列表;

			// Token: 0x04000903 RID: 2307
			public Type Data型;

			// Token: 0x04000904 RID: 2308
			public int 数据索引;
		}

		// Token: 0x0200027A RID: 634
		private struct 哈希关联参数<T>
		{
			// Token: 0x0600065C RID: 1628 RVA: 0x00005C74 File Offset: 0x00003E74
			public 哈希关联参数(GameData 数据, DataField 字段, ISet<T> 内部列表, int 数据索引)
			{
				
				this.数据 = 数据;
				this.字段 = 字段;
				this.内部列表 = 内部列表;
				this.数据索引 = 数据索引;
			}

			// Token: 0x04000905 RID: 2309
			public GameData 数据;

			// Token: 0x04000906 RID: 2310
			public DataField 字段;

			// Token: 0x04000907 RID: 2311
			public ISet<T> 内部列表;

			// Token: 0x04000908 RID: 2312
			public int 数据索引;
		}

		// Token: 0x0200027B RID: 635
		private struct 字典关联参数
		{
			// Token: 0x0600065D RID: 1629 RVA: 0x0002F370 File Offset: 0x0002D570
			public 字典关联参数(GameData 数据, DataField 字段, IDictionary 内部字典, object 字典键, object 字典值, Type 键类型, Type 值类型, int 键索引, int 值索引)
			{
				
				this.数据 = 数据;
				this.字段 = 字段;
				this.内部字典 = 内部字典;
				this.字典键 = 字典键;
				this.字典值 = 字典值;
				this.键类型 = 键类型;
				this.值类型 = 值类型;
				this.键索引 = 键索引;
				this.值索引 = 值索引;
			}

			// Token: 0x04000909 RID: 2313
			public GameData 数据;

			// Token: 0x0400090A RID: 2314
			public DataField 字段;

			// Token: 0x0400090B RID: 2315
			public Type 键类型;

			// Token: 0x0400090C RID: 2316
			public Type 值类型;

			// Token: 0x0400090D RID: 2317
			public int 键索引;

			// Token: 0x0400090E RID: 2318
			public int 值索引;

			// Token: 0x0400090F RID: 2319
			public object 字典键;

			// Token: 0x04000910 RID: 2320
			public object 字典值;

			// Token: 0x04000911 RID: 2321
			public IDictionary 内部字典;
		}
	}
}
