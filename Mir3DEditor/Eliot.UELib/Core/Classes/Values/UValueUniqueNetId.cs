using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueUniqueNetId : UValueProperty
    {
        public Guid A { get; set; }
        public Guid B { get; set; }
        public Guid C { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            A = stream.ReadGuid();
            B = stream.ReadGuid();
            C = stream.ReadGuid();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(A);
            stream.Write(B);
            stream.Write(C);
        }

        public override string ToString()
        {
            return $"A:{A},B:{B},C:{C}";
        }
    }
}
