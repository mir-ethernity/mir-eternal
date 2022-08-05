using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 556, 长度 = 31, 注释 = "申请加入行会")]
	public sealed class 申请加入行会 : GamePacket
	{
		
		public 申请加入行会()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 25)]
		public string GuildName;
	}
}
