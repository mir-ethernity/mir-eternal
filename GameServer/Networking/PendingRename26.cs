using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1006, 长度 = 6, 注释 = "删除角色回应")]
	public sealed class 删除角色应答 : GamePacket
	{
		
		public 删除角色应答()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
