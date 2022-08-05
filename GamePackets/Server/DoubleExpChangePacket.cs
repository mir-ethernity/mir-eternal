using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 76, 长度 = 6, 注释 = "DoubleExpChangePacket")]
	public sealed class DoubleExpChangePacket : GamePacket
	{
		
		public DoubleExpChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int DoubleExp;
	}
}
