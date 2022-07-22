using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Data
{
	// Token: 0x02000261 RID: 609
	public sealed class HashMonitor<T> : IEnumerable<T>, IEnumerable
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600052B RID: 1323 RVA: 0x00024AB0 File Offset: 0x00022CB0
		// (remove) Token: 0x0600052C RID: 1324 RVA: 0x00024AE8 File Offset: 0x00022CE8
		public event HashMonitor<T>.更改委托 更改事件;

		// Token: 0x0600052D RID: 1325 RVA: 0x00004E15 File Offset: 0x00003015
		public HashMonitor(GameData 数据)
		{
			
			this.v = new HashSet<T>();
			
			this.对应数据 = 数据;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00004E34 File Offset: 0x00003034
		public IEnumerator<T> GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00004E46 File Offset: 0x00003046
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this.v).GetEnumerator();
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00004E34 File Offset: 0x00003034
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.v.GetEnumerator();
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00024B20 File Offset: 0x00022D20
		public override string ToString()
		{
			HashSet<T> hashSet = this.v;
			if (hashSet == null)
			{
				return null;
			}
			return hashSet.Count.ToString();
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00004E53 File Offset: 0x00003053
		private void 设置状态()
		{
			if (this.对应数据 != null)
			{
				this.对应数据.已经修改 = true;
				GameDataGateway.已经修改 = true;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x00004E6F File Offset: 0x0000306F
		public int Count
		{
			get
			{
				return this.v.Count;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x00004E7C File Offset: 0x0000307C
		public ISet<T> ISet
		{
			get
			{
				return this.v;
			}
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00004E84 File Offset: 0x00003084
		public void Clear()
		{
			if (this.v.Count > 0)
			{
				this.v.Clear();
				HashMonitor<T>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<T>());
				}
				this.设置状态();
			}
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00004EC1 File Offset: 0x000030C1
		public bool Add(T Tv)
		{
			if (this.v.Add(Tv))
			{
				HashMonitor<T>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<T>());
				}
				this.设置状态();
				return true;
			}
			return false;
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00004EF6 File Offset: 0x000030F6
		public bool Remove(T Tv)
		{
			if (this.v.Remove(Tv))
			{
				HashMonitor<T>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(this.v.ToList<T>());
				}
				this.设置状态();
				return true;
			}
			return false;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00004F2B File Offset: 0x0000312B
		public void QuietlyAdd(T Tv)
		{
			this.v.Add(Tv);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00004F3A File Offset: 0x0000313A
		public bool Contains(T Tv)
		{
			return this.v.Contains(Tv);
		}

		// Token: 0x04000818 RID: 2072
		private readonly HashSet<T> v;

		// Token: 0x04000819 RID: 2073
		private readonly GameData 对应数据;

		// Token: 0x02000262 RID: 610
		// (Invoke) Token: 0x0600053B RID: 1339
		public delegate void 更改委托(List<T> 更改列表);
	}
}
