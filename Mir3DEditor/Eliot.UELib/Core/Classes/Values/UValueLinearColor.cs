using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueLinearColor : UValueProperty
    {
        public float R { get; private set; }
        public float G { get; private set; }
        public float B { get; private set; }
        public float A { get; private set; }

        public override void Deserialize(IUnrealStream stream)
        {
            R = stream.ReadFloat();
            G = stream.ReadFloat();
            B = stream.ReadFloat();
            A = stream.ReadFloat();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(R);
            stream.Write(G);
            stream.Write(B);
            stream.Write(A);
        }

        public override string ToString()
        {
            return $"R:{R},G:{G},B:{B},A:{A}";
        }
    }
}
