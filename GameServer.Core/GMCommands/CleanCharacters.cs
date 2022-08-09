using System;
using System.Threading.Tasks;
using GameServer.Data;

namespace GameServer
{

    public sealed class CleanCharacters : GMCommand
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

            GameDataGateway.CleanCharacters(this.MinLevel, this.限制天数);

        }


        [FieldAttribute(0, Position = 0)]
        public int MinLevel;


        [FieldAttribute(0, Position = 1)]
        public int 限制天数;
    }
}
