using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 264, Length = 16, Description = "高级铭文洗练")]
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
