using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameServer.Templates
{
    public static class SystemDataService
    {
        public static void LoadData()
        {
            List<Type> dataTypesToLoad = new List<Type>
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
            };

            Task.Run(delegate ()
            {
                foreach (Type type in dataTypesToLoad)
                {
                    MethodInfo method = type.GetMethod("LoadData", BindingFlags.Static | BindingFlags.Public);

                    if (method != null)
                    {
                        method.Invoke(null, null);
                    }
                    else
                    {
                        MessageBox.Show(type.Name + " Failed to find 'LoadData' method, Failed to load");
                        continue;
                    }

                    FieldInfo field = type.GetField("DataSheet", BindingFlags.Static | BindingFlags.Public);
                    if (field == null)
                    {
                        MessageBox.Show(type.Name + " Failed to find 'DataSheet' property, Failed to load");
                        continue;
                    }

                    object obj = field.GetValue(null);
                    if (obj == null)
                    {
                        MessageBox.Show(type.Name + " Failed to load content, Check data directory");
                        continue;
                    }

                    PropertyInfo property = obj.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public);
                    if (property == null)
                    {
                        MessageBox.Show(type.Name + " Failed to find 'Count' property, Failed to load");
                        continue;
                    }

                    int num = (int)property.GetValue(obj);
                    MainForm.AddSystemLog(string.Format("{0} Loaded, Total: {1}", type.Name, num));
                }
            }).Wait();
        }
    }
}
