using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 608, 长度 = 38, 注释 = "AddDiplomaticAnnouncementPacket")]
	public sealed class AddDiplomaticAnnouncementPacket : GamePacket
	{
		
		public AddDiplomaticAnnouncementPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 外交类型;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 外交时间;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 1)]
		public byte 行会等级;

		
		[WrappingFieldAttribute(下标 = 12, 长度 = 1)]
		public byte 行会人数;

		
		[WrappingFieldAttribute(下标 = 13, 长度 = 25)]
		public string 行会名字;
	}
}
