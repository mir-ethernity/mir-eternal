using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using UELib.Annotations;
using UELib.Core.Types;
using UELib.Types;
using UELib.UnrealScript;

namespace UELib.Core
{
    /// <summary>
    /// [Default]Properties values deserializer.
    /// </summary>
    public sealed class UDefaultProperty : IUnrealDecompilable
    {
        [Flags]
        public enum DeserializeFlags : byte
        {
            None = 0x00,
            WithinStruct = 0x01,
            WithinArray = 0x02,
            Complex = WithinStruct | WithinArray,
        }

        private const byte DoNotAppendName = 0x01;
        private const byte ReplaceNameMarker = 0x02;

        private const int V3 = 220;
        // FIXME: Wrong version, naive approach
        private const int VAtomicStructs = V3;
        private const int VEnumName = 633;
        private const int VBoolSizeToOne = 673;

        internal IUnrealStream _Buffer => _Container.Buffer;

        internal readonly UObject _Container;
        internal UStruct _Outer;
        private bool _RecordingEnabled = true;

        internal long _BeginOffset { get; set; }
        private long _ValueOffset { get; set; }
        public byte[] ValueData { get; set; }
        private byte _TempFlags { get; set; }

        #region Serialized Members

        /// <summary>
        /// Name of the UProperty.
        ///
        /// get and private remain to maintain compatibility with UE Explorer
        /// </summary>
        [PublicAPI]
        public UName Name { get; private set; }

        /// <summary>
        /// Name of the UStruct. If type equals StructProperty.
        /// </summary>
        [PublicAPI][CanBeNull] public UName ItemName;

        /// <summary>
        /// Name of the UEnum. If Type equals ByteProperty.
        /// </summary>
        [PublicAPI][CanBeNull] public UName EnumName;

        public UName TypeName { get; private set; }

        /// <summary>
        /// See PropertyType enum in UnrealFlags.cs
        /// </summary>
        [PublicAPI] public PropertyType Type;

        /// <summary>
        /// The stream size of this DefaultProperty.
        /// </summary>
        internal int Size { get; set; }

        /// <summary>
        /// Whether this property is part of an static array, and the index into it
        /// </summary>
        public int ArrayIndex = -1;

        /// <summary>
        /// Value of the UBoolProperty. If Type equals BoolProperty.
        /// </summary>
        public bool? BoolValue;

        public List<UDefaultProperty> ChildrenProperties = new List<UDefaultProperty>();
        public List<UObject> ChildrenObjects = new List<UObject>();

        /// <summary>
        /// The deserialized and decompiled output.
        ///
        /// Serves as a temporary workaround, don't rely on it.
        /// </summary>
        [PublicAPI]
        public string Value { get; set; }
        public byte[] PropData { get; private set; }
        public UValueProperty GoodValue { get; set; }


        #endregion

        #region Constructors

        public override string ToString()
        {
            return $"{Name}={GoodValue}";
        }

        public UDefaultProperty(UObject owner, UStruct outer = null)
        {
            _Container = owner;
            _Outer = (outer ?? _Container as UStruct) ?? _Container.Outer as UStruct;
        }

        /// <returns>True if there are more property tags.</returns>
        public bool Deserialize()
        {
            _BeginOffset = _Buffer.Position;

            if (_BeginOffset >= _Buffer.Length)
                return false;

            if (DeserializeNextTag())
            {
                return false;
            }

            _ValueOffset = _Buffer.Position;

            if (ValueData == null)
            {
                ValueData = new byte[Size];
                _Buffer.Read(ValueData, 0, Size);
                _Buffer.Position = _ValueOffset;
            }

            try
            {
                string valueType = null;

                if (valueType == null)
                    valueType = !string.IsNullOrEmpty(ItemName)
                        ? UValuePropertyFactory.IsKnownType(ItemName) ? ItemName : "StructProperty"
                        : TypeName;

                GoodValue = UValuePropertyFactory.Create(this, _Buffer, valueType, Size);
                Value = DeserializeValue();

                _RecordingEnabled = false;
            }
            catch (Exception ex)
            {
                GoodValue = null;
            }
            finally
            {
                // Even if something goes wrong, we can still skip everything and safely deserialize the next property if any!
                // Note: In some builds @Size is not serialized
                if ((_ValueOffset + Size) != _Buffer.Position)
                {
                    var somethingIsBroken = true;
                }

                if (_ValueOffset + Size > _Buffer.Position)
                    _Buffer.Position = _ValueOffset + Size;
            }

            return true;
        }

