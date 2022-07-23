using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 518, 长度 = 45, 注释 = "AddMembersToTeamPacket")]
	public sealed class AddMembersToTeamPacket : GamePacket
	{
		
		public AddMembersToTeamPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 10, 长度 = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(下标 = 42, 长度 = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(下标 = 43, 长度 = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(下标 = 44, 长度 = 1)]
		public byte 在线离线;
	}
}
