using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 117, 长度 = 6, 注释 = "点击Npc开始与之对话")]
	public sealed class 开始Npcc对话 : GamePacket
	{
		
		public 开始Npcc对话()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