        public void Serialize(IUnrealStream stream)
        {
            Size = 0;
            stream.Write(Name);
            stream.Write(TypeName);

            if (TypeName.IsNone()) return;

            var sizePosition = stream.Position;
            stream.Write(0);
            stream.Write(ArrayIndex);

            if (PropData != null) stream.Write(PropData);

            var currentPos = stream.Position;
            if (GoodValue != null)
            {
                var pos = stream.Position;
                try
                {
                    GoodValue.Serialize(stream);
                }
                catch (Exception)
                {
                    stream.Seek(pos, System.IO.SeekOrigin.Begin);
                    stream.Write(ValueData);
                }
            }
            else
                stream.Write(ValueData);

            var endPos = stream.Position;

            if (Type != PropertyType.BoolProperty)
            {
                Size = (int)(endPos - currentPos);
                stream.Seek(sizePosition, System.IO.SeekOrigin.Begin);
                stream.Write(Size);
                stream.Seek(endPos, System.IO.SeekOrigin.Begin);
            }
        }

        /// <returns>True if this is the last tag.</returns>
        private bool DeserializeNextTag()
        {
            Name = _Buffer.ReadNameReference();
            if (Name.IsNone()) return true;

            UName typeName = _Buffer.ReadNameReference();
            TypeName = typeName;
            Enum.TryParse<PropertyType>(typeName, out Type);

            if (TypeName.IsNone()) return false;

            Size = _Buffer.ReadInt32();

            ArrayIndex = _Buffer.ReadInt32();

            DeserializeTypeDataUE3();

            return false;
        }

        private void DeserializeTypeDataUE3()
        {
            byte[] tmp;
            int pos;

            switch (Type)
            {
                case PropertyType.StructProperty:
                    pos = (int)_Buffer.Position;
                    tmp = new byte[8];
                    _Buffer.Read(tmp, 0, 8);
                    _Buffer.Position = pos;
                    PropData = tmp;

                    ItemName = _Buffer.ReadNameReference();
                    break;

                case PropertyType.ByteProperty:
                    if (_Buffer.Version >= VEnumName)
                    {
                        pos = (int)_Buffer.Position;
                        tmp = new byte[8];
                        _Buffer.Read(tmp, 0, 8);
                        _Buffer.Position = pos;
                        PropData = tmp;

                        EnumName = _Buffer.ReadNameReference();
                    }
                    break;

                case PropertyType.BoolProperty:
                    pos = (int)_Buffer.Position;
                    tmp = new byte[_Buffer.Version >= VBoolSizeToOne ? 1 : 4];
                    _Buffer.Read(tmp, 0, tmp.Length);
                    _Buffer.Position = pos;
                    PropData = new byte[0];
                    ValueData = tmp;

                    BoolValue = _Buffer.Version >= VBoolSizeToOne
                        ? _Buffer.ReadByte() > 0
                        : _Buffer.ReadInt32() > 0;
                    break;
            }
        }

        /// <summary>
        /// Deserialize the value of this UPropertyTag instance.
        ///
        /// Note:
        ///     Only call after the whole package has been deserialized!
        /// </summary>
        /// <returns>The deserialized value if any.</returns>
        [PublicAPI]
        public string DeserializeValue(DeserializeFlags deserializeFlags = DeserializeFlags.None)
        {
            if (_Buffer == null)
            {
                _Container.EnsureBuffer();
                if (_Buffer == null) throw new DeserializationException("_Buffer is not initialized!");
            }

            _Buffer.Seek(_ValueOffset, System.IO.SeekOrigin.Begin);
            try
            {
                return DeserializeDefaultPropertyValue(Type, ref deserializeFlags);
            }
            catch (DeserializationException e)
            {
                return e.ToString();
            }
        }

