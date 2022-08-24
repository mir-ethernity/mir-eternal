using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Client, Id = 113, Length = 14, Description = "ClickNpcDialogPacket")]
	public sealed class ClickNpcDialogPacket : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int 对象编号;

		[WrappingField(SubScript = 6, Length = 4)]
		public int QuestId;

		[WrappingField(SubScript = 10, Length = 4)]
		public int Unknown;
	}
}
