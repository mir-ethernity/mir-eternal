using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using GameServer.Data;
using GameServer.Templates;
using GameServer.Networking;
using GamePackets.Server;

namespace GameServer.Maps
{

    public abstract class MapObject
    {

        public override string ToString()
        {
            return this.ObjectName;
        }

        public DateTime RecoveryTime { get; set; }
        public DateTime HealTime { get; set; }
        public DateTime TimeoutTime { get; set; }
        public DateTime CurrentTime { get; set; }
        public DateTime ProcessTime { get; set; }
        public virtual int ProcessInterval { get; }
        public int TreatmentCount { get; set; }
        public int TreatmentBase { get; set; }
        public byte ActionId { get; set; }
        public bool FightingStance { get; set; }
        public abstract GameObjectType ObjectType { get; }
        public abstract ObjectSize ObjectSize { get; }
        public ushort WalkSpeed => (ushort)this[GameObjectStats.WalkSpeed];
        public ushort RunSpeed => (ushort)this[GameObjectStats.RunSpeed];
        public virtual int WalkInterval => WalkSpeed * 60;
        public virtual int RunInterval => RunSpeed * 60;
        public virtual int ObjectId { get; set; }
        public virtual int CurrentHP { get; set; }
        public virtual int CurrentMP { get; set; }
        public virtual byte CurrentLevel { get; set; }
        public virtual bool Died { get; set; }
        public virtual bool Blocking { get; set; }
        public virtual bool CanBeHit => !this.Died;
        public virtual string ObjectName { get; set; }
        public virtual GameDirection CurrentDirection { get; set; }
        public virtual MapInstance CurrentMap { get; set; }
        public virtual Point CurrentPosition { get; set; }
        public virtual ushort CurrentAltitude => CurrentMap.GetTerrainHeight(CurrentPosition);
        public virtual DateTime BusyTime { get; set; }
        public virtual DateTime HardTime { get; set; }
        public virtual DateTime WalkTime { get; set; }
        public virtual DateTime RunTime { get; set; }
        public virtual Dictionary<GameObjectStats, int> Stats { get; }
        public virtual MonitorDictionary<int, DateTime> Coolings { get; }
        public virtual MonitorDictionary<ushort, BuffData> Buffs { get; }

        public bool SecondaryObject;
        public bool ActiveObject;
        public HashSet<MapObject> NeighborsImportant;
        public HashSet<MapObject> NeighborsSneak;
        public HashSet<MapObject> Neighbors;
        public HashSet<SkillInstance> SkillTasks;
        public HashSet<TrapObject> Traps;
        public Dictionary<object, Dictionary<GameObjectStats, int>> StatsBonus;

        public virtual int this[GameObjectStats Stat]
        {
            get
            {
                if (!Stats.ContainsKey(Stat))
                {
                    return 0;
                }
                return Stats[Stat];
            }
            set
            {
                Stats[Stat] = value;
                if (Stat == GameObjectStats.MaxHP)
                {
                    CurrentHP = Math.Min(CurrentHP, value);
                    return;
                }
                if (Stat == GameObjectStats.MaxMP)
                {
                    CurrentMP = Math.Min(CurrentMP, value);
                }
            }
        }

        public virtual void RefreshStats()
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            foreach (object obj in Enum.GetValues(typeof(GameObjectStats)))
            {
                int num5 = 0;
                GameObjectStats stat = (GameObjectStats)obj;
                foreach (KeyValuePair<object, Dictionary<GameObjectStats, int>> keyValuePair in StatsBonus)
                {
                    int num6;
                    if (keyValuePair.Value != null && keyValuePair.Value.TryGetValue(stat, out num6) && num6 != 0)
                    {
                        if (keyValuePair.Key is BuffData)
                        {
                            if (stat == GameObjectStats.WalkSpeed)
                            {
                                num2 = Math.Max(num2, num6);
                                num = Math.Min(num, num6);
                            }
                            else if (stat == GameObjectStats.RunSpeed)
                            {
                                num4 = Math.Max(num4, num6);
                                num3 = Math.Min(num3, num6);
                            }
                            else
                            {
                                num5 += num6;
                            }
                        }
                        else
                        {
                            num5 += num6;
                        }
                    }
                }
                if (stat == GameObjectStats.WalkSpeed)
                {
                    this[stat] = Math.Max(1, num5 + num + num2);
                }
                else if (stat == GameObjectStats.RunSpeed)
                {
                    this[stat] = Math.Max(1, num5 + num3 + num4);
                }
                else if (stat == GameObjectStats.Luck)
                {
                    this[stat] = num5;
                }
                else
                {
                    this[stat] = Math.Max(0, num5);
                }
            }

            if (this is PlayerObject playerObject)
            {
                foreach (PetObject petObject in playerObject.Pets)
                {
                    if (petObject.Template.InheritsStats != null)
                    {
                        var dictionary = new Dictionary<GameObjectStats, int>();
                        foreach (var InheritStat in petObject.Template.InheritsStats)
                        {
                            dictionary[InheritStat.ConvertStat] = (int)(this[InheritStat.InheritsStats] * InheritStat.Ratio);
                        }
                        petObject.StatsBonus[playerObject.CharacterData] = dictionary;
                        petObject.RefreshStats();
                    }
                }
            }
        }

        public virtual void Process()
        {
            CurrentTime = MainProcess.CurrentTime;
            ProcessTime = MainProcess.CurrentTime.AddMilliseconds(ProcessInterval);
        }

        public virtual void Dies(MapObject obj, bool skillKill)
        {
            SendPacket(new ObjectDiesPacket
            {
                ObjectId = ObjectId
            });

            SkillTasks.Clear();
            Died = true;
            Blocking = false;

            foreach (var neightborObject in Neighbors)
                neightborObject.NotifyObjectDies(this);
        }

        public MapObject()
        {
            CurrentTime = MainProcess.CurrentTime;
            SkillTasks = new HashSet<SkillInstance>();
            Traps = new HashSet<TrapObject>();
            NeighborsImportant = new HashSet<MapObject>();
            NeighborsSneak = new HashSet<MapObject>();
            Neighbors = new HashSet<MapObject>();
            Stats = new Dictionary<GameObjectStats, int>();
            Coolings = new MonitorDictionary<int, DateTime>(null);
            Buffs = new MonitorDictionary<ushort, BuffData>(null);
            StatsBonus = new Dictionary<object, Dictionary<GameObjectStats, int>>();
            ProcessTime = MainProcess.CurrentTime.AddMilliseconds(MainProcess.RandomNumber.Next(ProcessInterval));
        }

        public void UnbindGrid()
        {
            foreach (Point location in ComputingClass.GetLocationRange(CurrentPosition, CurrentDirection, ObjectSize))
                CurrentMap[location].Remove(this);
        }

        public void BindGrid()
        {
            foreach (Point location in ComputingClass.GetLocationRange(CurrentPosition, CurrentDirection, ObjectSize))
                CurrentMap[location].Add(this);
        }

        public void Delete()
        {
            NotifyNeightborClear();
            UnbindGrid();
            SecondaryObject = false;
            MapGatewayProcess.RemoveObject(this);
            ActiveObject = false;
            MapGatewayProcess.DeactivateObject(this);
        }

        public int GetDistance(Point location) => ComputingClass.GridDistance(this.CurrentPosition, location);

        public int GetDistance(MapObject obj) => ComputingClass.GridDistance(this.CurrentPosition, obj.CurrentPosition);

        public void SendPacket(GamePacket packet)
        {
            if (packet.PacketInfo.Broadcast)
                BroadcastPacket(packet);

            if (this is PlayerObject playerObj)
                playerObj.ActiveConnection?.SendPacket(packet);
        }

        private void BroadcastPacket(GamePacket packet)
        {
            foreach (MapObject obj in this.Neighbors)
            {
                PlayerObject PlayerObject = obj as PlayerObject;
                if (PlayerObject != null && !PlayerObject.NeighborsSneak.Contains(this) && PlayerObject != null)
                {
                    PlayerObject.ActiveConnection.SendPacket(packet);
                }
            }
        }

        public bool CanBeSeenBy(MapObject obj)
        {
            return Math.Abs(CurrentPosition.X - obj.CurrentPosition.X) <= 20
                && Math.Abs(CurrentPosition.Y - obj.CurrentPosition.Y) <= 20;
        }


        public bool CanAttack(MapObject obj)
        {
            if (obj.Died)
                return false;

            if (this is MonsterObject monsterObject)
            {
                return monsterObject.ActiveAttackTarget && (
                    obj is PlayerObject
                    || obj is PetObject
                    || (obj is GuardObject guardObject && guardObject.CanBeInjured)
                    );
            }
            else if (this is GuardObject guardObject)
            {
                return guardObject.ActiveAttackTarget
                    && (
                        (obj is MonsterObject neightborMonsterObject && neightborMonsterObject.ActiveAttackTarget)
                        || (obj is PlayerObject playerObject && playerObject.红名玩家)
                        || (obj is PetObject && guardObject.MobId == 6734)
                    );
            }
            else if (this is PetObject)
            {
                return obj is MonsterObject neightborMonsterObject
                    && neightborMonsterObject.ActiveAttackTarget;
            }

            return false;
        }

        public bool IsNeightbor(MapObject obj)
        {
            switch (ObjectType)
            {
                case GameObjectType.Player:
                    return true;
                case GameObjectType.Pet:
                case GameObjectType.Monster:
                    return obj.ObjectType == GameObjectType.Monster
                        || obj.ObjectType == GameObjectType.Player
                        || obj.ObjectType == GameObjectType.Pet
                        || obj.ObjectType == GameObjectType.NPC
                        || obj.ObjectType == GameObjectType.Trap;
                case GameObjectType.NPC:
                    return obj.ObjectType == GameObjectType.Monster
                        || obj.ObjectType == GameObjectType.Player
                        || obj.ObjectType == GameObjectType.Pet
                        || obj.ObjectType == GameObjectType.Trap;
                case GameObjectType.Item:
                    return obj.ObjectType == GameObjectType.Player;
                case GameObjectType.Trap:
                    return obj.ObjectType == GameObjectType.Player
                        || obj.ObjectType == GameObjectType.Pet;
            }

            return false;
        }

        public GameObjectRelationship GetRelationship(MapObject obj)
        {
            if (this == obj)
                return GameObjectRelationship.ItSelf;

            if (obj is TrapObject neightborTrapObject)
                obj = neightborTrapObject.TrapSource;

            if (this is GuardObject)
            {
                if (obj is MonsterObject || obj is PetObject || obj is PlayerObject)
                    return GameObjectRelationship.Hostility;
            }
            else if (this is PlayerObject playerObject)
            {
                if (obj is MonsterObject)
                    return GameObjectRelationship.Hostility;
                else if (obj is GuardObject)
                    return playerObject.AttackMode == AttackMode.全体 && CurrentMap.MapId != 80
                        ? GameObjectRelationship.Hostility
                        : GameObjectRelationship.Friendly;
                else if (obj is PlayerObject neightborPlayerObject)
                    return playerObject.AttackMode == AttackMode.和平
                        || (
                            playerObject.AttackMode == AttackMode.行会
                            && playerObject.Guild != null
                            && neightborPlayerObject.Guild != null
                            && (
                                playerObject.Guild == neightborPlayerObject.Guild
                                || playerObject.Guild.结盟行会.ContainsKey(neightborPlayerObject.Guild)
                            )
                        )
                        || (
                            playerObject.AttackMode == AttackMode.组队 && (
                                playerObject.Team != null && neightborPlayerObject.Team != null
                                && playerObject.Team == neightborPlayerObject.Team
                            )
                        )
                        || (
                            playerObject.AttackMode == AttackMode.善恶 && (
                                !playerObject.红名玩家 && !neightborPlayerObject.红名玩家
                            )
                        )
                        || (
                            playerObject.AttackMode == AttackMode.Hostility && (
                                playerObject.Guild == null
                                || neightborPlayerObject == null
                                || !playerObject.Guild.Hostility行会.ContainsKey(neightborPlayerObject.Guild)
                            )
                        )
                        ? GameObjectRelationship.Friendly
                        : GameObjectRelationship.Hostility;
                else if (obj is PetObject petObject)
                    return (petObject.PlayerOwner == this && playerObject.AttackMode != AttackMode.全体)
                        || (playerObject.AttackMode == AttackMode.和平)
                        || (playerObject.AttackMode == AttackMode.行会 && playerObject.Guild != null && petObject.PlayerOwner.Guild != null && (playerObject.Guild == petObject.PlayerOwner.Guild || playerObject.Guild.结盟行会.ContainsKey(petObject.PlayerOwner.Guild)))
                        || (playerObject.AttackMode == AttackMode.组队 && playerObject.Team != null && petObject.PlayerOwner.Team != null && playerObject.Team == petObject.PlayerOwner.Team)
                        || (playerObject.AttackMode == AttackMode.善恶 && !petObject.PlayerOwner.红名玩家 && !petObject.PlayerOwner.灰名玩家)
                        || (playerObject.AttackMode != AttackMode.Hostility && (
                            playerObject.Guild == null
                            || petObject.PlayerOwner.Guild == null
                            || !playerObject.Guild.Hostility行会.ContainsKey(petObject.PlayerOwner.Guild)
                        ))
                        ? GameObjectRelationship.Friendly
                        : petObject.PlayerOwner == this
                            ? GameObjectRelationship.Friendly | GameObjectRelationship.Hostility
                            : GameObjectRelationship.Hostility;

            }
            else if (this is PetObject petObject)
                return petObject.PlayerOwner != obj
                    ? petObject.PlayerOwner.GetRelationship(obj)
                    : GameObjectRelationship.Friendly;
            else if (this is TrapObject trapObject)
                return trapObject.TrapSource.GetRelationship(obj);
            else if (obj is not MonsterObject)
                return GameObjectRelationship.Hostility;

            return GameObjectRelationship.Friendly;
        }

