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

    public abstract class UValueProperty
    {
        public UDefaultProperty Property { get; set; }
        public int Size { get; set; }
        public byte[] OriginalBuffer { get; internal set; }

        public abstract void Deserialize(IUnrealStream stream);
        public abstract void Serialize(IUnrealStream stream);
    }
}