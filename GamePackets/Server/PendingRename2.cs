using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(Source = PacketSource.Server, Id = 99, Length = 5, Description = "释放完成, 可以释放下一个技能")]
	public sealed class 技能释放完成 : GamePacket
	{
		
		public 技能释放完成()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 2)]
		public ushort SkillId;

		
		[WrappingFieldAttribute(SubScript = 4, Length = 1)]
		public byte 动作编号;
	}
}
