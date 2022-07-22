using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Data
{
	// Token: 0x02000263 RID: 611
	public sealed class MonitorDictionary<TK, TV> : IEnumerable<KeyValuePair<TK, TV>>, IEnumerable
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600053E RID: 1342 RVA: 0x00024B48 File Offset: 0x00022D48
		// (remove) Token: 0x0600053F RID: 1343 RVA: 0x00024B80 File Offset: 0x00022D80
		public event MonitorDictionary<TK, TV>.更改委托 更改事件;

		// Token: 0x06000540 RID: 1344 RVA: 0x00004F48 File Offset: 0x00003148
		public MonitorDictionary(GameData 数据)
		{
			
			this.v = new Dictionary<TK, TV>();
			
			this.对应数据 = 数据;
		}

		// Token: 0x17000062 RID: 98
		public TV this[TK key]
		{
			get
			{
				TV result;
				if (!this.v.TryGetValue(key, out result))
				{
					return default(TV);
				}
				return result;
			}
			set
			{
				this.v[key] = value;
				MonitorDictionary<TK, TV>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<KeyValuePair<TK, TV>>());
				}
				this.设置状态();
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x00004F98 File Offset: 0x00003198
		public ICollection<TK> Keys
		{
			get
			{
				return this.v.Keys;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x00004FA5 File Offset: 0x000031A5
		public ICollection<TV> Values
		{
			get
			{
				return this.v.Values;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x00004FB2 File Offset: 0x000031B2
		public IDictionary IDictionary_0
		{
			get
			{
				return this.v;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x00004FBA File Offset: 0x000031BA
		public int Count
		{
			get
			{
				return this.v.Count;
			}
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x00004FC7 File Offset: 0x000031C7
		public bool ContainsKey(TK k)
		{
			return this.v.ContainsKey(k);
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00004FD5 File Offset: 0x000031D5
		public bool TryGetValue(TK k, out TV v)
		{
			return this.v.TryGetValue(k, out v);
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00004FE4 File Offset: 0x000031E4
		public void Add(TK key, TV value)
		{
			this.v.Add(key, value);
			MonitorDictionary<TK, TV>.更改委托 更改委托 = this.更改事件;
			if (更改委托 != null)
			{
				更改委托(this.v.ToList<KeyValuePair<TK, TV>>());
			}
			this.设置状态();
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00005015 File Offset: 0x00003215
		public bool Remove(TK key)
		{
			if (this.v.Remove(key))
			{
				MonitorDictionary<TK, TV>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<KeyValuePair<TK, TV>>());
				}
				this.设置状态();
				return true;
			}
			return false;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0000504A File Offset: 0x0000324A
		public void Clear()
		{
			if (this.v.Count > 0)
			{
				this.v.Clear();
				MonitorDictionary<TK, TV>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<KeyValuePair<TK, TV>>());
				}
				this.设置状态();
			}
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00005087 File Offset: 0x00003287
		public void QuietlyAdd(TK key, TV value)
		{
			this.v.Add(key, value);
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00005096 File Offset: 0x00003296
		public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x000050A8 File Offset: 0x000032A8
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.v).GetEnumerator();
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00005096 File Offset: 0x00003296
		IEnumerator<KeyValuePair<TK, TV>> IEnumerable<KeyValuePair<TK, TV>>.GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00024BE0 File Offset: 0x00022DE0
		public override string ToString()
		{
			Dictionary<TK, TV> dictionary = this.v;
			if (dictionary == null)
			{
				return null;
			}
			return dictionary.Count.ToString();
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x000050B5 File Offset: 0x000032B5
		private void 设置状态()
		{
			if (this.对应数据 != null)
			{
				this.对应数据.已经修改 = true;
				GameDataGateway.已经修改 = true;
			}
		}

		// Token: 0x0400081B RID: 2075
		private readonly Dictionary<TK, TV> v;

		// Token: 0x0400081C RID: 2076
		private readonly GameData 对应数据;

		// Token: 0x02000264 RID: 612
		// (Invoke) Token: 0x06000553 RID: 1363
		public delegate void 更改委托(List<KeyValuePair<TK, TV>> 更改字典);
	}
}
