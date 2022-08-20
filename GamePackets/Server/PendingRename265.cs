using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 279, Length = 4, Description = "更换角色计时")]
	public sealed class 更换角色计时 : GamePacket
	{
		
		public 更换角色计时()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 成功;
	}
}
