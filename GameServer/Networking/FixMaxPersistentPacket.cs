using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 343, 长度 = 3, 注释 = "FixMaxPersistentPacket")]
	public sealed class FixMaxPersistentPacket : GamePacket
	{
		
		public FixMaxPersistentPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public bool 修复失败;
	}
}
