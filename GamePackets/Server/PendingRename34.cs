using System;
using System.Drawing;

namespace GameServer.Networking
{
	
	[PacketInfo(Source = PacketSource.Server, Id = 94, Length = 25, Description = "StartToReleaseSkillPacket", Broadcast = true)]
	public sealed class StartToReleaseSkillPacket : GamePacket
	{
		[WrappingField(SubScript = 2, Length = 4)]
		public int ObjectId;
		
		[WrappingField(SubScript = 6, Length = 2)]
		public ushort SkillId;
		
		[WrappingField(SubScript = 8, Length = 1)]
		public byte SkillLevel;
		
		[WrappingField(SubScript = 9, Length = 1)]
		public byte SkillInscription;
		
		[WrappingField(SubScript = 10, Length = 4)]
		public int TargetId;
		
		[WrappingField(SubScript = 14, Length = 4)]
		public Point AnchorCoords;
		
		[WrappingField(SubScript = 18, Length = 2)]
		public ushort AnchorHeight;

		[WrappingField(SubScript = 20, Length = 2)]
		public ushort AccelerationRate1 = 10000;
		
		[WrappingField(SubScript = 22, Length = 2)]
		public ushort AccelerationRate2 = 10000;
		
		[WrappingField(SubScript = 24, Length = 1)]
		public byte ActionId;
	}
}
