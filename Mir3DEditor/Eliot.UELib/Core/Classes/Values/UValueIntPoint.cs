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
    public class UValueIntPoint : UValueProperty
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            X = stream.ReadInt32();
            Y = stream.ReadInt32();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(X);
            stream.Write(Y);
        }

        public override string ToString()
        {
            return $"X: {X}, Y:{Y}";
        }
    }
}