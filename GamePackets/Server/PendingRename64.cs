using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 556, Length = 6, Description = "玩家申请收徒")]
	public sealed class 申请收徒应答 : GamePacket
	{
		
		public 申请收徒应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
