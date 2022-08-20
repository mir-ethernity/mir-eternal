using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 253, Length = 3, Description = "玩家镶嵌灵石")]
	public sealed class 成功镶嵌灵石 : GamePacket
	{
		
		public 成功镶嵌灵石()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 灵石状态;
	}
}
