using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 264, 长度 = 16, 注释 = "高级铭文洗练")]
	public sealed class 玩家高级洗练 : GamePacket
	{
		
		public 玩家高级洗练()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort 洗练结果;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 2)]
		public ushort 铭文位一;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 铭文位二;
	}
}
