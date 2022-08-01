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


        public byte[] GenerateLoginAgreementDescription()
        {
            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                binaryWriter.Write(Config.ProtocolKey1);
                binaryWriter.Write(Config.ProtocolKey2);
                binaryWriter.Write(Config.ProtocolKey3);
                return memoryStream.ToArray();
            }
        }


        public void 账号下线()
        {
            this.网络连接.Account = null;
            this.网络连接 = null;
            NetworkServiceGateway.ActiveConnections -= 1U;
        }


        public void 账号登录(SConnection 当前网络, string 物理地址)
        {
            当前网络.发送封包(new AccountLoginSuccessPacket
            {
                协议数据 = this.GenerateLoginAgreementDescription()
            });
            当前网络.发送封包(new 同步服务状态());
            当前网络.发送封包(new BackCharacterListPacket
            {
                列表描述 = this.角色列表描述()
            });
            当前网络.Account = this;
            当前网络.当前阶段 = GameStage.SelectingCharacterScene;
            this.网络连接 = 当前网络;
            this.网络连接.物理地址 = 物理地址;
            NetworkServiceGateway.ActiveConnections += 1U;
        }


        public void 返回登录(SConnection 当前网络)
        {
            当前网络.CallExceptionEventHandler(new Exception("客户端返回登录."));
        }


        public void 创建角色(SConnection 当前网络, 客户创建角色 P)
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


        public void 删除角色(SConnection 当前网络, 客户删除角色 P)
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
                        当前网络.CallExceptionEventHandler(new Exception("删除角色时找回列表已满, 断开连接."));
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


        public void 永久删除(SConnection 当前网络, 彻底删除角色 P)
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
                        角色编号 = CharacterData.Id
                    });
                    return;
                }
            }
            当前网络.发送封包(new LoginErrorMessagePacket
            {
                错误代码 = 277U
            });
        }


        public void GetBackCharacter(SConnection 当前网络, 客户GetBackCharacterPacket P)
        {
            GameData GameData;
            if (GameDataGateway.CharacterDataTable.DataSheet.TryGetValue(P.角色编号, out GameData))
            {
                CharacterData CharacterData = GameData as CharacterData;
                if (CharacterData != null && this.冻结列表.Contains(CharacterData))
                {
                    if (this.角色列表.Count >= 4)
                    {
                        当前网络.CallExceptionEventHandler(new Exception("GetBackCharacter时角色列表已满, 断开连接."));
                        return;
                    }
                    CharacterData.FreezeDate.V = default(DateTime);
                    this.冻结列表.Remove(CharacterData);
                    this.角色列表.Add(CharacterData);
                    当前网络.发送封包(new GetBackCharacterAnswersPacket
                    {
                        角色编号 = CharacterData.Id
                    });
                    return;
                }
            }
            当前网络.发送封包(new LoginErrorMessagePacket
            {
                错误代码 = 277U
            });
        }


        public void 进入游戏(SConnection conn, 客户进入游戏 P)
        {
            GameData GameData;
            if (GameDataGateway.CharacterDataTable.DataSheet.TryGetValue(P.角色编号, out GameData))
            {
                CharacterData CharacterData = GameData as CharacterData;
                if (CharacterData != null && this.角色列表.Contains(CharacterData))
                {
                    if (MainProcess.CurrentTime < this.封禁日期.V)
                    {
                        conn.发送封包(new LoginErrorMessagePacket
                        {
                            错误代码 = 285U,
                            参数一 = ComputingClass.TimeShift(this.封禁日期.V)
                        });
                        return;
                    }
                    if (MainProcess.CurrentTime < CharacterData.封禁日期.V)
                    {
                        conn.发送封包(new LoginErrorMessagePacket
                        {
                            错误代码 = 285U,
                            参数一 = ComputingClass.TimeShift(CharacterData.封禁日期.V)
                        });
                        return;
                    }
                    conn.发送封包(new EnterGameAnswerPacket
                    {
                        角色编号 = CharacterData.Id
                    });
                    conn.Player = new PlayerObject(CharacterData, conn);
                    conn.当前阶段 = GameStage.LoadingScene;
                    return;
                }
            }
            conn.发送封包(new LoginErrorMessagePacket
            {
                错误代码 = 284U
            });
        }


        public void 更换角色(SConnection 当前网络)
        {
            当前网络.发送封包(new 更换角色计时
            {
                成功 = true
            });
            当前网络.发送封包(new 更换角色应答());
            当前网络.发送封包(new ObjectOutOfViewPacket
            {
                对象编号 = 当前网络.Player.ObjectId
            });
            当前网络.Player.玩家角色下线();
            当前网络.发送封包(new BackCharacterListPacket
            {
                列表描述 = this.角色列表描述()
            });
        }


        public SConnection 网络连接;


        public readonly DataMonitor<string> Account;


        public readonly DataMonitor<DateTime> 封禁日期;


        public readonly DataMonitor<DateTime> 删除日期;


        public readonly HashMonitor<CharacterData> 角色列表;


        public readonly HashMonitor<CharacterData> 冻结列表;


        public readonly HashMonitor<CharacterData> 删除列表;
    }
}
