using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 35, Length = 0, Description = "同步角色装备")]
	public sealed class 同步角色装备 : GamePacket
	{
		
		public 同步角色装备()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 40, Length = 1)]
		public byte 装备数量;

		
		[WrappingFieldAttribute(SubScript = 41, Length = 0)]
		public byte[] 字节描述;
	}
}
