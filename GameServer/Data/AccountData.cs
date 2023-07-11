using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameServer.Maps;
using GameServer.Networking;

namespace GameServer.Data
{

    [FastDataReturnAttribute(SearchFilder = "Account")]
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
            using MemoryStream ms = new MemoryStream(new byte[847]);
            using BinaryWriter bw = new BinaryWriter(ms);

            var protocol1 = new byte[] { 51, 53, 50, 54, 51, 53, 49, 57, 56, 48, 0, 56, 48, 0, 58, 50, 53, 58, 97, 97, 58, 51, 102, 58, 50, 50, 58, 48, 54, 0, 85, 76, 83, 50, 49 };
            var protocol2 = new byte[] { 53, 53, 51, 50, 101, 48, 54, 57, 50, 100, 50, 51, 52, 98, 98, 48, 57, 97, 56, 98, 99, 50, 100, 102, 100, 102, 57, 97, 51, 1, 129, 110, 6, 0, 0, 7, 0, 0, 0, 50, 48, 49, 54, 45, 48, 50, 45, 50, 54, 0, 120, 156, 237, 86, 205, 106, 20, 65, 16, 238, 237, 249, 91, 247, 103, 102, 93, 163, 65, 34, 26, 140, 108, 196, 104, 80, 148, 8, 122, 16, 37, 228, 224, 205, 120, 86, 60, 120, 243, 45, 4, 197, 231 };
            var protocol3 = new byte[] { 240, 226, 197, 103, 208, 131, 111, 226, 197, 139, 55, 31, 32, 86, 237, 124, 159, 243, 109, 147, 68, 68, 49, 151, 45, 40, 170, 187, 186, 254, 187, 171, 102, 66, 8, 161, 31, 142, 135, 218, 240, 0, 240, 81, 214, 67, 91, 95, 150, 61, 161, 204, 66, 216, 239, 133, 80, 226, 204, 237, 151, 135, 200, 57, 20, 71, 156, 57, 239, 180, 97, 52, 92, 53, 28, 32, 206, 6, 242, 35, 224, 24, 114, 126, 62, 193, 126, 12, 217, 10, 120, 23, 57, 184, 252, 10, 124, 85, 160, 111, 160, 119, 207, 240, 25, 120, 174, 239, 185, 93, 17, 27, 142, 219, 240, 93, 193, 94, 9, 191, 99, 145, 217, 130, 111, 231, 63, 55, 180, 82, 132, 83, 134, 57, 228, 11, 156, 157, 151, 156, 47, 192, 70, 1, 27, 37, 244, 106, 201, 91, 107, 52, 16, 185, 50, 89, 159, 133, 142, 211, 115, 208, 25, 128, 94, 52, 58, 133, 31, 234, 177, 214, 121, 114, 7, 81, 116, 115, 196, 231, 245, 219, 21, 89, 173, 177, 219, 248, 146, 117, 126, 104, 231, 12, 214, 35, 212, 180, 2, 245, 252, 54, 37, 134, 33, 248, 165, 32, 253, 215, 178, 102, 205, 41, 83, 32, 158, 74, 98, 202, 32, 83, 73, 28, 49, 182, 57, 100, 64, 198, 77, 217, 245, 164, 190, 78, 27, 212, 139, 247, 224, 188, 91, 114, 247, 172, 147, 159, 237, 136, 78, 133, 152, 134, 18, 55, 245, 25, 63, 145, 239, 66, 115, 90, 149, 245, 84, 98, 172, 69, 174, 150, 115, 230, 89, 225, 60, 2, 157, 71, 253, 153, 188, 43, 98, 41, 178, 190, 191, 36, 119, 57, 0, 111, 2, 234, 50, 125, 201, 57, 38, 186, 17, 185, 228, 216, 55, 178, 207, 37, 78, 230, 50, 183, 83, 180, 247, 151, 37, 181, 103, 158, 105, 205, 72, 153, 59, 243, 159, 98, 221, 191, 218, 233, 233, 27, 218, 16, 59, 90, 131, 70, 222, 2, 253, 191, 180, 245, 154, 225, 157, 176, 216, 31, 140, 141, 241, 243, 110, 53, 246, 90, 234, 78, 63, 122, 87, 15, 13, 175, 75, 126, 148, 245, 253, 135, 216, 198, 51, 146, 248, 247, 144, 219, 53, 121, 7, 236, 85, 222, 157, 203, 46, 97, 9, 127, 3, 143, 194, 226, 140, 243, 183, 117, 3, 123, 107, 169, 121, 47, 220, 14, 109, 63, 124, 202, 91, 217, 173, 208, 245, 196, 38, 214, 251, 88, 187, 254, 12, 168, 125, 55, 16, 29, 246, 142, 246, 30, 103, 88, 249, 27, 28, 29, 193, 143, 199, 240, 171, 100, 239, 190, 222, 199, 174, 55, 235, 68, 231, 102, 104, 231, 0, 99, 250, 22, 22, 103, 1, 229, 118, 64, 31, 24, 110, 136, 109, 253, 46, 114, 102, 232, 108, 162, 141, 89, 232, 230, 98, 145, 212, 130, 125, 238, 223, 131, 87, 162, 231, 176, 22, 186, 239, 140, 243, 125, 118, 12, 5, 57, 167, 117, 54, 205, 103, 164, 212, 252, 215, 28, 234, 181, 244, 93, 236, 102, 234, 16, 53, 105, 18, 27, 7, 9, 232, 108, 36, 239, 179, 228, 249, 53, 180, 255, 136, 220, 115, 190, 189, 77, 244, 156, 238, 38, 246, 253, 126, 248, 237, 218, 179, 24, 183, 109, 127, 127, 221, 214, 246, 32, 31, 27, 239, 71, 111, 177, 38, 147, 164, 70, 90, 103, 167, 223, 77, 127, 37, 107, 101, 158, 134, 37, 44, 97, 9, 255, 3, 202, 19, 242, 235, 115, 237, 245, 9, 249, 254, 151, 192, 185, 235, 117, 124, 98, 243, 235, 69, 56, 252, 187, 231, 115, 50, 251, 3, 187, 63, 1, 233, 74, 233, 158 };

