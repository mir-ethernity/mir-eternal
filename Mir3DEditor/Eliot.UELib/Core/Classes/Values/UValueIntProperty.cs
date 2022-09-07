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
    public class UValueIntProperty : UValueProperty
    {
        public int Number { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            Number = stream.ReadInt32();
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