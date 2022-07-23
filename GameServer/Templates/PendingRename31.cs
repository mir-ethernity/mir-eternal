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
			List<Type> 模板列表 = new List<Type>
			{
				typeof(游戏怪物),
				typeof(地图守卫),
				typeof(对话数据),
				typeof(游戏地图),
				typeof(地形数据),
				typeof(地图区域),
				typeof(TeleportGates),
				typeof(怪物刷新),
				typeof(Guards),
				typeof(游戏物品),
				typeof(随机属性),
				typeof(装备属性),
				typeof(游戏商店),
				typeof(珍宝商品),
				typeof(游戏称号),
				typeof(铭文技能),
				typeof(游戏技能),
				typeof(技能陷阱),
				typeof(游戏Buff)
			};
			Task.Run(delegate()
			{
				foreach (Type type in 模板列表)
				{
					MethodInfo method = type.GetMethod("LoadData", BindingFlags.Static | BindingFlags.Public);
					if (method != null)
					{
						method.Invoke(null, null);
					}
					else
					{
						MessageBox.Show(type.Name + " Failed to find load method, Failed to load");
					}
					FieldInfo field = type.GetField("DataSheet", BindingFlags.Static | BindingFlags.Public);
					object obj = (field != null) ? field.GetValue(null) : null;
					if (obj == null)
					{
						goto IL_88;
					}
					PropertyInfo property = obj.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public);
					if (property == null)
					{
						goto IL_88;
					}
					object obj2 = property.GetValue(obj);
					IL_92:
					int num = (int)obj2;
					if (num != 0)
					{
						MainForm.AddSystemLog(string.Format("{0} Loaded, Total: {1}", type.Name, num));
						continue;
					}
					MainForm.AddSystemLog(type.Name + " Error on load, Be careful to check the data directory.");
					continue;
					IL_88:
					obj2 = null;
					goto IL_92;
				}
			}).Wait();
		}
	}
}
