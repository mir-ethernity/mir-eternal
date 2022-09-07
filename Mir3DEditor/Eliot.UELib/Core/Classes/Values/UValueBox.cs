using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueBox : UValueProperty
    {
        public UValueVector Min { get; set; }
        public UValueVector Max { get; set; }
        public byte IsValid { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            var pos = (int)stream.Position;
            Min = (UValueVector)UValuePropertyFactory.Create(Property, stream, "Vector", 12);
            Max = (UValueVector)UValuePropertyFactory.Create(Property, stream, "Vector", 12);
            IsValid = stream.ReadByte();
        }

        public override void Serialize(IUnrealStream stream)
        {
            Min.Serialize(stream);
            Max.Serialize(stream);
            stream.Write(IsValid);
        }

        public override string ToString()
        {
            return $"Min:{Min},Max:{Max}";
        }
    }
}
