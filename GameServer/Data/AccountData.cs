using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.Maps;
using GameServer.Networking;

namespace GameServer.Data
{
	
	[FastDataReturnAttribute(检索字段 = "Account")]
	public sealed class AccountData : GameData
	{
		
		public AccountData()
		{
			
			
		}

		
		public AccountData(string 账号)
		{
			
			
			this.Account.V = 账号;
			GameDataGateway.AccountData表.AddData(this, true);
		}

		
		public override string ToString()
		{
			DataMonitor<string> DataMonitor = this.Account;
			if (DataMonitor == null)
			{
				return null;
			}
			return DataMonitor.V;
		}

		
		public byte[] 角色列表描述()
		{
			// TODO: Method to send characters
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((byte)(Math.Min(4, this.角色列表.Count) + Math.Min(5, this.冻结列表.Count)));
					List<CharacterData> list = (from O in this.角色列表
					orderby O.当前等级.V descending
					select O).ToList();
					int num = 0;
					while (num < 4 && num < list.Count)
					{
						binaryWriter.Write(list[num].角色描述());
						num++;
					}
					List<CharacterData> list2 = (from O in this.冻结列表
												 orderby O.当前等级.V descending
					select O).ToList<CharacterData>();
					int num2 = 0;
					while (num2 < 5 && num2 < list2.Count)
					{
						binaryWriter.Write(list2[num2].角色描述());
						num2++;
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
		public byte[] 登录协议描述()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					byte[] buffer = new byte[]
					{
						51,
						53,
						54,
						50,
						50,
						54,
						50,
						55,
						48,
						52,
						0,
						48,
						49,
						0,
						49,
						102,
						102,
						50,
						54,
						48,
						58,
						54,
						53,
						58,
						100,
						102,
						58,
						48,
						51,
						0,
						85,
						76,
						83,
						50,
						49,
						45,
						100,
						54,
						97,
						48,
						55,
						53,
						51,
						50,
						48,
						48,
						55,
						49,
						52,
						56,
						102,
						48,
						98,
						98,
						55,
						57,
						100,
						100,
						50,
						102,
						100,
						56,
						56,
						56,
						55,
						1,
						129,
						110,
						6,
						0,
						0,
						6,
						0,
						0,
						0
					};
					byte[] buffer2 = new byte[]
					{
						50,
						48,
						50,
						48,
						45,
						48,
						49,
						45,
						48,
						49,
						0
					};
					byte[] buffer3 = new byte[]
					{
						120,
						156,
						237,
						86,
						59,
						110,
						20,
						65,
						16,
						237,
						157,
						239,
						50,
						179,
						59,
						179,
						44,
						31,
						131,
						140,
						192,
						194,
						214,
						26,
						97,
						176,
						64,
						32,
						35,
						65,
						128,
						64,
						150,
						3,
						50,
						156,
						131,
						8,
						200,
						56,
						5,
						4,
						136,
						115,
						144,
						56,
						224,
						14,
						16,
						112,
						19,
						18,
						14,
						192,
						1,
						76,
						213,
						206,
						123,
						204,
						219,
						150,
						109,
						132,
						64,
						50,
						193,
						150,
						84,
						170,
						238,
						234,
						250,
						119,
						87,
						205,
						132,
						16,
						194,
						48,
						156,
						12,
						141,
						225,
						33,
						224,
						147,
						172,
						107,
						91,
						95,
						151,
						61,
						161,
						72,
						67,
						216,
						31,
						132,
						80,
						224,
						204,
						237,
						23,
						71,
						200,
						57,
						228,
						199,
						156,
						57,
						239,
						172,
						97,
						98,
						184,
						98,
						88,
						33,
						206,
						22,
						242,
						35,
						224,
						24,
						114,
						126,
						62,
						193,
						126,
						12,
						217,
						18,
						248,
						0,
						57,
						184,
						252,
						121,
						248,
						42,
						65,
						223,
						66,
						239,
						161,
						225,
						11,
						240,
						92,
						223,
						115,
						219,
						16,
						27,
						142,
						219,
						240,
						93,
						194,
						94,
						1,
						191,
						99,
						145,
						217,
						130,
						111,
						231,
						191,
						52,
						180,
						82,
						132,
						51,
						134,
						25,
						228,
						115,
						156,
						93,
						150,
						156,
						175,
						192,
						70,
						14,
						27,
						5,
						244,
						26,
						201,
						91,
						107,
						84,
						137,
						92,
						17,
						173,
						47,
						64,
						199,
						233,
						69,
						232,
						84,
						160,
						87,
						141,
						78,
						225,
						135,
						122,
						172,
						117,
						22,
						221,
						65,
						34,
						186,
						25,
						226,
						243,
						250,
						237,
						138,
						172,
						214,
						216,
						109,
						124,
						77,
						123,
						63,
						151,
						32,
						115,
						14,
						116,
						132,
						154,
						150,
						160,
						158,
						223,
						166,
						196,
						80,
						131,
						95,
						8,
						210,
						127,
						35,
						107,
						214,
						156,
						50,
						57,
						226,
						41,
						37,
						166,
						20,
						50,
						228,
						205,
						243,
						73,
						186,
						28,
						82,
						32,
						227,
						166,
						236,
						90,
						84,
						95,
						167,
						45,
						234,
						197,
						123,
						112,
						222,
						93,
						185,
						123,
						214,
						201,
						207,
						118,
						68,
						167,
						68,
						76,
						181,
						196,
						77,
						125,
						198,
						79,
						228,
						187,
						208,
						156,
						86,
						100,
						61,
						149,
						24,
						27,
						145,
						107,
						228,
						156,
						121,
						150,
						56,
						79,
						128,
						206,
						163,
						254,
						76,
						222,
						21,
						177,
						16,
						89,
						223,
						95,
						147,
						187,
						172,
						192,
						155,
						128,
						186,
						204,
						80,
						114,
						78,
						34,
						221,
						4,
						185,
						100,
						216,
						183,
						178,
						207,
						36,
						78,
						230,
						50,
						183,
						147,
						119,
						247,
						151,
						70,
						181,
						103,
						158,
						113,
						205,
						72,
						153,
						59,
						243,
						159,
						98,
						61,
						188,
						209,
						235,
						233,
						27,
						90,
						23,
						59,
						90,
						131,
						86,
						222,
						2,
						253,
						191,
						182,
						245,
						170,
						225,
						253,
						176,
						216,
						31,
						140,
						141,
						241,
						243,
						110,
						53,
						246,
						70,
						234,
						78,
						63,
						122,
						87,
						79,
						12,
						111,
						73,
						126,
						148,
						245,
						253,
						65,
						210,
						197,
						51,
						146,
						248,
						247,
						144,
						219,
						77,
						121,
						7,
						236,
						85,
						222,
						221,
						18,
						150,
						240,
						183,
						240,
						52,
						44,
						206,
						56,
						127,
						91,
						183,
						177,
						183,
						150,
						154,
						247,
						194,
						189,
						208,
						245,
						195,
						231,
						172,
						147,
						221,
						10,
						125,
						79,
						108,
						98,
						189,
						143,
						181,
						235,
						207,
						128,
						218,
						119,
						149,
						232,
						176,
						119,
						180,
						247,
						56,
						195,
						138,
						223,
						224,
						232,
						24,
						126,
						114,
						2,
						191,
						140,
						246,
						238,
						235,
						99,
						210,
						247,
						102,
						19,
						233,
						220,
						9,
						221,
						28,
						96,
						76,
						223,
						195,
						226,
						44,
						160,
						220,
						14,
						232,
						99,
						195,
						117,
						177,
						173,
						223,
						69,
						206,
						12,
						157,
						77,
						180,
						49,
						11,
						253,
						92,
						204,
						163,
						90,
						176,
						207,
						253,
						123,
						240,
						70,
						244,
						28,
						86,
						67,
						byte.MaxValue,
						157,
						113,
						190,
						207,
						142,
						90,
						144,
						115,
						90,
						103,
						211,
						124,
						70,
						74,
						205,
						127,
						205,
						161,
						65,
						71,
						63,
						36,
						253,
						76,
						173,
						81,
						147,
						54,
						178,
						113,
						24,
						129,
						206,
						70,
						242,
						190,
						72,
						158,
						223,
						66,
						247,
						143,
						200,
						61,
						231,
						219,
						251,
						72,
						207,
						233,
						110,
						100,
						223,
						239,
						135,
						223,
						174,
						61,
						139,
						113,
						219,
						246,
						143,
						214,
						108,
						109,
						15,
						242,
						153,
						241,
						126,
						12,
						22,
						107,
						50,
						129,
						143,
						37,
						44,
						97,
						9,
						byte.MaxValue,
						15,
						156,
						86,
						79,
						250,
						92,
						123,
						119,
						74,
						190,
						byte.MaxValue,
						37,
						112,
						238,
						122,
						29,
						159,
						219,
						64,
						124,
						21,
						142,
						254,
						238,
						249,
						156,
						76,
						byte.MaxValue,
						192,
						238,
						79,
						119,
						235,
						212,
						81
					};
					binaryWriter.Write(buffer);
					binaryWriter.Write(buffer2);
					binaryWriter.Write(buffer3);
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		
		public void 账号下线()
		{
			this.网络连接.绑定账号 = null;
			this.网络连接 = null;
			NetworkServiceGateway.ActiveConnections -= 1U;
		}

		
		public void 账号登录(客户网络 当前网络, string 物理地址)
		{
			当前网络.发送封包(new AccountLoginSuccessPacket
			{
				协议数据 = this.登录协议描述()
			});
			当前网络.发送封包(new 同步服务状态());
			当前网络.发送封包(new BackCharacterListPacket
			{
				列表描述 = this.角色列表描述()
			});
			当前网络.绑定账号 = this;
			当前网络.当前阶段 = GameStage.选择角色;
			this.网络连接 = 当前网络;
			this.网络连接.物理地址 = 物理地址;
			NetworkServiceGateway.ActiveConnections += 1U;
		}

		
		public void 返回登录(客户网络 当前网络)
		{
			当前网络.尝试断开连接(new Exception("客户端返回登录."));
		}

		
		public void 创建角色(客户网络 当前网络, 客户创建角色 P)
		{
			if (GameDataGateway.CharacterDataTable.DataSheet.Count >= 1000000)
			{
				当前网络.发送封包(new LoginErrorMessagePacket
				{
					错误代码 = 304U
				});
				return;
			}
			if (this.角色列表.Count >= 4)
			{
				当前网络.发送封包(new LoginErrorMessagePacket
				{
					错误代码 = 267U
				});
				return;
			}
			if (Encoding.UTF8.GetBytes(P.名字).Length > 24)
			{
				当前网络.发送封包(new LoginErrorMessagePacket
				{
					错误代码 = 270U
				});
				return;
			}
			if (GameDataGateway.CharacterDataTable[P.名字] != null)
			{
				当前网络.发送封包(new LoginErrorMessagePacket
				{
					错误代码 = 272U
				});
				return;
			}
			GameObjectRace GameObjectProfession;
			if (!Enum.TryParse<GameObjectRace>(P.职业.ToString(), out GameObjectProfession) || !Enum.IsDefined(typeof(GameObjectRace), GameObjectProfession))
			{
				当前网络.发送封包(new LoginErrorMessagePacket
				{
					错误代码 = 258U
				});
				return;
			}
			GameObjectGender GameObjectGender;
			if (!Enum.TryParse<GameObjectGender>(P.性别.ToString(), out GameObjectGender) || !Enum.IsDefined(typeof(GameObjectGender), GameObjectGender))
			{
				当前网络.发送封包(new LoginErrorMessagePacket
				{
					错误代码 = 258U
				});
				return;
			}
			ObjectHairColorType ObjectHairColorType;
			if (!Enum.TryParse<ObjectHairColorType>(P.发色.ToString(), out ObjectHairColorType) || !Enum.IsDefined(typeof(ObjectHairColorType), ObjectHairColorType))
			{
				当前网络.发送封包(new LoginErrorMessagePacket
				{
					错误代码 = 258U
				});
				return;
			}
			ObjectHairType ObjectHairType;
			if (!Enum.TryParse<ObjectHairType>(((int)P.职业 * 65536 + (int)P.性别 * 256 + (int)P.发型).ToString(), out ObjectHairType) || !Enum.IsDefined(typeof(ObjectHairType), ObjectHairType))
			{
				当前网络.发送封包(new LoginErrorMessagePacket
				{
					错误代码 = 258U
				});
				return;
			}
			ObjectFaceType ObjectFaceType;
			if (Enum.TryParse<ObjectFaceType>(((int)P.职业 * 65536 + (int)P.性别 * 256 + (int)P.脸型).ToString(), out ObjectFaceType) && Enum.IsDefined(typeof(ObjectFaceType), ObjectFaceType))
			{
				当前网络.发送封包(new CharacterCreatedSuccessfullyPacket
				{
					角色描述 = new CharacterData(this, P.名字, GameObjectProfession, GameObjectGender, ObjectHairType, ObjectHairColorType, ObjectFaceType).角色描述()
				});
				return;
			}
			当前网络.发送封包(new LoginErrorMessagePacket
			{
				错误代码 = 258U
			});
		}

		
		public void 删除角色(客户网络 当前网络, 客户删除角色 P)
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.DataSheet.TryGetValue(P.角色编号, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null && this.角色列表.Contains(CharacterData))
				{
					if (CharacterData.所属行会.V != null)
					{
						当前网络.发送封包(new LoginErrorMessagePacket
						{
							错误代码 = 280U
						});
						return;
					}
					if (CharacterData.所属师门.V != null && (CharacterData.所属师门.V.师门成员.Contains(CharacterData) || CharacterData.所属师门.V.师门成员.Count != 0))
					{
						当前网络.发送封包(new LoginErrorMessagePacket
						{
							错误代码 = 280U
						});
						return;
					}
					if (this.冻结列表.Count >= 5)
					{
						当前网络.尝试断开连接(new Exception("删除角色时找回列表已满, 断开连接."));
						return;
					}
					CharacterData.FreezeDate.V = MainProcess.CurrentTime;
					this.角色列表.Remove(CharacterData);
					this.冻结列表.Add(CharacterData);
					当前网络.发送封包(new 删除角色应答
					{
						角色编号 = CharacterData.数据索引.V
					});
					return;
				}
			}
			当前网络.发送封包(new LoginErrorMessagePacket
			{
				错误代码 = 277U
			});
		}

		
		public void 永久删除(客户网络 当前网络, 彻底删除角色 P)
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.DataSheet.TryGetValue(P.角色编号, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null && this.冻结列表.Contains(CharacterData))
				{
					if (CharacterData.角色等级 >= 40)
					{
						当前网络.发送封包(new LoginErrorMessagePacket
						{
							错误代码 = 291U
						});
						return;
					}
					if (this.删除日期.V.Date == MainProcess.CurrentTime.Date)
					{
						当前网络.发送封包(new LoginErrorMessagePacket
						{
							错误代码 = 282U
						});
						return;
					}
					this.删除日期.V = (CharacterData.删除日期.V = MainProcess.CurrentTime);
					this.冻结列表.Remove(CharacterData);
					this.删除列表.Add(CharacterData);
					当前网络.发送封包(new DeleteCharacterPacket
					{
						角色编号 = CharacterData.角色编号
					});
					return;
				}
			}
			当前网络.发送封包(new LoginErrorMessagePacket
			{
				错误代码 = 277U
			});
		}

		
		public void GetBackCharacter(客户网络 当前网络, 客户GetBackCharacterPacket P)
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.DataSheet.TryGetValue(P.角色编号, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null && this.冻结列表.Contains(CharacterData))
				{
					if (this.角色列表.Count >= 4)
					{
						当前网络.尝试断开连接(new Exception("GetBackCharacter时角色列表已满, 断开连接."));
						return;
					}
					CharacterData.FreezeDate.V = default(DateTime);
					this.冻结列表.Remove(CharacterData);
					this.角色列表.Add(CharacterData);
					当前网络.发送封包(new GetBackCharacterAnswersPacket
					{
						角色编号 = CharacterData.角色编号
					});
					return;
				}
			}
			当前网络.发送封包(new LoginErrorMessagePacket
			{
				错误代码 = 277U
			});
		}

		
		public void 进入游戏(客户网络 当前网络, 客户进入游戏 P)
		{
			GameData GameData;
			if (GameDataGateway.CharacterDataTable.DataSheet.TryGetValue(P.角色编号, out GameData))
			{
				CharacterData CharacterData = GameData as CharacterData;
				if (CharacterData != null && this.角色列表.Contains(CharacterData))
				{
					if (MainProcess.CurrentTime < this.封禁日期.V)
					{
						当前网络.发送封包(new LoginErrorMessagePacket
						{
							错误代码 = 285U,
							参数一 = ComputingClass.TimeShift(this.封禁日期.V)
						});
						return;
					}
					if (MainProcess.CurrentTime < CharacterData.封禁日期.V)
					{
						当前网络.发送封包(new LoginErrorMessagePacket
						{
							错误代码 = 285U,
							参数一 = ComputingClass.TimeShift(CharacterData.封禁日期.V)
						});
						return;
					}
					当前网络.发送封包(new EnterGameAnswerPacket
					{
						角色编号 = CharacterData.角色编号
					});
					当前网络.绑定角色 = new PlayerObject(CharacterData, 当前网络);
					当前网络.当前阶段 = GameStage.场景加载;
					return;
				}
			}
			当前网络.发送封包(new LoginErrorMessagePacket
			{
				错误代码 = 284U
			});
		}

		
		public void 更换角色(客户网络 当前网络)
		{
			当前网络.发送封包(new 更换角色计时
			{
				成功 = true
			});
			当前网络.发送封包(new 更换角色应答());
			当前网络.发送封包(new ObjectOutOfViewPacket
			{
				对象编号 = 当前网络.绑定角色.MapId
			});
			当前网络.绑定角色.玩家角色下线();
			当前网络.发送封包(new BackCharacterListPacket
			{
				列表描述 = this.角色列表描述()
			});
		}

		
		public 客户网络 网络连接;

		
		public readonly DataMonitor<string> Account;

		
		public readonly DataMonitor<DateTime> 封禁日期;

		
		public readonly DataMonitor<DateTime> 删除日期;

		
		public readonly HashMonitor<CharacterData> 角色列表;

		
		public readonly HashMonitor<CharacterData> 冻结列表;

		
		public readonly HashMonitor<CharacterData> 删除列表;
	}
}
