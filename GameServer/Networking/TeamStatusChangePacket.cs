using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 521, 长度 = 52, 注释 = "TeamStatusChangePacket")]
	public sealed class TeamStatusChangePacket : GamePacket
	{
		
		public TeamStatusChangePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 队伍名字;

		
		[WrappingFieldAttribute(下标 = 38, 长度 = 4)]
		public int 成员上限;

		
		[WrappingFieldAttribute(下标 = 42, 长度 = 1)]
		public byte 分配方式;

		
		[WrappingFieldAttribute(下标 = 44, 长度 = 4)]
		public int 队长编号;
	}
}
