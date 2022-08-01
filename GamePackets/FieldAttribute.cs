using System;

namespace GameServer
{
	
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class FieldAttribute : Attribute
	{
		public FieldAttribute(int position = 0)
		{
			Position = position;
		}
		
		public int Position;

		public bool IsOptional { get; set; }
	}
}