        /// <summary>
        /// Deserialize a default property value of a specified type.
        /// </summary>
        /// <param name="type">Kind of type to try deserialize.</param>
        /// <returns>The deserialized value if any.</returns>
        private string DeserializeDefaultPropertyValue(PropertyType type, ref DeserializeFlags deserializeFlags)
        {
            var orgOuter = _Outer;
            var propertyValue = string.Empty;

            try
            {
                // Deserialize Value
                switch (type)
                {
                    case PropertyType.BoolProperty:
                        {
                            Debug.Assert(BoolValue != null, nameof(BoolValue) + " != null");
                            bool value = BoolValue.Value;
                            if (Size == 1 && _Buffer.Version < V3)
                            {
                                value = _Buffer.ReadByte() > 0;
                            }

                            propertyValue = value ? "true" : "false";
                            break;
                        }

                    case PropertyType.StrProperty:
                        {
                            string value = _Buffer.ReadText();
                            propertyValue = PropertyDisplay.FormatLiteral(value);
                            break;
                        }

                    case PropertyType.NameProperty:
                        {
                            var value = _Buffer.ReadNameReference();
                            propertyValue = value;
                            break;
                        }

                    case PropertyType.IntProperty:
                        {
                            int value = _Buffer.ReadInt32();
                            propertyValue = PropertyDisplay.FormatLiteral(value);
                            break;
                        }

#if BIOSHOCK
                    case PropertyType.QwordProperty:
                        {
                            long value = _Buffer.ReadInt64();
                            propertyValue = PropertyDisplay.FormatLiteral(value);
                            break;
                        }

                    case PropertyType.XWeakReferenceProperty:
                        propertyValue = "/* XWeakReference: (?=" + _Buffer.ReadName() + ",?=" + _Buffer.ReadName() +
                                        ",?=" + _Buffer.ReadByte() + ",?=" + _Buffer.ReadName() + ") */";
                        break;
#endif

                    case PropertyType.FloatProperty:
                        {
                            float value = _Buffer.ReadFloat();
                            propertyValue = PropertyDisplay.FormatLiteral(value);
                            break;
                        }

                    case PropertyType.ByteProperty:
                        {
                            if (_Buffer.Version >= V3 && Size == 8)
                            {
                                string value = _Buffer.ReadName();
                                propertyValue = value;
                                if (_Buffer.Version >= VEnumName) propertyValue = $"{EnumName}.{propertyValue}";
                            }
                            else
                            {
                                byte value = _Buffer.ReadByte();
                                propertyValue = PropertyDisplay.FormatLiteral(value);
                            }

                            break;
                        }

                    case PropertyType.InterfaceProperty:
                    case PropertyType.ComponentProperty:
                    case PropertyType.ObjectProperty:
                        {
                            var constantObject = _Buffer.ReadObject();
                            ChildrenObjects.Add(constantObject);
                            if (constantObject != null)
                            {
                                var inline = false;
                                // If true, object is an archetype or subobject.
                                if (constantObject.Outer == _Container &&
                                    (deserializeFlags & DeserializeFlags.WithinStruct) == 0)
                                {
                                    // Unknown objects are only deserialized on demand.
                                    constantObject.BeginDeserializing();
                                    if (constantObject.Properties != null && constantObject.Properties.Count > 0)
                                    {
                                        inline = true;
                                        propertyValue = constantObject.Decompile() + "\r\n" + UDecompilingState.Tabs;

                                        _TempFlags |= DoNotAppendName;
                                        if ((deserializeFlags & DeserializeFlags.WithinArray) != 0)
                                        {
                                            _TempFlags |= ReplaceNameMarker;
                                            propertyValue += $"%ARRAYNAME%={constantObject.Name}";
                                        }
                                        else
                                        {
                                            propertyValue += $"{Name}={constantObject.Name}";
                                        }
                                    }
                                }

                                if (!inline)
                                    // =CLASS'Package.Group(s)+.Name'
                                    propertyValue = $"{constantObject.GetClassName()}\'{constantObject.GetOuterGroup()}\'";
                            }
                            else
                            {
                                // =none
                                propertyValue = "none";
                            }

                            break;
                        }

                    case PropertyType.ClassProperty:
                        {
                            var classObject = _Buffer.ReadObject();
                            propertyValue = classObject != null
                                ? $"class'{classObject.Name}'"
                                : "none";
                            break;
                        }

                    case PropertyType.DelegateProperty:
                        {
                            _TempFlags |= DoNotAppendName;

                            var outerObj = _Buffer.ReadObject(); // Where the assigned delegate property exists.

                            string delegateName = _Buffer.ReadName();

                            // Strip __%delegateName%__Delegate
                            string normalizedDelegateName = ((string)Name).Substring(2, Name.Length - 12);
                            propertyValue = $"{normalizedDelegateName}={delegateName}";
                            break;
                        }

                    #region HardCoded Struct Types

                    case PropertyType.Color:
                        {
                            var color = _Buffer.ReadAtomicStruct<UColor>();
                            propertyValue += PropertyDisplay.FormatLiteral(color);
                            break;
                        }

                    case PropertyType.LinearColor:
                        {
                            string r = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string g = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string b = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string a = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);

                            propertyValue += $"R={r},G={g},B={b},A={a}";
                            break;
                        }

                    case PropertyType.Vector:
                        {
                            string x = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string y = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string z = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);

                            propertyValue += $"X={x},Y={y},Z={z}";
                            break;
                        }

                    case PropertyType.TwoVectors:
                        {
                            string v1 = DeserializeDefaultPropertyValue(PropertyType.Vector, ref deserializeFlags);
                            string v2 = DeserializeDefaultPropertyValue(PropertyType.Vector, ref deserializeFlags);
                            propertyValue += $"v1=({v1}),v2=({v2})";
                            break;
                        }

                    case PropertyType.Vector4:
                        {
                            string x = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string y = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string z = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string w = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);

                            propertyValue += $"X={x},Y={y},Z={z},W={w}";
                            break;
                        }

