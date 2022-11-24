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
    public static class UValuePropertyFactory
    {
        private static Dictionary<string, Type> _types;

        static UValuePropertyFactory()
        {
            _types = typeof(UValueProperty)
                .Assembly.GetExportedTypes()
                .Where(x => typeof(UValueProperty).IsAssignableFrom(x))
                .ToDictionary(x => x.Name.Substring(6));
        }

        public static bool IsKnownType(string name) => _types.ContainsKey(name);

        public static UValueProperty Create(UDefaultProperty property, IUnrealStream stream, string type, int size)
        {
            UValueProperty value;
            if (_types.ContainsKey(type))
                value = (UValueProperty)Activator.CreateInstance(_types[type]);
            else
                value = new UValueUnknownProperty();

            var pos = stream.Position;
            var raw = new byte[size];

            stream.Read(raw, 0, size);
            stream.Seek(pos, System.IO.SeekOrigin.Begin);

            value.OriginalBuffer = raw;
            value.Property = property;
            value.Size = size;
            
            value.Deserialize(stream);

            return value;
        }
    }
}