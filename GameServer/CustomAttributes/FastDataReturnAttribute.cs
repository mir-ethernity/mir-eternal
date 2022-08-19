using System;

namespace GameServer
{
	
	[AttributeUsage(AttributeTargets.Class)]
	public class FastDataReturnAttribute : Attribute
	{
		
		public FastDataReturnAttribute()
		{
			
			
		}

		
		public string SearchFilder;
	}
}
