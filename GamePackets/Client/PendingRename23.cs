using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 137, Length = 0, Description = "上传游戏设置")]
	public sealed class 上传游戏设置 : GamePacket
	{
		
		public 上传游戏设置()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 0)]
		public byte[] 字节描述;
	}
}
