using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using GameServer.Maps;
using GameServer.Data;
using GamePackets.Client;
using System.Text;

namespace GameServer.Networking
{

    public sealed class SConnection
    {
        private DateTime DisconnectTime;
        private bool Sending;
        private byte[] ReceivedData;
        private readonly EventHandler<Exception> ErrorEventHandler;
        private ConcurrentQueue<GamePacket> ReceivedPackets;
        private ConcurrentQueue<GamePacket> SendPackets;
        public bool ConnectionErrored;
        public readonly DateTime ConnectedTime;
        public readonly TcpClient Connection;
        public GameStage CurrentStage;
        public AccountData Account;
        public PlayerObject Player;
        public string NetAddress;
        public string MacAddress;
        public int TotalSended;
        public int TotalReceived;

        public SConnection(TcpClient tcpClient)
        {
            ReceivedData = new byte[0];
            ReceivedPackets = new ConcurrentQueue<GamePacket>();
            SendPackets = new ConcurrentQueue<GamePacket>();

            Connection = tcpClient;
            Connection.NoDelay = true;
            ConnectedTime = MainProcess.CurrentTime;
            DisconnectTime = MainProcess.CurrentTime.AddMinutes(Config.掉线判定时间);
            ErrorEventHandler = (EventHandler<Exception>)Delegate.Combine(ErrorEventHandler, new EventHandler<Exception>(NetworkServiceGateway.断网回调));
            NetAddress = Connection.Client.RemoteEndPoint.ToString().Split(':')[0];
            StartAsyncReceive();
        }