        public bool IsSpecificType(MapObject obj, SpecifyTargetType targetType)
        {
            if (obj is TrapObject trapObject)
                obj = trapObject.TrapSource;

            var targetDirection = ComputingClass.GetDirection(obj.CurrentPosition, CurrentPosition);

            if (this is MonsterObject monsterObject)
            {
                return targetType == SpecifyTargetType.None
                    || (targetType & SpecifyTargetType.LowLevelTarget) == SpecifyTargetType.LowLevelTarget && CurrentLevel < obj.CurrentLevel
                    || (targetType & SpecifyTargetType.AllMonsters) == SpecifyTargetType.AllMonsters
                    || (targetType & SpecifyTargetType.LowLevelMonster) == SpecifyTargetType.LowLevelMonster && CurrentLevel < obj.CurrentLevel
                    || ((targetType & SpecifyTargetType.LowBloodMonster) == SpecifyTargetType.LowBloodMonster && (float)this.CurrentHP / (float)this[GameObjectStats.MaxHP] < 0.4f)
                    || ((targetType & SpecifyTargetType.Normal) == SpecifyTargetType.Normal && monsterObject.Category == MonsterLevelType.Normal)
                    || ((targetType & SpecifyTargetType.Undead) == SpecifyTargetType.Undead && monsterObject.怪物种族 == MonsterRaceType.Undead)
                    || ((targetType & SpecifyTargetType.ZergCreature) == SpecifyTargetType.ZergCreature && monsterObject.怪物种族 == MonsterRaceType.ZergCreature)
                    || ((targetType & SpecifyTargetType.WomaMonster) == SpecifyTargetType.WomaMonster && monsterObject.怪物种族 == MonsterRaceType.WomaMonster)
                    || ((targetType & SpecifyTargetType.PigMonster) == SpecifyTargetType.PigMonster && monsterObject.怪物种族 == MonsterRaceType.PigMonster)
                    || ((targetType & SpecifyTargetType.ZumaMonster) == SpecifyTargetType.ZumaMonster && monsterObject.怪物种族 == MonsterRaceType.ZumaMonster)
                    || ((targetType & SpecifyTargetType.DragonMonster) == SpecifyTargetType.DragonMonster && monsterObject.怪物种族 == MonsterRaceType.DragonMonster)
                    || ((targetType & SpecifyTargetType.EliteMonsters) == SpecifyTargetType.EliteMonsters && (monsterObject.Category == MonsterLevelType.Elite || monsterObject.Category == MonsterLevelType.Boss))
                    || (((targetType & SpecifyTargetType.Backstab) == SpecifyTargetType.Backstab) && (
                            (CurrentDirection == GameDirection.上方 && (targetDirection == GameDirection.左上 || targetDirection == GameDirection.上方 || targetDirection == GameDirection.右上))
                            || (CurrentDirection == GameDirection.左上 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.左上 || targetDirection == GameDirection.上方))
                            || (CurrentDirection == GameDirection.左方 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.左上 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.右方 && (targetDirection == GameDirection.右上 || targetDirection == GameDirection.右方 || targetDirection == GameDirection.右下))
                            || (CurrentDirection == GameDirection.右上 && (targetDirection == GameDirection.上方 || targetDirection == GameDirection.右上 || targetDirection == GameDirection.右方))
                            || (CurrentDirection == GameDirection.左下 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.下方 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.下方 && (targetDirection == GameDirection.右下 || targetDirection == GameDirection.下方 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.右下 && (targetDirection == GameDirection.右方 || targetDirection == GameDirection.右下 || targetDirection == GameDirection.下方))
                        )
                    );
            }
            else if (this is GuardObject)
            {
                return targetType == SpecifyTargetType.None
                    || ((targetType & SpecifyTargetType.LowLevelTarget) == SpecifyTargetType.LowLevelTarget && CurrentLevel < obj.CurrentLevel)
                    || (((targetType & SpecifyTargetType.Backstab) == SpecifyTargetType.Backstab) && (
                       (CurrentDirection == GameDirection.上方 && (targetDirection == GameDirection.左上 || targetDirection == GameDirection.上方 || targetDirection == GameDirection.右上))
                            || (CurrentDirection == GameDirection.左上 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.左上 || targetDirection == GameDirection.上方))
                            || (CurrentDirection == GameDirection.左方 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.左上 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.右方 && (targetDirection == GameDirection.右上 || targetDirection == GameDirection.右方 || targetDirection == GameDirection.右下))
                            || (CurrentDirection == GameDirection.右上 && (targetDirection == GameDirection.上方 || targetDirection == GameDirection.右上 || targetDirection == GameDirection.右方))
                            || (CurrentDirection == GameDirection.左下 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.下方 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.下方 && (targetDirection == GameDirection.右下 || targetDirection == GameDirection.下方 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.右下 && (targetDirection == GameDirection.右方 || targetDirection == GameDirection.右下 || targetDirection == GameDirection.下方))
                    ));
            }
            else if (this is PetObject petObject)
            {
                return targetType == SpecifyTargetType.None
                    || ((targetType & SpecifyTargetType.LowLevelTarget) == SpecifyTargetType.LowLevelTarget && this.CurrentLevel < obj.CurrentLevel)
                    || ((targetType & SpecifyTargetType.Undead) == SpecifyTargetType.Undead && petObject.宠物种族 == MonsterRaceType.Undead)
                    || ((targetType & SpecifyTargetType.ZergCreature) == SpecifyTargetType.ZergCreature && petObject.宠物种族 == MonsterRaceType.ZergCreature)
                    || ((targetType & SpecifyTargetType.AllPets) == SpecifyTargetType.AllPets)
                    || (((targetType & SpecifyTargetType.Backstab) == SpecifyTargetType.Backstab) && (
                     (CurrentDirection == GameDirection.上方 && (targetDirection == GameDirection.左上 || targetDirection == GameDirection.上方 || targetDirection == GameDirection.右上))
                            || (CurrentDirection == GameDirection.左上 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.左上 || targetDirection == GameDirection.上方))
                            || (CurrentDirection == GameDirection.左方 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.左上 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.右方 && (targetDirection == GameDirection.右上 || targetDirection == GameDirection.右方 || targetDirection == GameDirection.右下))
                            || (CurrentDirection == GameDirection.右上 && (targetDirection == GameDirection.上方 || targetDirection == GameDirection.右上 || targetDirection == GameDirection.右方))
                            || (CurrentDirection == GameDirection.左下 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.下方 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.下方 && (targetDirection == GameDirection.右下 || targetDirection == GameDirection.下方 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.右下 && (targetDirection == GameDirection.右方 || targetDirection == GameDirection.右下 || targetDirection == GameDirection.下方))
                    ));
            }
            else if (this is PlayerObject playerObject)
            {
                return targetType == SpecifyTargetType.None
                || ((targetType & SpecifyTargetType.LowLevelTarget) == SpecifyTargetType.LowLevelTarget && this.CurrentLevel < obj.CurrentLevel)
                    || ((targetType & SpecifyTargetType.ShieldMage) == SpecifyTargetType.ShieldMage && playerObject.CharRole == GameObjectRace.法师 && playerObject.Buffs.ContainsKey(25350))
                    || (((targetType & SpecifyTargetType.Backstab) == SpecifyTargetType.Backstab) && (
                     (CurrentDirection == GameDirection.上方 && (targetDirection == GameDirection.左上 || targetDirection == GameDirection.上方 || targetDirection == GameDirection.右上))
                            || (CurrentDirection == GameDirection.左上 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.左上 || targetDirection == GameDirection.上方))
                            || (CurrentDirection == GameDirection.左方 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.左上 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.右方 && (targetDirection == GameDirection.右上 || targetDirection == GameDirection.右方 || targetDirection == GameDirection.右下))
                            || (CurrentDirection == GameDirection.右上 && (targetDirection == GameDirection.上方 || targetDirection == GameDirection.右上 || targetDirection == GameDirection.右方))
                            || (CurrentDirection == GameDirection.左下 && (targetDirection == GameDirection.左方 || targetDirection == GameDirection.下方 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.下方 && (targetDirection == GameDirection.右下 || targetDirection == GameDirection.下方 || targetDirection == GameDirection.左下))
                            || (CurrentDirection == GameDirection.右下 && (targetDirection == GameDirection.右方 || targetDirection == GameDirection.右下 || targetDirection == GameDirection.下方))
                    ));
            }

            return false;
        }


        public virtual bool CanMove()
        {
            return !Died && !(MainProcess.CurrentTime < BusyTime) && !(MainProcess.CurrentTime < WalkTime) && !CheckStatus(GameObjectState.BusyGreen | GameObjectState.Inmobilized | GameObjectState.Paralyzed | GameObjectState.Absence);
        }

        public virtual bool CanRun()
        {
            return !Died && !(MainProcess.CurrentTime < BusyTime) && !(MainProcess.CurrentTime < this.RunTime) && !CheckStatus(GameObjectState.BusyGreen | GameObjectState.Disabled | GameObjectState.Inmobilized | GameObjectState.Paralyzed | GameObjectState.Absence);
        }

        public virtual bool CanBeTurned()
        {
            return !Died && !(MainProcess.CurrentTime < BusyTime) && !(MainProcess.CurrentTime < WalkTime) && !CheckStatus(GameObjectState.BusyGreen | GameObjectState.Paralyzed | GameObjectState.Absence);
        }

        public virtual bool CanBePushed(MapObject obj)
        {
            return obj == this
                || (
                    this is MonsterObject monsterObject
                    && monsterObject.CanBeDrivenBySkills
                    && obj.GetRelationship(this) == GameObjectRelationship.Hostility
                );
        }


