using NAudio.Wave;
using NVorbis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes
{
    [UnrealRegisterClass]
    public class USoundNodeWave : UCompressionBase
    {
        public byte[] Unknown1 { get; private set; }
        public byte[] BufferSound { get; set; }

        protected override void Deserialize()
        {
            base.Deserialize();

            var data = ProcessCompressedBulkData();
            var buff = data.Decompress();
            BufferSound = buff;
        }
    }
}
