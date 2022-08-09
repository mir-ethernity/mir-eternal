using System;

namespace GameServer.Data
{
	
	public sealed class DataMonitor<T>
	{
		
		public event DataMonitor<T>.更改委托 更改事件;

		
		public T V
		{
			get
			{
				return this.v;
			}
			set
			{
				this.v = value;
				DataMonitor<T>.更改委托 更改委托 = this.更改事件;
				if (更改委托 != null)
				{
					更改委托(value);
				}
				if (this.对应数据 != null)
				{
					this.对应数据.已经修改 = true;
					GameDataGateway.已经修改 = true;
				}
			}
		}

		
		public void QuietlySetValue(T value)
		{
			this.v = value;
		}

		
		public DataMonitor(GameData 数据)
		{
			
			
			this.对应数据 = 数据;
		}

		
		public override string ToString()
		{
			ref T ptr = ref this.v;
			if (default(T) == null)
			{
				T t = this.v;
				ptr =  t;
				if (t == null)
				{
					return null;
				}
			}
			return ptr.ToString();
		}

		
		private T v;

		
		private readonly GameData 对应数据;

		
		public delegate void 更改委托(T 更改数据);
	}
}
