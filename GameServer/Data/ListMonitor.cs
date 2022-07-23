using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Data
{
	
	public sealed class ListMonitor<T> : IEnumerable<T>, IEnumerable
	{
		
		// (add) Token: 0x06000512 RID: 1298 RVA: 0x000249B4 File Offset: 0x00022BB4
		// (remove) Token: 0x06000513 RID: 1299 RVA: 0x000249EC File Offset: 0x00022BEC
		public event ListMonitor<T>.更改委托 更改事件;

		
		public ListMonitor(GameData 数据)
		{
			
			this.v = new List<T>();
			
			this.对应数据 = 数据;
		}

		
		public IEnumerator<T> GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.v).GetEnumerator();
		}

		
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		
		public override string ToString()
		{
			List<T> list = this.v;
			if (list == null)
			{
				return null;
			}
			return list.Count.ToString();
		}

		
		private void 设置状态()
		{
			if (this.对应数据 != null)
			{
				this.对应数据.已经修改 = true;
				GameDataGateway.已经修改 = true;
			}
		}

		
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x00024A4C File Offset: 0x00022C4C
		public T Last
		{
			get
			{
				if (this.v.Count != 0)
				{
					return this.v.Last<T>();
				}
				return default(T);
			}
		}

		
		public T this[int 索引]
		{
			get
			{
				if (索引 >= this.v.Count)
				{
					return default(T);
				}
				return this.v[索引];
			}
			set
			{
				if (索引 >= this.v.Count)
				{
					return;
				}
				this.v[索引] = value;
				ListMonitor<T>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<T>());
				}
				this.设置状态();
			}
		}

		
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x00004CAA File Offset: 0x00002EAA
		public IList IList
		{
			get
			{
				return this.v;
			}
		}

		
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x00004CB2 File Offset: 0x00002EB2
		public int Count
		{
			get
			{
				return this.v.Count;
			}
		}

		
		public List<T> GetRange(int index, int count)
		{
			return this.v.GetRange(index, count);
		}

		
		public void Add(T Tv)
		{
			this.v.Add(Tv);
			ListMonitor<T>.更改委托 更改委托 = this.更改事件;
			if (更改委托 != null)
			{
				更改委托(this.v.ToList<T>());
			}
			this.设置状态();
		}

		
		public void Insert(int index, T Tv)
		{
			this.v.Insert(index, Tv);
			ListMonitor<T>.更改委托 更改委托 = this.更改事件;
			if (更改委托 != null)
			{
				更改委托(this.v.ToList<T>());
			}
			this.设置状态();
		}

		
		public void Remove(T Tv)
		{
			if (this.v.Remove(Tv))
			{
				ListMonitor<T>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<T>());
				}
				this.设置状态();
			}
		}

		
		public void RemoveAt(int i)
		{
			if (this.v.Count > i)
			{
				this.v.RemoveAt(i);
				ListMonitor<T>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<T>());
				}
				this.设置状态();
			}
		}

		
		public void Clear()
		{
			if (this.v.Count > 0)
			{
				this.v.Clear();
				ListMonitor<T>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<T>());
				}
				this.设置状态();
			}
		}

		
		public void SetValue(List<T> Lv)
		{
			this.v = Lv;
			ListMonitor<T>.更改委托 更改委托 = this.更改事件;
			if (更改委托 != null)
			{
				更改委托(this.v.ToList<T>());
			}
			this.设置状态();
		}

		
		public void QuietlyAdd(T Tv)
		{
			this.v.Add(Tv);
		}

		
		private List<T> v;

		
		private readonly GameData 对应数据;

		
		// (Invoke) Token: 0x06000528 RID: 1320
		public delegate void 更改委托(List<T> 更改列表);
	}
}
