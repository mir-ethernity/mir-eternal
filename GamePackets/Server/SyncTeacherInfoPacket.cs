using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 25, 长度 = 8, 注释 = "SyncTeacherInfoPacket")]
	public sealed class SyncTeacherInfoPacket : GamePacket
	{
		
		public SyncTeacherInfoPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 限制时间;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 1)]
		public byte 师门参数;

		
		[WrappingFieldAttribute(SubScript = 7, Length = 1)]
		public byte 师门推送;
	}
}
