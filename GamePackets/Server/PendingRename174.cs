using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 656, 长度 = 6, 注释 = "同步Ingots")]
	public sealed class 同步Ingots : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int Ingots;
	}
}
