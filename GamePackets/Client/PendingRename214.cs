using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 583, 长度 = 7, 注释 = "处理解敌申请")]
	public sealed class 处理解敌申请 : GamePacket
	{
		
		public 处理解敌申请()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 1)]
		public byte 回应类型;

		
		[WrappingFieldAttribute(SubScript = 3, Length = 4)]
		public int 行会编号;
	}
}
