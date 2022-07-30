using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 16, 长度 = 8, 注释 = "角色转动")]
	public sealed class 客户角色转动 : GamePacket
	{
		
		public 客户角色转动()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public short 转动方向;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public uint 转动耗时;
	}
}
