using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 253, 长度 = 3, 注释 = "玩家镶嵌灵石")]
	public sealed class 成功镶嵌灵石 : GamePacket
	{
		
		public 成功镶嵌灵石()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 灵石状态;
	}
}
