using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Data
{
	// Token: 0x0200025F RID: 607
	public sealed class ListMonitor<T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000512 RID: 1298 RVA: 0x000249B4 File Offset: 0x00022BB4
		// (remove) Token: 0x06000513 RID: 1299 RVA: 0x000249EC File Offset: 0x00022BEC
		public event ListMonitor<T>.更改委托 更改事件;

		// Token: 0x06000514 RID: 1300 RVA: 0x00004C10 File Offset: 0x00002E10
		public ListMonitor(GameData 数据)
		{
			
			this.v = new List<T>();
			
			this.对应数据 = 数据;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x00004C2F File Offset: 0x00002E2F
		public IEnumerator<T> GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00004C41 File Offset: 0x00002E41
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.v).GetEnumerator();
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00004C2F File Offset: 0x00002E2F
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00024A24 File Offset: 0x00022C24
		public override string ToString()
		{
			List<T> list = this.v;
			if (list == null)
			{
				return null;
			}
			return list.Count.ToString();
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x00004C4E File Offset: 0x00002E4E
		private void 设置状态()
		{
			if (this.对应数据 != null)
			{
				this.对应数据.已经修改 = true;
				GameDataGateway.已经修改 = true;
			}
		}

		// Token: 0x1700005C RID: 92
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

		// Token: 0x1700005D RID: 93
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

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x00004CAA File Offset: 0x00002EAA
		public IList IList
		{
			get
			{
				return this.v;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x00004CB2 File Offset: 0x00002EB2
		public int Count
		{
			get
			{
				return this.v.Count;
			}
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00004CBF File Offset: 0x00002EBF
		public List<T> GetRange(int index, int count)
		{
			return this.v.GetRange(index, count);
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x00004CCE File Offset: 0x00002ECE
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

		// Token: 0x06000521 RID: 1313 RVA: 0x00004CFE File Offset: 0x00002EFE
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

		// Token: 0x06000522 RID: 1314 RVA: 0x00004D2F File Offset: 0x00002F2F
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

		// Token: 0x06000523 RID: 1315 RVA: 0x00004D61 File Offset: 0x00002F61
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

		// Token: 0x06000524 RID: 1316 RVA: 0x00004D9F File Offset: 0x00002F9F
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

		// Token: 0x06000525 RID: 1317 RVA: 0x00004DDC File Offset: 0x00002FDC
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

		// Token: 0x06000526 RID: 1318 RVA: 0x00004E07 File Offset: 0x00003007
		public void QuietlyAdd(T Tv)
		{
			this.v.Add(Tv);
		}

		// Token: 0x04000815 RID: 2069
		private List<T> v;

		// Token: 0x04000816 RID: 2070
		private readonly GameData 对应数据;

		// Token: 0x02000260 RID: 608
		// (Invoke) Token: 0x06000528 RID: 1320
		public delegate void 更改委托(List<T> 更改列表);
	}
}
