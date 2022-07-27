using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.服务器, 编号 = 1007, 长度 = 6, 注释 = "GetBackCharacterCommand回应")]
	public sealed class GetBackCharacterAnswersPacket : GamePacket
	{
		
		public GetBackCharacterAnswersPacket()
		{
			
			
		}

		
		[WrappingFieldAttribute(SubScript = 2, Length = 4)]
		public int 角色编号;
	}
}