        public void Process()
        {
            try
            {
                if (!ConnectionErrored && !NetworkServiceGateway.StoppedService)
                {
                    if (MainProcess.CurrentTime > DisconnectTime)
                    {
                        CallExceptionEventHandler(new Exception("No response for a long time, disconnect."));
                    }
                    else
                    {
                        ProcessReceivedPackets();
                        SendAllPackets();
                    }
                }
                else if (!Sending && ReceivedPackets.Count == 0 && SendPackets.Count == 0)
                {
                    Player?.Disconnect();
                    Account?.Disconnect();
                    NetworkServiceGateway.Disconnected(this);
                    Connection.Client.Shutdown(SocketShutdown.Both);
                    Connection.Close();
                    ReceivedPackets = null;
                    SendPackets = null;
                    CurrentStage = GameStage.StartingSessionScene;
                }
                else
                {
                    ProcessReceivedPackets();
                    SendAllPackets();
                }
            }
            catch (Exception ex)
            {
                if (Player != null)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("处理网络数据时出现异常, 已断开对应连接");
                    sb.AppendLine($"账号:[{Account?.Account.V ?? "None"}]");
                    sb.AppendLine($"角色:[{Player?.ObjectName ?? "None"}]");
                    sb.AppendLine($"IP:[{NetAddress}]");
                    sb.AppendLine($"MAC:[{MacAddress}]");
                    sb.Append($"错误提示:[{ex.Message}]");
                    MainProcess.AddSystemLog(sb.ToString());
                }

                Player?.Disconnect();
                Account?.Disconnect();
                NetworkServiceGateway.Disconnected(this);
                Connection.Client?.Shutdown(SocketShutdown.Both);
                Connection?.Close();

                ReceivedPackets = null;
                SendPackets = null;
                CurrentStage = GameStage.StartingSessionScene;
            }
        }
        public void SendPacket(GamePacket packet)
        {
            if (!ConnectionErrored && !NetworkServiceGateway.StoppedService && packet != null)
            {
                if (Config.SendPacketsAsync)
                {
                    SendPackets.Enqueue(packet);
                }
                else
                {
                    MainForm.AddPacketLog(packet, false);
                    Connection.Client.Send(packet.取字节());
                }
            }
        }
        public void SendRaw(ushort type, ushort length, byte[] data, bool encoded = true)
        {
            byte[] output;
            if (length == 0)
            {
                output = new byte[data.Length + 4];
                Array.Copy(BitConverter.GetBytes((ushort)type), 0, output, 0, 2);
                Array.Copy(BitConverter.GetBytes((ushort)output.Length), 0, output, 2, 2);
                Array.Copy(data, 0, output, 4, data.Length);
            }
            else
            {
                output = new byte[data.Length + 2];
                Array.Copy(BitConverter.GetBytes((ushort)type), 0, output, 0, 2);
                Array.Copy(data, 0, output, 2, data.Length);
            }

            if (encoded)
                for (var i = 4; i < output.Length; i++)
                    output[i] ^= GamePacket.EncryptionKey;

            Connection.Client.Send(output);
        }
        public void CallExceptionEventHandler(Exception e)
        {
            if (!this.ConnectionErrored)
            {
                this.ConnectionErrored = true;
                EventHandler<Exception> eventHandler = this.ErrorEventHandler;
                if (eventHandler == null)
                {
                    return;
                }
                eventHandler(this, e);
            }
        }
        private void ProcessReceivedPackets()
        {
            while (!ReceivedPackets.IsEmpty)
            {
                if (ReceivedPackets.Count > Config.PacketLimit)
                {
                    ReceivedPackets.Clear();
                    NetworkServiceGateway.屏蔽网络(this.NetAddress);
                    CallExceptionEventHandler(new Exception("Too many packets, disconnect and restrict login."));
                    return;
                }

                if (ReceivedPackets.TryDequeue(out GamePacket packet))
                {
                    MainForm.AddPacketLog(packet, true);
                    if (!GamePacket.PacketMethods.TryGetValue(packet.PacketType, out MethodInfo methodInfo))
                    {
                        CallExceptionEventHandler(new Exception("No packet handling found, disconnect. Packet type: " + packet.PacketType.FullName));
                        return;
                    }
                    methodInfo.Invoke(this, new object[] { packet });
                }
            }
        }
        private void SendAllPackets()
        {
            List<byte> list = new();

            while (SendPackets.TryDequeue(out GamePacket packet))
            {
                MainForm.AddPacketLog(packet, false);
                list.AddRange(packet.取字节());
            }

            if (list.Count != 0)
            {
                开始异步发送(list);
            }
        }
        private void 延迟掉线时间()
        {
            this.DisconnectTime = MainProcess.CurrentTime.AddMinutes((double)Config.掉线判定时间);
        }
        private void StartAsyncReceive()
        {
            try
            {
                if (!this.ConnectionErrored && !NetworkServiceGateway.StoppedService)
                {
                    byte[] array = new byte[8192];
                    this.Connection.Client.BeginReceive(array, 0, array.Length, SocketFlags.None, new AsyncCallback(this.AsyncBeginReceive), array);
                }
            }
            catch (Exception ex)
            {
                this.CallExceptionEventHandler(new Exception("Asynchronous Receiving Error: " + ex.Message));
            }
        }
        private void AsyncBeginReceive(IAsyncResult result)
        {
            try
            {
                if (!this.ConnectionErrored && !NetworkServiceGateway.StoppedService && this.Connection.Client != null)
                {
                    Socket client = this.Connection.Client;
                    int num = (client != null) ? client.EndReceive(result) : 0;
                    if (num > 0)
                    {
                        this.TotalReceived += num;
                        NetworkServiceGateway.ReceivedBytes += (long)num;
                        Array src = result.AsyncState as byte[];
                        byte[] dst = new byte[this.ReceivedData.Length + num];
                        Buffer.BlockCopy(this.ReceivedData, 0, dst, 0, this.ReceivedData.Length);
                        Buffer.BlockCopy(src, 0, dst, this.ReceivedData.Length, num);
                        this.ReceivedData = dst;
                        for (; ; )
                        {
                            try
                            {
                                GamePacket GamePacket = GamePacket.GetPacket(this.ReceivedData, out this.ReceivedData);
                                if (GamePacket == null)
                                {
                                    break;
                                }
                                this.ReceivedPackets.Enqueue(GamePacket);
                            }
                            catch (Exception ex)
                            {
                                this.CallExceptionEventHandler(ex);
                                break;
                            }
                        }
                        this.延迟掉线时间();
                        this.StartAsyncReceive();
                    }
                    else
                    {
                        this.CallExceptionEventHandler(new Exception("Client disconnected."));
                    }
                }
            }
            catch (Exception ex)
            {
                this.CallExceptionEventHandler(new Exception("Packet construction error, message: " + ex.Message));
            }
        }
        private void 开始异步发送(List<byte> 数据)
        {
            try
            {
                this.Sending = true;
                this.Connection.Client.BeginSend(数据.ToArray(), 0, 数据.Count, SocketFlags.None, new AsyncCallback(this.发送完成回调), null);
            }
            catch (Exception ex)
            {
                this.Sending = false;
                this.SendPackets = new ConcurrentQueue<GamePacket>();
                this.CallExceptionEventHandler(new Exception("Asynchronous sending error: " + ex.Message));
            }
        }
        private void 发送完成回调(IAsyncResult 异步参数)
        {
            try
            {
                int num = this.Connection.Client.EndSend(异步参数);
                this.TotalSended += num;
                NetworkServiceGateway.SendedBytes += (long)num;
                if (num == 0)
                {
                    this.SendPackets = new ConcurrentQueue<GamePacket>();
                    this.CallExceptionEventHandler(new Exception("Error sending callback!"));
                }
                this.Sending = false;
            }
            catch (Exception ex)
            {
                this.Sending = false;
                this.SendPackets = new ConcurrentQueue<GamePacket>();
                this.CallExceptionEventHandler(new Exception("Sending callback errors: " + ex.Message));
            }
        }
        public void 处理封包(AddMountSkillPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.AddMountSkillPacket(P.Field, P.Unknown);
        }
        public void 处理封包(GetCurrentMountPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.SyncSelectedMount(P.SelectedMountId);
        }
        public void 处理封包(LockItemPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
        }
        public void 处理封包(UnknownC1 P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家进入场景();
            this.CurrentStage = GameStage.PlayingScene;
        }
        public void 处理封包(PlayerEnterScenePacket P)
        {

        }

