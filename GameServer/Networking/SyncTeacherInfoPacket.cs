using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 25, 长度 = 8, 注释 = "SyncTeacherInfoPacket")]
	public sealed class SyncTeacherInfoPacket : GamePacket
	{
		
		public SyncTeacherInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(下标 = 2, 长度 = 4)]
		public int 限制时间;

		
		[WrappingFieldAttribute(下标 = 6, 长度 = 1)]
		public byte 师门参数;

		
		[WrappingFieldAttribute(下标 = 7, 长度 = 1)]
		public byte 师门推送;
	}
}