                    case PropertyType.Vector2D:
                        {
                            string x = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string y = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            propertyValue += $"X={x},Y={y}";
                            break;
                        }

                    case PropertyType.Rotator:
                        {
                            string pitch = DeserializeDefaultPropertyValue(PropertyType.IntProperty, ref deserializeFlags);
                            string yaw = DeserializeDefaultPropertyValue(PropertyType.IntProperty, ref deserializeFlags);
                            string roll = DeserializeDefaultPropertyValue(PropertyType.IntProperty, ref deserializeFlags);
                            propertyValue += $"Pitch={pitch},Yaw={yaw},Roll={roll}";
                            break;
                        }

                    case PropertyType.Guid:
                        {
                            string a = DeserializeDefaultPropertyValue(PropertyType.IntProperty, ref deserializeFlags);
                            string b = DeserializeDefaultPropertyValue(PropertyType.IntProperty, ref deserializeFlags);
                            string c = DeserializeDefaultPropertyValue(PropertyType.IntProperty, ref deserializeFlags);
                            string d = DeserializeDefaultPropertyValue(PropertyType.IntProperty, ref deserializeFlags);
                            propertyValue += $"A={a},B={b},C={c},D={d}";
                            break;
                        }

                    case PropertyType.Sphere:
                    case PropertyType.Plane:
                        {
                            if (_Buffer.Version < VAtomicStructs)
                            {
                                throw new NotSupportedException("Not atomic");
                            }

                            string w = DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string v = DeserializeDefaultPropertyValue(PropertyType.Vector, ref deserializeFlags);
                            propertyValue += $"W={w},{v}";
                            break;
                        }

                    case PropertyType.Scale:
                        {
                            string scale = DeserializeDefaultPropertyValue(PropertyType.Vector, ref deserializeFlags);
                            string sheerRate =
                                DeserializeDefaultPropertyValue(PropertyType.FloatProperty, ref deserializeFlags);
                            string sheerAxis =
                                DeserializeDefaultPropertyValue(PropertyType.ByteProperty, ref deserializeFlags);
                            propertyValue += $"Scale=({scale}),SheerRate={sheerRate},SheerAxis={sheerAxis}";
                            break;
                        }

                    case PropertyType.Box:
                        {
                            if (_Buffer.Version < VAtomicStructs)
                            {
                                throw new NotSupportedException("Not atomic");
                            }

                            string min = DeserializeDefaultPropertyValue(PropertyType.Vector, ref deserializeFlags);
                            string max = DeserializeDefaultPropertyValue(PropertyType.Vector, ref deserializeFlags);
                            string isValid =
                                DeserializeDefaultPropertyValue(PropertyType.ByteProperty, ref deserializeFlags);
                            propertyValue += $"Min=({min}),Max=({max}),IsValid={isValid}";
                            break;
                        }

                    case PropertyType.Quat:
                        {
                            propertyValue += DeserializeDefaultPropertyValue(PropertyType.Plane, ref deserializeFlags);
                            break;
                        }

                    case PropertyType.Matrix:
                        {
                            if (_Buffer.Version < VAtomicStructs)
                            {
                                throw new NotSupportedException("Not atomic");
                            }

                            string xPlane = DeserializeDefaultPropertyValue(PropertyType.Plane, ref deserializeFlags);
                            string yPlane = DeserializeDefaultPropertyValue(PropertyType.Plane, ref deserializeFlags);
                            string zPlane = DeserializeDefaultPropertyValue(PropertyType.Plane, ref deserializeFlags);
                            string wPlane = DeserializeDefaultPropertyValue(PropertyType.Plane, ref deserializeFlags);
                            propertyValue += $"XPlane=({xPlane}),YPlane=({yPlane}),ZPlane=({zPlane}),WPlane=({wPlane})";
                            break;
                        }

