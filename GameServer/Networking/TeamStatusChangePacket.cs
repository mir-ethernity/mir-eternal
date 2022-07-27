using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 521, 长度 = 52, 注释 = "TeamStatusChangePacket")]
	public sealed class TeamStatusChangePacket : GamePacket
	{
		
		public TeamStatusChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 队伍名字;

		
		[WrappingFieldAttribute(SubScript = 38, Length = 4)]
		public int 成员上限;

		
		[WrappingFieldAttribute(SubScript = 42, Length = 1)]
		public byte 分配方式;

		
		[WrappingFieldAttribute(SubScript = 44, Length = 4)]
		public int 队长编号;
	}
}
