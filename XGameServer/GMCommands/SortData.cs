using System;
using System.Threading.Tasks;
using GameServer.Data;

namespace GameServer
{

    public sealed class SortData : GMCommand
    {

        public override ExecutionWay ExecutionWay
        {
            get
            {
                return ExecutionWay.只能空闲执行;
            }
        }


        public override void Execute()
        {
            SEnvir.AddCommandLog("<= @" + base.GetType().Name + " Start the command, do not close the window during the execution");
            GameDataGateway.SortDataCommand(true);
        }

    }
}