                    case PropertyType.IntPoint:
                        {
                            string x = DeserializeDefaultPropertyValue(PropertyType.IntProperty, ref deserializeFlags);
                            string y = DeserializeDefaultPropertyValue(PropertyType.IntProperty, ref deserializeFlags);
                            propertyValue += $"X={x},Y={y}";
                            break;
                        }

                    #endregion

                    case PropertyType.PointerProperty:
                    case PropertyType.StructProperty:
                        {
                            // We have to modify the outer so that dynamic arrays within this struct
                            // will be able to find its variables to determine the array type.
                            FindProperty(out _Outer);
                            var itemName = ItemName?.Name;
                            if (string.IsNullOrEmpty(itemName))
                                itemName = _Outer.Name;

                            deserializeFlags |= DeserializeFlags.WithinStruct;
                            var isHardCoded = false;
                            var hardcodedStructs = (PropertyType[])Enum.GetValues(typeof(PropertyType));
                            for (var i = (byte)PropertyType.StructOffset; i < hardcodedStructs.Length; ++i)
                            {
                                string structType = Enum.GetName(typeof(PropertyType), (byte)hardcodedStructs[i]);
                                if (string.Compare(itemName, structType, StringComparison.OrdinalIgnoreCase) != 0)
                                    continue;

                                // Not atomic if <=UE2,
                                // TODO: Figure out all non-atomic structs
                                if (_Buffer.Version < VAtomicStructs) switch (hardcodedStructs[i])
                                    {
                                        case PropertyType.Matrix:
                                        case PropertyType.Box:
                                        case PropertyType.Plane:
                                            goto nonAtomic;
                                    }

                                isHardCoded = true;
                                propertyValue += DeserializeDefaultPropertyValue(hardcodedStructs[i], ref deserializeFlags);
                                break;
                            }

                        nonAtomic:
                            if (!isHardCoded)
                            {
                                while (true)
                                {
                                    var tag = new UDefaultProperty(_Container, _Outer);
                                    if (tag.Deserialize())
                                    {
                                        ChildrenProperties.Add(tag);

                                        propertyValue += tag.Name +
                                                         (tag.ArrayIndex > 0 && tag.Type != PropertyType.BoolProperty
                                                             ? $"[{tag.ArrayIndex}]"
                                                             : string.Empty) +
                                                         "=" + tag.Value + ",";
                                    }
                                    else
                                    {
                                        if (propertyValue.EndsWith(","))
                                            propertyValue = propertyValue.Remove(propertyValue.Length - 1, 1);

                                        break;
                                    }
                                }
                            }

                            propertyValue = propertyValue.Length != 0
                                ? $"({propertyValue})"
                                : "none";
                            break;
                        }

                    case PropertyType.ArrayProperty:
                        {
                            int arraySize = _Buffer.ReadIndex();
                            {
                                propertyValue = "none";
                                break;
                            }

                            // Find the property within the outer/owner or its inheritances.
                            // If found it has to modify the outer so structs within this array can find their array variables.
                            // Additionally we need to know the property to determine the array's type.
                            var arrayType = PropertyType.None;
                            var property = FindProperty(out _Outer) as UArrayProperty;

                            if (property?.InnerProperty != null)
                            {
                                arrayType = property.InnerProperty.Type;
                            }
                            // If we did not find a reference to the associated property(because of imports)
                            // then try to determine the array's type by scanning the defined array types.
                            else if (UnrealConfig.VariableTypes != null && UnrealConfig.VariableTypes.ContainsKey(Name))
                            {
                                var varTuple = UnrealConfig.VariableTypes[Name];
                                if (varTuple != null) arrayType = varTuple.Item2;
                            }

                            if (arrayType == PropertyType.None)
                            {
                                //  arrayType = PropertyType.StructProperty;
                                propertyValue = "/* Array type was not detected. */";
                                break;
                            }

                            deserializeFlags |= DeserializeFlags.WithinArray;
                            if ((deserializeFlags & DeserializeFlags.WithinStruct) != 0)
                            {
                                // Hardcoded fix for InterpCurve and InterpCurvePoint.
                                if (string.Compare(Name, "Points", StringComparison.OrdinalIgnoreCase) == 0)
                                    arrayType = PropertyType.StructProperty;

                                for (var i = 0; i < arraySize; ++i)
                                    propertyValue += DeserializeDefaultPropertyValue(arrayType, ref deserializeFlags)
                                                     + (i != arraySize - 1 ? "," : string.Empty);

                                propertyValue = $"({propertyValue})";
                            }
                            else
                            {
                                for (var i = 0; i < arraySize; ++i)
                                {
                                    string elementValue = DeserializeDefaultPropertyValue(arrayType, ref deserializeFlags);
                                    if ((_TempFlags & ReplaceNameMarker) != 0)
                                    {
                                        propertyValue += elementValue.Replace("%ARRAYNAME%", $"{Name}({i})");
                                        _TempFlags = 0x00;
                                    }
                                    else
                                    {
                                        propertyValue += $"{Name}({i})={elementValue}";
                                    }

                                    if (i != arraySize - 1) propertyValue += "\r\n" + UDecompilingState.Tabs;
                                }
                            }

                            _TempFlags |= DoNotAppendName;
                            break;
                        }

