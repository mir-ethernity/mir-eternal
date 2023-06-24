using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueName : UValueProperty
    {
        public UName Name { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            Name = stream.ReadNameReference();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
