using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 584, 长度 = 28, 注释 = "申请行会敌对")]
	public sealed class 申请行会敌对 : GamePacket
	{
		
		public 申请行会敌对()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 敌对时间;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 25)]
		public string 行会名字;
	}
}
