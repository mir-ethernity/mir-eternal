using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 141, 长度 = 4, 注释 = "武器幸运变化")]
	public sealed class 武器幸运变化 : GamePacket
	{
		
		public 武器幸运变化()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public sbyte 幸运变化;
	}
}
