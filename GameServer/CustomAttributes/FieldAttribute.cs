using System;

namespace GameServer
{
	
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class FieldAttribute : Attribute
	{
		
		public FieldAttribute(int 排序 = 0)
		{
			
			
			this.排序 = 排序;
		}

		
		public int 排序;
	}
}
