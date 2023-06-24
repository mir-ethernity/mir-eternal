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
    public class UValueUnknownProperty : UValueProperty
    {
        public byte[] Raw { get; set; }

        public override void Deserialize(IUnrealStream stream)
        {
            Raw = new byte[Size];
            stream.Read(Raw, 0, Size);
        }

        public override void Serialize(IUnrealStream stream)
        {
            stream.Write(Raw);
        }

        public override string ToString()
        {
            if(Raw.Length > 1000)
            {
                var buff = new byte[1000];
                Array.Copy(Raw, buff, 1000);
                return "0x" + BitConverter.ToString(buff).Replace("-", "").ToLower();
            }
            return "0x" + BitConverter.ToString(Raw).Replace("-", "").ToLower();
        }
    }
}