        public virtual bool CanBeDisplaced(MapObject obj, Point location, int distance, int qty, bool throughtWall, out Point displacedLocation, out MapObject[] targets)
        {
            displacedLocation = CurrentPosition;
            targets = null;

            if (!(CurrentPosition == location) && CanBePushed(obj))
            {
                List<MapObject> list = new List<MapObject>();
                for (int i = 1; i <= distance; i++)
                {
                    if (throughtWall)
                    {
                        Point point = ComputingClass.GetFrontPosition(CurrentPosition, location, i);
                        if (CurrentMap.CanPass(point))
                        {
                            displacedLocation = point;
                        }
                        continue;
                    }
                    GameDirection 方向 = ComputingClass.GetDirection(CurrentPosition, location);
                    Point point2 = ComputingClass.GetFrontPosition(CurrentPosition, location, i);
                    if (CurrentMap.IsBlocked(point2))
                    {
                        break;
                    }
                    bool flag = false;
                    if (CurrentMap.CellBlocked(point2))
                    {
                        foreach (MapObject item in CurrentMap[point2].Where((MapObject O) => O.Blocking))
                        {
                            if (list.Count >= qty)
                            {
                                flag = true;
                                break;
                            }
                            if (!item.CanBeDisplaced(obj, ComputingClass.前方坐标(item.CurrentPosition, 方向, 1), 1, qty - list.Count - 1, throughtWall: false, out var _, out var targets2))
                            {
                                flag = true;
                                break;
                            }
                            list.Add(item);
                            list.AddRange(targets2);
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                    displacedLocation = point2;
                }
                targets = list.ToArray();
                return displacedLocation != CurrentPosition;
            }
            return false;
        }

        public virtual bool CheckStatus(GameObjectState state)
        {
            foreach (BuffData BuffData in this.Buffs.Values)
            {
                if ((BuffData.Effect & BuffEffectType.StatusFlag) != BuffEffectType.SkillSign && (BuffData.Template.PlayerState & state) != GameObjectState.Normal)
                {
                    return true;
                }
            }
            return false;
        }


        public void OnAddBuff(ushort buffId, MapObject obj)
        {
            if (this is ItemObject || this is TrapObject || (this is GuardObject guardObject && !guardObject.CanBeInjured))
                return;

            if (obj is TrapObject trapObject)
                obj = trapObject.TrapSource;


            if (!GameBuffs.DataSheet.TryGetValue(buffId, out var 游戏Buff))
                return;

            if ((游戏Buff.Effect & BuffEffectType.StatusFlag) != BuffEffectType.SkillSign)
            {
                if (((游戏Buff.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal || (游戏Buff.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal) && this.CheckStatus(GameObjectState.Exposed))
                    return;

                if ((游戏Buff.PlayerState & GameObjectState.Exposed) != GameObjectState.Normal)
                {
                    foreach (BuffData BuffData in this.Buffs.Values.ToList<BuffData>())
                    {
                        if ((BuffData.Template.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal || (BuffData.Template.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal)
                        {
                            移除Buff时处理(BuffData.Id.V);
                        }
                    }
                }
            }

            if ((游戏Buff.Effect & BuffEffectType.CausesSomeDamages) != BuffEffectType.SkillSign && 游戏Buff.DamageType == SkillDamageType.Burn && this.Buffs.ContainsKey(25352))
                return;

            ushort GroupId = (游戏Buff.GroupId != 0) ? 游戏Buff.GroupId : 游戏Buff.Id;
            BuffData BuffData2 = null;
            switch (游戏Buff.OverlayType)
            {
                case BuffOverlayType.SuperpositionDisabled:
                    if (this.Buffs.Values.FirstOrDefault((BuffData O) => O.Buff分组 == GroupId) == null)
                    {
                        BuffData2 = (this.Buffs[游戏Buff.Id] = new BuffData(obj, this, 游戏Buff.Id));
                    }
                    break;
                case BuffOverlayType.SimilarReplacement:
                    {
                        foreach (var BuffData3 in Buffs.Values.Where(O => O.Buff分组 == GroupId).ToList())
                        {
                            移除Buff时处理(BuffData3.Id.V);
                        }
                        BuffData2 = (this.Buffs[游戏Buff.Id] = new BuffData(obj, this, 游戏Buff.Id));
                        break;
                    }
                case BuffOverlayType.HomogeneousStacking:
                    {
                        if (!Buffs.TryGetValue(buffId, out var BuffData4))
                        {
                            BuffData2 = (this.Buffs[游戏Buff.Id] = new BuffData(obj, this, 游戏Buff.Id));
                            break;
                        }

                        BuffData4.当前层数.V = (byte)Math.Min(BuffData4.当前层数.V + 1, BuffData4.最大层数);
                        if (游戏Buff.AllowsSynthesis && BuffData4.当前层数.V >= 游戏Buff.BuffSynthesisLayer && GameBuffs.DataSheet.TryGetValue(游戏Buff.BuffSynthesisId, out var 游戏Buff2))
                        {
                            移除Buff时处理(BuffData4.Id.V);
                            OnAddBuff(游戏Buff.BuffSynthesisId, obj);
                            break;
                        }

                        BuffData4.剩余时间.V = BuffData4.持续时间.V;
                        if (BuffData4.Buff同步)
                        {
                            SendPacket(new ObjectStateChangePacket
                            {
                                对象编号 = this.ObjectId,
                                Id = BuffData4.Id.V,
                                Buff索引 = (int)BuffData4.Id.V,
                                当前层数 = BuffData4.当前层数.V,
                                剩余时间 = (int)BuffData4.剩余时间.V.TotalMilliseconds,
                                持续时间 = (int)BuffData4.持续时间.V.TotalMilliseconds
                            });
                        }
                        break;
                    }
                case BuffOverlayType.SimilarDelay:
                    {
                        if (Buffs.TryGetValue(buffId, out var BuffData5))
                        {
                            BuffData5.剩余时间.V += BuffData5.持续时间.V;
                            if (BuffData5.Buff同步)
                            {
                                SendPacket(new ObjectStateChangePacket
                                {
                                    对象编号 = this.ObjectId,
                                    Id = BuffData5.Id.V,
                                    Buff索引 = (int)BuffData5.Id.V,
                                    当前层数 = BuffData5.当前层数.V,
                                    剩余时间 = (int)BuffData5.剩余时间.V.TotalMilliseconds,
                                    持续时间 = (int)BuffData5.持续时间.V.TotalMilliseconds
                                });
                            }
                        }
                        else
                        {
                            BuffData2 = (this.Buffs[游戏Buff.Id] = new BuffData(obj, this, 游戏Buff.Id));
                        }
                        break;
                    }
            }

            if (BuffData2 == null)
                return;


            if (BuffData2.Buff同步)
            {
                SendPacket(new ObjectAddStatePacket
                {
                    SourceObjectId = this.ObjectId,
                    TargetObjectId = obj.ObjectId,
                    BuffId = BuffData2.Id.V,
                    BuffIndex = (int)BuffData2.Id.V,
                    Duration = (int)BuffData2.持续时间.V.TotalMilliseconds,
                    BuffLayers = BuffData2.当前层数.V,
                });
            }

            if ((游戏Buff.Effect & BuffEffectType.StatsIncOrDec) != BuffEffectType.SkillSign)
            {
                StatsBonus.Add(BuffData2, BuffData2.Stat加成);
                RefreshStats();
            }

            if ((游戏Buff.Effect & BuffEffectType.Riding) != BuffEffectType.SkillSign && this is PlayerObject playerObject)
            {
                if (GameMounts.DataSheet.TryGetValue(playerObject.CharacterData.CurrentMount.V, out GameMounts mount))
                {
                    playerObject.Riding = true;
                    StatsBonus.Add(BuffData2, mount.Stats);
                    RefreshStats();
                    if (mount.SoulAuraID > 0)
                        playerObject.OnAddBuff(mount.SoulAuraID, this);
                }

                SendPacket(new SyncObjectMountPacket
                {
                    ObjectId = ObjectId,
                    MountId = (byte)playerObject.CharacterData.CurrentMount.V
                });
            }

            if ((游戏Buff.Effect & BuffEffectType.StatusFlag) != BuffEffectType.SkillSign)
            {
                if ((游戏Buff.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                {
                    foreach (MapObject MapObject in this.Neighbors.ToList<MapObject>())
                    {
                        MapObject.对象隐身时处理(this);
                    }
                }
                if ((游戏Buff.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal)
                {
                    foreach (MapObject MapObject2 in this.Neighbors.ToList<MapObject>())
                    {
                        MapObject2.对象潜行时处理(this);
                    }
                }
            }
            if (游戏Buff.AssociatedId != 0)
            {
                OnAddBuff(游戏Buff.AssociatedId, obj);
            }
        }


        public void 移除Buff时处理(ushort 编号)
        {
            BuffData BuffData;
            if (this.Buffs.TryGetValue(编号, out BuffData))
            {
                MapObject MapObject;
                if (BuffData.Template.FollowedById != 0 && BuffData.Buff来源 != null && MapGatewayProcess.Objects.TryGetValue(BuffData.Buff来源.ObjectId, out MapObject) && MapObject == BuffData.Buff来源)
                {
                    this.OnAddBuff(BuffData.Template.FollowedById, BuffData.Buff来源);
                }
                if (BuffData.依存列表 != null)
                {
                    foreach (ushort 编号2 in BuffData.依存列表)
                    {
                        this.删除Buff时处理(编号2);
                    }
                }
                if (BuffData.添加冷却 && BuffData.绑定技能 != 0 && BuffData.Cooldown != 0)
                {
                    PlayerObject PlayerObject = this as PlayerObject;
                    if (PlayerObject != null && PlayerObject.MainSkills表.ContainsKey(BuffData.绑定技能))
                    {
                        DateTime dateTime = MainProcess.CurrentTime.AddMilliseconds((double)BuffData.Cooldown);
                        DateTime t = this.Coolings.ContainsKey((int)BuffData.绑定技能 | 16777216) ? this.Coolings[(int)BuffData.绑定技能 | 16777216] : default(DateTime);
                        if (dateTime > t)
                        {
                            this.Coolings[(int)BuffData.绑定技能 | 16777216] = dateTime;
                            this.SendPacket(new AddedSkillCooldownPacket
                            {
                                CoolingId = ((int)BuffData.绑定技能 | 16777216),
                                Cooldown = (int)BuffData.Cooldown
                            });
                        }
                    }
                }
                this.Buffs.Remove(编号);
                BuffData.Delete();
                if (BuffData.Buff同步)
                {
                    this.SendPacket(new ObjectRemovalStatusPacket
                    {
                        对象编号 = this.ObjectId,
                        Buff索引 = (int)编号
                    });
                }
                if ((BuffData.Effect & BuffEffectType.StatsIncOrDec) != BuffEffectType.SkillSign)
                {
                    this.StatsBonus.Remove(BuffData);
                    this.RefreshStats();
                }

                if ((BuffData.Effect & BuffEffectType.Riding) != BuffEffectType.SkillSign && this is PlayerObject playerObject)
                {
                    playerObject.Riding = false;
                    this.StatsBonus.Remove(BuffData);
                    this.RefreshStats();
                    if (GameMounts.DataSheet.TryGetValue(playerObject.CharacterData.CurrentMount.V, out GameMounts mount))
                        if (mount.SoulAuraID > 0) playerObject.移除Buff时处理(mount.SoulAuraID);
                }

                if ((BuffData.Effect & BuffEffectType.StatusFlag) != BuffEffectType.SkillSign)
                {
                    if ((BuffData.Template.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                    {
                        foreach (MapObject MapObject2 in this.Neighbors.ToList<MapObject>())
                        {
                            MapObject2.对象显隐时处理(this);
                        }
                    }
                    if ((BuffData.Template.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal)
                    {
                        foreach (MapObject MapObject3 in this.Neighbors.ToList<MapObject>())
                        {
                            MapObject3.对象显行时处理(this);
                        }
                    }
                }
            }
        }


        public void 删除Buff时处理(ushort 编号)
        {
            BuffData BuffData;
            if (this.Buffs.TryGetValue(编号, out BuffData))
            {
                if (BuffData.依存列表 != null)
                {
                    foreach (ushort 编号2 in BuffData.依存列表)
                    {
                        this.删除Buff时处理(编号2);
                    }
                }
                this.Buffs.Remove(编号);
                BuffData.Delete();
                if (BuffData.Buff同步)
                {
                    this.SendPacket(new ObjectRemovalStatusPacket
                    {
                        对象编号 = this.ObjectId,
                        Buff索引 = (int)编号
                    });
                }
                if ((BuffData.Effect & BuffEffectType.StatsIncOrDec) != BuffEffectType.SkillSign)
                {
                    this.StatsBonus.Remove(BuffData);
                    this.RefreshStats();
                }
                if ((BuffData.Effect & BuffEffectType.Riding) != BuffEffectType.SkillSign && this is PlayerObject playerObject)
                {
                    playerObject.Riding = false;
                    this.StatsBonus.Remove(BuffData);
                    this.RefreshStats();
                    if (GameMounts.DataSheet.TryGetValue(playerObject.CharacterData.CurrentMount.V, out GameMounts mount))
                        if (mount.SoulAuraID > 0) playerObject.移除Buff时处理(mount.SoulAuraID);
                }
                if ((BuffData.Effect & BuffEffectType.StatusFlag) != BuffEffectType.SkillSign)
                {
                    if ((BuffData.Template.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                    {
                        foreach (MapObject MapObject in this.Neighbors.ToList<MapObject>())
                        {
                            MapObject.对象显隐时处理(this);
                        }
                    }
                    if ((BuffData.Template.PlayerState & GameObjectState.StealthStatus) != GameObjectState.Normal)
                    {
                        foreach (MapObject MapObject2 in this.Neighbors.ToList<MapObject>())
                        {
                            MapObject2.对象显行时处理(this);
                        }
                    }
                }
            }
        }


        public void 轮询Buff时处理(BuffData 数据)
        {
            if (数据.到期消失 && (数据.剩余时间.V -= MainProcess.CurrentTime - this.CurrentTime) < TimeSpan.Zero)
            {
                this.移除Buff时处理(数据.Id.V);
                return;
            }
            if ((数据.处理计时.V -= MainProcess.CurrentTime - this.CurrentTime) < TimeSpan.Zero)
            {
                数据.处理计时.V += TimeSpan.FromMilliseconds((double)数据.处理间隔);
                if ((数据.Effect & BuffEffectType.CausesSomeDamages) != BuffEffectType.SkillSign)
                {
                    this.被动受伤时处理(数据);
                }
                if ((数据.Effect & BuffEffectType.LifeRecovery) != BuffEffectType.SkillSign)
                {
                    this.被动回复时处理(数据);
                }
            }
        }


        public void ProcessSkillHit(SkillInstance skill, C_01_CalculateHitTarget info)
        {
            MapObject obj = skill.CasterObject is TrapObject trap
                ? trap.TrapSource
                : skill.CasterObject;

            if (skill.Hits.ContainsKey(ObjectId) || !CanBeHit)
                return;

            if (this != obj && !Neighbors.Contains(obj))
                return;

            if (skill.Hits.Count >= info.HitsLimit)
                return;

            if ((info.LimitedTargetRelationship & obj.GetRelationship(this)) == 0)
                return;

            if ((info.LimitedTargetType & ObjectType) == 0)
                return;

            if (!IsSpecificType(skill.CasterObject, info.QualifySpecificType))
                return;

            if ((info.LimitedTargetRelationship & GameObjectRelationship.Hostility) != 0)
            {
                if (CheckStatus(GameObjectState.Invencible))
                    return;

                if ((this is PlayerObject || this is PetObject) && (obj is PlayerObject || obj is PetObject) && (CurrentMap.IsSafeZone(CurrentPosition) || obj.CurrentMap.IsSafeZone(obj.CurrentPosition)))
                    return;

                if (obj is MonsterObject && CurrentMap.IsSafeZone(CurrentPosition))
                    return;
            }

            // TODO: Sabak Gates (move some flag to database to remove hardcoded MonsterId)
            if (this is MonsterObject monsterObject && (monsterObject.MonsterId == 8618 || monsterObject.MonsterId == 8621))
            {
                if (obj is PlayerObject playerObject && playerObject.Guild != null && playerObject.Guild == SystemData.Data.OccupyGuild.V)
                    return;

                if (obj is PetObject petObject && petObject.PlayerOwner != null && petObject.PlayerOwner.Guild != null && petObject.PlayerOwner.Guild == SystemData.Data.OccupyGuild.V)
                    return;
            }

            int num = 0;
            float num2 = 0f;
            int num3 = 0;
            float num4 = 0f;

            switch (info.SkillEvasion)
            {
                case SkillEvasionType.SkillCannotBeEvaded:
                    num = 1;
                    break;
                case SkillEvasionType.CanBePhsyicallyEvaded:
                    num3 = this[GameObjectStats.PhysicalAgility];
                    num = obj[GameObjectStats.PhysicallyAccurate];
                    if (this is MonsterObject)
                    {
                        num2 += obj[GameObjectStats.怪物命中] / 10000f;
                        num4 += this[GameObjectStats.怪物闪避] / 10000f;
                    }
                    break;
                case SkillEvasionType.CanBeMagicEvaded:
                    num4 = this[GameObjectStats.MagicDodge] / 10000f;
                    if (this is MonsterObject)
                    {
                        num2 += obj[GameObjectStats.怪物命中] / 10000f;
                        num4 += this[GameObjectStats.怪物闪避] / 10000f;
                    }
                    break;
                case SkillEvasionType.CanBePoisonEvaded:
                    num4 = this[GameObjectStats.中毒躲避] / 10000f;
                    break;
                case SkillEvasionType.NonMonstersCanEvaded:
                    if (this is MonsterObject)
                        num = 1;
                    else
                    {
                        num3 = this[GameObjectStats.PhysicalAgility];
                        num = obj[GameObjectStats.PhysicallyAccurate];
                    }
                    break;
            }

            var value = new HitDetail(this)
            {
                Feedback = ComputingClass.IsHit(num, num3, num2, num4) ? info.SkillHitFeedback : SkillHitFeedback.Miss
            };

            skill.Hits.Add(this.ObjectId, value);
        }


        public void 被动受伤时处理(SkillInstance 技能, C_02_CalculateTargetDamage 参数, HitDetail 详情, float 伤害系数)
        {
            TrapObject TrapObject = 技能.CasterObject as TrapObject;
            MapObject MapObject = (TrapObject != null) ? TrapObject.TrapSource : 技能.CasterObject;
            if (this.Died)
            {
                详情.Feedback = SkillHitFeedback.丢失;
            }
            else if (!this.Neighbors.Contains(MapObject))
            {
                详情.Feedback = SkillHitFeedback.丢失;
            }
            else if ((MapObject.GetRelationship(this) & GameObjectRelationship.Hostility) == (GameObjectRelationship)0)
            {
                详情.Feedback = SkillHitFeedback.丢失;
            }
            else
            {
                MonsterObject MonsterObject = this as MonsterObject;
                if (MonsterObject != null && (MonsterObject.MonsterId == 8618 || MonsterObject.MonsterId == 8621) && this.GetDistance(MapObject) >= 4)
                {
                    详情.Feedback = SkillHitFeedback.丢失;
                }
            }
            if ((详情.Feedback & SkillHitFeedback.免疫) == SkillHitFeedback.正常 && (详情.Feedback & SkillHitFeedback.丢失) == SkillHitFeedback.正常)
            {
                if ((详情.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常)
                {
                    if (参数.技能斩杀类型 != SpecifyTargetType.None && ComputingClass.CheckProbability(参数.技能斩杀概率) && this.IsSpecificType(MapObject, 参数.技能斩杀类型))
                    {
                        详情.Damage = this.CurrentHP;
                    }
                    else
                    {
                        int[] 技能伤害基数 = 参数.技能伤害基数;
                        int? num = (技能伤害基数 != null) ? new int?(技能伤害基数.Length) : null;
                        int num2 = (int)技能.SkillLevel;
                        int num3 = (num.GetValueOrDefault() > num2 & num != null) ? 参数.技能伤害基数[(int)技能.SkillLevel] : 0;
                        float[] 技能伤害系数 = 参数.技能伤害系数;
                        num = ((技能伤害系数 != null) ? new int?(技能伤害系数.Length) : null);
                        num2 = (int)技能.SkillLevel;
                        float num4 = (num.GetValueOrDefault() > num2 & num != null) ? 参数.技能伤害系数[(int)技能.SkillLevel] : 0f;
                        if (this is MonsterObject)
                        {
                            num3 += MapObject[GameObjectStats.怪物伤害];
                        }
                        int num5 = 0;
                        float num6 = 0f;
                        if (参数.技能增伤类型 != SpecifyTargetType.None && this.IsSpecificType(MapObject, 参数.技能增伤类型))
                        {
                            num5 = 参数.技能增伤基数;
                            num6 = 参数.技能增伤系数;
                        }
                        int num7 = 0;
                        float num8 = 0f;
                        if (参数.技能破防概率 > 0f && ComputingClass.CheckProbability(参数.技能破防概率))
                        {
                            num7 = 参数.技能破防基数;
                            num8 = 参数.技能破防系数;
                        }
                        int num9 = 0;
                        int num10 = 0;
                        switch (参数.技能伤害类型)
                        {
                            case SkillDamageType.Attack:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinDef], this[GameObjectStats.MaxDef]);
                                num9 = ComputingClass.CalculateAttack(MapObject[GameObjectStats.MinDC], MapObject[GameObjectStats.MaxDC], MapObject[GameObjectStats.Luck]);
                                break;
                            case SkillDamageType.Magic:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinMCDef], this[GameObjectStats.MaxMCDef]);
                                num9 = ComputingClass.CalculateAttack(MapObject[GameObjectStats.MinMC], MapObject[GameObjectStats.MaxMC], MapObject[GameObjectStats.Luck]);
                                break;
                            case SkillDamageType.Taoism:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinMCDef], this[GameObjectStats.MaxMCDef]);
                                num9 = ComputingClass.CalculateAttack(MapObject[GameObjectStats.MinSC], MapObject[GameObjectStats.MaxSC], MapObject[GameObjectStats.Luck]);
                                break;
                            case SkillDamageType.Needle:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinDef], this[GameObjectStats.MaxDef]);
                                num9 = ComputingClass.CalculateAttack(MapObject[GameObjectStats.MinNC], MapObject[GameObjectStats.MaxNC], MapObject[GameObjectStats.Luck]);
                                break;
                            case SkillDamageType.Archery:
                                num10 = ComputingClass.计算防御(this[GameObjectStats.MinDef], this[GameObjectStats.MaxDef]);
                                num9 = ComputingClass.CalculateAttack(MapObject[GameObjectStats.MinBC], MapObject[GameObjectStats.MaxBC], MapObject[GameObjectStats.Luck]);
                                break;
                            case SkillDamageType.Toxicity:
                                num9 = MapObject[GameObjectStats.MaxSC];
                                break;
                            case SkillDamageType.Sacred:
                                num9 = ComputingClass.CalculateAttack(MapObject[GameObjectStats.MinHC], MapObject[GameObjectStats.MaxHC], 0);
                                break;
                        }
                        if (this is MonsterObject)
                        {
                            num10 = Math.Max(0, num10 - (int)((float)(num10 * MapObject[GameObjectStats.怪物破防]) / 10000f));
                        }
                        int num11 = 0;
                        float num12 = 0f;
                        int num13 = int.MaxValue;
                        foreach (BuffData BuffData in MapObject.Buffs.Values.ToList<BuffData>())
                        {
                            if ((BuffData.Effect & BuffEffectType.DamageIncOrDec) != BuffEffectType.SkillSign && (BuffData.Template.HowJudgeEffect == BuffDetherminationMethod.ActiveAttackDamageBoost || BuffData.Template.HowJudgeEffect == BuffDetherminationMethod.ActiveAttackDamageReduction))
                            {
                                bool flag = false;
                                switch (参数.技能伤害类型)
                                {
                                    case SkillDamageType.Attack:
                                    case SkillDamageType.Needle:
                                    case SkillDamageType.Archery:
                                        {
                                            BuffJudgmentType EffectJudgeType = BuffData.Template.EffectJudgeType;
                                            if (EffectJudgeType > BuffJudgmentType.AllPhysicalDamage)
                                            {
                                                if (EffectJudgeType == BuffJudgmentType.AllSpecificInjuries)
                                                {
                                                    HashSet<ushort> SpecificSkillId = BuffData.Template.SpecificSkillId;
                                                    flag = (SpecificSkillId != null && SpecificSkillId.Contains(技能.SkillId));
                                                }
                                            }
                                            else
                                            {
                                                flag = true;
                                            }
                                            break;
                                        }
                                    case SkillDamageType.Magic:
                                    case SkillDamageType.Taoism:
                                        switch (BuffData.Template.EffectJudgeType)
                                        {
                                            case BuffJudgmentType.AllSkillDamage:
                                            case BuffJudgmentType.AllMagicDamage:
                                                flag = true;
                                                break;
                                            case BuffJudgmentType.AllSpecificInjuries:
                                                {
                                                    HashSet<ushort> SpecificSkillId2 = BuffData.Template.SpecificSkillId;
                                                    flag = (SpecificSkillId2 != null && SpecificSkillId2.Contains(技能.SkillId));
                                                    break;
                                                }
                                        }
                                        break;
                                    case SkillDamageType.Toxicity:
                                    case SkillDamageType.Sacred:
                                    case SkillDamageType.Burn:
                                    case SkillDamageType.Tear:
                                        if (BuffData.Template.EffectJudgeType == BuffJudgmentType.AllSpecificInjuries)
                                        {
                                            HashSet<ushort> SpecificSkillId3 = BuffData.Template.SpecificSkillId;
                                            flag = (SpecificSkillId3 != null && SpecificSkillId3.Contains(技能.SkillId));
                                        }
                                        break;
                                }
                                if (flag)
                                {
                                    int v = (int)BuffData.当前层数.V;
                                    int[] DamageIncOrDecBase = BuffData.Template.DamageIncOrDecBase;
                                    num = ((DamageIncOrDecBase != null) ? new int?(DamageIncOrDecBase.Length) : null);
                                    num2 = (int)BuffData.Buff等级.V;
                                    int num14 = v * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData.Template.DamageIncOrDecBase[(int)BuffData.Buff等级.V] : 0);
                                    float num15 = (float)BuffData.当前层数.V;
                                    float[] DamageIncOrDecFactor = BuffData.Template.DamageIncOrDecFactor;
                                    num = ((DamageIncOrDecFactor != null) ? new int?(DamageIncOrDecFactor.Length) : null);
                                    num2 = (int)BuffData.Buff等级.V;
                                    float num16 = num15 * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData.Template.DamageIncOrDecFactor[(int)BuffData.Buff等级.V] : 0f);
                                    num11 += ((BuffData.Template.HowJudgeEffect == BuffDetherminationMethod.ActiveAttackDamageBoost) ? num14 : (-num14));
                                    num12 += ((BuffData.Template.HowJudgeEffect == BuffDetherminationMethod.ActiveAttackDamageBoost) ? num16 : (-num16));
                                    MapObject MapObject2;
                                    if (BuffData.Template.EffectiveFollowedById != 0 && BuffData.Buff来源 != null && MapGatewayProcess.Objects.TryGetValue(BuffData.Buff来源.ObjectId, out MapObject2) && MapObject2 == BuffData.Buff来源)
                                    {
                                        if (BuffData.Template.FollowUpSkillSource)
                                        {
                                            MapObject.OnAddBuff(BuffData.Template.EffectiveFollowedById, BuffData.Buff来源);
                                        }
                                        else
                                        {
                                            this.OnAddBuff(BuffData.Template.EffectiveFollowedById, BuffData.Buff来源);
                                        }
                                    }
                                    if (BuffData.Template.EffectRemoved)
                                    {
                                        MapObject.移除Buff时处理(BuffData.Id.V);
                                    }
                                }
                            }
                        }
                        foreach (BuffData BuffData2 in this.Buffs.Values.ToList<BuffData>())
                        {
                            if ((BuffData2.Effect & BuffEffectType.DamageIncOrDec) != BuffEffectType.SkillSign && (BuffData2.Template.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryIncrease || BuffData2.Template.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryReduction))
                            {
                                bool flag2 = false;
                                switch (参数.技能伤害类型)
                                {
                                    case SkillDamageType.Attack:
                                    case SkillDamageType.Needle:
                                    case SkillDamageType.Archery:
                                        {
                                            BuffJudgmentType EffectJudgeType = BuffData2.Template.EffectJudgeType;
                                            if (EffectJudgeType <= BuffJudgmentType.AllSpecificInjuries)
                                            {
                                                if (EffectJudgeType > BuffJudgmentType.AllPhysicalDamage)
                                                {
                                                    if (EffectJudgeType == BuffJudgmentType.AllSpecificInjuries)
                                                    {
                                                        HashSet<ushort> SpecificSkillId4 = BuffData2.Template.SpecificSkillId;
                                                        flag2 = (SpecificSkillId4 != null && SpecificSkillId4.Contains(技能.SkillId));
                                                    }
                                                }
                                                else
                                                {
                                                    flag2 = true;
                                                }
                                            }
                                            else if (EffectJudgeType != BuffJudgmentType.SourceSkillDamage && EffectJudgeType != BuffJudgmentType.SourcePhysicalDamage)
                                            {
                                                if (EffectJudgeType == BuffJudgmentType.SourceSpecificDamage)
                                                {
                                                    bool flag3;
                                                    if (MapObject == BuffData2.Buff来源)
                                                    {
                                                        HashSet<ushort> SpecificSkillId5 = BuffData2.Template.SpecificSkillId;
                                                        flag3 = (SpecificSkillId5 != null && SpecificSkillId5.Contains(技能.SkillId));
                                                    }
                                                    else
                                                    {
                                                        flag3 = false;
                                                    }
                                                    flag2 = flag3;
                                                }
                                            }
                                            else
                                            {
                                                flag2 = (MapObject == BuffData2.Buff来源);
                                            }
                                            break;
                                        }
                                    case SkillDamageType.Magic:
                                    case SkillDamageType.Taoism:
                                        {
                                            BuffJudgmentType EffectJudgeType = BuffData2.Template.EffectJudgeType;
                                            if (EffectJudgeType <= BuffJudgmentType.SourceSkillDamage)
                                            {
                                                switch (EffectJudgeType)
                                                {
                                                    case BuffJudgmentType.AllSkillDamage:
                                                    case BuffJudgmentType.AllMagicDamage:
                                                        flag2 = true;
                                                        goto IL_953;
                                                    case BuffJudgmentType.AllPhysicalDamage:
                                                    case (BuffJudgmentType)3:
                                                        goto IL_953;
                                                    case BuffJudgmentType.AllSpecificInjuries:
                                                        flag2 = BuffData2.Template.SpecificSkillId.Contains(技能.SkillId);
                                                        goto IL_953;
                                                    default:
                                                        if (EffectJudgeType != BuffJudgmentType.SourceSkillDamage)
                                                        {
                                                            goto IL_953;
                                                        }
                                                        break;
                                                }
                                            }
                                            else if (EffectJudgeType != BuffJudgmentType.SourceMagicDamage)
                                            {
                                                if (EffectJudgeType != BuffJudgmentType.SourceSpecificDamage)
                                                {
                                                    break;
                                                }
                                                bool flag4;
                                                if (MapObject == BuffData2.Buff来源)
                                                {
                                                    HashSet<ushort> SpecificSkillId6 = BuffData2.Template.SpecificSkillId;
                                                    flag4 = (SpecificSkillId6 != null && SpecificSkillId6.Contains(技能.SkillId));
                                                }
                                                else
                                                {
                                                    flag4 = false;
                                                }
                                                flag2 = flag4;
                                                break;
                                            }
                                            flag2 = (MapObject == BuffData2.Buff来源);
                                            break;
                                        }
                                    case SkillDamageType.Toxicity:
                                    case SkillDamageType.Sacred:
                                    case SkillDamageType.Burn:
                                    case SkillDamageType.Tear:
                                        {
                                            BuffJudgmentType EffectJudgeType = BuffData2.Template.EffectJudgeType;
                                            if (EffectJudgeType != BuffJudgmentType.AllSpecificInjuries)
                                            {
                                                if (EffectJudgeType == BuffJudgmentType.SourceSpecificDamage)
                                                {
                                                    bool flag5;
                                                    if (MapObject == BuffData2.Buff来源)
                                                    {
                                                        HashSet<ushort> SpecificSkillId7 = BuffData2.Template.SpecificSkillId;
                                                        flag5 = (SpecificSkillId7 != null && SpecificSkillId7.Contains(技能.SkillId));
                                                    }
                                                    else
                                                    {
                                                        flag5 = false;
                                                    }
                                                    flag2 = flag5;
                                                }
                                            }
                                            else
                                            {
                                                HashSet<ushort> SpecificSkillId8 = BuffData2.Template.SpecificSkillId;
                                                flag2 = (SpecificSkillId8 != null && SpecificSkillId8.Contains(技能.SkillId));
                                            }
                                            break;
                                        }
                                }
                            IL_953:
                                if (flag2)
                                {
                                    int v2 = (int)BuffData2.当前层数.V;
                                    int[] DamageIncOrDecBase2 = BuffData2.Template.DamageIncOrDecBase;
                                    num = ((DamageIncOrDecBase2 != null) ? new int?(DamageIncOrDecBase2.Length) : null);
                                    num2 = (int)BuffData2.Buff等级.V;
                                    int num17 = v2 * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData2.Template.DamageIncOrDecBase[(int)BuffData2.Buff等级.V] : 0);
                                    float num18 = (float)BuffData2.当前层数.V;
                                    float[] DamageIncOrDecFactor2 = BuffData2.Template.DamageIncOrDecFactor;
                                    num = ((DamageIncOrDecFactor2 != null) ? new int?(DamageIncOrDecFactor2.Length) : null);
                                    num2 = (int)BuffData2.Buff等级.V;
                                    float num19 = num18 * ((num.GetValueOrDefault() > num2 & num != null) ? BuffData2.Template.DamageIncOrDecFactor[(int)BuffData2.Buff等级.V] : 0f);
                                    num11 += ((BuffData2.Template.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryIncrease) ? num17 : (-num17));
                                    num12 += ((BuffData2.Template.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryIncrease) ? num19 : (-num19));
                                    MapObject MapObject3;
                                    if (BuffData2.Template.EffectiveFollowedById != 0 && BuffData2.Buff来源 != null && MapGatewayProcess.Objects.TryGetValue(BuffData2.Buff来源.ObjectId, out MapObject3) && MapObject3 == BuffData2.Buff来源)
                                    {
                                        if (BuffData2.Template.FollowUpSkillSource)
                                        {
                                            MapObject.OnAddBuff(BuffData2.Template.EffectiveFollowedById, BuffData2.Buff来源);
                                        }
                                        else
                                        {
                                            this.OnAddBuff(BuffData2.Template.EffectiveFollowedById, BuffData2.Buff来源);
                                        }
                                    }
                                    if (BuffData2.Template.HowJudgeEffect == BuffDetherminationMethod.PassiveInjuryReduction && BuffData2.Template.LimitedDamage)
                                    {
                                        num13 = Math.Min(num13, BuffData2.Template.LimitedDamageValue);
                                    }
                                    if (BuffData2.Template.EffectRemoved)
                                    {
                                        this.移除Buff时处理(BuffData2.Id.V);
                                    }
                                }
                            }
                        }
                        float num20 = (num4 + num6) * (float)num9 + (float)num3 + (float)num5 + (float)num11;
                        float val = (float)(num10 - num7) - (float)num10 * num8;
                        float val2 = (num20 - Math.Max(0f, val)) * (1f + num12) * 伤害系数;
                        int 技能伤害 = (int)Math.Min((float)num13, Math.Max(0f, val2));
                        详情.Damage = 技能伤害;
                    }
                }
                this.TimeoutTime = MainProcess.CurrentTime.AddSeconds(10.0);
                MapObject.TimeoutTime = MainProcess.CurrentTime.AddSeconds(10.0);
                if ((详情.Feedback & SkillHitFeedback.Miss) == SkillHitFeedback.正常)
                {
                    foreach (BuffData BuffData3 in this.Buffs.Values.ToList<BuffData>())
                    {
                        if ((BuffData3.Effect & BuffEffectType.StatusFlag) != BuffEffectType.SkillSign && (BuffData3.Template.PlayerState & GameObjectState.Absence) != GameObjectState.Normal)
                        {
                            this.移除Buff时处理(BuffData3.Id.V);
                        }
                    }
                }
                MonsterObject MonsterObject2 = this as MonsterObject;
                if (MonsterObject2 != null)
                {
                    MonsterObject2.HardTime = MainProcess.CurrentTime.AddMilliseconds((double)参数.目标硬直时间);
                    if (MapObject is PlayerObject || MapObject is PetObject)
                    {
                        MonsterObject2.HateObject.添加仇恨(MapObject, MainProcess.CurrentTime.AddMilliseconds((double)MonsterObject2.HateTime), 详情.Damage);
                    }
                }
                else
                {
                    PlayerObject PlayerObject = this as PlayerObject;
                    if (PlayerObject != null)
                    {
                        if (详情.Damage > 0)
                        {
                            PlayerObject.装备损失持久(详情.Damage);
                        }
                        if (详情.Damage > 0)
                        {
                            PlayerObject.扣除护盾时间(详情.Damage);
                        }
                        if (PlayerObject.GetRelationship(MapObject) == GameObjectRelationship.Hostility)
                        {
                            foreach (PetObject PetObject in PlayerObject.Pets.ToList<PetObject>())
                            {
                                if (PetObject.Neighbors.Contains(MapObject) && !MapObject.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                                {
                                    PetObject.HateObject.添加仇恨(MapObject, MainProcess.CurrentTime.AddMilliseconds((double)PetObject.HateTime), 0);
                                }
                            }
                        }
                        PlayerObject PlayerObject2 = MapObject as PlayerObject;
                        if (PlayerObject2 != null && !this.CurrentMap.自由区内(this.CurrentPosition) && !PlayerObject.灰名玩家 && !PlayerObject.红名玩家)
                        {
                            if (PlayerObject2.红名玩家)
                            {
                                PlayerObject2.减PK时间 = TimeSpan.FromMinutes(1.0);
                            }
                            else
                            {
                                PlayerObject2.灰名时间 = TimeSpan.FromMinutes(1.0);
                            }
                        }
                        else
                        {
                            PetObject PetObject2 = MapObject as PetObject;
                            if (PetObject2 != null && !this.CurrentMap.自由区内(this.CurrentPosition) && !PlayerObject.灰名玩家 && !PlayerObject.红名玩家)
                            {
                                if (PetObject2.PlayerOwner.红名玩家)
                                {
                                    PetObject2.PlayerOwner.减PK时间 = TimeSpan.FromMinutes(1.0);
                                }
                                else
                                {
                                    PetObject2.PlayerOwner.灰名时间 = TimeSpan.FromMinutes(1.0);
                                }
                            }
                        }
                    }
                    else
                    {
                        PetObject PetObject3 = this as PetObject;
                        if (PetObject3 != null)
                        {
                            if (MapObject != PetObject3.PlayerOwner && PetObject3.GetRelationship(MapObject) == GameObjectRelationship.Hostility)
                            {
                                PlayerObject 宠物主人 = PetObject3.PlayerOwner;
                                foreach (PetObject PetObject4 in ((宠物主人 != null) ? 宠物主人.Pets.ToList<PetObject>() : null))
                                {
                                    if (PetObject4.Neighbors.Contains(MapObject) && !MapObject.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                                    {
                                        PetObject4.HateObject.添加仇恨(MapObject, MainProcess.CurrentTime.AddMilliseconds((double)PetObject4.HateTime), 0);
                                    }
                                }
                            }
                            if (MapObject != PetObject3.PlayerOwner)
                            {
                                PlayerObject PlayerObject3 = MapObject as PlayerObject;
                                if (PlayerObject3 != null && !this.CurrentMap.自由区内(this.CurrentPosition) && !PetObject3.PlayerOwner.灰名玩家 && !PetObject3.PlayerOwner.红名玩家)
                                {
                                    PlayerObject3.灰名时间 = TimeSpan.FromMinutes(1.0);
                                }
                            }
                        }
                        else
                        {
                            GuardObject GuardInstance = this as GuardObject;
                            if (GuardInstance != null && GuardInstance.GetRelationship(MapObject) == GameObjectRelationship.Hostility)
                            {
                                GuardInstance.HateObject.添加仇恨(MapObject, default(DateTime), 0);
                            }
                        }
                    }
                }
                PlayerObject PlayerObject4 = MapObject as PlayerObject;
                if (PlayerObject4 != null)
                {
                    if (PlayerObject4.GetRelationship(this) == GameObjectRelationship.Hostility && !this.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                    {
                        foreach (PetObject PetObject5 in PlayerObject4.Pets.ToList<PetObject>())
                        {
                            if (PetObject5.Neighbors.Contains(this))
                            {
                                PetObject5.HateObject.添加仇恨(this, MainProcess.CurrentTime.AddMilliseconds((double)PetObject5.HateTime), 参数.增加宠物仇恨 ? 详情.Damage : 0);
                            }
                        }
                    }
                    EquipmentData EquipmentData;
                    if (MainProcess.CurrentTime > PlayerObject4.战具计时 && !PlayerObject4.Died && PlayerObject4.CurrentHP < PlayerObject4[GameObjectStats.MaxHP] && PlayerObject4.Equipment.TryGetValue(15, out EquipmentData) && EquipmentData.当前持久.V > 0 && (EquipmentData.Id == 99999106 || EquipmentData.Id == 99999107))
                    {
                        PlayerObject4.CurrentHP += ((this is MonsterObject) ? 20 : 10);
                        PlayerObject4.战具损失持久(1);
                        PlayerObject4.战具计时 = MainProcess.CurrentTime.AddMilliseconds(1000.0);
                    }
                }
                if ((this.CurrentHP = Math.Max(0, this.CurrentHP - 详情.Damage)) == 0)
                {
                    详情.Feedback |= SkillHitFeedback.死亡;
                    this.Dies(MapObject, true);
                }
                return;
            }
        }


        public void 被动受伤时处理(BuffData 数据)
        {
            int num = 0;
            switch (数据.伤害类型)
            {
                case SkillDamageType.Attack:
                case SkillDamageType.Needle:
                case SkillDamageType.Archery:
                    num = ComputingClass.计算防御(this[GameObjectStats.MinDef], this[GameObjectStats.MaxDef]);
                    break;
                case SkillDamageType.Magic:
                case SkillDamageType.Taoism:
                    num = ComputingClass.计算防御(this[GameObjectStats.MinMCDef], this[GameObjectStats.MaxMCDef]);
                    break;
            }
            int num2 = Math.Max(0, 数据.伤害基数.V * (int)数据.当前层数.V - num);
            this.CurrentHP = Math.Max(0, this.CurrentHP - num2);
            触发状态效果 触发状态效果 = new 触发状态效果();
            触发状态效果.Id = 数据.Id.V;
            MapObject buff来源 = 数据.Buff来源;
            触发状态效果.Buff来源 = ((buff来源 != null) ? buff来源.ObjectId : 0);
            触发状态效果.Buff目标 = this.ObjectId;
            触发状态效果.血量变化 = -num2;
            this.SendPacket(触发状态效果);
            if (this.CurrentHP == 0)
            {
                this.Dies(数据.Buff来源, false);
            }
        }


        public void 被动回复时处理(SkillInstance 技能, C_05_CalculateTargetReply 参数)
        {
            if (!this.Died)
            {
                if (this.CurrentMap == 技能.CasterObject.CurrentMap)
                {
                    if (this != 技能.CasterObject && !this.Neighbors.Contains(技能.CasterObject))
                    {
                        return;
                    }
                    TrapObject TrapObject = 技能.CasterObject as TrapObject;
                    MapObject MapObject = (TrapObject != null) ? TrapObject.TrapSource : 技能.CasterObject;
                    int[] 体力回复次数 = 参数.体力回复次数;
                    int? num = (体力回复次数 != null) ? new int?(体力回复次数.Length) : null;
                    int SkillLevel = (int)技能.SkillLevel;
                    int num2 = (num.GetValueOrDefault() > SkillLevel & num != null) ? 参数.体力回复次数[(int)技能.SkillLevel] : 0;
                    byte[] PhysicalRecoveryBase = 参数.PhysicalRecoveryBase;
                    num = ((PhysicalRecoveryBase != null) ? new int?(PhysicalRecoveryBase.Length) : null);
                    SkillLevel = (int)技能.SkillLevel;
                    int num3 = (int)((num.GetValueOrDefault() > SkillLevel & num != null) ? 参数.PhysicalRecoveryBase[(int)技能.SkillLevel] : 0);
                    float[] Taoism叠加次数 = 参数.Taoism叠加次数;
                    num = ((Taoism叠加次数 != null) ? new int?(Taoism叠加次数.Length) : null);
                    SkillLevel = (int)技能.SkillLevel;
                    float num4 = (num.GetValueOrDefault() > SkillLevel & num != null) ? 参数.Taoism叠加次数[(int)技能.SkillLevel] : 0f;
                    float[] Taoism叠加基数 = 参数.Taoism叠加基数;
                    num = ((Taoism叠加基数 != null) ? new int?(Taoism叠加基数.Length) : null);
                    SkillLevel = (int)技能.SkillLevel;
                    float num5 = (num.GetValueOrDefault() > SkillLevel & num != null) ? 参数.Taoism叠加基数[(int)技能.SkillLevel] : 0f;
                    int[] 立即回复基数 = 参数.立即回复基数;
                    num = ((立即回复基数 != null) ? new int?(立即回复基数.Length) : null);
                    SkillLevel = (int)技能.SkillLevel;
                    int num6;
                    if (num.GetValueOrDefault() > SkillLevel & num != null)
                    {
                        if (MapObject == this)
                        {
                            num6 = 参数.立即回复基数[(int)技能.SkillLevel];
                            goto IL_1F1;
                        }
                    }
                    num6 = 0;
                IL_1F1:
                    int num7 = num6;
                    float[] 立即回复系数 = 参数.立即回复系数;
                    num = ((立即回复系数 != null) ? new int?(立即回复系数.Length) : null);
                    SkillLevel = (int)技能.SkillLevel;
                    float num8;
                    if (num.GetValueOrDefault() > SkillLevel & num != null)
                    {
                        if (MapObject == this)
                        {
                            num8 = 参数.立即回复系数[(int)技能.SkillLevel];
                            goto IL_249;
                        }
                    }
                    num8 = 0f;
                IL_249:
                    float num9 = num8;
                    if (num4 > 0f)
                    {
                        num2 += (int)(num4 * (float)ComputingClass.CalculateAttack(MapObject[GameObjectStats.MinSC], MapObject[GameObjectStats.MaxSC], MapObject[GameObjectStats.Luck]));
                    }
                    if (num5 > 0f)
                    {
                        num3 += (int)(num5 * (float)ComputingClass.CalculateAttack(MapObject[GameObjectStats.MinSC], MapObject[GameObjectStats.MaxSC], MapObject[GameObjectStats.Luck]));
                    }
                    if (num7 > 0)
                    {
                        this.CurrentHP += num7;
                    }
                    if (num9 > 0f)
                    {
                        this.CurrentHP += (int)((float)this[GameObjectStats.MaxHP] * num9);
                    }
                    if (num2 > this.TreatmentCount && num3 > 0)
                    {
                        this.TreatmentCount = (int)((byte)num2);
                        this.TreatmentBase = num3;
                        this.HealTime = MainProcess.CurrentTime.AddMilliseconds(500.0);
                    }
                    return;
                }
            }
        }


        public void 被动回复时处理(BuffData 数据)
        {
            if (数据.Template.PhysicalRecoveryBase == null)
            {
                return;
            }
            if (数据.Template.PhysicalRecoveryBase.Length <= (int)数据.Buff等级.V)
            {
                return;
            }
            byte b = 数据.Template.PhysicalRecoveryBase[(int)数据.Buff等级.V];
            this.CurrentHP += (int)b;
            触发状态效果 触发状态效果 = new 触发状态效果();
            触发状态效果.Id = 数据.Id.V;
            MapObject buff来源 = 数据.Buff来源;
            触发状态效果.Buff来源 = ((buff来源 != null) ? buff来源.ObjectId : 0);
            触发状态效果.Buff目标 = this.ObjectId;
            触发状态效果.血量变化 = (int)b;
            this.SendPacket(触发状态效果);
        }


        public void ItSelf移动时处理(Point 坐标)
        {
            PlayerObject PlayerObject = this as PlayerObject;
            if (PlayerObject != null)
            {
                PlayerDeals 当前交易 = PlayerObject.当前交易;
                if (当前交易 != null)
                {
                    当前交易.结束交易();
                }
                using (List<BuffData>.Enumerator enumerator = this.Buffs.Values.ToList<BuffData>().GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        BuffData BuffData = enumerator.Current;
                        SkillTraps 陷阱模板;
                        if ((BuffData.Effect & BuffEffectType.CreateTrap) != BuffEffectType.SkillSign && SkillTraps.DataSheet.TryGetValue(BuffData.Template.TriggerTrapSkills, out 陷阱模板))
                        {
                            int num = 0;

                            for (; ; )
                            {
                                Point point = ComputingClass.GetFrontPosition(this.CurrentPosition, 坐标, num);
                                if (point == 坐标)
                                {
                                    break;
                                }
                                foreach (Point 坐标2 in ComputingClass.GetLocationRange(point, this.CurrentDirection, BuffData.Template.NumberTrapsTriggered))
                                {
                                    if (!this.CurrentMap.IsBlocked(坐标2))
                                    {
                                        IEnumerable<MapObject> source = this.CurrentMap[坐标2];
                                        Func<MapObject, bool> predicate = null;
                                        if (predicate == null)
                                        {
                                            predicate = delegate (MapObject O)
                                          {
                                              TrapObject TrapObject = O as TrapObject;
                                              return TrapObject != null && TrapObject.陷阱GroupId != 0 && TrapObject.陷阱GroupId == 陷阱模板.GroupId;
                                          };
                                        }
                                        if (source.FirstOrDefault(predicate) == null)
                                        {
                                            this.Traps.Add(new TrapObject(this, 陷阱模板, this.CurrentMap, 坐标2));
                                        }
                                    }
                                }
                                num++;
                            }
                        }
                        if ((BuffData.Effect & BuffEffectType.StatusFlag) != BuffEffectType.SkillSign && (BuffData.Template.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                        {
                            this.移除Buff时处理(BuffData.Id.V);
                        }
                    }
                    goto IL_30E;
                }
            }
            if (this is PetObject)
            {
                foreach (BuffData BuffData2 in this.Buffs.Values.ToList<BuffData>())
                {
                    SkillTraps 陷阱模板;
                    if ((BuffData2.Effect & BuffEffectType.CreateTrap) != BuffEffectType.SkillSign && SkillTraps.DataSheet.TryGetValue(BuffData2.Template.TriggerTrapSkills, out 陷阱模板))
                    {
                        int num2 = 0;

                        for (; ; )
                        {
                            Point point2 = ComputingClass.GetFrontPosition(this.CurrentPosition, 坐标, num2);
                            if (point2 == 坐标)
                            {
                                break;
                            }
                            foreach (Point 坐标3 in ComputingClass.GetLocationRange(point2, this.CurrentDirection, BuffData2.Template.NumberTrapsTriggered))
                            {
                                if (!this.CurrentMap.IsBlocked(坐标3))
                                {
                                    IEnumerable<MapObject> source2 = this.CurrentMap[坐标3];
                                    Func<MapObject, bool> predicate2 = null;
                                    if (predicate2 == null)
                                    {
                                        predicate2 = delegate (MapObject O)
                                       {
                                           TrapObject TrapObject = O as TrapObject;
                                           return TrapObject != null && TrapObject.陷阱GroupId != 0 && TrapObject.陷阱GroupId == 陷阱模板.GroupId;
                                       };
                                    }
                                    if (source2.FirstOrDefault(predicate2) == null)
                                    {
                                        this.Traps.Add(new TrapObject(this, 陷阱模板, this.CurrentMap, 坐标3));
                                    }
                                }
                            }
                            num2++;
                        }
                    }
                    if ((BuffData2.Effect & BuffEffectType.StatusFlag) != BuffEffectType.SkillSign && (BuffData2.Template.PlayerState & GameObjectState.Invisibility) != GameObjectState.Normal)
                    {
                        this.移除Buff时处理(BuffData2.Id.V);
                    }
                }
            }
        IL_30E:
            this.UnbindGrid();
            this.CurrentPosition = 坐标;
            this.BindGrid();
            this.更新邻居时处理();
            foreach (MapObject MapObject in this.Neighbors.ToList<MapObject>())
            {
                MapObject.对象移动时处理(this);
            }
        }


        public void NotifyNeightborClear()
        {
            foreach (MapObject MapObject in this.Neighbors.ToList<MapObject>())
            {
                MapObject.对象消失时处理(this);
            }
            this.Neighbors.Clear();
            this.NeighborsImportant.Clear();
            this.NeighborsSneak.Clear();
        }


        public void 更新邻居时处理()
        {
            foreach (MapObject MapObject in this.Neighbors.ToList<MapObject>())
            {
                if (this.CurrentMap != MapObject.CurrentMap || !this.CanBeSeenBy(MapObject))
                {
                    MapObject.对象消失时处理(this);
                    this.对象消失时处理(MapObject);
                }
            }
            for (int i = -20; i <= 20; i++)
            {
                for (int j = -20; j <= 20; j++)
                {
                    this.CurrentMap[new Point(this.CurrentPosition.X + i, this.CurrentPosition.Y + j)].ToList<MapObject>();
                    try
                    {
                        foreach (MapObject MapObject2 in this.CurrentMap[new Point(this.CurrentPosition.X + i, this.CurrentPosition.Y + j)])
                        {
                            if (MapObject2 != this)
                            {
                                if (!this.Neighbors.Contains(MapObject2) && this.IsNeightbor(MapObject2))
                                {
                                    this.对象出现时处理(MapObject2);
                                }
                                if (!MapObject2.Neighbors.Contains(this) && MapObject2.IsNeightbor(this))
                                {
                                    MapObject2.对象出现时处理(this);
                                }
                            }
                        }
                        goto IL_15C;
                    }
                    catch
                    {
                        goto IL_15C;
                    }
                    break;
                IL_15C:;
                }
            }
        }


        public void 对象移动时处理(MapObject 对象)
        {
            if (!(this is ItemObject))
            {
                PetObject PetObject = this as PetObject;
                if (PetObject != null)
                {
                    HateObject.仇恨详情 仇恨详情;
                    if (PetObject.CanAttack(对象) && this.GetDistance(对象) <= PetObject.RangeHate && !对象.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                    {
                        PetObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                    }
                    else if (this.GetDistance(对象) > PetObject.RangeHate && PetObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情) && 仇恨详情.仇恨时间 < MainProcess.CurrentTime)
                    {
                        PetObject.HateObject.移除仇恨(对象);
                    }
                }
                else
                {
                    MonsterObject MonsterObject = this as MonsterObject;
                    if (MonsterObject != null)
                    {
                        HateObject.仇恨详情 仇恨详情2;
                        if (this.GetDistance(对象) <= MonsterObject.RangeHate && MonsterObject.CanAttack(对象) && (MonsterObject.VisibleStealthTargets || !对象.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                        {
                            MonsterObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                        }
                        else if (this.GetDistance(对象) > MonsterObject.RangeHate && MonsterObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情2) && 仇恨详情2.仇恨时间 < MainProcess.CurrentTime)
                        {
                            MonsterObject.HateObject.移除仇恨(对象);
                        }
                    }
                    else
                    {
                        TrapObject TrapObject = this as TrapObject;
                        if (TrapObject != null)
                        {
                            if (ComputingClass.GetLocationRange(TrapObject.CurrentPosition, TrapObject.CurrentDirection, TrapObject.ObjectSize).Contains(对象.CurrentPosition))
                            {
                                TrapObject.被动触发陷阱(对象);
                            }
                        }
                        else
                        {
                            GuardObject GuardInstance = this as GuardObject;
                            if (GuardInstance != null)
                            {
                                if (GuardInstance.CanAttack(对象) && this.GetDistance(对象) <= GuardInstance.RangeHate)
                                {
                                    GuardInstance.HateObject.添加仇恨(对象, default(DateTime), 0);
                                }
                                else if (this.GetDistance(对象) > GuardInstance.RangeHate)
                                {
                                    GuardInstance.HateObject.移除仇恨(对象);
                                }
                            }
                        }
                    }
                }
            }
            if (!(对象 is ItemObject))
            {
                PetObject PetObject2 = 对象 as PetObject;
                if (PetObject2 != null)
                {
                    if (PetObject2.GetDistance(this) <= PetObject2.RangeHate && PetObject2.CanAttack(this) && !this.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                    {
                        PetObject2.HateObject.添加仇恨(this, default(DateTime), 0);
                        return;
                    }
                    HateObject.仇恨详情 仇恨详情3;
                    if (PetObject2.GetDistance(this) > PetObject2.RangeHate && PetObject2.HateObject.仇恨列表.TryGetValue(this, out 仇恨详情3) && 仇恨详情3.仇恨时间 < MainProcess.CurrentTime)
                    {
                        PetObject2.HateObject.移除仇恨(this);
                        return;
                    }
                }
                else
                {
                    MonsterObject MonsterObject2 = 对象 as MonsterObject;
                    if (MonsterObject2 != null)
                    {
                        if (MonsterObject2.GetDistance(this) <= MonsterObject2.RangeHate && MonsterObject2.CanAttack(this) && (MonsterObject2.VisibleStealthTargets || !this.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                        {
                            MonsterObject2.HateObject.添加仇恨(this, default(DateTime), 0);
                            return;
                        }
                        HateObject.仇恨详情 仇恨详情4;
                        if (MonsterObject2.GetDistance(this) > MonsterObject2.RangeHate && MonsterObject2.HateObject.仇恨列表.TryGetValue(this, out 仇恨详情4) && 仇恨详情4.仇恨时间 < MainProcess.CurrentTime)
                        {
                            MonsterObject2.HateObject.移除仇恨(this);
                            return;
                        }
                    }
                    else
                    {
                        TrapObject TrapObject2 = 对象 as TrapObject;
                        if (TrapObject2 != null)
                        {
                            if (ComputingClass.GetLocationRange(TrapObject2.CurrentPosition, TrapObject2.CurrentDirection, TrapObject2.ObjectSize).Contains(this.CurrentPosition))
                            {
                                TrapObject2.被动触发陷阱(this);
                                return;
                            }
                        }
                        else
                        {
                            GuardObject GuardInstance2 = 对象 as GuardObject;
                            if (GuardInstance2 != null)
                            {
                                if (GuardInstance2.CanAttack(this) && GuardInstance2.GetDistance(this) <= GuardInstance2.RangeHate)
                                {
                                    GuardInstance2.HateObject.添加仇恨(this, default(DateTime), 0);
                                    return;
                                }
                                if (GuardInstance2.GetDistance(this) > GuardInstance2.RangeHate)
                                {
                                    GuardInstance2.HateObject.移除仇恨(this);
                                }
                            }
                        }
                    }
                }
            }
        }


        public void 对象出现时处理(MapObject 对象)
        {
            if (this.NeighborsSneak.Remove(对象))
            {
                if (this is PlayerObject PlayerObject)
                {
                    GameObjectType 对象类型 = 对象.ObjectType;
                    if (对象类型 <= GameObjectType.NPC)
                    {
                        switch (对象类型)
                        {
                            case GameObjectType.Player:
                            case GameObjectType.Monster:
                                break;
                            case GameObjectType.Pet:
                                PlayerObject.ActiveConnection.SendPacket(new ObjectCharacterStopPacket
                                {
                                    对象编号 = 对象.ObjectId,
                                    对象坐标 = 对象.CurrentPosition,
                                    对象高度 = 对象.CurrentAltitude
                                });
                                PlayerObject.ActiveConnection.SendPacket(new ObjectComesIntoViewPacket
                                {
                                    出现方式 = 1,
                                    对象编号 = 对象.ObjectId,
                                    现身坐标 = 对象.CurrentPosition,
                                    现身高度 = 对象.CurrentAltitude,
                                    现身方向 = (ushort)对象.CurrentDirection,
                                    现身姿态 = ((byte)(对象.Died ? 13 : 1)),
                                    体力比例 = (byte)(对象.CurrentHP * 100 / 对象[GameObjectStats.MaxHP])
                                });
                                PlayerObject.ActiveConnection.SendPacket(new SyncObjectHP
                                {
                                    ObjectId = 对象.ObjectId,
                                    CurrentHP = 对象.CurrentHP,
                                    MaxHP = 对象[GameObjectStats.MaxHP]
                                });
                                PlayerObject.ActiveConnection.SendPacket(new ObjectTransformTypePacket
                                {
                                    改变类型 = 2,
                                    对象编号 = 对象.ObjectId
                                });
                                goto IL_356;
                            case (GameObjectType)3:
                                goto IL_356;
                            default:
                                if (对象类型 != GameObjectType.NPC)
                                {
                                    goto IL_356;
                                }
                                break;
                        }
                        PlayerObject.ActiveConnection.SendPacket(new ObjectCharacterStopPacket
                        {
                            对象编号 = 对象.ObjectId,
                            对象坐标 = 对象.CurrentPosition,
                            对象高度 = 对象.CurrentAltitude
                        });
                        SConnection 网络连接 = PlayerObject.ActiveConnection;
                        ObjectComesIntoViewPacket ObjectComesIntoViewPacket = new ObjectComesIntoViewPacket();
                        ObjectComesIntoViewPacket.出现方式 = 1;
                        ObjectComesIntoViewPacket.对象编号 = 对象.ObjectId;
                        ObjectComesIntoViewPacket.现身坐标 = 对象.CurrentPosition;
                        ObjectComesIntoViewPacket.现身高度 = 对象.CurrentAltitude;
                        ObjectComesIntoViewPacket.现身方向 = (ushort)对象.CurrentDirection;
                        ObjectComesIntoViewPacket.现身姿态 = ((byte)(对象.Died ? 13 : 1));
                        ObjectComesIntoViewPacket.体力比例 = (byte)(对象.CurrentHP * 100 / 对象[GameObjectStats.MaxHP]);
                        PlayerObject PlayerObject2 = 对象 as PlayerObject;
                        ObjectComesIntoViewPacket.AdditionalParam = ((byte)((PlayerObject2 == null || !PlayerObject2.灰名玩家) ? 0 : 2));
                        网络连接.SendPacket(ObjectComesIntoViewPacket);
                        PlayerObject.ActiveConnection.SendPacket(new SyncObjectHP
                        {
                            ObjectId = 对象.ObjectId,
                            CurrentHP = 对象.CurrentHP,
                            MaxHP = 对象[GameObjectStats.MaxHP]
                        });
                    }
                    else if (对象类型 != GameObjectType.Item)
                    {
                        if (对象类型 == GameObjectType.Trap)
                        {
                            PlayerObject.ActiveConnection.SendPacket(new TrapComesIntoViewPacket
                            {
                                MapId = 对象.ObjectId,
                                陷阱坐标 = 对象.CurrentPosition,
                                陷阱高度 = 对象.CurrentAltitude,
                                来源编号 = (对象 as TrapObject).TrapSource.ObjectId,
                                Id = (对象 as TrapObject).Id,
                                持续时间 = (对象 as TrapObject).陷阱剩余时间
                            });
                        }
                    }
                    else if (对象 is ItemObject dropObject)
                    {
                        PlayerObject.ActiveConnection.SendPacket(new ObjectDropItemsPacket
                        {
                            DropperObjectId = dropObject.DropperObjectId,
                            ItemObjectId = dropObject.ObjectId,
                            掉落坐标 = dropObject.CurrentPosition,
                            掉落高度 = dropObject.CurrentAltitude,
                            ItemId = dropObject.Id,
                            物品数量 = dropObject.堆叠数量,
                            OwnerPlayerId = dropObject.GetOwnerPlayerIdForDrop(PlayerObject),
                        });
                    }
                IL_356:
                    if (对象.Buffs.Count > 0)
                    {
                        PlayerObject.ActiveConnection.SendPacket(new 同步对象Buff
                        {
                            字节描述 = 对象.对象Buff简述()
                        });
                        return;
                    }
                }
                else if (this is TrapObject TrapObject)
                {
                    if (ComputingClass.GetLocationRange(TrapObject.CurrentPosition, TrapObject.CurrentDirection, TrapObject.ObjectSize).Contains(对象.CurrentPosition))
                    {
                        TrapObject.被动触发陷阱(对象);
                        return;
                    }
                }
                else if (this is PetObject PetObject)
                {
                    if (this.GetDistance(对象) <= PetObject.RangeHate && PetObject.CanAttack(对象) && !对象.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                    {
                        PetObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                        return;
                    }
                    HateObject.仇恨详情 仇恨详情;
                    if (this.GetDistance(对象) > PetObject.RangeHate && PetObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情) && 仇恨详情.仇恨时间 < MainProcess.CurrentTime)
                    {
                        PetObject.HateObject.移除仇恨(对象);
                        return;
                    }
                }
                else if (this is MonsterObject MonsterObject)
                {
                    if (this.GetDistance(对象) <= MonsterObject.RangeHate && MonsterObject.CanAttack(对象) && (MonsterObject.VisibleStealthTargets || !对象.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                    {
                        MonsterObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                        return;
                    }
                    HateObject.仇恨详情 仇恨详情2;
                    if (this.GetDistance(对象) > MonsterObject.RangeHate && MonsterObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情2) && 仇恨详情2.仇恨时间 < MainProcess.CurrentTime)
                    {
                        MonsterObject.HateObject.移除仇恨(对象);
                        return;
                    }
                }
            }
            else if (this.Neighbors.Add(对象))
            {
                if (对象 is PlayerObject || 对象 is PetObject)
                    this.NeighborsImportant.Add(对象);

                if (this is PlayerObject PlayerObject3)
                {
                    GameObjectType 对象类型 = 对象.ObjectType;
                    if (对象类型 <= GameObjectType.NPC)
                    {
                        switch (对象类型)
                        {
                            case GameObjectType.Player:
                            case GameObjectType.Monster:
                                break;
                            case GameObjectType.Pet:
                                PlayerObject3.ActiveConnection.SendPacket(new ObjectCharacterStopPacket
                                {
                                    对象编号 = 对象.ObjectId,
                                    对象坐标 = 对象.CurrentPosition,
                                    对象高度 = 对象.CurrentAltitude
                                });
                                PlayerObject3.ActiveConnection.SendPacket(new ObjectComesIntoViewPacket
                                {
                                    出现方式 = 1,
                                    对象编号 = 对象.ObjectId,
                                    现身坐标 = 对象.CurrentPosition,
                                    现身高度 = 对象.CurrentAltitude,
                                    现身方向 = (ushort)对象.CurrentDirection,
                                    现身姿态 = ((byte)(对象.Died ? 13 : 1)),
                                    体力比例 = (byte)(对象.CurrentHP * 100 / 对象[GameObjectStats.MaxHP])
                                });
                                PlayerObject3.ActiveConnection.SendPacket(new SyncObjectHP
                                {
                                    ObjectId = 对象.ObjectId,
                                    CurrentHP = 对象.CurrentHP,
                                    MaxHP = 对象[GameObjectStats.MaxHP]
                                });
                                PlayerObject3.ActiveConnection.SendPacket(new ObjectTransformTypePacket
                                {
                                    改变类型 = 2,
                                    对象编号 = 对象.ObjectId
                                });
                                goto IL_866;
                            case (GameObjectType)3:
                                goto IL_866;
                            default:
                                if (对象类型 != GameObjectType.NPC)
                                {
                                    goto IL_866;
                                }
                                break;
                        }
                        PlayerObject3.ActiveConnection.SendPacket(new ObjectCharacterStopPacket
                        {
                            对象编号 = 对象.ObjectId,
                            对象坐标 = 对象.CurrentPosition,
                            对象高度 = 对象.CurrentAltitude
                        });
                        SConnection 网络连接2 = PlayerObject3.ActiveConnection;
                        ObjectComesIntoViewPacket ObjectComesIntoViewPacket2 = new ObjectComesIntoViewPacket();
                        ObjectComesIntoViewPacket2.出现方式 = 1;
                        ObjectComesIntoViewPacket2.对象编号 = 对象.ObjectId;
                        ObjectComesIntoViewPacket2.现身坐标 = 对象.CurrentPosition;
                        ObjectComesIntoViewPacket2.现身高度 = 对象.CurrentAltitude;
                        ObjectComesIntoViewPacket2.现身方向 = (ushort)对象.CurrentDirection;
                        ObjectComesIntoViewPacket2.现身姿态 = ((byte)(对象.Died ? 13 : 1));
                        ObjectComesIntoViewPacket2.体力比例 = (byte)(对象.CurrentHP * 100 / 对象[GameObjectStats.MaxHP]);
                        PlayerObject PlayerObject4 = 对象 as PlayerObject;
                        ObjectComesIntoViewPacket2.AdditionalParam = ((byte)((PlayerObject4 == null || !PlayerObject4.灰名玩家) ? 0 : 2));
                        网络连接2.SendPacket(ObjectComesIntoViewPacket2);
                        PlayerObject3.ActiveConnection.SendPacket(new SyncObjectHP
                        {
                            ObjectId = 对象.ObjectId,
                            CurrentHP = 对象.CurrentHP,
                            MaxHP = 对象[GameObjectStats.MaxHP]
                        });
                    }
                    else if (对象类型 != GameObjectType.Item)
                    {
                        if (对象类型 == GameObjectType.Trap)
                        {
                            PlayerObject3.ActiveConnection.SendPacket(new TrapComesIntoViewPacket
                            {
                                MapId = 对象.ObjectId,
                                陷阱坐标 = 对象.CurrentPosition,
                                陷阱高度 = 对象.CurrentAltitude,
                                来源编号 = (对象 as TrapObject).TrapSource.ObjectId,
                                Id = (对象 as TrapObject).Id,
                                持续时间 = (对象 as TrapObject).陷阱剩余时间
                            });
                        }
                        else if (对象 is ChestObject chestObject && chestObject.IsAlredyOpened(PlayerObject3))
                        {
                            PlayerObject3.ActiveConnection.SendPacket(new ChestComesIntoViewPacket
                            {
                                ObjectId = 对象.ObjectId,
                                Direction = (ushort)对象.CurrentDirection,
                                Position = 对象.CurrentPosition,
                                Altitude = 对象.CurrentAltitude,
                                NPCTemplateId = chestObject.Template.Id,
                            });
                            chestObject.ActivateObject();
                        }
                    }
                    else if (对象 is ItemObject dropObject)
                    {
                        PlayerObject3.ActiveConnection.SendPacket(new ObjectDropItemsPacket
                        {
                            DropperObjectId = dropObject.DropperObjectId,
                            ItemObjectId = dropObject.ObjectId,
                            掉落坐标 = dropObject.CurrentPosition,
                            掉落高度 = dropObject.CurrentAltitude,
                            ItemId = dropObject.Id,
                            物品数量 = dropObject.堆叠数量,
                            OwnerPlayerId = dropObject.GetOwnerPlayerIdForDrop(PlayerObject3),
                        });
                    }
                IL_866:
                    if (对象.Buffs.Count > 0)
                    {
                        PlayerObject3.ActiveConnection.SendPacket(new 同步对象Buff
                        {
                            字节描述 = 对象.对象Buff简述()
                        });
                        return;
                    }
                }
                else if (this is TrapObject TrapObject2)
                {
                    if (ComputingClass.GetLocationRange(TrapObject2.CurrentPosition, TrapObject2.CurrentDirection, TrapObject2.ObjectSize).Contains(对象.CurrentPosition))
                    {
                        TrapObject2.被动触发陷阱(对象);
                        return;
                    }
                }
                else if (this is PetObject PetObject2)
                {
                    if (!this.Died)
                    {
                        if (this.GetDistance(对象) <= PetObject2.RangeHate && PetObject2.CanAttack(对象) && !对象.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                        {
                            PetObject2.HateObject.添加仇恨(对象, default(DateTime), 0);
                            return;
                        }
                        HateObject.仇恨详情 仇恨详情3;
                        if (this.GetDistance(对象) > PetObject2.RangeHate && PetObject2.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情3) && 仇恨详情3.仇恨时间 < MainProcess.CurrentTime)
                        {
                            PetObject2.HateObject.移除仇恨(对象);
                            return;
                        }
                    }
                }
                else if (this is MonsterObject MonsterObject2)
                {
                    if (!this.Died)
                    {
                        HateObject.仇恨详情 仇恨详情4;
                        if (this.GetDistance(对象) <= MonsterObject2.RangeHate && MonsterObject2.CanAttack(对象) && (MonsterObject2.VisibleStealthTargets || !对象.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                        {
                            MonsterObject2.HateObject.添加仇恨(对象, default(DateTime), 0);
                        }
                        else if (this.GetDistance(对象) > MonsterObject2.RangeHate && MonsterObject2.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情4) && 仇恨详情4.仇恨时间 < MainProcess.CurrentTime)
                        {
                            MonsterObject2.HateObject.移除仇恨(对象);
                        }
                        if (this.NeighborsImportant.Count != 0)
                        {
                            MonsterObject2.怪物激活处理();
                            return;
                        }
                    }
                }
                else if (this is GuardObject GuardInstance)
                {
                    if (!this.Died)
                    {
                        if (GuardInstance.CanAttack(对象) && this.GetDistance(对象) <= GuardInstance.RangeHate)
                        {
                            GuardInstance.HateObject.添加仇恨(对象, default(DateTime), 0);
                        }
                        else if (this.GetDistance(对象) > GuardInstance.RangeHate)
                        {
                            GuardInstance.HateObject.移除仇恨(对象);
                        }
                        if (this.NeighborsImportant.Count != 0)
                        {
                            GuardInstance.守卫激活处理();
                        }
                    }
                }
            }
        }


        public void 对象消失时处理(MapObject 对象)
        {
            if (this.Neighbors.Remove(对象))
            {
                this.NeighborsSneak.Remove(对象);
                this.NeighborsImportant.Remove(对象);
                if (!(this is ItemObject))
                {
                    PlayerObject PlayerObject = this as PlayerObject;
                    if (PlayerObject != null)
                    {
                        PlayerObject.ActiveConnection.SendPacket(new ObjectOutOfViewPacket
                        {
                            对象编号 = 对象.ObjectId
                        });
                        return;
                    }
                    PetObject PetObject = this as PetObject;
                    if (PetObject != null)
                    {
                        PetObject.HateObject.移除仇恨(对象);
                        return;
                    }
                    MonsterObject MonsterObject = this as MonsterObject;
                    if (MonsterObject != null)
                    {
                        if (!this.Died)
                        {
                            MonsterObject.HateObject.移除仇恨(对象);
                            if (MonsterObject.NeighborsImportant.Count == 0)
                            {
                                MonsterObject.怪物沉睡处理();
                                return;
                            }
                        }
                    }
                    else
                    {
                        GuardObject GuardInstance = this as GuardObject;
                        if (GuardInstance != null && !this.Died)
                        {
                            GuardInstance.HateObject.移除仇恨(对象);
                            if (GuardInstance.NeighborsImportant.Count == 0)
                            {
                                GuardInstance.守卫沉睡处理();
                            }
                        }
                    }
                }
            }
        }


        public void NotifyObjectDies(MapObject 对象)
        {
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null)
            {
                MonsterObject.HateObject.移除仇恨(对象);
                return;
            }
            PetObject PetObject = this as PetObject;
            if (PetObject != null)
            {
                PetObject.HateObject.移除仇恨(对象);
                return;
            }
            GuardObject GuardInstance = this as GuardObject;
            if (GuardInstance != null)
            {
                GuardInstance.HateObject.移除仇恨(对象);
                return;
            }
        }


        public void 对象隐身时处理(MapObject 对象)
        {
            PetObject PetObject = this as PetObject;
            if (PetObject != null && PetObject.HateObject.仇恨列表.ContainsKey(对象))
            {
                PetObject.HateObject.移除仇恨(对象);
            }
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null && MonsterObject.HateObject.仇恨列表.ContainsKey(对象) && !MonsterObject.VisibleStealthTargets)
            {
                MonsterObject.HateObject.移除仇恨(对象);
            }
        }


        public void 对象潜行时处理(MapObject 对象)
        {
            PetObject PetObject = this as PetObject;
            if (PetObject != null)
            {
                if (PetObject.HateObject.仇恨列表.ContainsKey(对象))
                {
                    PetObject.HateObject.移除仇恨(对象);
                }
                this.NeighborsSneak.Add(对象);
            }
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null && !MonsterObject.VisibleStealthTargets)
            {
                if (MonsterObject.HateObject.仇恨列表.ContainsKey(对象))
                {
                    MonsterObject.HateObject.移除仇恨(对象);
                }
                this.NeighborsSneak.Add(对象);
            }
            PlayerObject PlayerObject = this as PlayerObject;
            if (PlayerObject != null && (this.GetRelationship(对象) == GameObjectRelationship.Hostility || 对象.GetRelationship(this) == GameObjectRelationship.Hostility))
            {
                this.NeighborsSneak.Add(对象);
                PlayerObject.ActiveConnection.SendPacket(new ObjectOutOfViewPacket
                {
                    对象编号 = 对象.ObjectId
                });
            }
        }


        public void 对象显隐时处理(MapObject 对象)
        {
            PetObject PetObject = this as PetObject;
            if (PetObject != null)
            {
                HateObject.仇恨详情 仇恨详情;
                if (this.GetDistance(对象) <= PetObject.RangeHate && PetObject.CanAttack(对象) && !对象.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus))
                {
                    PetObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                }
                else if (this.GetDistance(对象) > PetObject.RangeHate && PetObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情) && 仇恨详情.仇恨时间 < MainProcess.CurrentTime)
                {
                    PetObject.HateObject.移除仇恨(对象);
                }
            }
            MonsterObject MonsterObject = this as MonsterObject;
            if (MonsterObject != null)
            {
                if (this.GetDistance(对象) <= MonsterObject.RangeHate && MonsterObject.CanAttack(对象) && (MonsterObject.VisibleStealthTargets || !对象.CheckStatus(GameObjectState.Invisibility | GameObjectState.StealthStatus)))
                {
                    MonsterObject.HateObject.添加仇恨(对象, default(DateTime), 0);
                    return;
                }
                HateObject.仇恨详情 仇恨详情2;
                if (this.GetDistance(对象) > MonsterObject.RangeHate && MonsterObject.HateObject.仇恨列表.TryGetValue(对象, out 仇恨详情2) && 仇恨详情2.仇恨时间 < MainProcess.CurrentTime)
                {
                    MonsterObject.HateObject.移除仇恨(对象);
                }
            }
        }


        public void 对象显行时处理(MapObject 对象)
        {
            if (this.NeighborsSneak.Contains(对象))
            {
                this.对象出现时处理(对象);
            }
        }


        public byte[] 对象Buff详述()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(34))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write((byte)this.Buffs.Count);
                    foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buffs)
                    {
                        binaryWriter.Write(keyValuePair.Value.Id.V);
                        binaryWriter.Write((int)keyValuePair.Value.Id.V);
                        binaryWriter.Write(keyValuePair.Value.当前层数.V);
                        binaryWriter.Write((int)keyValuePair.Value.剩余时间.V.TotalMilliseconds);
                        binaryWriter.Write((int)keyValuePair.Value.持续时间.V.TotalMilliseconds);
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }


        public byte[] 对象Buff简述()
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream(34))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
                {
                    binaryWriter.Write(ObjectId);
                    int num = 0;
                    foreach (KeyValuePair<ushort, BuffData> keyValuePair in this.Buffs)
                    {
                        binaryWriter.Write(keyValuePair.Value.Id.V);
                        binaryWriter.Write((int)keyValuePair.Value.Id.V);
                        if (++num >= 5)
                        {
                            break;
                        }
                    }
                    result = memoryStream.ToArray();
                }
            }
            return result;
        }
    }
}
