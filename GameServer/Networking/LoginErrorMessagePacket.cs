using System;

namespace GameServer.Networking
{
	// Token: 0x02000240 RID: 576
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1001, 长度 = 14, 注释 = "登录服务器,错误提示")]
	public sealed class LoginErrorMessagePacket : GamePacket
	{
		// Token: 0x06000329 RID: 809 RVA: 0x0000344A File Offset: 0x0000164A
		public LoginErrorMessagePacket()
		{
			
			
		}

		// Token: 0x04000797 RID: 1943
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public uint 错误代码;

		// Token: 0x04000798 RID: 1944
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 参数一;

		// Token: 0x04000799 RID: 1945
		[WrappingFieldAttribute(下标 = 10, 长度 = 4)]
		public int 参数二;
	}
}
