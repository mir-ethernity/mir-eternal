using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 50, 长度 = 10, 注释 = "对象转动", Broadcast = true)]
	public sealed class ObjectRotationDirectionPacket : GamePacket
	{
		
		public ObjectRotationDirectionPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 2)]
		public ushort 转向耗时;

		
		[WrappingFieldAttribute(SubScript = 8, Length = 2)]
		public ushort 对象朝向;
	}
}
