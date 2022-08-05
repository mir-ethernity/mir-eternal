using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 522, 长度 = 51, 注释 = "同步队员信息")]
	public sealed class 同步队员信息 : GamePacket
	{
		
		public 同步队员信息()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 队伍编号;

		
		[WrappingFieldAttribute(SubScript = 6, Length = 4)]
		public int 对象编号;

		
		[WrappingFieldAttribute(SubScript = 10, Length = 4)]
		public int 对象等级;

		
		[WrappingFieldAttribute(SubScript = 14, Length = 4)]
		public int MaxPhysicalStrength;

		
		[WrappingFieldAttribute(SubScript = 18, Length = 4)]
		public int MaxMagic2;

		
		[WrappingFieldAttribute(SubScript = 22, Length = 4)]
		public int CurrentStamina;

		
		[WrappingFieldAttribute(SubScript = 26, Length = 4)]
		public int 当前魔力;

		
		[WrappingFieldAttribute(SubScript = 30, Length = 4)]
		public int CurrentMap;

		
		[WrappingFieldAttribute(SubScript = 34, Length = 4)]
		public int 当前线路;

		
		[WrappingFieldAttribute(SubScript = 38, Length = 4)]
		public int 横向坐标;

		
		[WrappingFieldAttribute(SubScript = 42, Length = 4)]
		public int 纵向坐标;

		
		[WrappingFieldAttribute(SubScript = 46, Length = 4)]
		public int 坐标高度;

		
		[WrappingFieldAttribute(SubScript = 50, Length = 4)]
		public byte AttackMode;
	}
}
