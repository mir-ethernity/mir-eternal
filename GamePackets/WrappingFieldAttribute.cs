using System;

namespace GameServer
{
	
	[AttributeUsage(AttributeTargets.Field)]
	public class WrappingFieldAttribute : Attribute
	{
		
		public WrappingFieldAttribute()
		{
			
			
		}

		
		public ushort SubScript;

		
		public ushort Length;

		
		public bool Reverse;
	}
}
