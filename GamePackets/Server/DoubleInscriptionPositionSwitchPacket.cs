using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 267, Length = 8, Description = "DoubleInscriptionPositionSwitchPacket")]
	public sealed class DoubleInscriptionPositionSwitchPacket : GamePacket
	{
		
		public DoubleInscriptionPositionSwitchPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 当前栏位;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 第一铭文;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 第二铭文;
	}
}
