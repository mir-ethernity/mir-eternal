using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 570, 长度 = 7, 注释 = "CongratsToApprenticeForUpgradePacket")]
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
