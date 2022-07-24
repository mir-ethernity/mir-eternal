using System;
using System.Collections.Generic;
using System.IO;
using GameServer.Templates;

namespace GameServer.Data
{
	
	public class ItemData : GameData
	{
		
		// (get) Token: 0x06000569 RID: 1385 RVA: 0x00005180 File Offset: 0x00003380
		public GameItems 物品模板
		{
			get
			{
				return this.对应模板.V;
			}
		}

		
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x0000518D File Offset: 0x0000338D
		public ItemsForSale 出售类型
		{
			get
			{
				return this.物品模板.StoreType;
			}
		}

		
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x0000519A File Offset: 0x0000339A
		public ItemType 物品类型
		{
			get
			{
				return this.物品模板.Type;
			}
		}

		
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x000051A7 File Offset: 0x000033A7
		public PersistentItemType PersistType
		{
			get
			{
				return this.物品模板.PersistType;
			}
		}

		
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x000051B4 File Offset: 0x000033B4
		public GameObjectRace NeedRace
		{
			get
			{
				return this.物品模板.NeedRace;
			}
		}

		
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x000051C1 File Offset: 0x000033C1
		public GameObjectGender NeedGender
		{
			get
			{
				return this.物品模板.NeedGender;
			}
		}

		
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x000051CE File Offset: 0x000033CE
		public string Name
		{
			get
			{
				return this.物品模板.Name;
			}
		}

		
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x000051DB File Offset: 0x000033DB
		public int NeedLevel
		{
			get
			{
				return this.物品模板.NeedLevel;
			}
		}

		
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x000051E8 File Offset: 0x000033E8
		public int Id
		{
			get
			{
				return this.对应模板.V.Id;
			}
		}

		
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x000051FA File Offset: 0x000033FA
		public int Weight
		{
			get
			{
				if (this.PersistType != PersistentItemType.堆叠)
				{
					return this.物品模板.Weight;
				}
				return this.当前持久.V * this.物品模板.Weight;
			}
		}

		
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x00025024 File Offset: 0x00023224
		public int SalePrice
		{
			get
			{
				switch (this.对应模板.V.PersistType)
				{
				case PersistentItemType.无:
					return 1;
				case PersistentItemType.装备:
				{
					EquipmentData EquipmentData = this as EquipmentData;
					EquipmentItem 游戏装备 = this.对应模板.V as EquipmentItem;
					int v = EquipmentData.当前持久.V;
					int value = 游戏装备.ItemLast * 1000;
					int SalePrice = 游戏装备.SalePrice;
					int v2 = EquipmentData.幸运等级.V;
					int num = (int)Math.Max(0, v2);
					int num2 = (int)(EquipmentData.升级Attack.V * 100 + EquipmentData.升级Magic.V * 100 + EquipmentData.升级Taoism.V * 100 + EquipmentData.升级Needle.V * 100 + EquipmentData.升级Archery.V * 100);
					int num3 = 0;
					using (IEnumerator<铭文技能> enumerator = EquipmentData.铭文技能.Values.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current != null)
							{
								num3++;
							}
						}
					}
					int num4 = 0;
					foreach (RandomStats 随机Stat in EquipmentData.随机Stat)
					{
						num4 += 随机Stat.CombatBonus * 100;
					}
					int num5 = 0;
					foreach (GameItems 游戏物品 in EquipmentData.镶嵌灵石.Values)
					{
						string Name = 游戏物品.Name;
						uint num6 = PrivateImplementationDetails.ComputeStringHash(Name);
						if (num6 <= 1965594569U)
						{
							if (num6 <= 943749297U)
							{
								if (num6 <= 573099060U)
								{
									if (num6 <= 245049310U)
									{
										if (num6 <= 208490910U)
										{
											if (num6 <= 36171325U)
											{
												if (num6 != 35240798U)
												{
													if (num6 != 36171325U)
													{
														continue;
													}
													if (!(Name == "精绿灵石2级"))
													{
														continue;
													}
													goto IL_17B1;
												}
												else
												{
													if (!(Name == "精绿灵石5级"))
													{
														continue;
													}
													goto IL_174F;
												}
											}
											else if (num6 != 36983370U)
											{
												if (num6 != 74678801U)
												{
													if (num6 != 208490910U)
													{
														continue;
													}
													if (!(Name == "驭朱灵石4级"))
													{
														continue;
													}
													goto IL_1867;
												}
												else
												{
													if (!(Name == "透蓝灵石1级"))
													{
														continue;
													}
													goto IL_18BB;
												}
											}
											else
											{
												if (!(Name == "精绿灵石9级"))
												{
													continue;
												}
												goto IL_1827;
											}
										}
										else if (num6 <= 209834109U)
										{
											if (num6 != 209302955U)
											{
												if (num6 != 209834109U)
												{
													continue;
												}
												if (!(Name == "驭朱灵石3级"))
												{
													continue;
												}
												goto IL_18EF;
											}
											else
											{
												if (!(Name == "驭朱灵石1级"))
												{
													continue;
												}
												goto IL_18BB;
											}
										}
										else if (num6 != 210646154U)
										{
											if (num6 != 234198814U)
											{
												if (num6 != 245049310U)
												{
													continue;
												}
												if (!(Name == "蔚蓝灵石10级"))
												{
													continue;
												}
												goto IL_18D5;
											}
											else
											{
												if (!(Name == "狂热幻彩灵石10级"))
												{
													continue;
												}
												goto IL_18D5;
											}
										}
										else if (!(Name == "驭朱灵石8级"))
										{
											continue;
										}
									}
									else if (num6 <= 406321612U)
									{
										if (num6 <= 305587683U)
										{
											if (num6 != 263991377U)
											{
												if (num6 != 305587683U)
												{
													continue;
												}
												if (!(Name == "精绿灵石8级"))
												{
													continue;
												}
											}
											else
											{
												if (!(Name == "抵御幻彩灵石7级"))
												{
													continue;
												}
												goto IL_1807;
											}
										}
										else if (num6 != 335211465U)
										{
											if (num6 != 336023510U)
											{
												if (num6 != 406321612U)
												{
													continue;
												}
												if (!(Name == "精绿灵石10级"))
												{
													continue;
												}
												goto IL_18D5;
											}
											else if (!(Name == "韧紫灵石8级"))
											{
												continue;
											}
										}
										else
										{
											if (!(Name == "韧紫灵石3级"))
											{
												continue;
											}
											goto IL_18EF;
										}
									}
									else if (num6 <= 479250467U)
									{
										if (num6 != 470449305U)
										{
											if (num6 != 479250467U)
											{
												continue;
											}
											if (!(Name == "驭朱灵石9级"))
											{
												continue;
											}
											goto IL_1827;
										}
										else
										{
											if (!(Name == "命朱灵石7级"))
											{
												continue;
											}
											goto IL_1807;
										}
									}
									else if (num6 != 531090082U)
									{
										if (num6 != 549347465U)
										{
											if (num6 != 573099060U)
											{
												continue;
											}
											if (!(Name == "精绿灵石3级"))
											{
												continue;
											}
											goto IL_18EF;
										}
										else
										{
											if (!(Name == "透蓝灵石10级"))
											{
												continue;
											}
											goto IL_18D5;
										}
									}
									else if (!(Name == "抵御幻彩灵石8级"))
									{
										continue;
									}
								}
								else if (num6 <= 738772727U)
								{
									if (num6 <= 680541790U)
									{
										if (num6 <= 607107224U)
										{
											if (num6 != 603534887U)
											{
												if (num6 != 607107224U)
												{
													continue;
												}
												if (!(Name == "新阳灵石5级"))
												{
													continue;
												}
												goto IL_174F;
											}
											else
											{
												if (!(Name == "韧紫灵石1级"))
												{
													continue;
												}
												goto IL_18BB;
											}
										}
										else if (num6 != 607638378U)
										{
											if (num6 != 611931354U)
											{
												if (num6 != 680541790U)
												{
													continue;
												}
												if (!(Name == "橙黄灵石10级"))
												{
													continue;
												}
												goto IL_18D5;
											}
											else
											{
												if (!(Name == "透蓝灵石6级"))
												{
													continue;
												}
												goto IL_1884;
											}
										}
										else
										{
											if (!(Name == "新阳灵石3级"))
											{
												continue;
											}
											goto IL_18EF;
										}
									}
									else if (num6 <= 692924671U)
									{
										if (num6 != 691994144U)
										{
											if (num6 != 692924671U)
											{
												continue;
											}
											if (!(Name == "蔚蓝灵石2级"))
											{
												continue;
											}
											goto IL_17B1;
										}
										else
										{
											if (!(Name == "蔚蓝灵石9级"))
											{
												continue;
											}
											goto IL_1827;
										}
									}
									else if (num6 != 693736716U)
									{
										if (num6 != 714727999U)
										{
											if (num6 != 738772727U)
											{
												continue;
											}
											if (!(Name == "命朱灵石5级"))
											{
												continue;
											}
											goto IL_174F;
										}
										else
										{
											if (!(Name == "抵御幻彩灵石10级"))
											{
												continue;
											}
											goto IL_18D5;
										}
									}
									else
									{
										if (!(Name == "蔚蓝灵石5级"))
										{
											continue;
										}
										goto IL_174F;
									}
								}
								else if (num6 <= 804167584U)
								{
									if (num6 <= 771022468U)
									{
										if (num6 != 746349172U)
										{
											if (num6 != 771022468U)
											{
												continue;
											}
											if (!(Name == "守阳灵石1级"))
											{
												continue;
											}
											goto IL_18BB;
										}
										else
										{
											if (!(Name == "驭朱灵石2级"))
											{
												continue;
											}
											goto IL_17B1;
										}
									}
									else if (num6 != 799900731U)
									{
										if (num6 != 800712776U)
										{
											if (num6 != 804167584U)
											{
												continue;
											}
											if (!(Name == "橙黄灵石9级"))
											{
												continue;
											}
											goto IL_1827;
										}
										else
										{
											if (!(Name == "抵御幻彩灵石6级"))
											{
												continue;
											}
											goto IL_1884;
										}
									}
									else
									{
										if (!(Name == "抵御幻彩灵石9级"))
										{
											continue;
										}
										goto IL_1827;
									}
								}
								else if (num6 <= 805910156U)
								{
									if (num6 != 805098111U)
									{
										if (num6 != 805910156U)
										{
											continue;
										}
										if (!(Name == "橙黄灵石5级"))
										{
											continue;
										}
										goto IL_174F;
									}
									else
									{
										if (!(Name == "橙黄灵石2级"))
										{
											continue;
										}
										goto IL_17B1;
									}
								}
								else if (num6 != 840642163U)
								{
									if (num6 != 896281263U)
									{
										if (num6 != 943749297U)
										{
											continue;
										}
										if (!(Name == "深灰灵石4级"))
										{
											continue;
										}
										goto IL_1867;
									}
									else
									{
										if (!(Name == "进击幻彩灵石10级"))
										{
											continue;
										}
										goto IL_18D5;
									}
								}
								else
								{
									if (!(Name == "赤褐灵石7级"))
									{
										continue;
									}
									goto IL_1807;
								}
							}
							else if (num6 <= 1307537531U)
							{
								if (num6 <= 1144359777U)
								{
									if (num6 <= 1038933218U)
									{
										if (num6 <= 1014483090U)
										{
											if (num6 != 1007377040U)
											{
												if (num6 != 1014483090U)
												{
													continue;
												}
												if (!(Name == "进击幻彩灵石8级"))
												{
													continue;
												}
											}
											else
											{
												if (!(Name == "命朱灵石6级"))
												{
													continue;
												}
												goto IL_1884;
											}
										}
										else if (num6 != 1015295135U)
										{
											if (num6 != 1025365623U)
											{
												if (num6 != 1038933218U)
												{
													continue;
												}
												if (!(Name == "守阳灵石3级"))
												{
													continue;
												}
												goto IL_18EF;
											}
											else
											{
												if (!(Name == "命朱灵石10级"))
												{
													continue;
												}
												goto IL_18D5;
											}
										}
										else
										{
											if (!(Name == "进击幻彩灵石5级"))
											{
												continue;
											}
											goto IL_174F;
										}
									}
									else if (num6 <= 1127514398U)
									{
										if (num6 != 1108552913U)
										{
											if (num6 != 1127514398U)
											{
												continue;
											}
											if (!(Name == "盈绿灵石3级"))
											{
												continue;
											}
											goto IL_18EF;
										}
										else
										{
											if (!(Name == "赤褐灵石1级"))
											{
												continue;
											}
											goto IL_18BB;
										}
									}
									else if (num6 != 1128326443U)
									{
										if (num6 != 1128444925U)
										{
											if (num6 != 1144359777U)
											{
												continue;
											}
											if (!(Name == "新阳灵石4级"))
											{
												continue;
											}
											goto IL_1867;
										}
										else
										{
											if (!(Name == "盈绿灵石4级"))
											{
												continue;
											}
											goto IL_1867;
										}
									}
									else
									{
										if (!(Name == "盈绿灵石6级"))
										{
											continue;
										}
										goto IL_1884;
									}
								}
								else if (num6 <= 1230989269U)
								{
									if (num6 <= 1211660047U)
									{
										if (num6 != 1200044703U)
										{
											if (num6 != 1211660047U)
											{
												continue;
											}
											if (!(Name == "深灰灵石6级"))
											{
												continue;
											}
											goto IL_1884;
										}
										else
										{
											if (!(Name == "纯紫灵石1级"))
											{
												continue;
											}
											goto IL_18BB;
										}
									}
									else if (num6 != 1229646070U)
									{
										if (num6 != 1230458115U)
										{
											if (num6 != 1230989269U)
											{
												continue;
											}
											if (!(Name == "蔚蓝灵石4级"))
											{
												continue;
											}
											goto IL_1867;
										}
										else
										{
											if (!(Name == "蔚蓝灵石6级"))
											{
												continue;
											}
											goto IL_1884;
										}
									}
									else
									{
										if (!(Name == "蔚蓝灵石3级"))
										{
											continue;
										}
										goto IL_18EF;
									}
								}
								else if (num6 <= 1276630989U)
								{
									if (num6 != 1275287790U)
									{
										if (num6 != 1276630989U)
										{
											continue;
										}
										if (!(Name == "命朱灵石3级"))
										{
											continue;
										}
										goto IL_18EF;
									}
									else
									{
										if (!(Name == "命朱灵石4级"))
										{
											continue;
										}
										goto IL_1867;
									}
								}
								else if (num6 != 1284105784U)
								{
									if (num6 != 1300070770U)
									{
										if (num6 != 1307537531U)
										{
											continue;
										}
										if (!(Name == "守阳灵石2级"))
										{
											continue;
										}
										goto IL_17B1;
									}
									else
									{
										if (!(Name == "守阳灵石10级"))
										{
											continue;
										}
										goto IL_18D5;
									}
								}
								else
								{
									if (!(Name == "进击幻彩灵石6级"))
									{
										continue;
									}
									goto IL_1884;
								}
							}
							else if (num6 <= 1665978369U)
							{
								if (num6 <= 1480470696U)
								{
									if (num6 <= 1342837891U)
									{
										if (num6 != 1342025846U)
										{
											if (num6 != 1342837891U)
											{
												continue;
											}
											if (!(Name == "橙黄灵石6级"))
											{
												continue;
											}
											goto IL_1884;
										}
										else
										{
											if (!(Name == "橙黄灵石3级"))
											{
												continue;
											}
											goto IL_18EF;
										}
									}
									else if (num6 != 1342956373U)
									{
										if (num6 != 1468855352U)
										{
											if (num6 != 1480470696U)
											{
												continue;
											}
											if (!(Name == "深灰灵石5级"))
											{
												continue;
											}
											goto IL_174F;
										}
										else
										{
											if (!(Name == "纯紫灵石2级"))
											{
												continue;
											}
											goto IL_17B1;
										}
									}
									else
									{
										if (!(Name == "橙黄灵石4级"))
										{
											continue;
										}
										goto IL_1867;
									}
								}
								else if (num6 <= 1553359733U)
								{
									if (num6 != 1552016534U)
									{
										if (num6 != 1553359733U)
										{
											continue;
										}
										if (!(Name == "进击幻彩灵石3级"))
										{
											continue;
										}
										goto IL_18EF;
									}
									else
									{
										if (!(Name == "进击幻彩灵石4级"))
										{
											continue;
										}
										goto IL_1867;
									}
								}
								else if (num6 != 1645599130U)
								{
									if (num6 != 1665166324U)
									{
										if (num6 != 1665978369U)
										{
											continue;
										}
										if (!(Name == "盈绿灵石8级"))
										{
											continue;
										}
									}
									else
									{
										if (!(Name == "盈绿灵石5级"))
										{
											continue;
										}
										goto IL_174F;
									}
								}
								else
								{
									if (!(Name == "赤褐灵石6级"))
									{
										continue;
									}
									goto IL_1884;
								}
							}
							else if (num6 <= 1914880594U)
							{
								if (num6 <= 1697659818U)
								{
									if (num6 != 1697128664U)
									{
										if (num6 != 1697659818U)
										{
											continue;
										}
										if (!(Name == "狂热幻彩灵石7级"))
										{
											continue;
										}
										goto IL_1807;
									}
									else
									{
										if (!(Name == "狂热幻彩灵石1级"))
										{
											continue;
										}
										goto IL_18BB;
									}
								}
								else if (num6 != 1738109301U)
								{
									if (num6 != 1914349440U)
									{
										if (num6 != 1914880594U)
										{
											continue;
										}
										if (!(Name == "精绿灵石1级"))
										{
											continue;
										}
										goto IL_18BB;
									}
									else
									{
										if (!(Name == "精绿灵石7级"))
										{
											continue;
										}
										goto IL_1807;
									}
								}
								else
								{
									if (!(Name == "纯紫灵石7级"))
									{
										continue;
									}
									goto IL_1807;
								}
							}
							else if (num6 <= 1953388070U)
							{
								if (num6 != 1952576025U)
								{
									if (num6 != 1953388070U)
									{
										continue;
									}
									if (!(Name == "透蓝灵石2级"))
									{
										continue;
									}
									goto IL_17B1;
								}
								else
								{
									if (!(Name == "透蓝灵石9级"))
									{
										continue;
									}
									goto IL_1827;
								}
							}
							else if (num6 != 1954318597U)
							{
								if (num6 != 1964640041U)
								{
									if (num6 != 1965594569U)
									{
										continue;
									}
									if (!(Name == "赤褐灵石10级"))
									{
										continue;
									}
									goto IL_18D5;
								}
								else if (!(Name == "狂热幻彩灵石8级"))
								{
									continue;
								}
							}
							else
							{
								if (!(Name == "透蓝灵石5级"))
								{
									continue;
								}
								goto IL_174F;
							}
						}
						else if (num6 <= 3186246800U)
						{
							if (num6 <= 2719719079U)
							{
								if (num6 <= 2489297424U)
								{
									if (num6 <= 2214629611U)
									{
										if (num6 <= 2087909056U)
										{
											if (num6 != 2004277479U)
											{
												if (num6 != 2087909056U)
												{
													continue;
												}
												if (!(Name == "驭朱灵石6级"))
												{
													continue;
												}
												goto IL_1884;
											}
											else
											{
												if (!(Name == "纯紫灵石9级"))
												{
													continue;
												}
												goto IL_1827;
											}
										}
										else if (num6 != 2142391142U)
										{
											if (num6 != 2143734341U)
											{
												if (num6 != 2214629611U)
												{
													continue;
												}
												if (!(Name == "韧紫灵石5级"))
												{
													continue;
												}
												goto IL_174F;
											}
											else
											{
												if (!(Name == "抵御幻彩灵石3级"))
												{
													continue;
												}
												goto IL_18EF;
											}
										}
										else
										{
											if (!(Name == "抵御幻彩灵石4级"))
											{
												continue;
											}
											goto IL_1867;
										}
									}
									else if (num6 <= 2451395657U)
									{
										if (num6 != 2215160765U)
										{
											if (num6 != 2451395657U)
											{
												continue;
											}
											if (!(Name == "精绿灵石6级"))
											{
												continue;
											}
											goto IL_1884;
										}
										else
										{
											if (!(Name == "韧紫灵石7级"))
											{
												continue;
											}
											goto IL_1807;
										}
									}
									else if (num6 != 2486038143U)
									{
										if (num6 != 2486850188U)
										{
											if (num6 != 2489297424U)
											{
												continue;
											}
											if (!(Name == "透蓝灵石8级"))
											{
												continue;
											}
										}
										else
										{
											if (!(Name == "新阳灵石1级"))
											{
												continue;
											}
											goto IL_18BB;
										}
									}
									else
									{
										if (!(Name == "新阳灵石6级"))
										{
											continue;
										}
										goto IL_1884;
									}
								}
								else if (num6 <= 2649319065U)
								{
									if (num6 <= 2491039996U)
									{
										if (num6 != 2490227951U)
										{
											if (num6 != 2491039996U)
											{
												continue;
											}
											if (!(Name == "透蓝灵石4级"))
											{
												continue;
											}
											goto IL_1867;
										}
										else
										{
											if (!(Name == "透蓝灵石3级"))
											{
												continue;
											}
											goto IL_18EF;
										}
									}
									else if (num6 != 2619608627U)
									{
										if (num6 != 2625161609U)
										{
											if (num6 != 2649319065U)
											{
												continue;
											}
											if (!(Name == "守阳灵石4级"))
											{
												continue;
											}
											goto IL_1867;
										}
										else
										{
											if (!(Name == "驭朱灵石7级"))
											{
												continue;
											}
											goto IL_1807;
										}
									}
									else
									{
										if (!(Name == "命朱灵石9级"))
										{
											continue;
										}
										goto IL_1827;
									}
								}
								else if (num6 <= 2679437359U)
								{
									if (num6 != 2651474309U)
									{
										if (num6 != 2679437359U)
										{
											continue;
										}
										if (!(Name == "抵御幻彩灵石5级"))
										{
											continue;
										}
										goto IL_174F;
									}
									else if (!(Name == "守阳灵石8级"))
									{
										continue;
									}
								}
								else if (num6 != 2680249404U)
								{
									if (num6 != 2718739222U)
									{
										if (num6 != 2719719079U)
										{
											continue;
										}
										if (!(Name == "精绿灵石4级"))
										{
											continue;
										}
										goto IL_1867;
									}
									else
									{
										if (!(Name == "盈绿灵石10级"))
										{
											continue;
										}
										goto IL_18D5;
									}
								}
								else
								{
									if (!(Name == "抵御幻彩灵石2级"))
									{
										continue;
									}
									goto IL_17B1;
								}
							}
							else if (num6 <= 2988502213U)
							{
								if (num6 <= 2887120004U)
								{
									if (num6 <= 2754361565U)
									{
										if (num6 != 2751882164U)
										{
											if (num6 != 2754361565U)
											{
												continue;
											}
											if (!(Name == "新阳灵石8级"))
											{
												continue;
											}
										}
										else
										{
											if (!(Name == "韧紫灵石6级"))
											{
												continue;
											}
											goto IL_1884;
										}
									}
									else if (num6 != 2822149062U)
									{
										if (num6 != 2822961107U)
										{
											if (num6 != 2887120004U)
											{
												continue;
											}
											if (!(Name == "命朱灵石2级"))
											{
												continue;
											}
											goto IL_17B1;
										}
										else
										{
											if (!(Name == "深灰灵石2级"))
											{
												continue;
											}
											goto IL_17B1;
										}
									}
									else
									{
										if (!(Name == "深灰灵石7级"))
										{
											continue;
										}
										goto IL_1807;
									}
								}
								else if (num6 <= 2917642487U)
								{
									if (num6 != 2893072359U)
									{
										if (num6 != 2917642487U)
										{
											continue;
										}
										if (!(Name == "守阳灵石6级"))
										{
											continue;
										}
										goto IL_1884;
									}
									else
									{
										if (!(Name == "驭朱灵石5级"))
										{
											continue;
										}
										goto IL_174F;
									}
								}
								else if (num6 != 2986346969U)
								{
									if (num6 != 2987159014U)
									{
										if (num6 != 2988502213U)
										{
											continue;
										}
										if (!(Name == "赤褐灵石5级"))
										{
											continue;
										}
										goto IL_174F;
									}
									else
									{
										if (!(Name == "赤褐灵石2级"))
										{
											continue;
										}
										goto IL_17B1;
									}
								}
								else
								{
									if (!(Name == "赤褐灵石9级"))
									{
										continue;
									}
									goto IL_1827;
								}
							}
							else if (num6 <= 3090472484U)
							{
								if (num6 <= 3007257362U)
								{
									if (num6 != 3006726208U)
									{
										if (num6 != 3007257362U)
										{
											continue;
										}
										if (!(Name == "盈绿灵石7级"))
										{
											continue;
										}
										goto IL_1807;
									}
									else
									{
										if (!(Name == "盈绿灵石1级"))
										{
											continue;
										}
										goto IL_18BB;
									}
								}
								else if (num6 != 3022965878U)
								{
									if (num6 != 3023777923U)
									{
										if (num6 != 3090472484U)
										{
											continue;
										}
										if (!(Name == "深灰灵石9级"))
										{
											continue;
										}
										goto IL_1827;
									}
									else
									{
										if (!(Name == "新阳灵石2级"))
										{
											continue;
										}
										goto IL_17B1;
									}
								}
								else
								{
									if (!(Name == "新阳灵石7级"))
									{
										continue;
									}
									goto IL_1807;
								}
							}
							else if (num6 <= 3109167384U)
							{
								if (num6 != 3101887706U)
								{
									if (num6 != 3109167384U)
									{
										continue;
									}
									if (!(Name == "蔚蓝灵石1级"))
									{
										continue;
									}
									goto IL_18BB;
								}
								else
								{
									if (!(Name == "深灰灵石10级"))
									{
										continue;
									}
									goto IL_18D5;
								}
							}
							else if (num6 != 3109285866U)
							{
								if (num6 != 3163745580U)
								{
									if (num6 != 3186246800U)
									{
										continue;
									}
									if (!(Name == "守阳灵石5级"))
									{
										continue;
									}
									goto IL_174F;
								}
								else
								{
									if (!(Name == "进击幻彩灵石2级"))
									{
										continue;
									}
									goto IL_17B1;
								}
							}
							else
							{
								if (!(Name == "蔚蓝灵石7级"))
								{
									continue;
								}
								goto IL_1807;
							}
						}
						else if (num6 <= 3581907291U)
						{
							if (num6 <= 3424978266U)
							{
								if (num6 <= 3290876628U)
								{
									if (num6 <= 3221134488U)
									{
										if (num6 != 3187989372U)
										{
											if (num6 != 3221134488U)
											{
												continue;
											}
											if (!(Name == "橙黄灵石1级"))
											{
												continue;
											}
											goto IL_18BB;
										}
										else
										{
											if (!(Name == "守阳灵石9级"))
											{
												continue;
											}
											goto IL_1827;
										}
									}
									else if (num6 != 3221665642U)
									{
										if (num6 != 3276673720U)
										{
											if (num6 != 3290876628U)
											{
												continue;
											}
											if (!(Name == "新阳灵石9级"))
											{
												continue;
											}
											goto IL_1827;
										}
										else
										{
											if (!(Name == "盈绿灵石9级"))
											{
												continue;
											}
											goto IL_1827;
										}
									}
									else
									{
										if (!(Name == "橙黄灵石7级"))
										{
											continue;
										}
										goto IL_1807;
									}
								}
								else if (num6 <= 3360007324U)
								{
									if (num6 != 3348495148U)
									{
										if (num6 != 3360007324U)
										{
											continue;
										}
										if (!(Name == "深灰灵石1级"))
										{
											continue;
										}
										goto IL_18BB;
									}
									else
									{
										if (!(Name == "纯紫灵石6级"))
										{
											continue;
										}
										goto IL_1884;
									}
								}
								else if (num6 != 3376266089U)
								{
									if (num6 != 3423635067U)
									{
										if (num6 != 3424978266U)
										{
											continue;
										}
										if (!(Name == "命朱灵石8级"))
										{
											continue;
										}
									}
									else
									{
										if (!(Name == "命朱灵石1级"))
										{
											continue;
										}
										goto IL_18BB;
									}
								}
								else if (!(Name == "蔚蓝灵石8级"))
								{
									continue;
								}
							}
							else if (num6 <= 3524411567U)
							{
								if (num6 <= 3454157550U)
								{
									if (num6 != 3430725803U)
									{
										if (num6 != 3454157550U)
										{
											continue;
										}
										if (!(Name == "守阳灵石7级"))
										{
											continue;
										}
										goto IL_1807;
									}
									else
									{
										if (!(Name == "进击幻彩灵石9级"))
										{
											continue;
										}
										goto IL_1827;
									}
								}
								else if (num6 != 3488645865U)
								{
									if (num6 != 3523068368U)
									{
										if (num6 != 3524411567U)
										{
											continue;
										}
										if (!(Name == "赤褐灵石3级"))
										{
											continue;
										}
										goto IL_18EF;
									}
									else if (!(Name == "赤褐灵石8级"))
									{
										continue;
									}
								}
								else if (!(Name == "橙黄灵石8级"))
								{
									continue;
								}
							}
							else if (num6 <= 3575025888U)
							{
								if (num6 != 3525223612U)
								{
									if (num6 != 3575025888U)
									{
										continue;
									}
									if (!(Name == "狂热幻彩灵石9级"))
									{
										continue;
									}
									goto IL_1827;
								}
								else
								{
									if (!(Name == "赤褐灵石4级"))
									{
										continue;
									}
									goto IL_1867;
								}
							}
							else if (num6 != 3575956415U)
							{
								if (num6 != 3576768460U)
								{
									if (num6 != 3581907291U)
									{
										continue;
									}
									if (!(Name == "韧紫灵石10级"))
									{
										continue;
									}
									goto IL_18D5;
								}
								else
								{
									if (!(Name == "狂热幻彩灵石5级"))
									{
										continue;
									}
									goto IL_174F;
								}
							}
							else
							{
								if (!(Name == "狂热幻彩灵石2级"))
								{
									continue;
								}
								goto IL_17B1;
							}
						}
						else if (num6 <= 3968584065U)
						{
							if (num6 <= 3686647075U)
							{
								if (num6 <= 3616405898U)
								{
									if (num6 != 3614663326U)
									{
										if (num6 != 3616405898U)
										{
											continue;
										}
										if (!(Name == "纯紫灵石4级"))
										{
											continue;
										}
										goto IL_1867;
									}
									else if (!(Name == "纯紫灵石8级"))
									{
										continue;
									}
								}
								else if (num6 != 3627518701U)
								{
									if (num6 != 3628330746U)
									{
										if (num6 != 3686647075U)
										{
											continue;
										}
										if (!(Name == "纯紫灵石10级"))
										{
											continue;
										}
										goto IL_18D5;
									}
									else
									{
										if (!(Name == "深灰灵石3级"))
										{
											continue;
										}
										goto IL_18EF;
									}
								}
								else if (!(Name == "深灰灵石8级"))
								{
									continue;
								}
							}
							else if (num6 <= 3812095847U)
							{
								if (num6 != 3700260643U)
								{
									if (num6 != 3812095847U)
									{
										continue;
									}
									if (!(Name == "盈绿灵石2级"))
									{
										continue;
									}
									goto IL_17B1;
								}
								else
								{
									if (!(Name == "进击幻彩灵石1级"))
									{
										continue;
									}
									goto IL_18BB;
								}
							}
							else if (num6 != 3885010211U)
							{
								if (num6 != 3922679306U)
								{
									if (num6 != 3968584065U)
									{
										continue;
									}
									if (!(Name == "进击幻彩灵石7级"))
									{
										continue;
									}
									goto IL_1807;
								}
								else
								{
									if (!(Name == "新阳灵石10级"))
									{
										continue;
									}
									goto IL_18D5;
								}
							}
							else
							{
								if (Name == "纯紫灵石5级")
								{
									goto IL_174F;
								}
								continue;
							}
						}
						else if (num6 <= 4112884150U)
						{
							if (num6 <= 4093457362U)
							{
								if (num6 != 4093338880U)
								{
									if (num6 != 4093457362U)
									{
										continue;
									}
									if (!(Name == "韧紫灵石4级"))
									{
										continue;
									}
									goto IL_1867;
								}
								else
								{
									if (Name == "韧紫灵石2级")
									{
										goto IL_17B1;
									}
									continue;
								}
							}
							else if (num6 != 4094269407U)
							{
								if (num6 != 4101735347U)
								{
									if (num6 != 4112884150U)
									{
										continue;
									}
									if (!(Name == "狂热幻彩灵石3级"))
									{
										continue;
									}
									goto IL_18EF;
								}
								else
								{
									if (Name == "透蓝灵石7级")
									{
										goto IL_1807;
									}
									continue;
								}
							}
							else
							{
								if (Name == "韧紫灵石9级")
								{
									goto IL_1827;
								}
								continue;
							}
						}
						else if (num6 <= 4113814677U)
						{
							if (num6 != 4113696195U)
							{
								if (num6 != 4113814677U)
								{
									continue;
								}
								if (Name == "狂热幻彩灵石4级")
								{
									goto IL_1867;
								}
								continue;
							}
							else
							{
								if (Name == "狂热幻彩灵石6级")
								{
									goto IL_1884;
								}
								continue;
							}
						}
						else if (num6 != 4153333633U)
						{
							if (num6 != 4189275687U)
							{
								if (num6 != 4290635251U)
								{
									continue;
								}
								if (Name == "抵御幻彩灵石1级")
								{
									goto IL_18BB;
								}
								continue;
							}
							else
							{
								if (Name == "驭朱灵石10级")
								{
									goto IL_18D5;
								}
								continue;
							}
						}
						else
						{
							if (Name == "纯紫灵石3级")
							{
								goto IL_18EF;
							}
							continue;
						}
						num5 += 8000;
						continue;
						IL_174F:
						num5 += 5000;
						continue;
						IL_17B1:
						num5 += 2000;
						continue;
						IL_1807:
						num5 += 7000;
						continue;
						IL_1827:
						num5 += 9000;
						continue;
						IL_1867:
						num5 += 4000;
						continue;
						IL_1884:
						num5 += 6000;
						continue;
						IL_18BB:
						num5 += 1000;
						continue;
						IL_18D5:
						num5 += 10000;
						continue;
						IL_18EF:
						num5 += 3000;
					}
					int value2 = SalePrice + num + num2 + num3 + num4 + num5;
					decimal d = v / value * 0.9m * value2;
					decimal d2 = value2 * 0.1m;
					return (int)(d + d2);
				}
				case PersistentItemType.消耗:
				{
					int v2 = this.当前持久.V;
					int ItemLast = this.对应模板.V.ItemLast;
					int SalePrice2 = this.对应模板.V.SalePrice;
					return (int)(v2 / ItemLast * SalePrice2);
				}
				case PersistentItemType.堆叠:
				{
					int v3 = this.当前持久.V;
					return this.对应模板.V.SalePrice * v3;
				}
				case PersistentItemType.回复:
					return 1;
				case PersistentItemType.容器:
					return this.对应模板.V.SalePrice;
				case PersistentItemType.纯度:
					return this.对应模板.V.SalePrice;
				default:
					return 0;
				}
			}
		}

		
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x00005228 File Offset: 0x00003428
		public int 堆叠上限
		{
			get
			{
				return this.对应模板.V.ItemLast;
			}
		}

		
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x0000523A File Offset: 0x0000343A
		public int 默认持久
		{
			get
			{
				if (this.PersistType != PersistentItemType.装备)
				{
					return this.对应模板.V.ItemLast;
				}
				return this.对应模板.V.ItemLast * 1000;
			}
		}

		
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x0000526C File Offset: 0x0000346C
		// (set) Token: 0x06000577 RID: 1399 RVA: 0x00005279 File Offset: 0x00003479
		public byte 当前位置
		{
			get
			{
				return this.物品位置.V;
			}
			set
			{
				this.物品位置.V = value;
			}
		}

		
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x00005287 File Offset: 0x00003487
		public bool IsBound
		{
			get
			{
				return this.物品模板.IsBound;
			}
		}

		
		// (get) Token: 0x06000579 RID: 1401 RVA: 0x00005294 File Offset: 0x00003494
		public bool Resource
		{
			get
			{
				return this.对应模板.V.Resource;
			}
		}

		
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x000052A6 File Offset: 0x000034A6
		public bool CanSold
		{
			get
			{
				return this.物品模板.CanSold;
			}
		}

		
		// (get) Token: 0x0600057B RID: 1403 RVA: 0x000052B3 File Offset: 0x000034B3
		public bool 能否堆叠
		{
			get
			{
				return this.对应模板.V.PersistType == PersistentItemType.堆叠;
			}
		}

		
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x000052C8 File Offset: 0x000034C8
		public bool CanDrop
		{
			get
			{
				return this.物品模板.CanDrop;
			}
		}

		
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x000052D5 File Offset: 0x000034D5
		public ushort 技能编号
		{
			get
			{
				return this.物品模板.AdditionalSkill;
			}
		}

		
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x000052E2 File Offset: 0x000034E2
		public byte GroupId
		{
			get
			{
				return this.物品模板.Group;
			}
		}

		
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x000052EF File Offset: 0x000034EF
		public int GroupCooling
		{
			get
			{
				return this.物品模板.GroupCooling;
			}
		}

		
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x000052FC File Offset: 0x000034FC
		public int Cooldown
		{
			get
			{
				return this.物品模板.Cooldown;
			}
		}

		
		public ItemData()
		{
			
			
		}

		
		public ItemData(GameItems 模板, CharacterData 来源, byte 容器, byte 位置, int 持久)
		{
			
			
			this.对应模板.V = 模板;
			this.生成来源.V = 来源;
			this.物品容器.V = 容器;
			this.物品位置.V = 位置;
			this.生成时间.V = MainProcess.CurrentTime;
			this.最大持久.V = this.物品模板.ItemLast;
			this.当前持久.V = Math.Min(持久, this.最大持久.V);
			GameDataGateway.ItemData表.AddData(this, true);
		}

		
		public override string ToString()
		{
			return this.Name;
		}

		
		public virtual byte[] 字节描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(ItemData.数据版本);
					BinaryWriter binaryWriter2 = binaryWriter;
					CharacterData v = this.生成来源.V;
					binaryWriter2.Write((v != null) ? v.数据索引.V : 0);
					binaryWriter.Write(ComputingClass.时间转换(this.生成时间.V));
					binaryWriter.Write(this.对应模板.V.Id);
					binaryWriter.Write(this.物品容器.V);
					binaryWriter.Write(this.物品位置.V);
					binaryWriter.Write(this.当前持久.V);
					binaryWriter.Write(this.最大持久.V);
					binaryWriter.Write(this.IsBound ? 10 : 0);
					binaryWriter.Write(0);
					binaryWriter.Write(0);
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
		public virtual byte[] 字节描述(int 数量)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(ItemData.数据版本);
					BinaryWriter binaryWriter2 = binaryWriter;
					CharacterData v = this.生成来源.V;
					binaryWriter2.Write((v != null) ? v.数据索引.V : 0);
					binaryWriter.Write(ComputingClass.时间转换(this.生成时间.V));
					binaryWriter.Write(this.对应模板.V.Id);
					binaryWriter.Write(this.物品容器.V);
					binaryWriter.Write(this.物品位置.V);
					binaryWriter.Write(数量);
					binaryWriter.Write(this.最大持久.V);
					binaryWriter.Write(this.IsBound ? 10 : 0);
					binaryWriter.Write(0);
					binaryWriter.Write(0);
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
		static ItemData()
		{
			
			ItemData.数据版本 = 14;
		}

		
		public static byte 数据版本;

		
		public readonly DataMonitor<GameItems> 对应模板;

		
		public readonly DataMonitor<DateTime> 生成时间;

		
		public readonly DataMonitor<CharacterData> 生成来源;

		
		public readonly DataMonitor<int> 当前持久;

		
		public readonly DataMonitor<int> 最大持久;

		
		public readonly DataMonitor<byte> 物品容器;

		
		public readonly DataMonitor<byte> 物品位置;

		
		public int PurchaseId;
	}
}
