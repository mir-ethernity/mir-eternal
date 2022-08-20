using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 111, Length = 6, Description = "打开角色摊位")]
	public sealed class 打开角色摊位 : GamePacket
	{
		
		public 打开角色摊位()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
