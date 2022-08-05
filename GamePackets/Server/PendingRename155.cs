using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 513, 长度 = 66, 注释 = "同步角色信息")]
	public sealed class 同步角色信息 : GamePacket
	{
		
		public 同步角色信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(SubScript = 38, Length = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(SubScript = 39, Length = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(SubScript = 40, Length = 1)]
		public byte 会员等级;

		
		[WrappingFieldAttribute(SubScript = 41, Length = 25)]
		public string GuildName;
	}
}
