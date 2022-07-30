using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 117, 长度 = 10, 注释 = "移除BUFF")]
	public sealed class ObjectRemovalStatusPacket : GamePacket
	{
		
		public ObjectRemovalStatusPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int Buff索引;
	}
}
