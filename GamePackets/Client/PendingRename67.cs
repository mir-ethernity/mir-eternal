using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Client, 编号 = 582, 长度 = 6, 注释 = "申请解除Hostility")]
	public sealed class 申请解除Hostility : GamePacket
	{
		
		public 申请解除Hostility()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 行会编号;
	}
}
