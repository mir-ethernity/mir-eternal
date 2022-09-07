using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueQuat : UValueProperty
    {
        public float W { get; set; }
        public UValueVector V { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            W = stream.ReadFloat();
            V = (UValueVector)UValuePropertyFactory.Create(Property, stream, "Vector", 12);
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(W);
            V.Serialize(stream);
        }

        public override string ToString()
        {
            return $"W:{W},V:{V}";
        }
    }
}
