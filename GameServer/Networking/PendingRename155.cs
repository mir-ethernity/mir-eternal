using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 513, 长度 = 66, 注释 = "同步角色信息")]
	public sealed class 同步角色信息 : GamePacket
	{
		
		public 同步角色信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 32)]
		public string 对象名字;

		
		[WrappingFieldAttribute(下标 = 38, 长度 = 1)]
		public byte 对象职业;

		
		[WrappingFieldAttribute(下标 = 39, 长度 = 1)]
		public byte 对象性别;

		
		[WrappingFieldAttribute(下标 = 40, 长度 = 1)]
		public byte 会员等级;

		
		[WrappingFieldAttribute(下标 = 41, 长度 = 25)]
		public string 行会名字;
	}
}
