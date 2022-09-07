using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueFloatProperty : UValueProperty
    {
        public float Number { get; private set; }

        public override void Deserialize(IUnrealStream stream)
        {
            Number = stream.ReadFloat();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(Number);
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}
