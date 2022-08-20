using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 571, Length = 6, Description = "申请解除结盟")]
	public sealed class 申请解除结盟 : GamePacket
	{
		
		public 申请解除结盟()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
