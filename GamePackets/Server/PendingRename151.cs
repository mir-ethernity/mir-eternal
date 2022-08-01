using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 138, 长度 = 13, 注释 = "同步角色外形")]
	public sealed class 同步角色外形 : GamePacket
	{
		
		public 同步角色外形()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte ItemType;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int 装备编号;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 1)]
		public byte 升级次数;
	}
}
