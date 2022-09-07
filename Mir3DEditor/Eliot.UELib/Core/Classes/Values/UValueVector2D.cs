using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueVector2D : UValueProperty
    {
        public float X { get; set; }
        public float Y { get; set; }
        public override void Deserialize(IUnrealStream stream)
        {
            X = stream.ReadFloat();
            Y = stream.ReadFloat();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(X);
            stream.Write(Y);
        }

        public override string ToString()
        {
            return $"X:{X},Y:{Y}";
        }
    }
}
