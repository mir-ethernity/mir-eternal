using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Client, Id = 18, Length = 6, Description = "CharacterWalk")]
	public sealed class CharacterWalkPacket : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public Point Location;
	}
}
