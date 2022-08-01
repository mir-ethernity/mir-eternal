using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 526, 长度 = 43, 注释 = "查询对象队伍信息回应")]
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
