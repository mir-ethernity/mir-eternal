using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 568, 长度 = 6, 注释 = "RemoveApprenticePromptPacket")]
	public sealed class RemoveApprenticePromptPacket : GamePacket
	{
		
		public RemoveApprenticePromptPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
