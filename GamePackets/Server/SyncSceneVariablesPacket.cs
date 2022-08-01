using System;

namespace GameServer.Networking
{
	
	[PacketInfoAttribute(来源 = PacketSource.Server, 编号 = 184, 长度 = 0, 注释 = "SyncSceneVariablesPacket")]
	public sealed class SyncSceneVariablesPacket : GamePacket
	{
		
		public SyncSceneVariablesPacket()
		{
			
			
		}
	}
}
