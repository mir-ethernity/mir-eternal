using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueMatrix : UValueProperty
    {
        public UValuePlane X { get; set; }
        public UValuePlane Y { get; set; }
        public UValuePlane Z { get; set; }
        public UValuePlane W { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            X = (UValuePlane)UValuePropertyFactory.Create(Property, stream, "Plane", 16);
            Y = (UValuePlane)UValuePropertyFactory.Create(Property, stream, "Plane", 16);
            Z = (UValuePlane)UValuePropertyFactory.Create(Property, stream, "Plane", 16);
            W = (UValuePlane)UValuePropertyFactory.Create(Property, stream, "Plane", 16);
        }

        public override void Serialize(IUnrealStream stream)
        {
            X.Serialize(stream);
            Y.Serialize(stream);
            Z.Serialize(stream);
            W.Serialize(stream);
        }

        public override string ToString()
        {
            return $"X:{X},Y:{Y},Z:{Z},W:{W}";
        }
    }
}
