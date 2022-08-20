using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 553, Length = 7, Description = "查看行会列表")]
	public sealed class 查看行会列表 : GamePacket
	{
		
		public 查看行会列表()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 查看方式;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 行会编号;
	}
}
