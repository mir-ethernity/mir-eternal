using System;

namespace GameServer
{
	
	[AttributeUsage(AttributeTargets.Field)]
	public class WrappingFieldAttribute : Attribute
	{
		
		public WrappingFieldAttribute()
		{
			
			
		}

		
		public ushort 下标;

		
		public ushort 长度;

		
		public bool 反向;
	}
}
