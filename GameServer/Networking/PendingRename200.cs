using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 111, 长度 = 6, 注释 = "打开角色摊位")]
	public sealed class 打开角色摊位 : GamePacket
	{
		
		public 打开角色摊位()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
