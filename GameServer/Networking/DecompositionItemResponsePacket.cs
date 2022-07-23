using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 259, 长度 = 31, 注释 = "DecompositionItemResponsePacket")]
	public sealed class DecompositionItemResponsePacket : GamePacket
	{
		
		public DecompositionItemResponsePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public byte 分解数量;

		
		[WrappingFieldAttribute(下标 = 3, 长度 = 4)]
		public int 分解物品;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 4)]
		public int 分解物一;

		
		[WrappingFieldAttribute(下标 = 11, 长度 = 4)]
		public int 分解物二;

		
		[WrappingFieldAttribute(下标 = 15, 长度 = 4)]
		public int 分解物三;

		
		[WrappingFieldAttribute(下标 = 19, 长度 = 4)]
		public int 物品数一;

		
		[WrappingFieldAttribute(下标 = 23, 长度 = 4)]
		public int 物品数二;

		
		[WrappingFieldAttribute(下标 = 27, 长度 = 4)]
		public int 物品数三;
	}
}