        public void 处理封包(UnknownC2 P)
        {

        }
        public void 处理封包(UnknownC3 P)
        {
            //// 货币数量变动 (Server)
            //SendPacket(
            //149,
            //30,
            //new byte[] { 13, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0 }
            //);

            this.Player.ActiveConnection?.SendPacket(new UnknownS5
            {
                U1 = P.U1,
                U2 = 19225
            });
            //// u218 (Server)
            //SendPacket(
            //218,
            //10,
            //new byte[] { 59, 0, 0, 0, 25, 75, 0, 0 }
            //);
        }
        public void 处理封包(UnknownC4 P)
        {

        }
        public void 处理封包(UnknownC5 P)
        {

        }
        public void 处理封包(ReservedPacketZeroOnePacket P)
        {
        }
        public void 处理封包(ReservedPacketZeroTwoPacket P)
        {
        }
        public void 处理封包(ReservedPacketZeroThreePacket P)
        {
        }

        public void 处理封包(ToggleAwekeningExpPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            // TODO: Pending implement
        }

        public void 处理封包(PlayerCompleteQuestPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            Player.CompleteQuest(P.QuestId);
        }
        public void 处理封包(QuestTeleportPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.TeleportToQuest(P.QuestId);
        }
        public void 处理封包(AcceptRewardPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.AcceptReward(P.QuestId);
        }
        public void 处理封包(上传游戏设置 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家更改设置(P.字节描述);
        }
        public void 处理封包(客户碰触法阵 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(客户进入法阵 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家进入法阵(P.TeleportGateNumber);
        }
        public void 处理封包(ClickNpcDialogPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }

            this.Player.ProcessActionNPC(P.对象编号, P.QuestId);
        }
        public void 处理封包(RequestObjectDataPacket P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.请求对象外观(P.对象编号, P.状态编号);
        }
        public void 处理封包(客户网速测试 P)
        {
            if (CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            SendPacket(new InternetSpeedTestPacket
            {
                当前时间 = P.客户时间
            });
        }
        public void 处理封包(测试网关网速 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }

            SendPacket(new LoginQueryResponsePacket
            {
                当前时间 = P.客户时间
            });
        }
        public void 处理封包(客户请求复活 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家请求复活();
        }
        public void 处理封包(ToggleAttackMode P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (Enum.IsDefined(typeof(AttackMode), (int)P.AttackMode) && Enum.TryParse<AttackMode>(P.AttackMode.ToString(), out AttackMode 模式))
            {
                this.Player.更改AttackMode(模式);
                return;
            }
            this.CallExceptionEventHandler(new Exception("Wrong enumeration parameter is provided when changing the AttackMode. About to be disconnected."));
        }
        public void 处理封包(更改PetMode P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (Enum.IsDefined(typeof(PetMode), (int)P.PetMode) && Enum.TryParse<PetMode>(P.PetMode.ToString(), out PetMode 模式))
            {
                this.Player.更改PetMode(模式);
                return;
            }
            this.CallExceptionEventHandler(new Exception(string.Format("Wrong enumeration parameter is provided when changing PetMode. About to be disconnected. Parameter - {0}", P.PetMode)));
        }
        public void 处理封包(上传角色位置 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家同步位置();
        }
        public void 处理封包(客户角色转动 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (Enum.IsDefined(typeof(GameDirection), (int)P.转动方向) && Enum.TryParse<GameDirection>(P.转动方向.ToString(), out GameDirection 转动方向))
            {
                this.Player.玩家角色转动(转动方向);
                return;
            }
            this.CallExceptionEventHandler(new Exception("Wrong enumeration parameter provided when player character is rotated. Disconnection is imminent."));
        }
        public void 处理封包(客户角色走动 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家角色走动(P.坐标);
        }
        public void 处理封包(客户角色跑动 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家角色跑动(P.坐标);
        }
        public void 处理封包(CharacterSwitchSkillsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家开关技能(P.SkillId);
        }
        public void 处理封包(CharacterEquipmentSkillsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.技能栏位 < 32)
            {
                this.Player.EquipSkill(P.技能栏位, P.SkillId);
                return;
            }
            this.CallExceptionEventHandler(new Exception("Player supplied wrong packet parameters when assembling skills. Disconnection is imminent."));
        }
        public void 处理封包(CharacterReleaseSkillsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.UseSkill(P.SkillId, P.动作编号, P.目标编号, P.锚点坐标);
        }
        public void 处理封包(BattleStanceSwitchPacket P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家切换姿态();
        }
        public void 处理封包(客户更换角色 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Account.更换角色(this);
            this.CurrentStage = GameStage.SelectingCharacterScene;
        }
        public void 处理封包(场景加载完成 P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家进入场景();
            this.CurrentStage = GameStage.PlayingScene;
        }
        public void 处理封包(ExitCurrentCopyPacket P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家退出副本();
        }
        public void 处理封包(玩家退出登录 P)
        {
            if (this.CurrentStage == GameStage.StartingSessionScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Account.返回登录(this);
        }
        public void 处理封包(打开角色背包 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(CharacterPickupItemsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }

            // TODO: Pickup items
        }
        public void 处理封包(CharacterDropsItemsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家丢弃物品(P.背包类型, P.物品位置, P.丢弃数量);
        }
        public void 处理封包(CharacterTransferItemPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.TransferItem(P.当前背包, P.原有位置, P.目标背包, P.目标位置);
        }
        public void 处理封包(CharacterUseItemsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.UseItem(P.背包类型, P.物品位置);
        }
        public void 处理封包(玩家喝修复油 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家喝修复油(P.背包类型, P.物品位置);
        }
        public void 处理封包(玩家扩展背包 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.ExpandStorage(P.背包类型, P.扩展大小);
        }
        public void 处理封包(RequestStoreDataPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.RequestStoreDataPacket(P.版本编号);
        }
        public void 处理封包(CharacterPurchageItemsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家购买物品(P.StoreId, P.物品位置, P.购入数量);
        }
        public void 处理封包(CharacterSellItemsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家出售物品(P.背包类型, P.物品位置, P.卖出数量);
        }
        public void 处理封包(查询回购列表 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.请求回购清单();
        }
        public void 处理封包(CharacterRepurchageItemsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.物品位置 < 100)
            {
                this.Player.玩家回购物品(P.物品位置);
                return;
            }
            this.CallExceptionEventHandler(new Exception("The player has provided the wrong location parameters when buying back the item. Disconnection is imminent."));
        }
        public void 处理封包(商店修理单件 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.商店修理单件(P.背包类型, P.物品位置);
        }
        public void 处理封包(商店修理全部 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.商店修理全部();
        }
        public void 处理封包(商店特修单件 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.商店特修单件(P.物品容器, P.物品位置);
        }
        public void 处理封包(随身修理单件 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.随身修理单件(P.物品容器, P.物品位置, P.Id);
        }
        public void 处理封包(随身特修全部 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.随身修理全部();
        }
        public void 处理封包(CharacterOrganizerBackpackPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家整理背包(P.背包类型);
        }
        public void 处理封包(CharacterSplitItemsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家拆分物品(P.当前背包, P.物品位置, P.拆分数量, P.目标背包, P.目标位置);
        }
        public void 处理封包(CharacterBreakdownItemsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (Enum.TryParse<ItemBackPack>(P.背包类型.ToString(), out ItemBackPack ItemBackPack) && Enum.IsDefined(typeof(ItemBackPack), ItemBackPack))
            {
                this.Player.玩家分解物品(P.背包类型, P.物品位置, P.分解数量);
                return;
            }
            this.CallExceptionEventHandler(new Exception("Player provides wrong enumeration parameters when breaking down an item. Disconnection is imminent."));
        }
        public void 处理封包(CharacterSynthesisItemPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家合成物品();
        }
        public void 处理封包(玩家镶嵌灵石 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家镶嵌灵石(P.装备类型, P.装备位置, P.装备孔位, P.灵石类型, P.灵石位置);
        }
        public void 处理封包(玩家拆除灵石 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家拆除灵石(P.装备类型, P.装备位置, P.装备孔位);
        }
        public void 处理封包(OrdinaryInscriptionRefinementPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.OrdinaryInscriptionRefinementPacket(P.装备类型, P.装备位置, P.Id);
        }
        public void 处理封包(高级铭文洗练 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.高级铭文洗练(P.装备类型, P.装备位置, P.Id);
        }
        public void 处理封包(ReplaceInscriptionRefinementPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.ReplaceInscriptionRefinementPacket(P.装备类型, P.装备位置, P.Id);
        }
        public void 处理封包(ReplaceAdvancedInscriptionPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.高级洗练确认(P.装备类型, P.装备位置);
        }
        public void 处理封包(ReplaceLowLevelInscriptionsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.替换洗练确认(P.装备类型, P.装备位置);
        }
        public void 处理封包(AbandonInscriptionReplacementPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.放弃替换铭文();
        }
        public void 处理封包(UnlockDoubleInscriptionSlotPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.UnlockDoubleInscriptionSlotPacket(P.装备类型, P.装备位置, P.操作参数);
        }
        public void 处理封包(ToggleDoubleInscriptionBitPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.ToggleDoubleInscriptionBitPacket(P.装备类型, P.装备位置, P.操作参数);
        }
        public void 处理封包(传承武器铭文 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.传承武器铭文(P.来源类型, P.来源位置, P.目标类型, P.目标位置);
        }
        public void 处理封包(升级武器普通 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.升级武器普通(P.首饰组, P.材料组);
        }
        public void 处理封包(CharacterSelectionTargetPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.SelectObject(P.对象编号);
        }
        public void 处理封包(开始Npcc对话 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.开始Npcc对话(P.对象编号);
        }
        public void 处理封包(继续Npcc对话 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.继续Npcc对话(P.Id);
        }
        public void 处理封包(查看玩家装备 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查看对象装备(P.对象编号);
        }
        public void 处理封包(RequestDragonguardDataPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(RequestSoulStoneDataPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(查询奖励找回 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(同步角色战力 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询玩家战力(P.对象编号);
        }
        public void 处理封包(查询问卷调查 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(玩家申请交易 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家申请交易(P.对象编号);
        }
        public void 处理封包(玩家同意交易 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家同意交易(P.对象编号);
        }
        public void 处理封包(玩家结束交易 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家结束交易();
        }
        public void 处理封包(玩家放入金币 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家放入金币(P.NumberGoldCoins);
        }
        public void 处理封包(玩家放入物品 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家放入物品(P.放入位置, P.放入物品, P.物品容器, P.物品位置);
        }
        public void 处理封包(玩家锁定交易 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家锁定交易();
        }
        public void 处理封包(玩家解锁交易 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家解锁交易();
        }
        public void 处理封包(玩家确认交易 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家确认交易();
        }
        public void 处理封包(玩家准备摆摊 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家准备摆摊();
        }
        public void 处理封包(玩家重整摊位 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家重整摊位();
        }
        public void 处理封包(玩家开始摆摊 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家开始摆摊();
        }
        public void 处理封包(玩家收起摊位 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家收起摊位();
        }
        public void 处理封包(PutItemsInBoothPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.PutItemsInBoothPacket(P.放入位置, P.物品容器, P.物品位置, P.物品数量, P.物品价格);
        }
        public void 处理封包(取回摊位物品 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.取回摊位物品(P.取回位置);
        }
        public void 处理封包(更改摊位名字 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.更改摊位名字(P.摊位名字);
        }
        public void 处理封包(更改摊位外观 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.升级摊位外观(P.外观编号);
        }
        public void 处理封包(打开角色摊位 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家打开摊位(P.对象编号);
        }
        public void 处理封包(购买摊位物品 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.购买摊位物品(P.对象编号, P.物品位置, P.购买数量);
        }
        public void 处理封包(AddFriendsToFollowPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家添加关注(P.对象编号, P.对象名字);
        }
        public void 处理封包(取消好友关注 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家取消关注(P.对象编号);
        }
        public void 处理封包(CreateNewFriendGroupPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(MobileFriendsGroupPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(SendFriendChatPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.字节数据.Length < 7)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("数据太短,断开连接.  处理封包: {0},  数据长度:{1}", P.GetType(), P.字节数据.Length)));
                return;
            }
            if (P.字节数据.Last<byte>() != 0)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("数据错误,断开连接.  处理封包: {0},  无结束符.", P.GetType())));
                return;
            }
            this.Player.玩家好友聊天(P.字节数据);
        }
        public void 处理封包(玩家添加仇人 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家添加仇人(P.对象编号);
        }
        public void 处理封包(玩家删除仇人 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家删除仇人(P.对象编号);
        }
        public void 处理封包(玩家屏蔽对象 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家屏蔽目标(P.对象编号);
        }
        public void 处理封包(玩家解除屏蔽 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家解除屏蔽(P.对象编号);
        }
        public void 处理封包(玩家比较成就 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(SendChatMessagePacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.字节数据.Length < 7)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("数据太短,断开连接.  处理封包: {0},  数据长度:{1}", P.GetType(), P.字节数据.Length)));
                return;
            }
            if (P.字节数据.Last<byte>() != 0)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("数据错误,断开连接.  处理封包: {0},  无结束符.", P.GetType())));
                return;
            }
            this.Player.玩家发送广播(P.字节数据);
        }
        public void 处理封包(SendSocialMessagePacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            if (P.字节数据.Length < 6)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("数据太短,断开连接.  处理封包: {0},  数据长度:{1}", P.GetType(), P.字节数据.Length)));
                return;
            }
            if (P.字节数据.Last<byte>() != 0)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("数据错误,断开连接.  处理封包: {0},  无结束符.", P.GetType())));
                return;
            }
            this.Player.玩家发送消息(P.字节数据);
        }
        public void 处理封包(RequestCharacterDataPacket P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.请求角色资料(P.角色编号);
        }
        public void 处理封包(上传社交信息 P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(查询附近队伍 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询附近队伍();
        }
        public void 处理封包(查询队伍信息 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询队伍信息(P.对象编号);
        }
        public void 处理封包(申请创建队伍 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请创建队伍(P.对象编号, P.分配方式);
        }
        public void 处理封包(SendTeamRequestPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.SendTeamRequestPacket(P.对象编号);
        }
        public void 处理封包(申请离开队伍 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请队员离队(P.对象编号);
        }
        public void 处理封包(申请更改队伍 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请移交队长(P.队长编号);
        }
        public void 处理封包(回应组队请求 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.回应组队请求(P.对象编号, P.组队方式, P.回应方式);
        }
        public void 处理封包(玩家装配称号 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家使用称号(P.Id);
        }
        public void 处理封包(玩家卸下称号 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家卸下称号();
        }
        public void 处理封包(申请发送邮件 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请发送邮件(P.字节数据);
        }
        public void 处理封包(QueryMailboxContentPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.QueryMailboxContentPacket();
        }
        public void 处理封包(查看邮件内容 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查看邮件内容(P.邮件编号);
        }
        public void 处理封包(删除指定邮件 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.删除指定邮件(P.邮件编号);
        }
        public void 处理封包(提取邮件附件 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.提取邮件附件(P.邮件编号);
        }
        public void 处理封包(查询GuildName P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询行会信息(P.行会编号);
        }
        public void 处理封包(更多行会信息 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.更多行会信息();
        }
        public void 处理封包(查看行会列表 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查看行会列表(P.行会编号, P.查看方式);
        }
        public void 处理封包(FindCorrespondingGuildPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.FindCorrespondingGuildPacket(P.行会编号, P.GuildName);
        }
        public void 处理封包(申请加入行会 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请加入行会(P.行会编号, P.GuildName);
        }
        public void 处理封包(查看申请列表 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查看申请列表();
        }
        public void 处理封包(处理入会申请 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.处理入会申请(P.对象编号, P.处理类型);
        }
        public void 处理封包(处理入会邀请 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.处理入会邀请(P.对象编号, P.处理类型);
        }
        public void 处理封包(InviteToJoinGuildPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.InviteToJoinGuildPacket(P.对象名字);
        }
        public void 处理封包(OpenChestPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }

            this.Player.OpenChest(P.ObjectId);
        }
        public void 处理封包(CreateGuildPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请创建行会(P.Data);
        }
        public void 处理封包(申请解散行会 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请解散行会();
        }
        public void 处理封包(DonateGuildFundsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.DonateGuildFundsPacket(P.NumberGoldCoins);
        }
        public void 处理封包(DistributeGuildBenefitsPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.DistributeGuildBenefitsPacket();
        }
        public void 处理封包(申请离开行会 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请离开行会();
        }
        public void 处理封包(更改行会公告 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.更改行会公告(P.行会公告);
        }
        public void 处理封包(更改行会宣言 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.更改行会宣言(P.行会宣言);
        }
        public void 处理封包(设置行会禁言 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.设置行会禁言(P.对象编号, P.禁言状态);
        }
        public void 处理封包(变更会员职位 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.变更会员职位(P.对象编号, P.对象职位);
        }
        public void 处理封包(ExpelMembersPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.ExpelMembersPacket(P.对象编号);
        }
        public void 处理封包(TransferPresidentPositionPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.TransferPresidentPositionPacket(P.对象编号);
        }
        public void 处理封包(申请行会外交 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请行会外交(P.外交类型, P.外交时间, P.GuildName);
        }
        public void 处理封包(申请行会Hostility P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请行会Hostility(P.Hostility时间, P.GuildName);
        }
        public void 处理封包(处理结盟申请 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.处理结盟申请(P.处理类型, P.行会编号);
        }
        public void 处理封包(申请解除结盟 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请解除结盟(P.行会编号);
        }
        public void 处理封包(申请解除Hostility P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.申请解除Hostility(P.行会编号);
        }
        public void 处理封包(处理解敌申请 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.处理解除申请(P.行会编号, P.回应类型);
        }
        public void 处理封包(更改存储权限 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(查看结盟申请 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查看结盟申请();
        }
        public void 处理封包(更多GuildEvents P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.更多GuildEvents();
        }
        public void 处理封包(QueryGuildAchievementsPacket P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(开启行会活动 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(PublishWantedListPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(SyncedWantedListPacket P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(StartGuildWarPacket P)
        {
            if (this.CurrentStage != GameStage.LoadingScene && this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(查询地图路线 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询地图路线();
        }
        public void 处理封包(ToggleMapRoutePacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.ToggleMapRoutePacket();
        }
        public void 处理封包(跳过剧情动画 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(更改收徒推送 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.更改收徒推送(P.收徒推送);
        }
        public void 处理封包(查询师门成员 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询师门成员();
        }
        public void 处理封包(查询师门奖励 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询师门奖励();
        }
        public void 处理封包(查询拜师名册 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询拜师名册();
        }
        public void 处理封包(查询收徒名册 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询收徒名册();
        }
        public void 处理封包(CongratsToApprenticeForUpgradePacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(玩家申请拜师 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家申请拜师(P.对象编号);
        }
        public void 处理封包(同意拜师申请 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.同意拜师申请(P.对象编号);
        }
        public void 处理封包(RefusedApplyApprenticeshipPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.RefusedApplyApprenticeshipPacket(P.对象编号);
        }
        public void 处理封包(玩家申请收徒 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.玩家申请收徒(P.对象编号);
        }
        public void 处理封包(同意收徒申请 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.同意收徒申请(P.对象编号);
        }
        public void 处理封包(RejectionApprenticeshipAppPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.RejectionApprenticeshipAppPacket(P.对象编号);
        }
        public void 处理封包(AppForExpulsionPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.AppForExpulsionPacket(P.对象编号);
        }
        public void 处理封包(离开师门申请 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.离开师门申请();
        }
        public void 处理封包(提交出师申请 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.提交出师申请();
        }
        public void 处理封包(查询排名榜单 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询排名榜单(P.榜单类型, P.起始位置);
        }
        public void 处理封包(查看演武排名 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(刷新演武挑战 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(开始战场演武 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(EnterMartialArtsBatllefieldPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(跨服武道排名 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(LoginConsignmentPlatformPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.SendPacket(new 社交错误提示
            {
                错误编号 = 12804
            });
        }
        public void 处理封包(查询平台商品 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.SendPacket(new 社交错误提示
            {
                错误编号 = 12804
            });
        }
        public void 处理封包(InquireAboutSpecifiedProductPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.SendPacket(new 社交错误提示
            {
                错误编号 = 12804
            });
        }
        public void 处理封包(上架平台商品 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.SendPacket(new 社交错误提示
            {
                错误编号 = 12804
            });
        }
        public void 处理封包(RequestTreasureDataPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询珍宝商店(P.数据版本);
        }
        public void 处理封包(查询出售信息 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.查询出售信息();
        }
        public void 处理封包(购买珍宝商品 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.购买珍宝商品(P.Id, P.购买数量);
        }
        public void 处理封包(购买每周特惠 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.购买每周特惠(P.礼包编号);
        }
        public void 处理封包(购买玛法特权 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.购买玛法特权(P.特权类型, P.购买数量);
        }
        public void 处理封包(BookMarfaPrivilegesPacket P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.BookMarfaPrivilegesPacket(P.特权类型);
        }
        public void 处理封包(领取特权礼包 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Player.领取特权礼包(P.特权类型, P.礼包位置);
        }
        public void 处理封包(玩家每日签到 P)
        {
            if (this.CurrentStage != GameStage.PlayingScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
        }
        public void 处理封包(AcountLoginPacket P)
        {
            if (this.CurrentStage != GameStage.StartingSessionScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
            }
            else if (SystemData.Data.网卡封禁.TryGetValue(P.MacAddress, out DateTime t) && t > MainProcess.CurrentTime)
            {
                this.CallExceptionEventHandler(new Exception("NIC blocking, restricted login"));
            }
            else if (!NetworkServiceGateway.门票DataSheet.TryGetValue(P.Ticket, out TicketInformation TicketInformation))
            {
                this.CallExceptionEventHandler(new Exception("Logged tickets do not exist."));
            }
            else if (MainProcess.CurrentTime > TicketInformation.EffectiveTime)
            {
                this.CallExceptionEventHandler(new Exception("Login tickets have expired."));
            }
            else
            {
                AccountData AccountData2;
                if (GameDataGateway.AccountData表.Keyword.TryGetValue(TicketInformation.登录账号, out GameData GameData))
                {
                    AccountData AccountData = GameData as AccountData;
                    if (AccountData != null)
                    {
                        AccountData2 = AccountData;
                        goto IL_EF;
                    }
                }
                AccountData2 = new AccountData(TicketInformation.登录账号);
            IL_EF:
                AccountData AccountData3 = AccountData2;
                if (AccountData3.网络连接 != null)
                {
                    AccountData3.网络连接.SendPacket(new LoginErrorMessagePacket
                    {
                        错误代码 = 260U
                    });
                    AccountData3.网络连接.CallExceptionEventHandler(new Exception("Repeated login, kicked offline."));
                    this.CallExceptionEventHandler(new Exception("Account already online, unable to log in."));
                }
                else
                {
                    AccountData3.账号登录(this, P.MacAddress);
                }
            }
            NetworkServiceGateway.门票DataSheet.Remove(P.Ticket);
        }
        public void 处理封包(客户创建角色 P)
        {
            if (this.CurrentStage != GameStage.SelectingCharacterScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Account.创建角色(this, P);
        }
        public void 处理封包(客户删除角色 P)
        {
            if (this.CurrentStage != GameStage.SelectingCharacterScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Account.删除角色(this, P);
        }
        public void 处理封包(彻底删除角色 P)
        {
            if (this.CurrentStage != GameStage.SelectingCharacterScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Account.永久删除(this, P);
        }
        public void 处理封包(客户进入游戏 P)
        {
            if (this.CurrentStage != GameStage.SelectingCharacterScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Account.进入游戏(this, P);
        }
        public void 处理封包(客户GetBackCharacterPacket P)
        {
            if (this.CurrentStage != GameStage.SelectingCharacterScene)
            {
                this.CallExceptionEventHandler(new Exception(string.Format("Phase exception, disconnected.  Processing packet: {0}, Current phase: {1}", P.GetType(), this.CurrentStage)));
                return;
            }
            this.Account.GetBackCharacter(this, P);
        }
    }
}
