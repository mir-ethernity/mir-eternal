using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 119, 长度 = 6, 注释 = "提交选项继续NPC对话")]
	public sealed class 继续Npcc对话 : GamePacket
	{
		
		public 继续Npcc对话()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Id;
	}
}
