using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 10, Length = 6, Description = "更换角色")]
	public sealed class 客户更换角色 : GamePacket
	{
		
		public 客户更换角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 编号;
	}
}
