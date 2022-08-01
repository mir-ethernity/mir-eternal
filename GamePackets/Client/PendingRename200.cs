using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 111, 长度 = 6, 注释 = "打开角色摊位")]
	public sealed class 打开角色摊位 : GamePacket
	{
		
		public 打开角色摊位()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
