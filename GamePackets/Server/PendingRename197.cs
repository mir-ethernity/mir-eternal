using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 156, 长度 = 7, 注释 = "摆摊状态改变", Broadcast = true)]
	public sealed class 摆摊状态改变 : GamePacket
	{
		
		public 摆摊状态改变()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 摊位状态;
	}
}
