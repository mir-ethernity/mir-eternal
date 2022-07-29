using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 14, 长度 = 0, 注释 = "同步角色Stat")]
	public sealed class 同步角色Stat : GamePacket
	{
		
		public 同步角色Stat()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 6, Length = 0)]
		public byte[] StatDescription;
	}
}
