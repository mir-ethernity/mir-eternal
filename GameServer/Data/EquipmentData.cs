using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameServer.Templates;

namespace GameServer.Data
{
	
	public class EquipmentData : ItemData
	{
		
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0000531F File Offset: 0x0000351F
		public EquipmentItem 装备模板
		{
			get
			{
				return base.物品模板 as EquipmentItem;
			}
		}

		
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x00026D44 File Offset: 0x00024F44
		public int 装备战力
		{
			get
			{
				if (this.装备模板.Type == ItemType.武器)
				{
					int num = (int)((long)(this.装备模板.BasicPowerCombat * (int)(this.幸运等级.V + 20)) * 1717986919L >> 32 >> 3);
					int num2 = (int)(this.Sacred伤害.V * 3 + this.升级Attack.V * 5 + this.升级Magic.V * 5 + this.升级Taoism.V * 5 + this.升级Needle.V * 5 + this.升级Archery.V * 5);
					int num3 = this.随机Stat.Sum((RandomStats x) => x.CombatBonus);
					return num + num2 + num3;
				}
				int num4 = 0;
				switch (this.装备模板.EquipSet)
				{
				case GameEquipmentSet.祖玛装备:
				{
					ItemType Type = this.装备模板.Type;
					if (Type != ItemType.衣服)
					{
						if (Type - ItemType.腰带 <= 1 || Type == ItemType.头盔)
						{
							num4 = (int)(2 * this.升级次数.V);
						}
					}
					else
					{
						num4 = (int)(4 * this.升级次数.V);
					}
					break;
				}
				case GameEquipmentSet.赤月装备:
				{
					ItemType Type = this.装备模板.Type;
					if (Type != ItemType.衣服)
					{
						if (Type - ItemType.腰带 <= 1 || Type == ItemType.头盔)
						{
							num4 = (int)(4 * this.升级次数.V);
						}
					}
					else
					{
						num4 = (int)(6 * this.升级次数.V);
					}
					break;
				}
				case GameEquipmentSet.魔龙装备:
				{
					ItemType Type = this.装备模板.Type;
					if (Type != ItemType.衣服)
					{
						if (Type - ItemType.腰带 <= 1 || Type == ItemType.头盔)
						{
							num4 = (int)(5 * this.升级次数.V);
						}
					}
					else
					{
						num4 = (int)(8 * this.升级次数.V);
					}
					break;
				}
				case GameEquipmentSet.苍月装备:
				{
					ItemType Type = this.装备模板.Type;
					if (Type != ItemType.衣服)
					{
						if (Type - ItemType.腰带 <= 1 || Type == ItemType.头盔)
						{
							num4 = (int)(7 * this.升级次数.V);
						}
					}
					else
					{
						num4 = (int)(11 * this.升级次数.V);
					}
					break;
				}
				case GameEquipmentSet.星王装备:
					if (this.装备模板.Type == ItemType.衣服)
					{
						num4 = (int)(13 * this.升级次数.V);
					}
					break;
				case GameEquipmentSet.神秘装备:
				case GameEquipmentSet.城主装备:
				{
					ItemType Type = this.装备模板.Type;
					if (Type != ItemType.衣服)
					{
						if (Type - ItemType.腰带 <= 1 || Type == ItemType.头盔)
						{
							num4 = (int)(9 * this.升级次数.V);
						}
					}
					else
					{
						num4 = (int)(13 * this.升级次数.V);
					}
					break;
				}
				}
				int num5 = this.孔洞颜色.Count * 10;
				foreach (GameItems 游戏物品 in this.镶嵌灵石.Values)
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
												goto IL_18E4;
											}
											else
											{
												if (!(Name == "精绿灵石5级"))
												{
													continue;
												}
												goto IL_1885;
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
												goto IL_1991;
											}
											else
											{
												if (!(Name == "透蓝灵石1级"))
												{
													continue;
												}
												goto IL_19DC;
											}
										}
										else
										{
											if (!(Name == "精绿灵石9级"))
											{
												continue;
											}
											goto IL_1954;
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
											goto IL_1A0A;
										}
										else
										{
											if (!(Name == "驭朱灵石1级"))
											{
												continue;
											}
											goto IL_19DC;
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
											goto IL_19F3;
										}
										else
										{
											if (!(Name == "狂热幻彩灵石10级"))
											{
												continue;
											}
											goto IL_19F3;
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
											goto IL_1937;
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
											goto IL_19F3;
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
										goto IL_1A0A;
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
										goto IL_1954;
									}
									else
									{
										if (!(Name == "命朱灵石7级"))
										{
											continue;
										}
										goto IL_1937;
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
										goto IL_1A0A;
									}
									else
									{
										if (!(Name == "透蓝灵石10级"))
										{
											continue;
										}
										goto IL_19F3;
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
											goto IL_1885;
										}
										else
										{
											if (!(Name == "韧紫灵石1级"))
											{
												continue;
											}
											goto IL_19DC;
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
											goto IL_19F3;
										}
										else
										{
											if (!(Name == "透蓝灵石6级"))
											{
												continue;
											}
											goto IL_19A8;
										}
									}
									else
									{
										if (!(Name == "新阳灵石3级"))
										{
											continue;
										}
										goto IL_1A0A;
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
										goto IL_18E4;
									}
									else
									{
										if (!(Name == "蔚蓝灵石9级"))
										{
											continue;
										}
										goto IL_1954;
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
										goto IL_1885;
									}
									else
									{
										if (!(Name == "抵御幻彩灵石10级"))
										{
											continue;
										}
										goto IL_19F3;
									}
								}
								else
								{
									if (!(Name == "蔚蓝灵石5级"))
									{
										continue;
									}
									goto IL_1885;
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
										goto IL_19DC;
									}
									else
									{
										if (!(Name == "驭朱灵石2级"))
										{
											continue;
										}
										goto IL_18E4;
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
										goto IL_1954;
									}
									else
									{
										if (!(Name == "抵御幻彩灵石6级"))
										{
											continue;
										}
										goto IL_19A8;
									}
								}
								else
								{
									if (!(Name == "抵御幻彩灵石9级"))
									{
										continue;
									}
									goto IL_1954;
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
									goto IL_1885;
								}
								else
								{
									if (!(Name == "橙黄灵石2级"))
									{
										continue;
									}
									goto IL_18E4;
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
									goto IL_1991;
								}
								else
								{
									if (!(Name == "进击幻彩灵石10级"))
									{
										continue;
									}
									goto IL_19F3;
								}
							}
							else
							{
								if (!(Name == "赤褐灵石7级"))
								{
									continue;
								}
								goto IL_1937;
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
											goto IL_19A8;
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
											goto IL_1A0A;
										}
										else
										{
											if (!(Name == "命朱灵石10级"))
											{
												continue;
											}
											goto IL_19F3;
										}
									}
									else
									{
										if (!(Name == "进击幻彩灵石5级"))
										{
											continue;
										}
										goto IL_1885;
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
										goto IL_1A0A;
									}
									else
									{
										if (!(Name == "赤褐灵石1级"))
										{
											continue;
										}
										goto IL_19DC;
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
										goto IL_1991;
									}
									else
									{
										if (!(Name == "盈绿灵石4级"))
										{
											continue;
										}
										goto IL_1991;
									}
								}
								else
								{
									if (!(Name == "盈绿灵石6级"))
									{
										continue;
									}
									goto IL_19A8;
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
										goto IL_19A8;
									}
									else
									{
										if (!(Name == "纯紫灵石1级"))
										{
											continue;
										}
										goto IL_19DC;
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
										goto IL_1991;
									}
									else
									{
										if (!(Name == "蔚蓝灵石6级"))
										{
											continue;
										}
										goto IL_19A8;
									}
								}
								else
								{
									if (!(Name == "蔚蓝灵石3级"))
									{
										continue;
									}
									goto IL_1A0A;
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
									goto IL_1A0A;
								}
								else
								{
									if (!(Name == "命朱灵石4级"))
									{
										continue;
									}
									goto IL_1991;
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
									goto IL_18E4;
								}
								else
								{
									if (!(Name == "守阳灵石10级"))
									{
										continue;
									}
									goto IL_19F3;
								}
							}
							else
							{
								if (!(Name == "进击幻彩灵石6级"))
								{
									continue;
								}
								goto IL_19A8;
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
										goto IL_19A8;
									}
									else
									{
										if (!(Name == "橙黄灵石3级"))
										{
											continue;
										}
										goto IL_1A0A;
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
										goto IL_1885;
									}
									else
									{
										if (!(Name == "纯紫灵石2级"))
										{
											continue;
										}
										goto IL_18E4;
									}
								}
								else
								{
									if (!(Name == "橙黄灵石4级"))
									{
										continue;
									}
									goto IL_1991;
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
									goto IL_1A0A;
								}
								else
								{
									if (!(Name == "进击幻彩灵石4级"))
									{
										continue;
									}
									goto IL_1991;
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
									goto IL_1885;
								}
							}
							else
							{
								if (!(Name == "赤褐灵石6级"))
								{
									continue;
								}
								goto IL_19A8;
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
									goto IL_1937;
								}
								else
								{
									if (!(Name == "狂热幻彩灵石1级"))
									{
										continue;
									}
									goto IL_19DC;
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
									goto IL_19DC;
								}
								else
								{
									if (!(Name == "精绿灵石7级"))
									{
										continue;
									}
									goto IL_1937;
								}
							}
							else
							{
								if (!(Name == "纯紫灵石7级"))
								{
									continue;
								}
								goto IL_1937;
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
								goto IL_18E4;
							}
							else
							{
								if (!(Name == "透蓝灵石9级"))
								{
									continue;
								}
								goto IL_1954;
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
								goto IL_19F3;
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
							goto IL_1885;
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
											goto IL_19A8;
										}
										else
										{
											if (!(Name == "纯紫灵石9级"))
											{
												continue;
											}
											goto IL_1954;
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
											goto IL_1885;
										}
										else
										{
											if (!(Name == "抵御幻彩灵石3级"))
											{
												continue;
											}
											goto IL_1A0A;
										}
									}
									else
									{
										if (!(Name == "抵御幻彩灵石4级"))
										{
											continue;
										}
										goto IL_1991;
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
										goto IL_19A8;
									}
									else
									{
										if (!(Name == "韧紫灵石7级"))
										{
											continue;
										}
										goto IL_1937;
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
										goto IL_19DC;
									}
								}
								else
								{
									if (!(Name == "新阳灵石6级"))
									{
										continue;
									}
									goto IL_19A8;
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
										goto IL_1991;
									}
									else
									{
										if (!(Name == "透蓝灵石3级"))
										{
											continue;
										}
										goto IL_1A0A;
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
										goto IL_1991;
									}
									else
									{
										if (!(Name == "驭朱灵石7级"))
										{
											continue;
										}
										goto IL_1937;
									}
								}
								else
								{
									if (!(Name == "命朱灵石9级"))
									{
										continue;
									}
									goto IL_1954;
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
									goto IL_1885;
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
									goto IL_1991;
								}
								else
								{
									if (!(Name == "盈绿灵石10级"))
									{
										continue;
									}
									goto IL_19F3;
								}
							}
							else
							{
								if (!(Name == "抵御幻彩灵石2级"))
								{
									continue;
								}
								goto IL_18E4;
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
										goto IL_19A8;
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
										goto IL_18E4;
									}
									else
									{
										if (!(Name == "深灰灵石2级"))
										{
											continue;
										}
										goto IL_18E4;
									}
								}
								else
								{
									if (!(Name == "深灰灵石7级"))
									{
										continue;
									}
									goto IL_1937;
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
									goto IL_19A8;
								}
								else
								{
									if (!(Name == "驭朱灵石5级"))
									{
										continue;
									}
									goto IL_1885;
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
									goto IL_1885;
								}
								else
								{
									if (!(Name == "赤褐灵石2级"))
									{
										continue;
									}
									goto IL_18E4;
								}
							}
							else
							{
								if (!(Name == "赤褐灵石9级"))
								{
									continue;
								}
								goto IL_1954;
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
									goto IL_1937;
								}
								else
								{
									if (!(Name == "盈绿灵石1级"))
									{
										continue;
									}
									goto IL_19DC;
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
									goto IL_1954;
								}
								else
								{
									if (!(Name == "新阳灵石2级"))
									{
										continue;
									}
									goto IL_18E4;
								}
							}
							else
							{
								if (!(Name == "新阳灵石7级"))
								{
									continue;
								}
								goto IL_1937;
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
								goto IL_19DC;
							}
							else
							{
								if (!(Name == "深灰灵石10级"))
								{
									continue;
								}
								goto IL_19F3;
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
								goto IL_1885;
							}
							else
							{
								if (!(Name == "进击幻彩灵石2级"))
								{
									continue;
								}
								goto IL_18E4;
							}
						}
						else
						{
							if (!(Name == "蔚蓝灵石7级"))
							{
								continue;
							}
							goto IL_1937;
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
										goto IL_19DC;
									}
									else
									{
										if (!(Name == "守阳灵石9级"))
										{
											continue;
										}
										goto IL_1954;
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
										goto IL_1954;
									}
									else
									{
										if (!(Name == "盈绿灵石9级"))
										{
											continue;
										}
										goto IL_1954;
									}
								}
								else
								{
									if (!(Name == "橙黄灵石7级"))
									{
										continue;
									}
									goto IL_1937;
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
									goto IL_19DC;
								}
								else
								{
									if (!(Name == "纯紫灵石6级"))
									{
										continue;
									}
									goto IL_19A8;
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
									goto IL_19DC;
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
									goto IL_1937;
								}
								else
								{
									if (!(Name == "进击幻彩灵石9级"))
									{
										continue;
									}
									goto IL_1954;
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
									goto IL_1A0A;
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
								goto IL_1954;
							}
							else
							{
								if (!(Name == "赤褐灵石4级"))
								{
									continue;
								}
								goto IL_1991;
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
								goto IL_19F3;
							}
							else
							{
								if (!(Name == "狂热幻彩灵石5级"))
								{
									continue;
								}
								goto IL_1885;
							}
						}
						else
						{
							if (!(Name == "狂热幻彩灵石2级"))
							{
								continue;
							}
							goto IL_18E4;
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
									goto IL_1991;
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
									goto IL_19F3;
								}
								else
								{
									if (!(Name == "深灰灵石3级"))
									{
										continue;
									}
									goto IL_1A0A;
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
								goto IL_18E4;
							}
							else
							{
								if (!(Name == "进击幻彩灵石1级"))
								{
									continue;
								}
								goto IL_19DC;
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
								goto IL_1937;
							}
							else
							{
								if (!(Name == "新阳灵石10级"))
								{
									continue;
								}
								goto IL_19F3;
							}
						}
						else
						{
							if (Name == "纯紫灵石5级")
							{
								goto IL_1885;
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
								goto IL_1991;
							}
							else
							{
								if (Name == "韧紫灵石2级")
								{
									goto IL_18E4;
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
								goto IL_1A0A;
							}
							else
							{
								if (Name == "透蓝灵石7级")
								{
									goto IL_1937;
								}
								continue;
							}
						}
						else
						{
							if (Name == "韧紫灵石9级")
							{
								goto IL_1954;
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
								goto IL_1991;
							}
							continue;
						}
						else
						{
							if (Name == "狂热幻彩灵石6级")
							{
								goto IL_19A8;
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
								goto IL_19DC;
							}
							continue;
						}
						else
						{
							if (Name == "驭朱灵石10级")
							{
								goto IL_19F3;
							}
							continue;
						}
					}
					else
					{
						if (Name == "纯紫灵石3级")
						{
							goto IL_1A0A;
						}
						continue;
					}
					num5 += 80;
					continue;
					IL_1885:
					num5 += 50;
					continue;
					IL_18E4:
					num5 += 20;
					continue;
					IL_1937:
					num5 += 70;
					continue;
					IL_1954:
					num5 += 90;
					continue;
					IL_1991:
					num5 += 40;
					continue;
					IL_19A8:
					num5 += 60;
					continue;
					IL_19DC:
					num5 += 10;
					continue;
					IL_19F3:
					num5 += 100;
					continue;
					IL_1A0A:
					num5 += 30;
				}
				int num7 = this.随机Stat.Sum((RandomStats x) => x.CombatBonus);
				return this.装备模板.BasicPowerCombat + num4 + num7 + num5;
			}
		}

		
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x000287D8 File Offset: 0x000269D8
		public int 修理费用
		{
			get
			{
				int value = this.最大持久.V - this.当前持久.V;
				decimal d = ((EquipmentItem)this.对应模板.V).RepairCost;
				decimal d2 = ((EquipmentItem)this.对应模板.V).ItemLast * 1000m;
				return (int)(d / d2 * value);
			}
		}

		
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00028858 File Offset: 0x00026A58
		public int 特修费用
		{
			get
			{
				decimal d = this.最大持久.V - this.当前持久.V;
				decimal d2 = ((EquipmentItem)this.对应模板.V).SpecialRepairCost;
				decimal d3 = ((EquipmentItem)this.对应模板.V).ItemLast * 1000m;
				return (int)(d2 / d3 * d * CustomClass.装备特修折扣 * 1.15m);
			}
		}

		
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0000532C File Offset: 0x0000352C
		public int NeedAttack
		{
			get
			{
				return ((EquipmentItem)base.物品模板).NeedAttack;
			}
		}

		
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x0000533E File Offset: 0x0000353E
		public int NeedMagic
		{
			get
			{
				return ((EquipmentItem)base.物品模板).NeedMagic;
			}
		}

		
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x00005350 File Offset: 0x00003550
		public int NeedTaoism
		{
			get
			{
				return ((EquipmentItem)base.物品模板).NeedTaoism;
			}
		}

		
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x00005362 File Offset: 0x00003562
		public int NeedAcupuncture
		{
			get
			{
				return ((EquipmentItem)base.物品模板).NeedAcupuncture;
			}
		}

		
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x00005374 File Offset: 0x00003574
		public int NeedArchery
		{
			get
			{
				return ((EquipmentItem)base.物品模板).NeedArchery;
			}
		}

		
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x000051CE File Offset: 0x000033CE
		public string 装备名字
		{
			get
			{
				return base.物品模板.Name;
			}
		}

		
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x00005386 File Offset: 0x00003586
		public bool DisableDismount
		{
			get
			{
				return ((EquipmentItem)this.对应模板.V).DisableDismount;
			}
		}

		
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x0000539D File Offset: 0x0000359D
		public bool CanRepair
		{
			get
			{
				return base.PersistType == PersistentItemType.装备;
			}
		}

		
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x000288FC File Offset: 0x00026AFC
		public int 传承材料
		{
			get
			{
				switch (base.Id)
				{
				case 99900022:
					return 21001;
				case 99900023:
					return 21002;
				case 99900024:
					return 21003;
				case 99900025:
					return 21001;
				case 99900026:
					return 21001;
				case 99900027:
					return 21003;
				case 99900028:
					return 21002;
				case 99900029:
					return 21002;
				case 99900030:
					return 21001;
				case 99900031:
					return 21003;
				case 99900032:
					return 21001;
				case 99900033:
					return 21002;
				case 99900037:
					return 21001;
				case 99900038:
					return 21003;
				case 99900039:
					return 21002;
				case 99900044:
					return 21003;
				case 99900045:
					return 21001;
				case 99900046:
					return 21002;
				case 99900047:
					return 21003;
				case 99900048:
					return 21001;
				case 99900049:
					return 21003;
				case 99900050:
					return 21002;
				case 99900055:
					return 21004;
				case 99900056:
					return 21004;
				case 99900057:
					return 21004;
				case 99900058:
					return 21004;
				case 99900059:
					return 21004;
				case 99900060:
					return 21004;
				case 99900061:
					return 21004;
				case 99900062:
					return 21004;
				case 99900063:
					return 21002;
				case 99900064:
					return 21003;
				case 99900074:
					return 21005;
				case 99900076:
					return 21005;
				case 99900077:
					return 21005;
				case 99900078:
					return 21005;
				case 99900079:
					return 21005;
				case 99900080:
					return 21005;
				case 99900081:
					return 21005;
				case 99900082:
					return 21005;
				case 99900104:
					return 21006;
				case 99900105:
					return 21006;
				case 99900106:
					return 21006;
				case 99900107:
					return 21006;
				case 99900108:
					return 21006;
				case 99900109:
					return 21006;
				case 99900110:
					return 21006;
				case 99900111:
					return 21006;
				}
				return 0;
			}
		}

		
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x00028BAC File Offset: 0x00026DAC
		public string StatDescription
		{
			get
			{
				string text = "";
				Dictionary<GameObjectStats, int> dictionary = new Dictionary<GameObjectStats, int>();
				foreach (RandomStats 随机Stat in this.随机Stat)
				{
					dictionary[随机Stat.Stat] = 随机Stat.Value;
				}
				if (dictionary.ContainsKey(GameObjectStats.MinAttack) || dictionary.ContainsKey(GameObjectStats.MaxAttack))
				{
					int num;
					int num2;
					text += string.Format("\nAttack{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinAttack, out num) ? num : 0, dictionary.TryGetValue(GameObjectStats.MaxAttack, out num2) ? num2 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.MinMagic) || dictionary.ContainsKey(GameObjectStats.MaxMagic))
				{
					int num3;
					int num4;
					text += string.Format("\nMagic{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinMagic, out num3) ? num3 : 0, dictionary.TryGetValue(GameObjectStats.MaxMagic, out num4) ? num4 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.Minimalist) || dictionary.ContainsKey(GameObjectStats.GreatestTaoism))
				{
					int num5;
					int num6;
					text += string.Format("\nTaoism{0}-{1}", dictionary.TryGetValue(GameObjectStats.Minimalist, out num5) ? num5 : 0, dictionary.TryGetValue(GameObjectStats.GreatestTaoism, out num6) ? num6 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.MinNeedle) || dictionary.ContainsKey(GameObjectStats.MaxNeedle))
				{
					int num7;
					int num8;
					text += string.Format("\nNeedle{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinNeedle, out num7) ? num7 : 0, dictionary.TryGetValue(GameObjectStats.MaxNeedle, out num8) ? num8 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.MinBow) || dictionary.ContainsKey(GameObjectStats.MaxBow))
				{
					int num9;
					int num10;
					text += string.Format("\nArchery{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinBow, out num9) ? num9 : 0, dictionary.TryGetValue(GameObjectStats.MaxBow, out num10) ? num10 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.MinDef) || dictionary.ContainsKey(GameObjectStats.MaxDef))
				{
					int num11;
					int num12;
					text += string.Format("\n防御{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinDef, out num11) ? num11 : 0, dictionary.TryGetValue(GameObjectStats.MaxDef, out num12) ? num12 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.MinMagicDef) || dictionary.ContainsKey(GameObjectStats.MaxMagicDef))
				{
					int num13;
					int num14;
					text += string.Format("\n魔防{0}-{1}", dictionary.TryGetValue(GameObjectStats.MinMagicDef, out num13) ? num13 : 0, dictionary.TryGetValue(GameObjectStats.MaxMagicDef, out num14) ? num14 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.PhysicallyAccurate))
				{
					int num15;
					text += string.Format("\n准确度{0}", dictionary.TryGetValue(GameObjectStats.PhysicallyAccurate, out num15) ? num15 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.PhysicalAgility))
				{
					int num16;
					text += string.Format("\n敏捷度{0}", dictionary.TryGetValue(GameObjectStats.PhysicalAgility, out num16) ? num16 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength))
				{
					int num17;
					text += string.Format("\n体力值{0}", dictionary.TryGetValue(GameObjectStats.MaxPhysicalStrength, out num17) ? num17 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.MaxMagic2))
				{
					int num18;
					text += string.Format("\n法力值{0}", dictionary.TryGetValue(GameObjectStats.MaxMagic2, out num18) ? num18 : 0);
				}
				if (dictionary.ContainsKey(GameObjectStats.MagicDodge))
				{
					int num19;
					text += string.Format("\nMagicDodge{0}%", (dictionary.TryGetValue(GameObjectStats.MagicDodge, out num19) ? num19 : 0) / 100);
				}
				if (dictionary.ContainsKey(GameObjectStats.中毒躲避))
				{
					int num20;
					text += string.Format("\n中毒躲避{0}%", (dictionary.TryGetValue(GameObjectStats.中毒躲避, out num20) ? num20 : 0) / 100);
				}
				if (dictionary.ContainsKey(GameObjectStats.幸运等级))
				{
					int num21;
					text += string.Format("\n幸运+{0}", dictionary.TryGetValue(GameObjectStats.幸运等级, out num21) ? num21 : 0);
				}
				return text;
			}
		}

		
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x000053A8 File Offset: 0x000035A8
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x000053D0 File Offset: 0x000035D0
		public InscriptionSkill 第一铭文
		{
			get
			{
				if (this.当前铭栏.V == 0)
				{
					return this.铭文技能[0];
				}
				return this.铭文技能[2];
			}
			set
			{
				if (this.当前铭栏.V == 0)
				{
					this.铭文技能[0] = value;
					return;
				}
				this.铭文技能[2] = value;
			}
		}

		
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x000053FA File Offset: 0x000035FA
		// (set) Token: 0x06000598 RID: 1432 RVA: 0x00005422 File Offset: 0x00003622
		public InscriptionSkill 第二铭文
		{
			get
			{
				if (this.当前铭栏.V == 0)
				{
					return this.铭文技能[1];
				}
				return this.铭文技能[3];
			}
			set
			{
				if (this.当前铭栏.V == 0)
				{
					this.铭文技能[1] = value;
					return;
				}
				this.铭文技能[3] = value;
			}
		}

		
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x00028F9C File Offset: 0x0002719C
		// (set) Token: 0x0600059A RID: 1434 RVA: 0x00029034 File Offset: 0x00027234
		public InscriptionSkill 最优铭文
		{
			get
			{
				if (this.当前铭栏.V == 0)
				{
					if (this.铭文技能[0].Quality < this.铭文技能[1].Quality)
					{
						return this.铭文技能[1];
					}
					return this.铭文技能[0];
				}
				else
				{
					if (this.铭文技能[2].Quality < this.铭文技能[3].Quality)
					{
						return this.铭文技能[3];
					}
					return this.铭文技能[2];
				}
			}
			set
			{
				if (this.当前铭栏.V == 0)
				{
					if (this.铭文技能[0].Quality >= this.铭文技能[1].Quality)
					{
						this.铭文技能[0] = value;
						return;
					}
					this.铭文技能[1] = value;
					return;
				}
				else
				{
					if (this.铭文技能[2].Quality >= this.铭文技能[3].Quality)
					{
						this.铭文技能[2] = value;
						return;
					}
					this.铭文技能[3] = value;
					return;
				}
			}
		}

		
		// (get) Token: 0x0600059B RID: 1435 RVA: 0x000290D0 File Offset: 0x000272D0
		// (set) Token: 0x0600059C RID: 1436 RVA: 0x00029168 File Offset: 0x00027368
		public InscriptionSkill 最差铭文
		{
			get
			{
				if (this.当前铭栏.V == 0)
				{
					if (this.铭文技能[0].Quality >= this.铭文技能[1].Quality)
					{
						return this.铭文技能[1];
					}
					return this.铭文技能[0];
				}
				else
				{
					if (this.铭文技能[2].Quality >= this.铭文技能[3].Quality)
					{
						return this.铭文技能[3];
					}
					return this.铭文技能[2];
				}
			}
			set
			{
				if (this.当前铭栏.V == 0)
				{
					if (this.铭文技能[0].Quality < this.铭文技能[1].Quality)
					{
						this.铭文技能[0] = value;
						return;
					}
					this.铭文技能[1] = value;
					return;
				}
				else
				{
					if (this.铭文技能[2].Quality < this.铭文技能[3].Quality)
					{
						this.铭文技能[2] = value;
						return;
					}
					this.铭文技能[3] = value;
					return;
				}
			}
		}

		
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x0000544C File Offset: 0x0000364C
		// (set) Token: 0x0600059E RID: 1438 RVA: 0x00005472 File Offset: 0x00003672
		public int 双铭文点
		{
			get
			{
				if (this.当前铭栏.V == 0)
				{
					return this.洗练数一.V;
				}
				return this.洗练数二.V;
			}
			set
			{
				if (this.当前铭栏.V == 0)
				{
					this.洗练数一.V = value;
					return;
				}
				this.洗练数二.V = value;
			}
		}

		
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x00029204 File Offset: 0x00027404
		public Dictionary<GameObjectStats, int> 装备Stat
		{
			get
			{
				Dictionary<GameObjectStats, int> dictionary = new Dictionary<GameObjectStats, int>();
				if (this.装备模板.MinAttack != 0)
				{
					dictionary[GameObjectStats.MinAttack] = this.装备模板.MinAttack;
				}
				if (this.装备模板.MaxAttack != 0)
				{
					dictionary[GameObjectStats.MaxAttack] = this.装备模板.MaxAttack;
				}
				if (this.装备模板.MinMagic != 0)
				{
					dictionary[GameObjectStats.MinMagic] = this.装备模板.MinMagic;
				}
				if (this.装备模板.MaxMagic != 0)
				{
					dictionary[GameObjectStats.MaxMagic] = this.装备模板.MaxMagic;
				}
				if (this.装备模板.Minimalist != 0)
				{
					dictionary[GameObjectStats.Minimalist] = this.装备模板.Minimalist;
				}
				if (this.装备模板.GreatestTaoism != 0)
				{
					dictionary[GameObjectStats.GreatestTaoism] = this.装备模板.GreatestTaoism;
				}
				if (this.装备模板.MinNeedle != 0)
				{
					dictionary[GameObjectStats.MinNeedle] = this.装备模板.MinNeedle;
				}
				if (this.装备模板.MaxNeedle != 0)
				{
					dictionary[GameObjectStats.MaxNeedle] = this.装备模板.MaxNeedle;
				}
				if (this.装备模板.MinBow != 0)
				{
					dictionary[GameObjectStats.MinBow] = this.装备模板.MinBow;
				}
				if (this.装备模板.MaxBow != 0)
				{
					dictionary[GameObjectStats.MaxBow] = this.装备模板.MaxBow;
				}
				if (this.装备模板.MinDef != 0)
				{
					dictionary[GameObjectStats.MinDef] = this.装备模板.MinDef;
				}
				if (this.装备模板.MaxDef != 0)
				{
					dictionary[GameObjectStats.MaxDef] = this.装备模板.MaxDef;
				}
				if (this.装备模板.MinMagicDef != 0)
				{
					dictionary[GameObjectStats.MinMagicDef] = this.装备模板.MinMagicDef;
				}
				if (this.装备模板.MaxMagicDef != 0)
				{
					dictionary[GameObjectStats.MaxMagicDef] = this.装备模板.MaxMagicDef;
				}
				if (this.装备模板.MaxPhysicalStrength != 0)
				{
					dictionary[GameObjectStats.MaxPhysicalStrength] = this.装备模板.MaxPhysicalStrength;
				}
				if (this.装备模板.MaxMagic2 != 0)
				{
					dictionary[GameObjectStats.MaxMagic2] = this.装备模板.MaxMagic2;
				}
				if (this.装备模板.AttackSpeed != 0)
				{
					dictionary[GameObjectStats.AttackSpeed] = this.装备模板.AttackSpeed;
				}
				if (this.装备模板.MagicDodge != 0)
				{
					dictionary[GameObjectStats.MagicDodge] = this.装备模板.MagicDodge;
				}
				if (this.装备模板.PhysicallyAccurate != 0)
				{
					dictionary[GameObjectStats.PhysicallyAccurate] = this.装备模板.PhysicallyAccurate;
				}
				if (this.装备模板.PhysicalAgility != 0)
				{
					dictionary[GameObjectStats.PhysicalAgility] = this.装备模板.PhysicalAgility;
				}
				if (this.幸运等级.V != 0)
				{
					dictionary[GameObjectStats.幸运等级] = (dictionary.ContainsKey(GameObjectStats.幸运等级) ? (dictionary[GameObjectStats.幸运等级] + (int)this.幸运等级.V) : ((int)this.幸运等级.V));
				}
				if (this.升级Attack.V != 0)
				{
					dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + (int)this.升级Attack.V) : ((int)this.升级Attack.V));
				}
				if (this.升级Magic.V != 0)
				{
					dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + (int)this.升级Magic.V) : ((int)this.升级Magic.V));
				}
				if (this.升级Taoism.V != 0)
				{
					dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + (int)this.升级Taoism.V) : ((int)this.升级Taoism.V));
				}
				if (this.升级Needle.V != 0)
				{
					dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + (int)this.升级Needle.V) : ((int)this.升级Needle.V));
				}
				if (this.升级Archery.V != 0)
				{
					dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + (int)this.升级Archery.V) : ((int)this.升级Archery.V));
				}
				foreach (RandomStats 随机Stat in this.随机Stat.ToList<RandomStats>())
				{
					dictionary[随机Stat.Stat] = (dictionary.ContainsKey(随机Stat.Stat) ? (dictionary[随机Stat.Stat] + 随机Stat.Value) : 随机Stat.Value);
				}
				foreach (GameItems 游戏物品 in this.镶嵌灵石.Values)
				{
					int Id = 游戏物品.Id;
					if (Id <= 10324)
					{
						switch (Id)
						{
						case 10110:
							dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 1) : 1);
							break;
						case 10111:
							dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 2) : 2);
							break;
						case 10112:
							dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 3) : 3);
							break;
						case 10113:
							dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 4) : 4);
							break;
						case 10114:
							dictionary[GameObjectStats.GreatestTaoism] = (dictionary.ContainsKey(GameObjectStats.GreatestTaoism) ? (dictionary[GameObjectStats.GreatestTaoism] + 5) : 5);
							break;
						case 10115:
						case 10116:
						case 10117:
						case 10118:
						case 10119:
							break;
						case 10120:
							dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 5) : 5);
							break;
						case 10121:
							dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 10) : 10);
							break;
						case 10122:
							dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 15) : 15);
							break;
						case 10123:
							dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 20) : 20);
							break;
						case 10124:
							dictionary[GameObjectStats.MaxPhysicalStrength] = (dictionary.ContainsKey(GameObjectStats.MaxPhysicalStrength) ? (dictionary[GameObjectStats.MaxPhysicalStrength] + 25) : 25);
							break;
						default:
							switch (Id)
							{
							case 10220:
								dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 1) : 1);
								break;
							case 10221:
								dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 2) : 2);
								break;
							case 10222:
								dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 3) : 3);
								break;
							case 10223:
								dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 4) : 4);
								break;
							case 10224:
								dictionary[GameObjectStats.MaxDef] = (dictionary.ContainsKey(GameObjectStats.MaxDef) ? (dictionary[GameObjectStats.MaxDef] + 5) : 5);
								break;
							default:
								switch (Id)
								{
								case 10320:
									dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 1) : 1);
									break;
								case 10321:
									dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 2) : 2);
									break;
								case 10322:
									dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 3) : 3);
									break;
								case 10323:
									dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 4) : 4);
									break;
								case 10324:
									dictionary[GameObjectStats.MaxMagic] = (dictionary.ContainsKey(GameObjectStats.MaxMagic) ? (dictionary[GameObjectStats.MaxMagic] + 5) : 5);
									break;
								}
								break;
							}
							break;
						}
					}
					else if (Id <= 10524)
					{
						switch (Id)
						{
						case 10420:
							dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 1) : 1);
							break;
						case 10421:
							dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 2) : 2);
							break;
						case 10422:
							dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 3) : 3);
							break;
						case 10423:
							dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 4) : 4);
							break;
						case 10424:
							dictionary[GameObjectStats.MaxAttack] = (dictionary.ContainsKey(GameObjectStats.MaxAttack) ? (dictionary[GameObjectStats.MaxAttack] + 5) : 5);
							break;
						default:
							switch (Id)
							{
							case 10520:
								dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 1) : 1);
								break;
							case 10521:
								dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 2) : 2);
								break;
							case 10522:
								dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 3) : 3);
								break;
							case 10523:
								dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 4) : 4);
								break;
							case 10524:
								dictionary[GameObjectStats.MaxMagicDef] = (dictionary.ContainsKey(GameObjectStats.MaxMagicDef) ? (dictionary[GameObjectStats.MaxMagicDef] + 5) : 5);
								break;
							}
							break;
						}
					}
					else
					{
						switch (Id)
						{
						case 10620:
							dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 1) : 1);
							break;
						case 10621:
							dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 2) : 2);
							break;
						case 10622:
							dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 3) : 3);
							break;
						case 10623:
							dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 4) : 4);
							break;
						case 10624:
							dictionary[GameObjectStats.MaxNeedle] = (dictionary.ContainsKey(GameObjectStats.MaxNeedle) ? (dictionary[GameObjectStats.MaxNeedle] + 5) : 5);
							break;
						default:
							switch (Id)
							{
							case 10720:
								dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 1) : 1);
								break;
							case 10721:
								dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 2) : 2);
								break;
							case 10722:
								dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 3) : 3);
								break;
							case 10723:
								dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 4) : 4);
								break;
							case 10724:
								dictionary[GameObjectStats.MaxBow] = (dictionary.ContainsKey(GameObjectStats.MaxBow) ? (dictionary[GameObjectStats.MaxBow] + 5) : 5);
								break;
							}
							break;
						}
					}
				}
				return dictionary;
			}
		}

		
		public EquipmentData()
		{
			
			
		}

		
		public EquipmentData(EquipmentItem 模板, CharacterData 来源, byte 容器, byte 位置, bool 随机生成 = false)
		{
			
			
			this.对应模板.V = 模板;
			this.生成来源.V = 来源;
			this.物品容器.V = 容器;
			this.物品位置.V = 位置;
			this.生成时间.V = MainProcess.CurrentTime;
			this.物品状态.V = 1;
			this.最大持久.V = ((模板.PersistType == PersistentItemType.装备) ? (模板.ItemLast * 1000) : 模板.ItemLast);
			DataMonitor<int> 当前持久 = this.当前持久;
			int v;
			if (随机生成)
			{
				if (模板.PersistType == PersistentItemType.装备)
				{
					v = MainProcess.RandomNumber.Next(0, this.最大持久.V);
					goto IL_B8;
				}
			}
			v = this.最大持久.V;
			IL_B8:
			当前持久.V = v;
			if (随机生成 && 模板.PersistType == PersistentItemType.装备)
			{
				this.随机Stat.SetValue(GameServer.Templates.EquipmentStats.GenerateStats(base.物品类型, false));
			}
			GameDataGateway.EquipmentData表.AddData(this, true);
		}

		
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x00029E88 File Offset: 0x00028088
		public int 重铸所需灵气
		{
			get
			{
				switch (base.物品类型)
				{
				case ItemType.衣服:
				case ItemType.披风:
				case ItemType.腰带:
				case ItemType.鞋子:
				case ItemType.护肩:
				case ItemType.护腕:
				case ItemType.头盔:
					return 112003;
				case ItemType.项链:
				case ItemType.戒指:
				case ItemType.手镯:
				case ItemType.勋章:
				case ItemType.玉佩:
					return 112002;
				case ItemType.武器:
					return 112001;
				default:
					return 0;
				}
			}
		}

		
		public override byte[] 字节描述()
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
					binaryWriter.Write(base.IsBound ? 10 : 0);
					int num = 256 | (int)this.当前铭栏.V;
					if (this.双铭文栏.V)
					{
						num |= 512;
					}
					binaryWriter.Write((short)num);
					int num2 = 0;
					if (this.物品状态.V != 1)
					{
						num2 |= 1;
					}
					else if (this.随机Stat.Count != 0)
					{
						num2 |= 1;
					}
					else if (this.Sacred伤害.V != 0)
					{
						num2 |= 1;
					}
					if (this.随机Stat.Count >= 1)
					{
						num2 |= 2;
					}
					if (this.随机Stat.Count >= 2)
					{
						num2 |= 4;
					}
					if (this.随机Stat.Count >= 3)
					{
						num2 |= 8;
					}
					if (this.随机Stat.Count >= 4)
					{
						num2 |= 16;
					}
					if (this.幸运等级.V != 0)
					{
						num2 |= 2048;
					}
					if (this.升级次数.V != 0)
					{
						num2 |= 4096;
					}
					if (this.孔洞颜色.Count != 0)
					{
						num2 |= 8192;
					}
					if (this.镶嵌灵石[0] != null)
					{
						num2 |= 16384;
					}
					if (this.镶嵌灵石[1] != null)
					{
						num2 |= 32768;
					}
					if (this.镶嵌灵石[2] != null)
					{
						num2 |= 65536;
					}
					if (this.镶嵌灵石[3] != null)
					{
						num2 |= 131072;
					}
					if (this.Sacred伤害.V != 0)
					{
						num2 |= 4194304;
					}
					else if (this.圣石数量.V != 0)
					{
						num2 |= 4194304;
					}
					if (this.祈祷次数.V != 0)
					{
						num2 |= 8388608;
					}
					if (this.装备神佑.V)
					{
						num2 |= 33554432;
					}
					binaryWriter.Write(num2);
					if ((num2 & 1) != 0)
					{
						binaryWriter.Write(this.物品状态.V);
					}
					if ((num2 & 2) != 0)
					{
						binaryWriter.Write((ushort)this.随机Stat[0].StatId);
					}
					if ((num2 & 4) != 0)
					{
						binaryWriter.Write((ushort)this.随机Stat[1].StatId);
					}
					if ((num2 & 8) != 0)
					{
						binaryWriter.Write((ushort)this.随机Stat[2].StatId);
					}
					if ((num2 & 16) != 0)
					{
						binaryWriter.Write((ushort)this.随机Stat[3].StatId);
					}
					if ((num & 256) != 0)
					{
						int num3 = 0;
						if (this.铭文技能[0] != null)
						{
							num3 |= 1;
						}
						if (this.铭文技能[1] != null)
						{
							num3 |= 2;
						}
						binaryWriter.Write((short)num3);
						binaryWriter.Write(this.洗练数一.V * 10000);
						if ((num3 & 1) != 0)
						{
							binaryWriter.Write(this.铭文技能[0].Index);
						}
						if ((num3 & 2) != 0)
						{
							binaryWriter.Write(this.铭文技能[1].Index);
						}
					}
					if ((num & 512) != 0)
					{
						int num4 = 0;
						if (this.铭文技能[2] != null)
						{
							num4 |= 1;
						}
						if (this.铭文技能[3] != null)
						{
							num4 |= 2;
						}
						binaryWriter.Write((short)num4);
						binaryWriter.Write(this.洗练数二.V * 10000);
						if ((num4 & 1) != 0)
						{
							binaryWriter.Write(this.铭文技能[2].Index);
						}
						if ((num4 & 2) != 0)
						{
							binaryWriter.Write(this.铭文技能[3].Index);
						}
					}
					if ((num2 & 2048) != 0)
					{
						binaryWriter.Write(this.幸运等级.V);
					}
					if ((num2 & 4096) != 0)
					{
						binaryWriter.Write(this.升级次数.V);
						binaryWriter.Write(0);
						binaryWriter.Write(this.升级Attack.V);
						binaryWriter.Write(this.升级Magic.V);
						binaryWriter.Write(this.升级Taoism.V);
						binaryWriter.Write(this.升级Needle.V);
						binaryWriter.Write(this.升级Archery.V);
						binaryWriter.Write(new byte[3]);
						binaryWriter.Write(this.灵魂绑定.V);
					}
					if ((num2 & 8192) != 0)
					{
						binaryWriter.Write(new byte[]
						{
							(byte)this.孔洞颜色[0],
							(byte)this.孔洞颜色[1],
							(byte)this.孔洞颜色[2],
							(byte)this.孔洞颜色[3]
						});
					}
					if ((num2 & 16384) != 0)
					{
						binaryWriter.Write(this.镶嵌灵石[0].Id);
					}
					if ((num2 & 32768) != 0)
					{
						binaryWriter.Write(this.镶嵌灵石[1].Id);
					}
					if ((num2 & 65536) != 0)
					{
						binaryWriter.Write(this.镶嵌灵石[2].Id);
					}
					if ((num2 & 131072) != 0)
					{
						binaryWriter.Write(this.镶嵌灵石[3].Id);
					}
					if ((num2 & 524288) != 0)
					{
						binaryWriter.Write(0);
					}
					if ((num2 & 1048576) != 0)
					{
						binaryWriter.Write(0);
					}
					if ((num2 & 2097152) != 0)
					{
						binaryWriter.Write(0);
					}
					if ((num2 & 4194304) != 0)
					{
						binaryWriter.Write(this.Sacred伤害.V);
						binaryWriter.Write(this.圣石数量.V);
					}
					if ((num2 & 8388608) != 0)
					{
						binaryWriter.Write((int)this.祈祷次数.V);
					}
					if ((num2 & 33554432) != 0)
					{
						binaryWriter.Write(this.装备神佑.V);
					}
					if ((num2 & 67108864) != 0)
					{
						binaryWriter.Write(0);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
		public readonly DataMonitor<byte> 升级次数;

		
		public readonly DataMonitor<byte> 升级Attack;

		
		public readonly DataMonitor<byte> 升级Magic;

		
		public readonly DataMonitor<byte> 升级Taoism;

		
		public readonly DataMonitor<byte> 升级Needle;

		
		public readonly DataMonitor<byte> 升级Archery;

		
		public readonly DataMonitor<bool> 灵魂绑定;

		
		public readonly DataMonitor<byte> 祈祷次数;

		
		public readonly DataMonitor<sbyte> 幸运等级;

		
		public readonly DataMonitor<bool> 装备神佑;

		
		public readonly DataMonitor<byte> Sacred伤害;

		
		public readonly DataMonitor<ushort> 圣石数量;

		
		public readonly DataMonitor<bool> 双铭文栏;

		
		public readonly DataMonitor<byte> 当前铭栏;

		
		public readonly DataMonitor<int> 洗练数一;

		
		public readonly DataMonitor<int> 洗练数二;

		
		public readonly DataMonitor<byte> 物品状态;

		
		public readonly ListMonitor<RandomStats> 随机Stat;

		
		public readonly ListMonitor<EquipHoleColor> 孔洞颜色;

		
		public readonly MonitorDictionary<byte, InscriptionSkill> 铭文技能;

		
		public readonly MonitorDictionary<byte, GameItems> 镶嵌灵石;
	}
}
