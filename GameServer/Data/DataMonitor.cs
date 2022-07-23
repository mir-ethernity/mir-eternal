using System;

namespace GameServer.Data
{
	
	public sealed class DataMonitor<T>
	{
		
		// (add) Token: 0x06000507 RID: 1287 RVA: 0x00024900 File Offset: 0x00022B00
		// (remove) Token: 0x06000508 RID: 1288 RVA: 0x00024938 File Offset: 0x00022B38
		public event DataMonitor<T>.更改委托 更改事件;

		
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x00004BB6 File Offset: 0x00002DB6
		// (set) Token: 0x0600050A RID: 1290 RVA: 0x00004BBE File Offset: 0x00002DBE
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

		
		// (Invoke) Token: 0x0600050F RID: 1295
		public delegate void 更改委托(T 更改数据);
	}
}
