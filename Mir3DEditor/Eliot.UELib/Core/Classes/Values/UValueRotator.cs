using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueRotator : UValueProperty
    {
        public int Pitch { get; set; }
        public int Yaw { get; set; }
        public int Roll { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            Pitch = stream.ReadInt32();
            Yaw = stream.ReadInt32();
            Roll = stream.ReadInt32();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(Pitch);
            stream.Write(Yaw);
            stream.Write(Roll);
        }

        public override string ToString()
        {
            return $"Pitch:{Pitch},Yaw:{Yaw},Roll:{Roll}";
        }
    }
}
