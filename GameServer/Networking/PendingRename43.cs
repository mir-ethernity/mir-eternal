using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 265, 长度 = 3, 注释 = "确认替换铭文")]
	public sealed class 确认替换铭文 : GamePacket
	{
		
		public 确认替换铭文()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 1)]
		public bool 确定替换;
	}
}