            ms.Seek(2, SeekOrigin.Begin);
            ms.Write(protocol1);
            bw.Write((byte)0);
            ms.Write(protocol2);
            ms.Write(protocol3);

            ms.Seek(0, SeekOrigin.Begin);

            bw.Write((byte)(Math.Min(4, this.Characters.Count) + Math.Min(5, this.冻结列表.Count)));

            List<CharacterData> activePlayers = (from O in this.Characters
                                                 orderby O.Level.V descending
                                                 select O).ToList();

            int num = 0;
            while (num < 4 && num < activePlayers.Count)
            {
                activePlayers[num].角色描述(bw);
                num++;
            }

            List<CharacterData> freezePlayers = (from O in this.冻结列表
                                                 orderby O.Level.V descending
                                                 select O).ToList<CharacterData>();

            int num2 = 0;
            while (num2 < 5 && num2 < freezePlayers.Count)
            {
                freezePlayers[num2].角色描述(bw);
                num2++;
            }

            ms.Seek(protocol1.Length + protocol2.Length + protocol3.Length + 3, SeekOrigin.Begin);

            var time = ComputingClass.TimeShift(MainProcess.CurrentTime);
            var buffer = new byte[84] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 53, 105, 46, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (var i = 0; i < buffer.Length; i++)
                buffer[i] ^= GamePacket.EncryptionKey;

            ms.Write(buffer);

