using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 213, 长度 = 7, 注释 = "玩家获得称号")]
	public sealed class ObtainTitlePacket : GamePacket
	{
		
		public ObtainTitlePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte Id;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int ExpireTime;
	}
}
