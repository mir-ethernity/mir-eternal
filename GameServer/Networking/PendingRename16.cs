using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 1002, 长度 = 40, 注释 = "创建角色")]
	public sealed class 客户创建角色 : GamePacket
	{
		
		public 客户创建角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 32)]
		public string 名字;

		
		[WrappingFieldAttribute(下标 = 34, 长度 = 1)]
		public byte 性别;

		
		[WrappingFieldAttribute(下标 = 35, 长度 = 1)]
		public byte 职业;

		
		[WrappingFieldAttribute(下标 = 36, 长度 = 1)]
		public byte 发型;

		
		[WrappingFieldAttribute(下标 = 37, 长度 = 1)]
		public byte 发色;

		
		[WrappingFieldAttribute(下标 = 38, 长度 = 1)]
		public byte 脸型;
	}
}
