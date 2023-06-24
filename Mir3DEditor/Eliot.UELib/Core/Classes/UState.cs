using System.Collections.Generic;
using UELib.Flags;

namespace UELib.Core
{
    public struct ULabelEntry
    {
        public string Name;
        public int Position;
    }

    /// <summary>
    /// Represents a unreal state.
    /// </summary>
    [UnrealRegisterClass]
    public partial class UState : UStruct
    {
        // FIXME: Version 61 is the lowest package version I know that supports StateFlags.
        private const int VStateFlags = 61;
        // FIXME: Version
        private const int VFuncMap = 220;
        public const int VProbeMaskReducedAndIgnoreMaskRemoved = 691;

        #region Serialized Members

        /// <summary>
        /// Mask of current functions being probed by this class.
        /// </summary>
        public ulong ProbeMask;

        /// <summary>
        /// Mask of current functions being ignored by the present state node.
        /// </summary>
        public ulong IgnoreMask;

        /// <summary>
        /// Offset into the ScriptStack where the FLabelEntry persist.
        /// </summary>
        public ushort LabelTableOffset;

        /// <summary>
        /// This state's flags mask e.g. Auto, Simulated.
        /// TODO: Retype to UStateFlags and deprecate HasStateFlag, among others
        /// </summary>
        private uint _StateFlags;

        public UMap<UName, UFunction> FuncMap;

        #endregion

        #region Script Members

        public IList<UFunction> Functions { get; private set; }

        #endregion

        #region Constructors

        protected override void Deserialize()
        {
            base.Deserialize();

            if (Package.Version < VProbeMaskReducedAndIgnoreMaskRemoved)
            {
                ProbeMask = _Buffer.ReadUInt64();
                IgnoreMask = _Buffer.ReadUInt64();
            }
            else
            {
                ProbeMask = _Buffer.ReadUInt32();
            }

            noMasks:
            LabelTableOffset = _Buffer.ReadUInt16();

            if (Package.Version >= VStateFlags)
            {
                _StateFlags = _Buffer.ReadUInt32();
            }

            if (Package.Version < VFuncMap) return;
            _Buffer.ReadMap(out FuncMap); 
        }

        protected override void FindChildren()
        {
            base.FindChildren();
            Functions = new List<UFunction>();
            for (var child = Children; child != null; child = child.NextField)
            {
                if (child.IsClassType("Function"))
                {
                    Functions.Insert(0, (UFunction)child);
                }
            }
        }

        #endregion

        #region Methods

        public bool HasStateFlag(StateFlags flag)
        {
            return (_StateFlags & (uint)flag) != 0;
        }

        public bool HasStateFlag(uint flag)
        {
            return (_StateFlags & flag) != 0;
        }

        #endregion
    }
}