using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueObjectProperty : UValueProperty
    {
        public UObject Obj { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            Obj = stream.ReadObject();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(Obj);
        }

        public override string ToString()
        {
            return Obj != null ? $"{Obj.Name} ({(int)Obj})" : "N/a";
        }
    }
}
