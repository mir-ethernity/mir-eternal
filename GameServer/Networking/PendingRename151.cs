using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 138, 长度 = 13, 注释 = "同步角色外形")]
	public sealed class 同步角色外形 : GamePacket
	{
		
		public 同步角色外形()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 装备部位;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 4)]
		public int 装备编号;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 1)]
		public byte 升级次数;
	}
}
