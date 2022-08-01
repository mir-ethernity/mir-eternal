using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 536, 长度 = 6, 注释 = "RefusedApplyApprenticeshipPacket")]
	public sealed class RefusedApplyApprenticeshipPacket : GamePacket
	{
		
		public RefusedApplyApprenticeshipPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
