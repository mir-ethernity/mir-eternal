using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib.Core.Classes.Values
{
    public class UValueArrayProperty : UValueProperty
    {
        public UValueProperty[] Array { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            var position = stream.Position;
            int arraySize = stream.ReadIndex();
            Array = new UValueProperty[arraySize];

            if (arraySize == 0)
                return;

            var buffLength = (int)(stream.Length - position - 4);

            var expectedEqualsItemSize = (Size - 4) / arraySize;

            var propertyType = "StructProperty";
            var outer = Property._Outer ?? Property._Container.Class as UStruct;
            var foundSpecificType = false;

            for (var structField = outer; structField != null; structField = structField.Super as UStruct)
            {
                var nextField = outer.Children;

                while (nextField != null)
                {
                    if (nextField is UProperty && nextField.Name == Property.Name)
                    {
                        if (nextField is UArrayProperty arrayField && arrayField.InnerProperty != null)
                        {
                            propertyType = arrayField.InnerProperty.Type.ToString();
                            foundSpecificType = true;
                            break;
                        }
                    }
                    nextField = nextField.NextField;
                }

                if (foundSpecificType) break;
            }

            if (!foundSpecificType)
            {
                if (expectedEqualsItemSize == 0) expectedEqualsItemSize = 16;
                if (expectedEqualsItemSize == 4) propertyType = "IntProperty";
                else if (expectedEqualsItemSize == 16) propertyType = "Guid";
                else if (expectedEqualsItemSize == 8) propertyType = "Name";
                else if (expectedEqualsItemSize < 16) propertyType = "Unknown";
            }

            for (var i = 0; i < arraySize; i++)
            {
                //var arrayItemPos = stream.Position;
                //var arrayItemSize = (int)(Size - (arrayItemPos - position));
                //if (arrayItemSize <= 0) break;
                Array[i] = UValuePropertyFactory.Create(Property, stream, propertyType, expectedEqualsItemSize);
            }
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.WriteIndex(Array.Length);
            for (var i = 0; i < Array.Length; i++)
                Array[i].Serialize(stream);
        }

        public override string ToString()
        {
            var items = Array.Select((x, i) => $"[{i}] {x}").ToArray();

            return string.Join(Environment.NewLine, items);
        }
    }
}
