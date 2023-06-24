using System;
using System.Collections.Generic;
using UELib.Flags;

namespace UELib.Core
{
    /// <summary>
    /// Represents a unreal function.
    /// </summary>
    [UnrealRegisterClass]
    public partial class UFunction : UStruct, IUnrealNetObject
    {
        private const uint VFriendlyName = 189;

        #region Serialized Members

        public ushort NativeToken { get; private set; }

        public byte OperPrecedence { get; private set; }

        /// <value>
        /// 32bit in UE2
        /// 64bit in UE3
        /// </value>
        private ulong FunctionFlags { get; set; }

        public ushort RepOffset { get; private set; }

        public bool RepReliable => HasFunctionFlag(Flags.FunctionFlags.NetReliable);

        public uint RepKey => RepOffset | ((uint)Convert.ToByte(RepReliable) << 16);

        #endregion

        #region Script Members

        public List<UProperty> Params { get; private set; }
        public UProperty ReturnProperty { get; private set; }

        #endregion

        #region Constructors

        protected override void Deserialize()
        {
            base.Deserialize();

            if (_Buffer.Version < 64)
            {
                ushort paramsSize = _Buffer.ReadUShort();
            }

            NativeToken = _Buffer.ReadUShort();

            if (_Buffer.Version < 64)
            {
                byte paramsCount = _Buffer.ReadByte();
            }

            OperPrecedence = _Buffer.ReadByte();

            if (_Buffer.Version < 64)
            {
                ushort returnValueOffset = _Buffer.ReadUShort();
            }

            FunctionFlags = _Buffer.ReadUInt32();
            if (HasFunctionFlag(Flags.FunctionFlags.Net))
            {
                RepOffset = _Buffer.ReadUShort();
            }

            // TODO: Data-strip version?
            if (_Buffer.Version >= VFriendlyName && !Package.IsConsoleCooked())
            {
                FriendlyName = _Buffer.ReadNameReference();
            }
            else
            {
                // HACK: Workaround for packages that have stripped FriendlyName data.
                // FIXME: Operator names need to be translated.
                FriendlyName = Table.ObjectName;
            }
        }

        protected override void FindChildren()
        {
            base.FindChildren();
            Params = new List<UProperty>();
            foreach (var property in Variables)
            {
                if (property.HasPropertyFlag(PropertyFlagsLO.ReturnParm)) ReturnProperty = property;

                if (property.IsParm()) Params.Add(property);
            }
        }

        #endregion

        #region Methods

        public bool HasFunctionFlag(FunctionFlags flag)
        {
            return ((uint)FunctionFlags & (uint)flag) != 0;
        }

        public bool IsOperator()
        {
            return HasFunctionFlag(Flags.FunctionFlags.Operator);
        }

        public bool IsPost()
        {
            return IsOperator() && OperPrecedence == 0;
        }

        public bool IsPre()
        {
            return IsOperator() && HasFunctionFlag(Flags.FunctionFlags.PreOperator);
        }

        #endregion
    }
}