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
    public class UValueStrProperty : UValueProperty
    {
        public string Text { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            Text = stream.ReadText();
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.UW.WriteText(Text);
        }

        public override string ToString()
        {
            return Text;
        }
    }
}