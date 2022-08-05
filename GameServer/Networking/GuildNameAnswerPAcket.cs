using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 582, 长度 = 48, 注释 = "查询GuildName")]
	public sealed class GuildNameAnswerPAcket : GamePacket
	{
		
		public GuildNameAnswerPAcket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 25)]
		public string GuildName;

		
		[WrappingFieldAttribute(SubScript = 31, Length = 4)]
		public int 会长编号;

		
		[WrappingFieldAttribute(SubScript = 35, Length = 4)]
		public DateTime 创建时间;

		
		[WrappingFieldAttribute(SubScript = 39, Length = 1)]
		public byte 行会人数;

		
		[WrappingFieldAttribute(SubScript = 40, Length = 1)]
		public byte 行会等级;
	}
}
