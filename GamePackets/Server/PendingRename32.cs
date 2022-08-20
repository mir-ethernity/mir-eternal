using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 119, Length = 6, Description = "提交选项继续NPC对话")]
	public sealed class 继续Npcc对话 : GamePacket
	{
		
		public 继续Npcc对话()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Id;
	}
}
