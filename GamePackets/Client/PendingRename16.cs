using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Client, Id = 1002, Length = 40, Description = "创建角色")]
	public sealed class 客户创建角色 : GamePacket
	{
		
		public 客户创建角色()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 32)]
		public string 名字;

		
		[WrappingFieldAttribute(SubScript = 34, Length = 1)]
		public byte 性别;

		
		[WrappingFieldAttribute(SubScript = 35, Length = 1)]
		public byte 职业;

		
		[WrappingFieldAttribute(SubScript = 36, Length = 1)]
		public byte 发型;

		
		[WrappingFieldAttribute(SubScript = 37, Length = 1)]
		public byte 发色;

		
		[WrappingFieldAttribute(SubScript = 38, Length = 1)]
		public byte 脸型;
	}
}
