using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 57, 长度 = 55, 注释 = "复活信息(无此封包不会弹出复活框)")]
	public sealed class SendResurrectionMessagePacket : GamePacket
	{
		
		public SendResurrectionMessagePacket()
		{
			
			this.复活描述 = new byte[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				161,
				134,
				1,
				0,
				1,
				0,
				0,
				0,
				2,
				1,
				0,
				0,
				0,
				100,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			
		}

		
		public byte[] 复活描述;
	}
}
