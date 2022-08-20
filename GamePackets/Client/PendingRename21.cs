using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 525, Length = 40, Description = "上传社交信息(已屏蔽)")]
	public sealed class 上传社交信息 : GamePacket
	{
		
		public 上传社交信息()
		{
			
			
		}
	}
}
