using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 526, Length = 43, Description = "查询对象队伍信息回应")]
	public sealed class 查询队伍应答 : GamePacket
	{
		
		public 查询队伍应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 队伍名字;

		
		[WrappingFieldAttribute(SubScript = 39, Length = 4)]
		public int 队长编号;
	}
}
