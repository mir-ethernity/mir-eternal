using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 116, Length = 21, Description = "添加BUFF", Broadcast = true)]
	public sealed class ObjectAddStatePacket : GamePacket
	{
		
		public ObjectAddStatePacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int SourceObjectId;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort BuffId;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 4)]
		public int BuffIndex;

		
		[WrappingFieldAttribute(SubScript = 12, Length = 4)]
		public int TargetObjectId;

		
		[WrappingFieldAttribute(SubScript = 16, Length = 4)]
		public int Duration;

		
		[WrappingFieldAttribute(SubScript = 20, Length = 1)]
		public byte BuffLayers;
	}
}
