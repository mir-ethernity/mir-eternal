using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using UELib.Annotations;
using UELib.Flags;

namespace UELib.Core
{
    /// <summary>
    /// Unknown Object
    ///
    /// Notes:
    ///     Instances of this class are created because of a class type that was not found within the 'RegisteredClasses' list.
    ///     Instances of this class will only be deserialized on demand.
    /// </summary>
    public sealed class UnknownObject : UObject
    {
        public byte[] Data { get; set; }

        /// <summary>
        /// Creates a new instance of the UELib.Core.UnknownObject class.
        /// </summary>
        public UnknownObject()
        {
            ShouldDeserializeOnDemand = false;
        }

        protected override void Deserialize()
        {
            if (Package.Version > 400 && _Buffer.Length >= 12)
            {
                // componentClassIndex
                _Buffer.Position += sizeof(int);
                int componentNameIndex = _Buffer.ReadNameIndex();
                if (componentNameIndex == (int)Table.ObjectName)
                {
                    base.Deserialize();
                    Data = Array.Empty<byte>();
                    return;
                }

                _Buffer.Position -= 12;
            }

            base.Deserialize();
            Data = new byte[_Buffer.Length - _Buffer.Position];
            _Buffer.Read(Data, 0, Data.Length);
        }

        public override void Serialize(IUnrealStream stream)
        {
            base.Serialize(stream);
            stream.Write(Data, 0, Data.Length);
        }

        protected override bool CanDisposeBuffer()
        {
            return false;
        }
    }
}