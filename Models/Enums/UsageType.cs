using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Enums
{
    public enum UsageType
    {
        Unknown = 0,
        RecoveryHP = 1,
        RecoveryMP = 2,
        Medicine = 3,
        RandomTeleport = 4,
        Treasure = 5,
        UnpackStack = 6,
        GainIngots = 7,
        TownTeleport = 8,
        Blessing = 9,
        SwitchSkill = 10,  //切换技能
        AdquireMount = 11 //获取坐骑
    }
}
