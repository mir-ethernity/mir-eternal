using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 265, Length = 3, Description = "确认替换铭文")]
	public sealed class 确认替换铭文 : GamePacket
	{
		
		public 确认替换铭文()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 确定替换;
	}
}
