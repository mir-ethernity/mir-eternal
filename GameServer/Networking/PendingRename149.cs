using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 14, 长度 = 0, 注释 = "同步角色属性")]
	public sealed class 同步角色属性 : GamePacket
	{
		
		public 同步角色属性()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 0)]
		public byte[] StatDescription;
	}
}
