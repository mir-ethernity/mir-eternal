
namespace GameServer
{

    public sealed class NoobSupport : GMCommand
    {

        public override ExecutionWay ExecutionWay
        {
            get
            {
                return ExecutionWay.只能后台执行;
            }
        }


        public override void Execute()
        {
            Config.NoobLevel = 扶持等级;
            SEnvir.AddCommandLog(string.Format("<= @{0} command has been executed, current support level: {1}", base.GetType().Name, Config.NoobLevel));
        }


        public NoobSupport()
        {


        }


        [FieldAttribute(0, Position = 0)]
        public byte 扶持等级;
    }
}
