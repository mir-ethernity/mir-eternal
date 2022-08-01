using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 539, 长度 = 6, 注释 = "同意收徒申请")]
	public sealed class 同意收徒申请 : GamePacket
	{
		
		public 同意收徒申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;
	}
}
