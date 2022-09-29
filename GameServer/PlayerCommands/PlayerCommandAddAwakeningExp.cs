using GameServer.Data;
using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.PlayerCommands
{
    public class PlayerCommandAddAwakeningExp : PlayerCommand
    {
        [Field(Position = 0)]
        public int Amount;

        public override void Execute()
        {
            if (Amount + Player.CharacterData.AwakeningExp.V > Config.MaxAwakeningExp)
            {
                Amount = Config.MaxAwakeningExp - Player.CharacterData.AwakeningExp.V;
                Player.CharacterData.AwakeningExpEnabled.V = false;
                Player.ActiveConnection?.SendPacket(new SyncSupplementaryVariablesPacket
                {
                    变量类型 = 1,
                    变量索引 = 50,
                    对象编号 = Player.ObjectId,
                    变量内容 = 3616
                });
            }

            Player.CharacterData.AwakeningExp.V += Amount;

            Player.ActiveConnection?.SendPacket(new CharacterExpChangesPacket
            {
                经验增加 = 0,
                今日增加 = 0,
                经验上限 = 10000000,
                DoubleExp = Player.DoubleExp,
                CurrentExp = Player.CurrentExp,
                升级所需 = Player.MaxExperience,
                GainAwakeningExp = Amount,
                MaxAwakeningExp = Config.MaxAwakeningExp
            });
        }
    }
}
