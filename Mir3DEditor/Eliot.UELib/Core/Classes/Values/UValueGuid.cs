using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueGuid : UValueProperty
    {
        public Guid GUID { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            GUID = stream.ReadGuid();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(GUID);
        }

        public override string ToString()
        {
            return GUID.ToString("N");
        }
    }
}
