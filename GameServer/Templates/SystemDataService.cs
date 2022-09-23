using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameServer.Templates
{
    public static class SystemDataService
    {

        public static void LoadData()
        {
            var types = new Type[]
            {
                typeof(Monsters),
                typeof(Guards),
                typeof(NpcDialogs),
                typeof(GameMap),
                typeof(Terrains),
                typeof(MapAreas),
                typeof(TeleportGates),
                typeof(MonsterSpawns),
                typeof(MapGuards),
                typeof(GameItems),
                typeof(RandomStats),
                typeof(EquipmentStats),
                typeof(GameStore),
                typeof(Treasures),
                typeof(GameTitle),
                typeof(InscriptionSkill),
                typeof(GameSkills),
                typeof(SkillTraps),
                typeof(GameBuffs),
                typeof(InscriptionItems),
                typeof(ChestTemplate),
                typeof(MapChest),
                typeof(GameQuests),
                typeof(GameMounts),
            };

            Parallel.ForEach(types, (type) =>
            {
                LoadDataType(type);
            });
        }

        public static void ReloadData()
        {
            var types = new Type[]
           {
                typeof(Monsters),
                typeof(Guards),
                typeof(NpcDialogs),
                typeof(TeleportGates),
                typeof(MonsterSpawns),
                typeof(MapGuards),
                typeof(GameItems),
                typeof(RandomStats),
                typeof(EquipmentStats),
                typeof(GameStore),
                typeof(Treasures),
                typeof(GameTitle),
                typeof(InscriptionSkill),
                typeof(GameSkills),
                typeof(SkillTraps),
                typeof(GameBuffs),
                typeof(InscriptionItems),
                typeof(ChestTemplate),
                typeof(MapChest),
                typeof(GameQuests),
                typeof(GameMounts),
           };

            foreach (var type in types)
                MainProcess.ReloadTasks.Enqueue(() => LoadDataType(type));
        }

        public static void LoadDataType(Type type)
        {
            var watcher = new Stopwatch();

            MethodInfo method = type.GetMethod("LoadData", BindingFlags.Static | BindingFlags.Public);

            if (method != null)
            {
                watcher.Start();
                method.Invoke(null, null);
                watcher.Stop();
            }
            else
            {
                MainForm.AddSystemLog(type.Name + " Failed to find 'LoadData' method, Failed to load");
                return;
            }

            FieldInfo field = type.GetField("DataSheet", BindingFlags.Static | BindingFlags.Public);
            if (field == null)
            {
                MainForm.AddSystemLog(type.Name + " Failed to find 'DataSheet' property, Failed to load");
                return;
            }

            object obj = field.GetValue(null);
            if (obj == null)
            {
                MainForm.AddSystemLog(type.Name + " Failed to load content, Check data directory");
                return;
            }

            PropertyInfo property = obj.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public);
            if (property == null)
            {
                MainForm.AddSystemLog(type.Name + " Failed to find 'Count' property, Failed to load");
                return;
            }

            int num = (int)property.GetValue(obj);
            MainForm.AddSystemLog(string.Format("{0} Loaded, Total: {1}, Elapsed: {2}ms", type.Name, num, watcher.ElapsedMilliseconds));
        }
    }
}
