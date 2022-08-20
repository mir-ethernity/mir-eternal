using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 570, Length = 7, Description = "CongratsToApprenticeForUpgradePacket")]
	public sealed class 恭喜徒弟升级 : GamePacket
	{
		
		public 恭喜徒弟升级()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 徒弟编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public int 祝贺等级;
	}
}
