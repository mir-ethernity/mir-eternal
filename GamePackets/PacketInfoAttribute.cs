using System;

namespace GameServer
{
	
	[AttributeUsage(AttributeTargets.Class)]
	public class PacketInfoAttribute : Attribute
	{
		
		public PacketInfoAttribute()
		{
			
			
		}

		
		public PacketSource Source;

		
		public ushort Id;

		
		public ushort Length;

		
		public string Description;

		public bool NoDebug;

		public bool Broadcast;
	}
}
