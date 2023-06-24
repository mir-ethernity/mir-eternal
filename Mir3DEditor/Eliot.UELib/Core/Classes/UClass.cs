using System;
using System.Collections.Generic;
using System.Diagnostics;
using UELib.Annotations;
using UELib.Flags;

namespace UELib.Core
{
    /// <summary>
    /// Represents a unreal class.
    /// </summary>
    [UnrealRegisterClass]
    public partial class UClass : UState
    {
        public struct Dependency : IUnrealSerializableClass
        {
            public int Class { get; private set; }

            public void Serialize(IUnrealStream stream)
            {
                // TODO: Implement code
            }

            public void Deserialize(IUnrealStream stream)
            {
                Class = stream.ReadObjectIndex();

                // Deep
                var u1 = stream.ReadInt32();

                // ScriptTextCRC
                var u2 = stream.ReadUInt32();
            }
        }

        #region Serialized Members

        private ulong ClassFlags { get; set; }

        public Guid ClassGuid;
        public UClass Within { get; private set; }
        public UName ConfigName { get; private set; }
        [CanBeNull] public UName DLLBindName;
        public string NativeClassName = string.Empty;
        public bool ForceScriptOrder;

        /// <summary>
        /// A list of class dependencies that this class depends on. Includes Imports and Exports.
        ///
        /// Deprecated @ PackageVersion:186
        /// </summary>
        public UArray<Dependency> ClassDependencies;

        /// <summary>
        /// A list of objects imported from a package.
        /// </summary>
        public IList<int> PackageImports;

        /// <summary>
        /// Index of component names into the NameTableList.
        /// UE3
        /// </summary>
        public IList<int> Components = null;

        /// <summary>
        /// Index of unsorted categories names into the NameTableList.
        /// UE3
        /// </summary>
        public IList<int> DontSortCategories;

        /// <summary>
        /// Index of hidden categories names into the NameTableList.
        /// </summary>
        public IList<int> HideCategories;

        /// <summary>
        /// Index of auto expanded categories names into the NameTableList.
        /// UE3
        /// </summary>
        public IList<int> AutoExpandCategories;

        /// <summary>
        /// A list of class group.
        /// </summary>
        public IList<int> ClassGroups;

        /// <summary>
        /// Index of auto collapsed categories names into the NameTableList.
        /// UE3
        /// </summary>
        public IList<int> AutoCollapseCategories;

        /// <summary>
        /// Index of (Object/Name?)
        /// UE3
        /// </summary>
        public IList<int> ImplementedInterfaces;

        [CanBeNull] public UArray<UObject> Vengeance_Implements;

        #endregion

        #region Script Members

        public IList<UState> States { get; protected set; }

        #endregion

        #region Constructors

