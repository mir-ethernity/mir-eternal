using System;

namespace GameServer.Data
{
	// Token: 0x0200025D RID: 605
	public sealed class DataMonitor<T>
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000507 RID: 1287 RVA: 0x00024900 File Offset: 0x00022B00
		// (remove) Token: 0x06000508 RID: 1288 RVA: 0x00024938 File Offset: 0x00022B38
		public event DataMonitor<T>.更改委托 更改事件;

		// Token: 0x1700005B RID: 91
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

		// Token: 0x0600050B RID: 1291 RVA: 0x00004BF3 File Offset: 0x00002DF3
		public void QuietlySetValue(T value)
		{
			this.v = value;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00004BFC File Offset: 0x00002DFC
		public DataMonitor(GameData 数据)
		{
			
			
			this.对应数据 = 数据;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00024970 File Offset: 0x00022B70
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

		// Token: 0x04000812 RID: 2066
		private T v;

		// Token: 0x04000813 RID: 2067
		private readonly GameData 对应数据;

		// Token: 0x0200025E RID: 606
		// (Invoke) Token: 0x0600050F RID: 1295
		public delegate void 更改委托(T 更改数据);
	}
}
