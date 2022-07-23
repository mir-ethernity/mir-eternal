using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 50, 长度 = 10, 注释 = "对象转动")]
	public sealed class ObjectRotationDirectionPacket : GamePacket
	{
		
		public ObjectRotationDirectionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 2)]
		public ushort 转向耗时;

		
		[WrappingFieldAttribute(下标 = 8, 长度 = 2)]
		public ushort 对象朝向;
	}
}
