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
    public class UValueByteProperty : UValueProperty
    {
        public UName EnumValue { get; set; } = null;
        public byte? ByteValue { get; set; } = null;

        public override void Deserialize(IUnrealStream stream)
        {
            if (Size == 8)
            {
                EnumValue = stream.ReadNameReference();
            }
            else
            {
                ByteValue = stream.ReadByte();
            }
        }

        public override void Serialize(IUnrealStream stream)
        {
            if (EnumValue != null)
                stream.Write(EnumValue);
            else
                stream.Write(ByteValue ?? 0);
        }

        public override string ToString()
        {
            if (Property.EnumName != null)
                return $"{Property.EnumName}.{EnumValue}";
            return (ByteValue ?? 0).ToString();
        }
    }
}