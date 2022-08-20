using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 567, Length = 6, Description = "收徒成功提示")]
	public sealed class 收徒成功提示 : GamePacket
	{
		
		public 收徒成功提示()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
