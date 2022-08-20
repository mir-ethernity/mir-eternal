using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 81, Length = 13, Description = "发送PK的结果")]
	public sealed class 同步对战结果 : GamePacket
	{
		
		public 同步对战结果()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 击杀方式;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 胜方编号;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 4)]
		public int 败方编号;

		
		[WrappingFieldAttribute(SubScript = 11, Length = 2)]
		public ushort PK值惩罚;
	}
}
