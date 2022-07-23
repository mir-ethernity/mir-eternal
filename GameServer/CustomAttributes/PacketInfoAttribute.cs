using System;

namespace GameServer
{
	
	[AttributeUsage(AttributeTargets.Class)]
	public class PacketInfoAttribute : Attribute
	{
		
		public PacketInfoAttribute()
		{
			
			
		}

		
		public PacketSource 来源;

		
		public ushort 编号;

		
		public ushort 长度;

		
		public string 注释;
	}
}