                    default:
                        propertyValue = "/* Unknown default property type! */";
                        break;
                }
            }
            catch (Exception e)
            {
                return $"{propertyValue}\r\n/* Exception thrown while deserializing {Name}\r\n{e} */";
            }
            finally
            {
                _Outer = orgOuter;
            }

            return propertyValue;
        }

        #endregion

        #region Decompilation

        public string Decompile()
        {
            _TempFlags = 0x00;
            string value;
            _Container.EnsureBuffer();
            try
            {
                value = DeserializeValue();
            }
            catch (Exception e)
            {
                value = $"//{e}";
            }
            finally
            {
                _Container.MaybeDisposeBuffer();
            }

            // Array or Inlined object
            if ((_TempFlags & DoNotAppendName) != 0)
                // The tag handles the name etc on its own.
                return value;

            var arrayIndex = string.Empty;
            if (ArrayIndex > 0 && Type != PropertyType.BoolProperty) arrayIndex += $"[{ArrayIndex}]";

            return $"{Name}{arrayIndex}={value}";
        }

        #endregion

        #region Methods

        private UProperty FindProperty(out UStruct outer)
        {
            UProperty property = null;
            outer = _Outer ?? _Container.Class as UStruct;

            for (var structField = outer; structField != null; structField = structField.Super as UStruct)
            {
                UField nextField = outer.Children;

                while (nextField != null)
                {
                    if (nextField is UProperty && nextField.Name == Name)
                        return (UProperty)nextField;

                    nextField = nextField.NextField;
                }

                if (structField.Variables == null || !structField.Variables.Any())
                    continue;

                property = structField.Variables.Find(i => i.Table.ObjectName == Name);
                if (property == null)
                    continue;

                switch (property.Type)
                {
                    case PropertyType.StructProperty:
                        outer = ((UStructProperty)property).StructObject;
                        break;

                    case PropertyType.ArrayProperty:
                        var arrayField = property as UArrayProperty;
                        Debug.Assert(arrayField != null, "arrayField != null");
                        var arrayInnerField = arrayField.InnerProperty;
                        if (arrayInnerField.Type == PropertyType.StructProperty)
                            _Outer = ((UStructProperty)arrayInnerField).StructObject;

                        break;

                    default:
                        outer = structField;
                        break;
                }

                break;
            }

            return property;
        }

        #endregion

    }

    [System.Runtime.InteropServices.ComVisible(false)]
    public sealed class DefaultPropertiesCollection : List<UDefaultProperty>
    {
        public UObject Container { get; private set; }

        public DefaultPropertiesCollection(UObject container)
        {
            Container = container;
        }


        [CanBeNull]
        public UDefaultProperty Find(string name)
        {
            return Find(prop => prop.Name == name);
        }

        [CanBeNull]
        public UDefaultProperty Find(UName name)
        {
            return Find(prop => prop.Name == name);
        }

        public bool Contains(string name)
        {
            return Find(name) != null;
        }

        public bool Contains(UName name)
        {
            return Find(name) != null;
        }

        public void Set(string name, object value)
        {
            var prop = Find(name);

            if (prop == null)
                throw new NotSupportedException("ATM not support add new properties");

            if (value is int)
                prop.GoodValue = new UValueIntProperty() { Number = (int)value };
            else if(value is string)
                prop.GoodValue = new UValueStrProperty() { Text = (string)value };
            else
                throw new NotSupportedException($"Not support set for value type {value.GetType().Name}");

        }
    }
}