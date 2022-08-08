using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Data
{
	
	public sealed class HashMonitor<T> : IEnumerable<T>, IEnumerable
	{
		
		public event HashMonitor<T>.更改委托 更改事件;

		
		public HashMonitor(GameData 数据)
		{
			
			this.v = new HashSet<T>();
			
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
			HashSet<T> hashSet = this.v;
			if (hashSet == null)
			{
				return null;
			}
			return hashSet.Count.ToString();
		}

		
		private void 设置状态()
		{
			if (this.对应数据 != null)
			{
				this.对应数据.已经修改 = true;
				GameDataGateway.已经修改 = true;
			}
		}

		
		public int Count
		{
			get
			{
				return this.v.Count;
			}
		}

		
		public ISet<T> ISet
		{
			get
			{
				return this.v;
			}
		}

		
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

		
		public void QuietlyAdd(T Tv)
		{
			this.v.Add(Tv);
		}

		
		public bool Contains(T Tv)
		{
			return this.v.Contains(Tv);
		}

		
		private readonly HashSet<T> v;

		
		private readonly GameData 对应数据;

		
		public delegate void 更改委托(List<T> 更改列表);
	}
}
