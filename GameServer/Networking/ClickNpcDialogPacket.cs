using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 113, 长度 = 14, 注释 = "ClickNpcDialogPacket")]
	public sealed class ClickNpcDialogPacket : GamePacket
	{
		
		public ClickNpcDialogPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
