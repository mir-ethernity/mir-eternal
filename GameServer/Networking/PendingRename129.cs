using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 255, 长度 = 6, 注释 = "OrdinaryInscriptionRefinementPacket")]
	public sealed class 玩家普通洗练 : GamePacket
	{
		
		public 玩家普通洗练()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 2)]
		public ushort 铭文位一;

		
		[WrappingFieldAttribute(下标 = 4, 长度 = 2)]
		public ushort 铭文位二;
	}
}
