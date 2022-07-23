using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 556, 长度 = 31, 注释 = "申请加入行会")]
	public sealed class 申请加入行会 : GamePacket
	{
		
		public 申请加入行会()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 25)]
		public string 行会名字;
	}
}
