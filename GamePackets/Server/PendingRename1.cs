using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 289, 长度 = 3, 注释 = "玩家每日签到")]
	public sealed class 每日签到应答 : GamePacket
	{
		
		public 每日签到应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 签到次数;
	}
}
