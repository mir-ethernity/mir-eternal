using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 568, Length = 6, Description = "RemoveApprenticePromptPacket")]
	public sealed class RemoveApprenticePromptPacket : GamePacket
	{
		
		public RemoveApprenticePromptPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
