using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Data
{
	
	public sealed class MonitorDictionary<TK, TV> : IEnumerable<KeyValuePair<TK, TV>>, IEnumerable
	{
		
		// (add) Token: 0x0600053E RID: 1342 RVA: 0x00024B48 File Offset: 0x00022D48
		// (remove) Token: 0x0600053F RID: 1343 RVA: 0x00024B80 File Offset: 0x00022D80
		public event MonitorDictionary<TK, TV>.更改委托 更改事件;

		
		public MonitorDictionary(GameData 数据)
		{
			
			this.v = new Dictionary<TK, TV>();
			
			this.对应数据 = 数据;
		}

		
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

		
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x00004F98 File Offset: 0x00003198
		public ICollection<TK> Keys
		{
			get
			{
				return this.v.Keys;
			}
		}

		
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x00004FA5 File Offset: 0x000031A5
		public ICollection<TV> Values
		{
			get
			{
				return this.v.Values;
			}
		}

		
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x00004FB2 File Offset: 0x000031B2
		public IDictionary IDictionary_0
		{
			get
			{
				return this.v;
			}
		}

		
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x00004FBA File Offset: 0x000031BA
		public int Count
		{
			get
			{
				return this.v.Count;
			}
		}

		
		public bool ContainsKey(TK k)
		{
			return this.v.ContainsKey(k);
		}

		
		public bool TryGetValue(TK k, out TV v)
		{
			return this.v.TryGetValue(k, out v);
		}

		
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

		
		public void QuietlyAdd(TK key, TV value)
		{
			this.v.Add(key, value);
		}

		
		public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.v).GetEnumerator();
		}

		
		IEnumerator<KeyValuePair<TK, TV>> IEnumerable<KeyValuePair<TK, TV>>.GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		
		public override string ToString()
		{
			Dictionary<TK, TV> dictionary = this.v;
			if (dictionary == null)
			{
				return null;
			}
			return dictionary.Count.ToString();
		}

		
		private void 设置状态()
		{
			if (this.对应数据 != null)
			{
				this.对应数据.已经修改 = true;
				GameDataGateway.已经修改 = true;
			}
		}

		
		private readonly Dictionary<TK, TV> v;

		
		private readonly GameData 对应数据;

		
		// (Invoke) Token: 0x06000553 RID: 1363
		public delegate void 更改委托(List<KeyValuePair<TK, TV>> 更改字典);
	}
}
