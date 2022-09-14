namespace GameServer.PlayerCommands
{
    public class PlayerCommandResetQuests : PlayerCommand
    {
        public override void Execute()
        {
            Player.CharacterData.Quests.Clear();

            Player.SendMessage($"You need logout to restart quests");
        }
    }
}
