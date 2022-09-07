using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UELib.Core.Types;

namespace UELib.Core.Classes.Values
{
    public class UValueColor : UValueProperty
    {
        public UColor Color { get; private set; }

        public override void Deserialize(IUnrealStream stream)
        {
            Color = stream.ReadAtomicStruct<UColor>();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.WriteAtomicStruct(Color);
        }

        public override string ToString()
        {
            return Color.ToString();
        }
    }
}
