using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 568, 长度 = 6, 注释 = "RemoveApprenticePromptPacket")]
	public sealed class RemoveApprenticePromptPacket : GamePacket
	{
		
		public RemoveApprenticePromptPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
