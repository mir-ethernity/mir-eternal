using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 251, 长度 = 6, 注释 = "UnblockPlayerPacket")]
	public sealed class UnblockPlayerPacket : GamePacket
	{
		
		public UnblockPlayerPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