        // TODO: Clean this mess up...
        protected override void Deserialize()
        {
            base.Deserialize();

            ClassFlags = _Buffer.ReadUInt32();

            if (Package.Version >= 276)
            {
                if (Package.Version < 547)
                {
                    byte unknownByte = _Buffer.ReadByte();
                }
            }
            else
            {
                ClassGuid = _Buffer.ReadGuid();
            }

            if (Package.Version < 248)
            {
                _Buffer.ReadArray(out ClassDependencies);
                PackageImports = DeserializeGroup(nameof(PackageImports));
            }

        skipTo61Stuff:
            if (Package.Version >= 62)
            {
                // Class Name Extends Super.Name Within _WithinIndex
                //      Config(_ConfigIndex);
                Within = _Buffer.ReadObject<UClass>();
                ConfigName = _Buffer.ReadNameReference();

                const int vHideCategoriesOldOrder = 539;
                bool isHideCategoriesOldOrder = Package.Version <= vHideCategoriesOldOrder
#if TERA
                                                || Package.Build == UnrealPackage.GameBuild.BuildName.Tera
#endif
                    ;

                // +HideCategories
                if (Package.Version >= 99)
                {
                    // TODO: Corrigate Version
                    if (Package.Version >= 220)
                    {
                        // TODO: Corrigate Version
                        if ((isHideCategoriesOldOrder && !Package.IsConsoleCooked() &&
                             !Package.Build.Flags.HasFlag(BuildFlags.XenonCooked))
#if TRANSFORMERS
                            || Package.Build == UnrealPackage.GameBuild.BuildName.Transformers
#endif
                           )
                            DeserializeHideCategories();

                        DeserializeComponentsMap();

                        // RoboBlitz(369)
                        // TODO: Corrigate Version
                        if (Package.Version >= 369) DeserializeInterfaces();
                    }

                    if (!Package.IsConsoleCooked() && !Package.Build.Flags.HasFlag(BuildFlags.XenonCooked))
                    {
                        if (Package.Version >= 603
#if TERA
                            && Package.Build != UnrealPackage.GameBuild.BuildName.Tera
#endif
                           )
                            DontSortCategories = DeserializeGroup("DontSortCategories");

                        // FIXME: Added in v99, removed in ~220?
                        if (Package.Version < 220 || !isHideCategoriesOldOrder)
                        {
                            DeserializeHideCategories();
#if SPELLBORN
                            if (Package.Build == UnrealPackage.GameBuild.BuildName.Spellborn)
                            {
                                uint replicationFlags = _Buffer.ReadUInt32();
                            }
#endif
                        }

                        // +AutoExpandCategories
                        if (Package.Version >= 185)
                        {
                            // 490:GoW1, 576:CrimeCraft
                            if (!HasClassFlag(Flags.ClassFlags.CollapseCategories)
                                || Package.Version <= vHideCategoriesOldOrder || Package.Version >= 576)
                                AutoExpandCategories = DeserializeGroup("AutoExpandCategories");

                            if (Package.Version > 670)
                            {
                                AutoCollapseCategories = DeserializeGroup("AutoCollapseCategories");

                                if (Package.Version >= 749)
                                {
                                    // bForceScriptOrder
                                    ForceScriptOrder = _Buffer.ReadInt32() > 0;

                                    if (Package.Version >= UnrealPackage.VCLASSGROUP)
                                    {
                                        ClassGroups = DeserializeGroup("ClassGroups");
                                        if (Package.Version >= 813)
                                        {
                                            NativeClassName = _Buffer.ReadText();
                                        }
                                    }
                                }
                            }

                            // FIXME: Found first in(V:655), Definitely not in APB and GoW 2
                            // TODO: Corrigate Version
                            if (Package.Version > 575 && Package.Version < 673                               )
                            {
                                int unknownInt32 = _Buffer.ReadInt32();

                            }
                        }
                    }

                    if (Package.Version >= UnrealPackage.VDLLBIND)
                    {
                        if (!Package.Build.Flags.HasFlag(BuildFlags.NoDLLBind))
                        {
                            DLLBindName = _Buffer.ReadNameReference();
                        }
                    }
                }
            }

            // In later UE3 builds, defaultproperties are stored in separated objects named DEFAULT_namehere,
            // TODO: Corrigate Version
            if (Package.Version >= 322)
            {
                Default = _Buffer.ReadObject();
            }
            else
            {
                DeserializeProperties();
            }
        }

        private void DeserializeInterfaces()
        {
            // See http://udn.epicgames.com/Three/UnrealScriptInterfaces.html
            int interfacesCount = _Buffer.ReadInt32();
            if (interfacesCount <= 0)
                return;

            ImplementedInterfaces = new List<int>(interfacesCount);
            for (var i = 0; i < interfacesCount; ++i)
            {
                int interfaceIndex = _Buffer.ReadInt32();
                int typeIndex = _Buffer.ReadInt32();
                ImplementedInterfaces.Add(interfaceIndex);
            }
        }

        private void DeserializeHideCategories()
        {
            HideCategories = DeserializeGroup("HideCategories");
        }

        private void DeserializeComponentsMap()
        {
            int componentsCount = _Buffer.ReadInt32();
            if (componentsCount <= 0)
                return;

            // NameIndex/ObjectIndex
            int numBytes = componentsCount * 12;
            _Buffer.Skip(numBytes);
        }

        protected override void FindChildren()
        {
            base.FindChildren();
            States = new List<UState>();
            for (var child = Children; child != null; child = child.NextField)
                if (child.IsClassType("State"))
                    States.Insert(0, (UState)child);
        }

        #endregion

        #region Methods

        private IList<int> DeserializeGroup(string groupName = "List", int count = -1)
        {
            if (count == -1) count = _Buffer.ReadLength();

            if (count <= 0)
                return null;

            var groupList = new List<int>(count);
            for (var i = 0; i < count; ++i)
            {
                int index = _Buffer.ReadNameIndex();
                groupList.Add(index);
            }

            return groupList;
        }

        public bool HasClassFlag(ClassFlags flag)
        {
            return (ClassFlags & (uint)flag) != 0;
        }

        public bool HasClassFlag(uint flag)
        {
            return (ClassFlags & flag) != 0;
        }

        public bool IsClassInterface()
        {
            return (Super != null && string.Compare(Super.Name, "Interface", StringComparison.OrdinalIgnoreCase) == 0)
                   || string.Compare(Name, "Interface", StringComparison.OrdinalIgnoreCase) == 0;
        }

        public bool IsClassWithin()
        {
            return Within != null && !string.Equals(Within.Name, "Object", StringComparison.OrdinalIgnoreCase);
        }

        #endregion
    }
}