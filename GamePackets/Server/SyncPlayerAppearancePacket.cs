using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 64, Length = 133, Description = "SyncPlayerAppearancePacket")]
	public sealed class SyncPlayerAppearancePacket : GamePacket
	{
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int ObjectId;

		[WrappingField(SubScript = 6, Length = 1)]
		public byte Unknown1;
		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte Race;
		
		[WrappingFieldAttribute(SubScript = 8, Length = 1)]
		public byte Gender;
		
		[WrappingFieldAttribute(SubScript = 9, Length = 1)]
		public byte HairType;
		
		[WrappingFieldAttribute(SubScript = 10, Length = 1)]
		public byte HairColor;
		
		[WrappingFieldAttribute(SubScript = 11, Length = 1)]
		public byte Face;

		[WrappingFieldAttribute(SubScript = 12, Length = 1)]
		public byte Unknown2;

		[WrappingFieldAttribute(SubScript = 13, Length = 1)]
		public byte Unknown3;

		[WrappingFieldAttribute(SubScript = 14, Length = 1)]
		public int PKLevel;

		[WrappingFieldAttribute(SubScript = 15, Length = 4)]
		public byte[] Unknown4 = new byte[4];

		[WrappingFieldAttribute(SubScript = 19, Length = 1)]
		public byte WeaponType;
		
		[WrappingFieldAttribute(SubScript = 20, Length = 4)]
		public int WeaponBody;
		
		[WrappingFieldAttribute(SubScript = 24, Length = 4)]
		public int Clothes;
		
		[WrappingFieldAttribute(SubScript = 28, Length = 4)]
		public int Cloak;
		
		[WrappingFieldAttribute(SubScript = 32, Length = 4)]
		public int CurrentHP;
		
		[WrappingFieldAttribute(SubScript = 36, Length = 4)]
		public int CurrentMP;

		[WrappingFieldAttribute(SubScript = 40, Length = 6)]
		public byte[] Unknown5 = new byte[6];
		
		[WrappingFieldAttribute(SubScript = 46, Length = 4)]
		public int AppearanceTime;
		
		[WrappingFieldAttribute(SubScript = 50, Length = 1)]
		public byte StallStatus;
		
		[WrappingFieldAttribute(SubScript = 51, Length = 0)]
		public string BoothName;
		
		[WrappingFieldAttribute(SubScript = 84, Length = 45)]
		public string Name;
		
		[WrappingFieldAttribute(SubScript = 118, Length = 4)]
		public int GuildId;
	}
}
