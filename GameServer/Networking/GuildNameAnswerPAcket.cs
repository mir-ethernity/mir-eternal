using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 582, 长度 = 48, 注释 = "查询行会名字")]
	public sealed class GuildNameAnswerPAcket : GamePacket
	{
		
		public GuildNameAnswerPAcket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 25)]
		public string 行会名字;

		
		[WrappingFieldAttribute(下标 = 31, 长度 = 4)]
		public int 会长编号;

		
		[WrappingFieldAttribute(下标 = 35, 长度 = 4)]
		public DateTime 创建时间;

		
		[WrappingFieldAttribute(下标 = 39, 长度 = 1)]
		public byte 行会人数;

		
		[WrappingFieldAttribute(下标 = 40, 长度 = 1)]
		public byte 行会等级;
	}
}
