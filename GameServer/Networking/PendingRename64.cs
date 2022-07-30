using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 556, 长度 = 6, 注释 = "玩家申请收徒")]
	public sealed class 申请收徒应答 : GamePacket
	{
		
		public 申请收徒应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
