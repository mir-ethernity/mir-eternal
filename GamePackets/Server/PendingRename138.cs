using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 121, Length = 10, Description = "CharacterSelectionTargetPacket")]
	public sealed class 玩家选中目标 : GamePacket
	{
		
		public 玩家选中目标()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 目标编号;
	}
}
