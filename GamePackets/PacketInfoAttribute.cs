using System;

namespace GameServer
{
	
	[AttributeUsage(AttributeTargets.Class)]
	public class PacketInfoAttribute : Attribute
	{
		public PacketSource Source;
		
		public ushort Id;
		
		public ushort Length;
		
		public string Description;

		public bool NoDebug;

		public bool Broadcast;

		public bool UseIntSize = false;
	}
}
