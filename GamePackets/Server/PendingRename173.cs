using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 85, Length = 8, Description = "泡泡提示")]
	public sealed class 同步气泡提示 : GamePacket
	{
		
		public 同步气泡提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 泡泡类型;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 4)]
		public int 泡泡参数;
	}
}
