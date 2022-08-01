using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 656, 长度 = 6, 注释 = "同步元宝数量")]
	public sealed class 同步元宝数量 : GamePacket
	{
		
		public 同步元宝数量()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 元宝数量;
	}
}
