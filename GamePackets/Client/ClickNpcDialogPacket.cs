using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 113, Length = 14, Description = "ClickNpcDialogPacket")]
	public sealed class ClickNpcDialogPacket : GamePacket
	{
		
		public ClickNpcDialogPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