            return ms.ToArray();
        }


        public byte[] GenerateLoginAgreementDescription()
        {
            return new byte[761] { 51, 53, 50, 54, 51, 53, 49, 57, 56, 48, 0, 56, 48, 0, 58, 50, 53, 58, 97, 97, 58, 51, 102, 58, 50, 50, 58, 48, 54, 0, 85, 76, 83, 50, 49, 45, 53, 53, 51, 50, 101, 48, 54, 57, 50, 100, 50, 51, 52, 98, 98, 48, 57, 97, 56, 98, 99, 50, 100, 102, 100, 102, 57, 97, 51, 1, 129, 110, 6, 0, 0, 7, 0, 0, 0, 50, 48, 49, 54, 45, 48, 50, 45, 50, 54, 0, 120, 156, 237, 86, 205, 106, 20, 65, 16, 238, 237, 249, 91, 247, 103, 102, 93, 163, 65, 34, 26, 140, 108, 196, 104, 80, 148, 8, 122, 16, 37, 228, 224, 205, 120, 86, 60, 120, 243, 45, 4, 197, 231, 240, 226, 197, 103, 208, 131, 111, 226, 197, 139, 55, 31, 32, 86, 237, 124, 159, 243, 109, 147, 68, 68, 49, 151, 45, 40, 170, 187, 186, 254, 187, 171, 102, 66, 8, 161, 31, 142, 135, 218, 240, 0, 240, 81, 214, 67, 91, 95, 150, 61, 161, 204, 66, 216, 239, 133, 80, 226, 204, 237, 151, 135, 200, 57, 20, 71, 156, 57, 239, 180, 97, 52, 92, 53, 28, 32, 206, 6, 242, 35, 224, 24, 114, 126, 62, 193, 126, 12, 217, 10, 120, 23, 57, 184, 252, 10, 124, 85, 160, 111, 160, 119, 207, 240, 25, 120, 174, 239, 185, 93, 17, 27, 142, 219, 240, 93, 193, 94, 9, 191, 99, 145, 217, 130, 111, 231, 63, 55, 180, 82, 132, 83, 134, 57, 228, 11, 156, 157, 151, 156, 47, 192, 70, 1, 27, 37, 244, 106, 201, 91, 107, 52, 16, 185, 50, 89, 159, 133, 142, 211, 115, 208, 25, 128, 94, 52, 58, 133, 31, 234, 177, 214, 121, 114, 7, 81, 116, 115, 196, 231, 245, 219, 21, 89, 173, 177, 219, 248, 146, 117, 126, 104, 231, 12, 214, 35, 212, 180, 2, 245, 252, 54, 37, 134, 33, 248, 165, 32, 253, 215, 178, 102, 205, 41, 83, 32, 158, 74, 98, 202, 32, 83, 73, 28, 49, 182, 57, 100, 64, 198, 77, 217, 245, 164, 190, 78, 27, 212, 139, 247, 224, 188, 91, 114, 247, 172, 147, 159, 237, 136, 78, 133, 152, 134, 18, 55, 245, 25, 63, 145, 239, 66, 115, 90, 149, 245, 84, 98, 172, 69, 174, 150, 115, 230, 89, 225, 60, 2, 157, 71, 253, 153, 188, 43, 98, 41, 178, 190, 191, 36, 119, 57, 0, 111, 2, 234, 50, 125, 201, 57, 38, 186, 17, 185, 228, 216, 55, 178, 207, 37, 78, 230, 50, 183, 83, 180, 247, 151, 37, 181, 103, 158, 105, 205, 72, 153, 59, 243, 159, 98, 221, 191, 218, 233, 233, 27, 218, 16, 59, 90, 131, 70, 222, 2, 253, 191, 180, 245, 154, 225, 157, 176, 216, 31, 140, 141, 241, 243, 110, 53, 246, 90, 234, 78, 63, 122, 87, 15, 13, 175, 75, 126, 148, 245, 253, 135, 216, 198, 51, 146, 248, 247, 144, 219, 53, 121, 7, 236, 85, 222, 157, 203, 46, 97, 9, 127, 3, 143, 194, 226, 140, 243, 183, 117, 3, 123, 107, 169, 121, 47, 220, 14, 109, 63, 124, 202, 91, 217, 173, 208, 245, 196, 38, 214, 251, 88, 187, 254, 12, 168, 125, 55, 16, 29, 246, 142, 246, 30, 103, 88, 249, 27, 28, 29, 193, 143, 199, 240, 171, 100, 239, 190, 222, 199, 174, 55, 235, 68, 231, 102, 104, 231, 0, 99, 250, 22, 22, 103, 1, 229, 118, 64, 31, 24, 110, 136, 109, 253, 46, 114, 102, 232, 108, 162, 141, 89, 232, 230, 98, 145, 212, 130, 125, 238, 223, 131, 87, 162, 231, 176, 22, 186, 239, 140, 243, 125, 118, 12, 5, 57, 167, 117, 54, 205, 103, 164, 212, 252, 215, 28, 234, 181, 244, 93, 236, 102, 234, 16, 53, 105, 18, 27, 7, 9, 232, 108, 36, 239, 179, 228, 249, 53, 180, 255, 136, 220, 115, 190, 189, 77, 244, 156, 238, 38, 246, 253, 126, 248, 237, 218, 179, 24, 183, 109, 127, 127, 221, 214, 246, 32, 31, 27, 239, 71, 111, 177, 38, 147, 164, 70, 90, 103, 167, 223, 77, 127, 37, 107, 101, 158, 134, 37, 44, 97, 9, 255, 3, 202, 19, 242, 235, 115, 237, 245, 9, 249, 254, 151, 192, 185, 235, 117, 124, 98, 243, 235, 69, 56, 252, 187, 231, 115, 50, 251, 3, 187, 63, 1, 233, 74, 233, 158 };
            //using (var memoryStream = new MemoryStream())
            //using (var binaryWriter = new BinaryWriter(memoryStream))
            //{
            //    binaryWriter.Write(Config.ProtocolKey1);
            //    binaryWriter.Write(Config.ProtocolKey2);
            //    binaryWriter.Write(Config.ProtocolKey3);
            //    return memoryStream.ToArray();
            //}
        }


        public void Disconnect()
        {
            this.网络连接.Account = null;
            this.网络连接 = null;
            NetworkServiceGateway.ActiveConnections -= 1U;
        }


        public void 账号登录(SConnection conn, string MacAddress)
        {
            conn.SendPacket(new AccountLoginSuccessPacket
            {
                协议数据 = GenerateLoginAgreementDescription()
            });
            conn.SendPacket(new 同步服务状态());
            conn.SendPacket(new UnknownS692() { U1 = 100, U2 = 130, U3 = 160, U4 = 190, U5 = 220, U6 = 250, U7 = 250 });
            conn.SendPacket(new UnknownS693() { });
            conn.SendPacket(new BackCharacterListPacket
            {
                列表描述 = this.角色列表描述()
            });
            conn.Account = this;
            conn.CurrentStage = GameStage.SelectingCharacterScene;
            this.网络连接 = conn;
            this.网络连接.MacAddress = MacAddress;
            NetworkServiceGateway.ActiveConnections += 1U;
        }


        public void 返回登录(SConnection 当前网络)
        {
            当前网络.CallExceptionEventHandler(new Exception("Client returned to login screen"));
        }


        public void 创建角色(SConnection 当前网络, 客户创建角色 P)
        {
            if (GameDataGateway.CharacterDataTable.DataSheet.Count >= 1000000)
            {
                当前网络.SendPacket(new LoginErrorMessagePacket
                {
                    错误代码 = 304U
                });
                return;
            }
            if (this.Characters.Count >= 4)
            {
                当前网络.SendPacket(new LoginErrorMessagePacket
                {
                    错误代码 = 267U
                });
                return;
            }
            if (Encoding.UTF8.GetBytes(P.名字).Length > 24)
            {
                当前网络.SendPacket(new LoginErrorMessagePacket
                {
                    错误代码 = 270U
                });
                return;
            }
            if (GameDataGateway.CharacterDataTable[P.名字] != null)
            {
                当前网络.SendPacket(new LoginErrorMessagePacket
                {
                    错误代码 = 272U
                });
                return;
            }
            GameObjectRace GameObjectProfession;
            if (!Enum.TryParse<GameObjectRace>(P.职业.ToString(), out GameObjectProfession) || !Enum.IsDefined(typeof(GameObjectRace), GameObjectProfession))
            {
                当前网络.SendPacket(new LoginErrorMessagePacket
                {
                    错误代码 = 258U
                });
                return;
            }
            GameObjectGender GameObjectGender;
            if (!Enum.TryParse<GameObjectGender>(P.性别.ToString(), out GameObjectGender) || !Enum.IsDefined(typeof(GameObjectGender), GameObjectGender))
            {
                当前网络.SendPacket(new LoginErrorMessagePacket
                {
                    错误代码 = 258U
                });
                return;
            }
            ObjectHairColorType ObjectHairColorType;
            if (!Enum.TryParse<ObjectHairColorType>(P.发色.ToString(), out ObjectHairColorType) || !Enum.IsDefined(typeof(ObjectHairColorType), ObjectHairColorType))
            {
                当前网络.SendPacket(new LoginErrorMessagePacket
                {
                    错误代码 = 258U
                });
                return;
            }
            ObjectHairType ObjectHairType;
            if (!Enum.TryParse<ObjectHairType>(((int)P.职业 * 65536 + (int)P.性别 * 256 + (int)P.发型).ToString(), out ObjectHairType) || !Enum.IsDefined(typeof(ObjectHairType), ObjectHairType))
            {
                当前网络.SendPacket(new LoginErrorMessagePacket
                {
                    错误代码 = 258U
                });
                return;
            }
            ObjectFaceType ObjectFaceType;
            if (Enum.TryParse<ObjectFaceType>(((int)P.职业 * 65536 + (int)P.性别 * 256 + (int)P.脸型).ToString(), out ObjectFaceType) && Enum.IsDefined(typeof(ObjectFaceType), ObjectFaceType))
            {
                当前网络.SendPacket(new CharacterCreatedSuccessfullyPacket
                {
                    角色描述 = new CharacterData(this, P.名字, GameObjectProfession, GameObjectGender, ObjectHairType, ObjectHairColorType, ObjectFaceType).角色描述()
                });
                return;
            }
            当前网络.SendPacket(new LoginErrorMessagePacket
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
                if (CharacterData != null && this.Characters.Contains(CharacterData))
                {
                    if (CharacterData.Guild.V != null)
                    {
                        当前网络.SendPacket(new LoginErrorMessagePacket
                        {
                            错误代码 = 280U
                        });
                        return;
                    }
                    if (CharacterData.Teacher.V != null && (CharacterData.Teacher.V.师门成员.Contains(CharacterData) || CharacterData.Teacher.V.师门成员.Count != 0))
                    {
                        当前网络.SendPacket(new LoginErrorMessagePacket
                        {
                            错误代码 = 280U
                        });
                        return;
                    }
                    if (this.冻结列表.Count >= 5)
                    {
                        当前网络.CallExceptionEventHandler(new Exception("The retrieval list is full when you delete a character, disconnect."));
                        return;
                    }
                    CharacterData.FreezeDate.V = MainProcess.CurrentTime;
                    this.Characters.Remove(CharacterData);
                    this.冻结列表.Add(CharacterData);
                    当前网络.SendPacket(new 删除角色应答
                    {
                        角色编号 = CharacterData.Index.V
                    });
                    return;
                }
            }
            当前网络.SendPacket(new LoginErrorMessagePacket
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
                    if (CharacterData.CharLevel >= 40)
                    {
                        当前网络.SendPacket(new LoginErrorMessagePacket
                        {
                            错误代码 = 291U
                        });
                        return;
                    }
                    if (this.DateDelete.V.Date == MainProcess.CurrentTime.Date)
                    {
                        当前网络.SendPacket(new LoginErrorMessagePacket
                        {
                            错误代码 = 282U
                        });
                        return;
                    }
                    this.DateDelete.V = (CharacterData.DateDelete.V = MainProcess.CurrentTime);
                    this.冻结列表.Remove(CharacterData);
                    this.删除列表.Add(CharacterData);
                    当前网络.SendPacket(new DeleteCharacterPacket
                    {
                        角色编号 = CharacterData.CharId
                    });
                    return;
                }
            }
            当前网络.SendPacket(new LoginErrorMessagePacket
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
                    if (this.Characters.Count >= 4)
                    {
                        当前网络.CallExceptionEventHandler(new Exception("GetBackCharacter when the list of characters is full, disconnect."));
                        return;
                    }
                    CharacterData.FreezeDate.V = default(DateTime);
                    this.冻结列表.Remove(CharacterData);
                    this.Characters.Add(CharacterData);
                    当前网络.SendPacket(new GetBackCharacterAnswersPacket
                    {
                        角色编号 = CharacterData.CharId
                    });
                    return;
                }
            }
            当前网络.SendPacket(new LoginErrorMessagePacket
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
                if (CharacterData != null && this.Characters.Contains(CharacterData))
                {
                    if (MainProcess.CurrentTime < this.封禁日期.V)
                    {
                        conn.SendPacket(new LoginErrorMessagePacket
                        {
                            错误代码 = 285U,
                            参数一 = ComputingClass.TimeShift(this.封禁日期.V)
                        });
                        return;
                    }
                    if (MainProcess.CurrentTime < CharacterData.封禁日期.V)
                    {
                        conn.SendPacket(new LoginErrorMessagePacket
                        {
                            错误代码 = 285U,
                            参数一 = ComputingClass.TimeShift(CharacterData.封禁日期.V)
                        });
                        return;
                    }

                    conn.SendPacket(new EnterGameAnswerPacket
                    {
                        角色编号 = CharacterData.CharId
                    });

                    conn.Player = new PlayerObject(CharacterData, conn);
                    conn.CurrentStage = GameStage.LoadingScene;
                    return;
                }
            }
            conn.SendPacket(new LoginErrorMessagePacket
            {
                错误代码 = 284U
            });
        }


        public void 更换角色(SConnection 当前网络)
        {
            当前网络.SendPacket(new 更换角色计时
            {
                成功 = true
            });
            当前网络.SendPacket(new 更换角色应答());
            当前网络.SendPacket(new ObjectOutOfViewPacket
            {
                对象编号 = 当前网络.Player.ObjectId
            });
            当前网络.Player.Disconnect();
            当前网络.SendPacket(new BackCharacterListPacket
            {
                列表描述 = this.角色列表描述()
            });
        }


        public SConnection 网络连接;


        public readonly DataMonitor<string> Account;


        public readonly DataMonitor<DateTime> 封禁日期;


        public readonly DataMonitor<DateTime> DateDelete;


        public readonly HashMonitor<CharacterData> Characters;


        public readonly HashMonitor<CharacterData> 冻结列表;


        public readonly HashMonitor<CharacterData> 删除列表;
    }
}
