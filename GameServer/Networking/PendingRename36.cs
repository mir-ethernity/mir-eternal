using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 117, 长度 = 6, 注释 = "点击Npc开始与之对话")]
	public sealed class 开始Npcc对话 : GamePacket
	{
		
		public 开始Npcc对话()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;
	}
}
