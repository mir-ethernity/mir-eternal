using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes
{
    [UnrealRegisterClass]
    public class UTexture2D : UCompressionBase
    {
        public int MipMapsCount { get; private set; }

        protected override void Deserialize()
        {
            base.Deserialize();

            MipMapsCount = _Buffer.ReadInt32();

            for (var i = 0; i < MipMapsCount; i++)
            {
                ProcessCompressedBulkData();
            }
        }
    }
}
