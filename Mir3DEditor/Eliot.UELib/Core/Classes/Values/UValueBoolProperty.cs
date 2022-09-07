using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UELib.Annotations;
using UELib.Core.Types;
using UELib.Types;
using UELib.UnrealScript;

namespace UELib.Core
{
    public class UValueBoolProperty : UValueProperty
    {
        public bool Flag { get; private set; }
        public override void Deserialize(IUnrealStream stream)
        {
            Flag = Property.BoolValue ?? false;
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write((byte)(Flag ? 1 : 0));
        }

        public override string ToString()
        {
            return Flag ? "true" : "false";
        }
    }
}