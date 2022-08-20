using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 71, Length = 6, Description = "传承武器铭文")]
	public sealed class 传承武器铭文 : GamePacket
	{
		
		public 传承武器铭文()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 来源类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 1)]
		public byte 来源位置;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 目标类型;

		
		[WrappingFieldAttribute(SubScript = 5, Length = 1)]
		public byte 目标位置;
	}
}
