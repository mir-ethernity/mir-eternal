using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.客户端, 编号 = 176, 长度 = 0, 注释 = "DistributeGuildBenefitsPacket")]
	public sealed class DistributeGuildBenefitsPacket : GamePacket
	{
		
		public DistributeGuildBenefitsPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 1)]
		public byte 发放方式;

		
		[WrappingFieldAttribute(下标 = 5, 长度 = 4)]
		public int 发放总额;

		
		[WrappingFieldAttribute(下标 = 13, 长度 = 2)]
		public ushort 发放人数;

		
		[WrappingFieldAttribute(下标 = 15, 长度 = 0)]
		public int 对象编号;
	}
}
