using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UELib.Annotations;
using UELib.Core.Types;
using UELib.Types;
using UELib.UnrealScript;

namespace UELib.Core
{
    public class UValueStructProperty : UValueProperty
    {
        public byte[] Raw { get; private set; }

        public List<UDefaultProperty> Properties { get; set; } = new List<UDefaultProperty>();

        public override void Deserialize(IUnrealStream stream)
        {
            var maxPosition = stream.Position + Size;

            while (maxPosition > stream.Position)
            {
                var tag = new UDefaultProperty(Property._Container, Property._Outer);
                if (tag.Deserialize())
                    Properties.Add(tag);
                else
                    break;
            }
        }

        public override void Serialize(IUnrealStream stream)
        {
            foreach (var prop in Properties)
                prop.Serialize(stream);
            stream.WriteNone();
        }

        public override string ToString()
        {
            var info = Properties.Select(x => $"{x.Name}={x.GoodValue}").ToArray();
            return string.Join(", ", info);
        }
    }
}