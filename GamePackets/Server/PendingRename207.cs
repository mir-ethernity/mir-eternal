using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 551, 长度 = 6, 注释 = "同意拜师申请")]
	public sealed class 拜师申请通过 : GamePacket
	{
		
		public 拜师申请通过()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
