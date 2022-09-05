using System;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Client, Id = 114, Length = 10, Description = "玩家完成任务")]
	public sealed class PlayerCompleteQuestPacket : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int QuestId;

		[WrappingField(SubScript = 6, Length = 4)]
		public int Unknown;
	}
}
