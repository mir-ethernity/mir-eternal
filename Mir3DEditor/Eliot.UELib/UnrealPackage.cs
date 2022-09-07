using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using UELib.Annotations;
using UELib.Flags;

namespace UELib
{
    using Core;
    using Decoding;

    /// <summary>
    /// Represents the method that will handle the UELib.UnrealPackage.NotifyObjectAdded
    /// event of a new added UELib.Core.UObject.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A UELib.UnrealPackage.ObjectEventArgs that contains the event data.</param>
    public delegate void NotifyObjectAddedEventHandler(object sender, ObjectEventArgs e);

    /// <summary>
    /// Represents the method that will handle the UELib.UnrealPackage.NotifyPackageEvent
    /// event of a triggered event within the UELib.UnrealPackage.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A UELib.UnrealPackage.PackageEventArgs that contains the event data.</param>
    public delegate void PackageEventHandler(object sender, UnrealPackage.PackageEventArgs e);

    /// <summary>
    /// Represents the method that will handle the UELib.UnrealPackage.NotifyInitializeUpdate
    /// event of a UELib.Core.UObject update.
    /// </summary>
    [PublicAPI]
    public delegate void NotifyUpdateEvent();

    /// <summary>
    /// Registers the class as an Unreal class. The class's name is required to begin with the letter "U".
    /// When an Unreal Package is initializing, all described objects will be initialized as the registered class if its name matches as described by its export item.
    /// 
    /// Note: Usage restricted to the executing assembly(UELib) only!
    /// </summary>
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class UnrealRegisterClassAttribute : Attribute
    {
    }

    /// <summary>
    /// Represents data of a loaded unreal package.
    /// </summary>
    public sealed partial class UnrealPackage : IDisposable, IBuffered
    {
        #region General Members

        // Reference to the stream used when reading this package
        public UPackageStream Stream { get; private set; }

        /// <summary>
        /// The signature of a 'Unreal Package'.
        /// </summary>
        public const uint Signature = 0x9E2A83C1;

        public const uint Signature_BigEndian = 0xC1832A9E;

        /// <summary>
        /// The full name of this package including directory.
        /// </summary>
        private readonly string _FullPackageName = "UnrealPackage";

        [PublicAPI] public string FullPackageName => _FullPackageName;

        [PublicAPI] public string PackageName => Path.GetFileNameWithoutExtension(_FullPackageName);

        [PublicAPI] public string PackageDirectory => Path.GetDirectoryName(_FullPackageName);

        #endregion

        #region Serialized Members

        private uint _Version;

        public uint Version
        {
            get => OverrideVersion > 0 ? OverrideVersion : _Version;
            set => _Version = value;
        }

        /// <summary>
        /// For debugging purposes. Change this to override the present Version deserialized from the package.
        /// </summary>
        public static ushort OverrideVersion;

        #region Version history

        public const int VSIZEPREFIXDEPRECATED = 64;
        public const int VINDEXDEPRECATED = 178;
        public const int VCOOKEDPACKAGES = 277;

        /// <summary>
        /// DLLBind(Name)
        /// </summary>
        public const int VDLLBIND = 655;

        /// <summary>
        /// New class modifier "ClassGroup(Name[,Name])"
        /// </summary>
        public const int VCLASSGROUP = 789;

        private const int VCompression = 334;
        private const int VEngineVersion = 245;
        private const int VGroup = 269;
        private const int VHeaderSize = 249;
        private const int VPackageSource = 482;
        private const int VAdditionalPackagesToCook = 516;
        private const int VTextureAllocations = 767;

        #endregion

        private ushort _LicenseeVersion;

        public ushort LicenseeVersion
        {
            get => OverrideLicenseeVersion > 0 ? OverrideLicenseeVersion : _LicenseeVersion;
            private set => _LicenseeVersion = value;
        }

        /// <summary>
        /// For debugging purposes. Change this to override the present Version deserialized from the package.
        /// </summary>
        public static ushort OverrideLicenseeVersion;

        public GameBuild Build { get; private set; }

        /// <summary>
        /// Whether the package was serialized in BigEndian encoding.
        /// </summary>
        public bool IsBigEndianEncoded { get; }

        /// <summary>
        /// The bitflags of this package.
        /// </summary>
        public PackageFlags PackageFlags;

        /// <summary>
        /// Size of the Header. Basically points to the first Object in the package.
        /// </summary>
        public int HeaderSize { get; private set; }

        /// <summary>
        /// The group the package is associated with in the Content Browser.
        /// </summary>
        public string Group;

        private TablesData _TablesData;
        public TablesData Summary => _TablesData;

        /// <summary>
        /// The guid of this package. Used to test if the package on a client is equal to the one on a server.
        /// </summary>
        [PublicAPI]
        public Guid GUID { get; private set; }

        /// <summary>
        /// List of heritages. UE1 way of defining generations.
        /// </summary>
        private IList<ushort> _Heritages;

        /// <summary>
        /// List of package generations.
        /// </summary>
        [PublicAPI]
        public UArray<UGenerationTableItem> Generations => _Generations;

        private UArray<UGenerationTableItem> _Generations;

        private UArray<UTextureInfo> _Textures;

        /// <summary>
        /// The Engine version the package was created with.
        /// </summary>
        [DefaultValue(-1)]
        [PublicAPI]
        public int EngineVersion { get; private set; }

        /// <summary>
        /// The Cooker version the package was cooked with.
        /// </summary>
        [PublicAPI]
        public int CookerVersion { get; private set; }

        /// <summary>
        /// The type of compression the package is compressed with.
        /// </summary>
        [PublicAPI]
        public CompressionFlags CompressionFlags { get; private set; }

        /// <summary>
        /// List of compressed chunks throughout the package.
        /// Null if package version less is than <see cref="VCompression" />
        /// </summary>
        [PublicAPI("UE Explorer requires 'get'")]
        [CanBeNull]
        public UArray<CompressedChunk> CompressedChunks => _CompressedChunks;

        [CanBeNull] private UArray<CompressedChunk> _CompressedChunks;

        /// <summary>
        /// List of unique unreal names.
        /// </summary>
        [PublicAPI]
        public List<UNameTableItem> Names { get; private set; }

        /// <summary>
        /// List of info about exported objects.
        /// </summary>
        [PublicAPI]
        public List<UExportTableItem> Exports { get; private set; }

        /// <summary>
        /// List of info about depends objects.
        /// </summary>
        [PublicAPI]
        public List<UDependTableItem> Depends { get; private set; }

        /// <summary>
        /// List of info about imported objects.
        /// </summary>
        [PublicAPI]
        public List<UImportTableItem> Imports { get; private set; }

        public IDictionary<string, IDictionary<string, UImportTableItem>> ImportsIndex { get; private set; }

        [PublicAPI]
        public List<UThumbnailTableItem> Thumbnails { get; private set; }

        /// <summary>
        /// List of info about dependency objects.
        /// </summary>
        //public List<UDependencyTableItem> Dependencies{ get; private set; }

        #endregion

        #region Initialized Members

        /// <summary>
        /// Class types that should get added to the ObjectsList.
        /// </summary>
        private readonly Dictionary<string, Type> _ClassTypes = new Dictionary<string, Type>();

        /// <summary>
        /// List of UObjects that were constructed by function ConstructObjects, later deserialized and linked.
        ///
        /// Includes Exports and Imports!.
        /// </summary>
        [PublicAPI]
        public List<UObject> Objects { get; private set; }
        public uint PackageSource { get; private set; }
        public UArray<string> AdditionalPackagesToCook { get; private set; }
        public byte[] UnknownDataBeforeThumbnailInfo { get; private set; }

        [PublicAPI] public NativesTablePackage NTLPackage;

        [PublicAPI] public IBufferDecoder Decoder;
        private static List<Func<string, byte[]>> _callbacksToLoadImportFile = new List<Func<string, byte[]>>();

        #endregion
        #region Constructors


        [PublicAPI]
        [Obsolete]
        public static UnrealPackage DeserializePackage(string packagePath, FileAccess fileAccess = FileAccess.Read)
        {
            var buffer = File.ReadAllBytes(packagePath);
            var stream = new UPackageStream(packagePath, buffer);
            var pkg = new UnrealPackage(stream);
            pkg.Deserialize(stream);
            return pkg;
        }

        /// <summary>
        /// Creates a new instance of the UELib.UnrealPackage class with a PackageStream and name.
        /// </summary>
        /// <param name="stream">A loaded UELib.PackageStream.</param>
        public UnrealPackage(UPackageStream stream)
        {
            _FullPackageName = stream.Name;
            Stream = stream;
            Stream.PostInit(this);

            // File Type
            // Signature is tested in UPackageStream
            IsBigEndianEncoded = stream.BigEndianCode;
        }


        public static void RegisterCallbackToLoadImportFile(Func<string, byte[]> callback)
        {
            _callbacksToLoadImportFile.Add(callback);
        }

        public static byte[] LoadImportFile(string name)
        {
            foreach (var callback in _callbacksToLoadImportFile)
            {
                var buff = callback(name);
                if (buff != null)
                    return buff;
            }

            return null;
        }

        public void Serialize(IUnrealStream stream)
        {
            // Serialize tables
            var namesBuffer = new UObjectStream(stream);
            foreach (var name in Names) name.Serialize(namesBuffer);

            var importsBuffer = new UObjectStream(stream);
            foreach (var import in Imports) import.Serialize(importsBuffer);

            var exportsBuffer = new UObjectStream(stream);
            foreach (var export in Exports) export.Serialize(exportsBuffer);

            var dependsBuffer = new UObjectStream(stream);
            foreach (var depend in Depends) depend.Serialize(dependsBuffer);

            var thumbnailsBuffer = new UObjectStream(stream);
            foreach (var thumbnail in Thumbnails) thumbnail.Serialize(thumbnailsBuffer);

            stream.Seek(0, SeekOrigin.Begin);
            stream.Write(Signature);

            // Serialize header
            int version = (int)(Version & 0x0000FFFFU) | (LicenseeVersion << 16);
            stream.Write(version);

            long headerSizePosition = stream.Position;
            if (Version >= VHeaderSize)
            {
                stream.Write(HeaderSize);
                if (Version >= VGroup) stream.Write(Group);
            }

            stream.Write((uint)PackageFlags);

            _TablesData.NamesCount = Names.Count;
            _TablesData.ExportsCount = Exports.Count;
            _TablesData.ImportsCount = Imports.Count;

            long tablesDataPosition = stream.Position;
            _TablesData.Serialize(stream);

            // TODO: Serialize Heritages

            stream.Write(GUID);

            if (Build != GameBuild.BuildName.MKKE)
            {
                _Generations.Serialize<UGenerationTableItem>(stream);
            }

            if (Version >= VEngineVersion)
            {
                stream.Write(EngineVersion);
                if (Version >= VCOOKEDPACKAGES)
                {
                    stream.Write(CookerVersion);

                    if (Version >= VCompression)
                        stream.Write((uint)CompressionFlags);
                    CompressedChunks.Serialize<CompressedChunk>(stream);
                }
            }

            if (Version >= VPackageSource)
                stream.Write(PackageSource);

            if (Version >= VAdditionalPackagesToCook)
            {
                stream.WriteArray(AdditionalPackagesToCook);
            }

            if (Version >= VTextureAllocations)
            {
                stream.WriteArray(_Textures);
            }


            // Write tables
            // names
            Console.WriteLine("Writing names at position " + stream.Position);
            _TablesData.NamesOffset = (int)stream.Position;
            byte[] namesBytes = namesBuffer.GetBuffer();
            stream.Write(namesBytes, 0, (int)namesBuffer.Length);

            // imports
            Console.WriteLine("Writing imports at position " + stream.Position);
            _TablesData.ImportsOffset = (int)stream.Position;
            byte[] importsBytes = importsBuffer.GetBuffer();
            stream.Write(importsBytes, 0, (int)importsBuffer.Length);

            // exports
            Console.WriteLine("Writing exports at position " + stream.Position);
            _TablesData.ExportsOffset = (int)stream.Position;
            byte[] exportsBytes = exportsBuffer.GetBuffer();
            stream.Write(exportsBytes, 0, (int)exportsBuffer.Length);

            // depends
            Console.WriteLine("Writing depends at position " + stream.Position);
            _TablesData.DependsOffset = (int)stream.Position;
            byte[] dependsBytes = dependsBuffer.GetBuffer();
            stream.Write(dependsBytes, 0, (int)dependsBuffer.Length);

            // ImportExportGuids
            _TablesData.ImportExportGuidsOffset = (int)stream.Position;

            // TODO: me faltan 300 bytes
            stream.Write(UnknownDataBeforeThumbnailInfo);

            // thumbnail
            if (Version >= 584)
            {
                _TablesData.ThumbnailTableOffset = (int)stream.Position;
                stream.Write(Thumbnails.Count);
                byte[] thumbnailsBytes = thumbnailsBuffer.GetBuffer();
                stream.Write(thumbnailsBytes, 0, (int)thumbnailsBuffer.Length);
            }

            // set header size
            HeaderSize = (int)stream.Position;
            stream.Seek(headerSizePosition, SeekOrigin.Begin);
            stream.Write(HeaderSize);


            // Serialize tables data again now that offsets are known.
            stream.Seek(tablesDataPosition, SeekOrigin.Begin);
            _TablesData.Serialize(stream);

            // return to end header
            stream.Seek(HeaderSize, SeekOrigin.Begin);

            foreach (var exp in Exports)
            {
                exp.SerialOffset = (int)stream.Position;
                exp.Object.Serialize(stream);
                exp.SerialSize = (int)stream.Position - (int)exp.SerialOffset;
            }

            exportsBuffer = new UObjectStream(stream);
            foreach (var export in Exports) export.Serialize(exportsBuffer);

            stream.Seek(_TablesData.ExportsOffset, SeekOrigin.Begin);
            exportsBytes = exportsBuffer.GetBuffer();
            stream.Write(exportsBytes, 0, (int)exportsBuffer.Length);

            stream.Flush();
        }

        public IEnumerable<PackageFlags> GetPackageFlags()
        {
            var f = ((PackageFlags)PackageFlags);
            foreach (PackageFlags value in Enum.GetValues(typeof(PackageFlags)))
                if (f.HasFlag(value))
                    yield return value;
        }

        // TODO: Move to FilePackageSummary, but first we want to merge the support-* branches
        public void Deserialize(UPackageStream stream)
        {
            // Read as one variable due Big Endian Encoding.
            Version = stream.ReadUInt32();
            LicenseeVersion = (ushort)(Version >> 16);
            Version &= 0xFFFFU;
            Console.WriteLine("Package Version:" + Version + "/" + LicenseeVersion);

            Build = new GameBuild(this);
            Console.WriteLine("Build:" + Build.Name);

            stream.BuildDetected(Build);

            if (Version >= VHeaderSize)
            {
#if BIOSHOCK
                if (Build == GameBuild.BuildName.Bioshock_Infinite)
                {
                    int unk = stream.ReadInt32();
                }
#endif
#if MKKE
                if (Build == GameBuild.BuildName.MKKE) stream.Skip(8);
#endif
#if TRANSFORMERS
                if (Build == GameBuild.BuildName.Transformers
                    && LicenseeVersion >= 55)
                {
                    if (LicenseeVersion >= 181) stream.Skip(16);

                    stream.Skip(4);
                }
#endif
                // Offset to the first class(not object) in the package.
                HeaderSize = stream.ReadInt32();
                Console.WriteLine("Header Size: " + HeaderSize);
            }

            if (Version >= VGroup)
            {
                // UPK content category e.g. Weapons, Sounds or Meshes.
                Group = stream.ReadText();
            }

            // Bitflags such as AllowDownload.
            PackageFlags = (PackageFlags)stream.ReadUInt32();
            Console.WriteLine("Package Flags:" + PackageFlags);

            // Summary data such as ObjectCount.
            _TablesData = new TablesData();
            _TablesData.Deserialize(stream);
            if (Version < 68)
            {
                int heritageCount = stream.ReadInt32();
                int heritageOffset = stream.ReadInt32();

                stream.Seek(heritageOffset, SeekOrigin.Begin);
                _Heritages = new List<ushort>(heritageCount);
                for (var i = 0; i < heritageCount; ++i) _Heritages.Add(stream.ReadUShort());
            }
            else
            {
#if THIEF_DS || DEUSEX_IW
                if (Build == GameBuild.BuildName.Thief_DS ||
                    Build == GameBuild.BuildName.DeusEx_IW)
                {
                    //stream.Skip( 4 );
                    int unknown = stream.ReadInt32();
                    Console.WriteLine("Unknown:" + unknown);
                }
#endif
#if BORDERLANDS
                if (Build == GameBuild.BuildName.Borderlands) stream.Skip(4);
#endif
#if MKKE
                if (Build == GameBuild.BuildName.MKKE) stream.Skip(4);
#endif
                if (Build == GameBuild.BuildName.Spellborn
                    && stream.Version >= 148)
                    goto skipGuid;
                GUID = stream.ReadGuid();
                Console.WriteLine("GUID:" + GUID);
            skipGuid:
#if TERA
                if (Build == GameBuild.BuildName.Tera) stream.Position -= 4;
#endif
#if MKKE
                if (Build != GameBuild.BuildName.MKKE)
                {
#endif
                    int generationCount = stream.ReadInt32();
                    Console.WriteLine("Generations Count:" + generationCount);
#if APB
                    // Guid, however only serialized for the first generation item.
                    if (stream.Package.Build == GameBuild.BuildName.APB &&
                        stream.Package.LicenseeVersion >= 32)
                    {
                        stream.Skip(16);
                    }
#endif
                    stream.ReadArray(out _Generations, generationCount);
#if MKKE
                }
#endif
                if (Version >= VEngineVersion)
                {
                    // The Engine Version this package was created with
                    EngineVersion = stream.ReadInt32();
                    Console.WriteLine("EngineVersion:" + EngineVersion);
                }

                if (Version >= VCOOKEDPACKAGES)
                {
                    // The Cooker Version this package was cooked with
                    CookerVersion = stream.ReadInt32();
                    Console.WriteLine("CookerVersion:" + CookerVersion);
                }

                // Read compressed info?
                if (Version >= VCompression)
                {
                    CompressionFlags = (CompressionFlags)stream.ReadUInt32();

                    Console.WriteLine("CompressionFlags:" + CompressionFlags);
                    stream.ReadArray(out _CompressedChunks);
                }

                if (Version >= VPackageSource)
                {
                    PackageSource = stream.ReadUInt32();
                    Console.WriteLine("PackageSource:" + PackageSource);
                }

                if (Version >= VAdditionalPackagesToCook)
                {
                    UArray<string> additionalPackagesToCook;
                    stream.ReadArray(out additionalPackagesToCook);
                    AdditionalPackagesToCook = additionalPackagesToCook;
#if DCUO
                    if (Build == GameBuild.BuildName.DCUO)
                    {
                        var realNameOffset = (int)stream.Position;
                        Debug.Assert(
                            realNameOffset <= _TablesData.NamesOffset,
                            "realNameOffset is > the parsed name offset for a DCUO package, we don't know where to go now!"
                        );

                        int offsetDif = _TablesData.NamesOffset - realNameOffset;
                        _TablesData.NamesOffset -= offsetDif;
                        _TablesData.ImportsOffset -= offsetDif;
                        _TablesData.ExportsOffset -= offsetDif;
                        _TablesData.DependsOffset = 0; // not working
                        _TablesData.ImportExportGuidsOffset -= offsetDif;
                        _TablesData.ThumbnailTableOffset -= offsetDif;
                    }
#endif
                }

                if (Version >= VTextureAllocations)
                {
                    stream.ReadArray(out _Textures);
                }
            }
#if ROCKETLEAGUE
            if (Build == GameBuild.BuildName.RocketLeague
                && IsCooked())
            {
                int garbageSize = stream.ReadInt32();
                Debug.WriteLine(garbageSize, "GarbageSize");
                int compressedChunkInfoOffset = stream.ReadInt32();
                Debug.WriteLine(compressedChunkInfoOffset, "CompressedChunkInfoOffset");
                int lastBlockSize = stream.ReadInt32();
                Debug.WriteLine(lastBlockSize, "LastBlockSize");
                Debug.Assert(stream.Position == _TablesData.NamesOffset, "There is more data before the NameTable");
                // Data after this is encrypted
            }
#endif

#if AA2
            if (Build == GameBuild.BuildName.AA2
                // Note: Never true, AA2 is not a detected build for packages with LicenseeVersion 27 or less
                // But we'll preserve this nonetheless
                && LicenseeVersion >= 19)
            {
                bool isEncrypted = stream.ReadInt32() > 0;
                if (isEncrypted)
                {
                    // TODO: Use a stream wrapper instead; but this is blocked by an overly intertwined use of PackageStream.
                    if (LicenseeVersion >= 33)
                    {
                        var decoder = new CryptoDecoderAA2();
                        Decoder = decoder;
                    }
                    else
                    {
                        var decoder = new CryptoDecoderWithKeyAA2();
                        Decoder = decoder;

                        long nonePosition = _TablesData.NamesOffset;
                        stream.Seek(nonePosition, SeekOrigin.Begin);
                        byte scrambledNoneLength = stream.ReadByte();
                        decoder.Key = scrambledNoneLength;
                        stream.Seek(nonePosition, SeekOrigin.Begin);
                        byte unscrambledNoneLength = stream.ReadByte();
                        Debug.Assert((unscrambledNoneLength & 0x3F) == 5);
                    }
                }

                // Always one
                //int unkCount = stream.ReadInt32();
                //for (var i = 0; i < unkCount; i++)
                //{
                //    // All zero
                //    stream.Skip(24);
                //    // Always identical to the package's GUID
                //    var guid = stream.ReadGuid();
                //}

                //// Always one
                //int unk2Count = stream.ReadInt32();
                //for (var i = 0; i < unk2Count; i++)
                //{
                //    // All zero
                //    stream.Skip(12);
                //}
            }
#endif
            // Read the name table
#if TERA
            if (Build == GameBuild.BuildName.Tera) _TablesData.NamesCount = Generations.Last().NamesCount;
#endif

            if (CompressionFlags == CompressionFlags.LZO)
            {
                Stream = stream = stream.Decompress(this, _CompressedChunks);
                stream.Seek(4, SeekOrigin.Begin);
            }

            if (_TablesData.NamesCount > 0)
            {
                stream.Seek(_TablesData.NamesOffset, SeekOrigin.Begin);
                Names = new List<UNameTableItem>(_TablesData.NamesCount);
                for (var i = 0; i < _TablesData.NamesCount; ++i)
                {
                    var nameEntry = new UNameTableItem { Offset = (int)stream.Position, Index = i };
                    nameEntry.Deserialize(stream);
                    nameEntry.Size = (int)(stream.Position - nameEntry.Offset);
                    Names.Add(nameEntry);
                }
#if SPELLBORN
                // WTF were they thinking? Change DRFORTHEWIN to None
                if (Build == GameBuild.BuildName.Spellborn
                    && Names[0].Name == "DRFORTHEWIN")
                    Names[0].Name = "None";
                // False??
                //Debug.Assert(stream.Position == _TablesData.ImportsOffset);
#endif
            }

            // Read Import Table
            if (_TablesData.ImportsCount > 0)
            {
                stream.Seek(_TablesData.ImportsOffset, SeekOrigin.Begin);
                Imports = new List<UImportTableItem>(_TablesData.ImportsCount);
                ImportsIndex = new Dictionary<string, IDictionary<string, UImportTableItem>>();

                for (var i = 0; i < _TablesData.ImportsCount; ++i)
                {
                    var imp = new UImportTableItem { Offset = (int)stream.Position, Index = i, Owner = this };
                    imp.Deserialize(stream);
                    imp.Size = (int)(stream.Position - imp.Offset);
                    Imports.Add(imp);

                    if (!ImportsIndex.ContainsKey(imp.PackageName))
                        ImportsIndex.Add(imp.PackageName, new Dictionary<string, UImportTableItem>());

                    if (!ImportsIndex[imp.PackageName].ContainsKey(imp.ObjectName))
                        ImportsIndex[imp.PackageName].Add(imp.ObjectName, imp);
                }
            }

            // Read Export Table
            if (_TablesData.ExportsCount > 0)
            {
                stream.Seek(_TablesData.ExportsOffset, SeekOrigin.Begin);
                Exports = new List<UExportTableItem>(_TablesData.ExportsCount);
                for (var i = 0; i < _TablesData.ExportsCount; ++i)
                {
                    var exp = new UExportTableItem { Offset = (int)stream.Position, Index = i, Owner = this };
                    exp.Deserialize(stream);
                    exp.Size = (int)(stream.Position - exp.Offset);
                    Exports.Add(exp);
                }

                if (_TablesData.DependsOffset > 0)
                {
                    stream.Seek(_TablesData.DependsOffset, SeekOrigin.Begin);
                    var count = _TablesData.ExportsCount;
                    Depends = new List<UDependTableItem>(count);
#if BIOSHOCK
                    // FIXME: Version?
                    if (Build == GameBuild.BuildName.Bioshock_Infinite)
                    {
                        Depends = new List<UDependTableItem>(stream.ReadInt32());
                    }
#endif

                    for (var i = 0; i < count; ++i)
                    {
                        var dep = new UDependTableItem { Offset = (int)stream.Position, Index = i, Owner = this };
                        dep.Deserialize(stream);
                        dep.Size = (int)(stream.Position - dep.Offset);
                        Depends.Add(dep);
                    }

                }
            }

            if (_TablesData.ImportExportGuidsOffset > 0)
            {
                for (var i = 0; i < _TablesData.ImportGuidsCount; ++i)
                {
                    string levelName = stream.ReadText();
                    int guidCount = stream.ReadInt32();
                    stream.Skip(guidCount * 16);
                }

                for (var i = 0; i < _TablesData.ExportGuidsCount; ++i)
                {
                    var objectGuid = stream.ReadGuid();
                    int exportIndex = stream.ReadInt32();
                }
            }

            if (_TablesData.ThumbnailTableOffset != 0)
            {
                UnknownDataBeforeThumbnailInfo = new byte[_TablesData.ThumbnailTableOffset - stream.Position];
                stream.Read(UnknownDataBeforeThumbnailInfo, 0, UnknownDataBeforeThumbnailInfo.Length);

                int thumbnailCount = stream.ReadInt32();
                Thumbnails = new List<UThumbnailTableItem>(thumbnailCount);

                for (var i = 0; i < thumbnailCount; ++i)
                {
                    var dep = new UThumbnailTableItem { Offset = (int)stream.Position, Index = i, Owner = this };
                    dep.Deserialize(stream);
                    dep.Size = (int)(stream.Position - dep.Offset);
                    Thumbnails.Add(dep);
                }

            }

            Debug.Assert(stream.Position <= int.MaxValue);
            HeaderSize = (int)stream.Position;
        }

        /// <summary>
        /// Constructs all export objects.
        /// </summary>
        /// <param name="initFlags">Initializing rules such as deserializing and/or linking.</param>
        [PublicAPI]
        public void InitializeExportObjects(InitFlags initFlags = InitFlags.All)
        {
            Objects = new List<UObject>(Exports.Count);
            foreach (var exp in Exports) CreateObject(exp);

            if ((initFlags & InitFlags.Deserialize) == 0)
                return;

            DeserializeObjects();
            if ((initFlags & InitFlags.Link) != 0) LinkObjects();
        }

        /// <summary>
        /// Constructs all import objects.
        /// </summary>
        /// <param name="initialize">If TRUE initialize all constructed objects.</param>
        [PublicAPI]
        public void InitializeImportObjects(bool initialize = true)
        {
            Objects = new List<UObject>(Imports.Count);
            foreach (var imp in Imports) CreateObject(imp);

            if (!initialize) return;

            foreach (var obj in Objects) obj.PostInitialize();
        }

        /// <summary>
        /// Initializes all the objects that resist in this package as well tries to import deserialized data from imported objects.
        /// </summary>
        /// <param name="initFlags">A collection of initializing flags to notify what should be initialized.</param>
        /// <example>InitializePackage( UnrealPackage.InitFlags.All )</example>
        [PublicAPI]
        public void InitializePackage(InitFlags initFlags = InitFlags.All)
        {
            if ((initFlags & InitFlags.RegisterClasses) != 0) RegisterExportedClassTypes();

            if ((initFlags & InitFlags.Construct) == 0) return;

            ConstructObjects();

            if ((initFlags & InitFlags.Deserialize) == 0)
                return;

            try
            {
                DeserializeObjects();
            }
            catch (Exception ex)
            {
                throw new DeserializingObjectsException();
            }

            foreach (var obj in Objects)
                obj.PostInitialize();

            try
            {
                if ((initFlags & InitFlags.Link) != 0) LinkObjects();
            }
            catch
            {
                throw new LinkingObjectsException();
            }

            DisposeStream();
        }

        /// <summary>
        ///
        /// </summary>
        public class PackageEventArgs : EventArgs
        {
            /// <summary>
            /// Event identification.
            /// </summary>
            public enum Id : byte
            {
                /// <summary>
                /// Constructing Export/Import objects.
                /// </summary>
                Construct = 0,

                /// <summary>
                /// Deserializing objects.
                /// </summary>
                Deserialize = 1,

                /// <summary>
                /// Importing objects from linked packages.
                /// </summary>
                [Obsolete] Import = 2,

                /// <summary>
                /// Connecting deserialized object indexes.
                /// </summary>
                Link = 3,

                /// <summary>
                /// Deserialized a Export/Import object.
                /// </summary>
                Object = 0xFF
            }

            /// <summary>
            /// The event identification.
            /// </summary>
            [PublicAPI] public readonly Id EventId;

            /// <summary>
            /// Constructs a new event with @eventId.
            /// </summary>
            /// <param name="eventId">Event identification.</param>
            public PackageEventArgs(Id eventId)
            {
                EventId = eventId;
            }
        }

        /// <summary>
        ///
        /// </summary>
        [PublicAPI]
        public event PackageEventHandler NotifyPackageEvent;

        private void OnNotifyPackageEvent(PackageEventArgs e)
        {
            NotifyPackageEvent?.Invoke(this, e);
        }

        /// <summary>
        /// Called when an object is added to the ObjectsList via the AddObject function.
        /// </summary>
        [PublicAPI]
        public event NotifyObjectAddedEventHandler NotifyObjectAdded;

        /// <summary>
        /// Constructs all the objects based on data from _ExportTableList and _ImportTableList, and
        /// all constructed objects are added to the _ObjectsList.
        /// </summary>
        private void ConstructObjects()
        {
            Objects = new List<UObject>();
            OnNotifyPackageEvent(new PackageEventArgs(PackageEventArgs.Id.Construct));
            if (Exports == null) return;
            foreach (var exp in Exports)
                try
                {
                    CreateObject(exp);
                }
                catch (Exception exc)
                {
                    throw new UnrealException("couldn't create export object for " + exp, exc);
                }

            foreach (var imp in Imports)
                try
                {
                    CreateObject(imp);
                }
                catch (Exception exc)
                {
                    throw new UnrealException("couldn't create import object for " + imp, exc);
                }
        }

        /// <summary>
        /// Deserializes all exported objects.
        /// </summary>
        private void DeserializeObjects()
        {
            // Only exports should be deserialized and PostInitialized!
            OnNotifyPackageEvent(new PackageEventArgs(PackageEventArgs.Id.Deserialize));

            //if (Imports != null)
            //{
            //    foreach (var imp in Imports)
            //    {
            //        if (imp.PackageName != imp.Object.Package.PackageName)
            //        {
            //            var package = UnrealLoader.GetFromCache(imp.PackageName);
            //            if (package == null)
            //            {
            //                var buff = LoadImportFile(imp.PackageName);

            //                if (buff != null)
            //                {
            //                    package = UnrealLoader.LoadCachedPackage(imp.PackageName, buff);
            //                    package.InitializePackage();
            //                }
            //            }

            //            if (package != null)
            //            {
            //                var test = package.Exports.OrderBy(x => x.ObjectName.Name).ToArray();
            //                var exportObject = package.Exports.Where(x => x.ObjectName.Name == imp.ObjectName.Name).FirstOrDefault();
            //                if (exportObject != null)
            //                    imp.Object = exportObject.Object;
            //            }
            //        }
            //    }
            //}

            if (Exports != null)
            {
                foreach (var exp in Exports)
                {
                    exp.Object.BeginDeserializing();
                    exp.Object.PostInitialize();
                    OnNotifyPackageEvent(new PackageEventArgs(PackageEventArgs.Id.Object));
                }
            }


        }

        /// <summary>
        /// Initializes all exported objects.
        /// </summary>
        private void LinkObjects()
        {
            // Notify that deserializing is done on all objects, now objects can read properties that were dependent on deserializing
            OnNotifyPackageEvent(new PackageEventArgs(PackageEventArgs.Id.Link));
            if (Exports == null) return;
            foreach (var exp in Exports)
                try
                {
                    if (!(exp.Object is UnknownObject))
                        exp.Object.PostInitialize();

                    OnNotifyPackageEvent(new PackageEventArgs(PackageEventArgs.Id.Object));
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("InvalidCastException occurred on object: " + exp.Object);
                }
        }

        private void RegisterExportedClassTypes()
        {
            var exportedTypes = Assembly.GetExecutingAssembly().GetExportedTypes();
            foreach (var exportedType in exportedTypes)
            {
                object[] attributes = exportedType.GetCustomAttributes(typeof(UnrealRegisterClassAttribute), false);
                if (attributes.Length == 1) AddClassType(exportedType.Name.Substring(1), exportedType);
            }
        }

        #endregion

        #region Methods

        private void CreateObject(UObjectTableItem table)
        {
            var classType = GetClassType(table.ClassName);
            table.Object = classType == null
                ? new UnknownObject()
                : (UObject)Activator.CreateInstance(classType);
            AddObject(table.Object, table);
            OnNotifyPackageEvent(new PackageEventArgs(PackageEventArgs.Id.Object));
        }

        private void AddObject(UObject obj, UObjectTableItem table)
        {
            table.Object = obj;
            obj.Package = this;
            obj.Table = table;

            Objects.Add(obj);
            NotifyObjectAdded?.Invoke(this, new ObjectEventArgs(obj));
        }

        /// <summary>
        /// Writes the present PackageFlags to disk. HardCoded!
        /// Only supports UT2004.
        /// </summary>
        [PublicAPI]
        [Obsolete]
        public void WritePackageFlags()
        {
            Stream.Position = 8;
            Stream.Write((uint)PackageFlags);
        }

        [PublicAPI]
        [Obsolete]
        public void RegisterClass(string className, Type classObject)
        {
            AddClassType(className, classObject);
        }

        [PublicAPI]
        public void AddClassType(string className, Type classObject)
        {
            var name = className.ToLower();
            if (!_ClassTypes.ContainsKey(name))
                _ClassTypes.Add(className.ToLower(), classObject);
        }

        [PublicAPI]
        public Type GetClassType(string className)
        {
            _ClassTypes.TryGetValue(className.ToLower(), out var classType);
            return classType;
        }

        [PublicAPI]
        public bool HasClassType(string className)
        {
            return _ClassTypes.ContainsKey(className.ToLower());
        }

        [PublicAPI]
        [Obsolete]
        public bool IsRegisteredClass(string className)
        {
            return HasClassType(className);
        }

        /// <summary>
        /// Returns an Object that resides at the specified ObjectIndex.
        ///
        /// if index is positive an exported Object will be returned.
        /// if index is negative an imported Object will be returned.
        /// if index is zero null will be returned.
        /// </summary>
        [PublicAPI]
        public UObject GetIndexObject(int objectIndex)
        {
            if (objectIndex < 0)
            {
                var idx = -objectIndex - 1;
                return idx < Imports.Count
                    ? Imports[idx].Object
                    : null;
            }

            return objectIndex > 0 && Exports.Count > objectIndex - 1
                    ? Exports[objectIndex - 1].Object
                    : null;
        }

        [PublicAPI]
        public string GetIndexObjectName(int objectIndex)
        {
            return GetIndexTable(objectIndex).ObjectName;
        }

        /// <summary>
        /// Returns a name that resides at the specified NameIndex.
        /// </summary>
        [PublicAPI]
        public string GetIndexName(int nameIndex)
        {
            return Names[nameIndex].Name;
        }

        /// <summary>
        /// Returns an UnrealTable that resides at the specified TableIndex.
        ///
        /// if index is positive an ExportTable will be returned.
        /// if index is negative an ImportTable will be returned.
        /// if index is zero null will be returned.
        /// </summary>
        [PublicAPI]
        public UObjectTableItem GetIndexTable(int tableIndex)
        {
            return tableIndex < 0
                ? Imports[-tableIndex - 1]
                : tableIndex > 0
                    ? (UObjectTableItem)Exports[tableIndex - 1]
                    : null;
        }

        [PublicAPI]
        [Obsolete("See below")]
        public UObject FindObject(string objectName, Type classType, bool checkForSubclass = false)
        {
            var obj = Objects?.Find(o => string.Compare(o.Name, objectName, StringComparison.OrdinalIgnoreCase) == 0 &&
                                         (checkForSubclass
                                             ? o.GetType().IsSubclassOf(classType)
                                             : o.GetType() == classType));
            return obj;
        }

        [PublicAPI]
        public T FindObject<T>(string objectName, bool checkForSubclass = false) where T : UObject
        {
            var obj = Objects?.Find(o => string.Compare(o.Name, objectName, StringComparison.OrdinalIgnoreCase) == 0 &&
                                         (checkForSubclass
                                             ? o.GetType().IsSubclassOf(typeof(T))
                                             : o.GetType() == typeof(T)));
            return obj as T;
        }

        [PublicAPI]
        public UObject FindObjectByGroup(string objectGroup)
        {
            string[] groups = objectGroup.Split('.');
            UObject lastObj = null;
            for (var i = 0; i < groups.Length; ++i)
            {
                var obj = Objects.Find(o =>
                    string.Compare(o.Name, groups[i], StringComparison.OrdinalIgnoreCase) == 0 && o.Outer == lastObj);
                if (obj != null)
                {
                    lastObj = obj;
                }
                else
                {
                    lastObj = Objects.Find(o =>
                        string.Compare(o.Name, groups[i], StringComparison.OrdinalIgnoreCase) == 0);
                    break;
                }
            }

            return lastObj;
        }

        /// <summary>
        /// Checks whether this package is marked with @flag.
        /// </summary>
        /// <param name="flag">The enum @flag to test.</param>
        /// <returns>Whether this package is marked with @flag.</returns>
        [PublicAPI]
        public bool HasPackageFlag(PackageFlags flag)
        {
            return (PackageFlags & flag) != 0;
        }

        /// <summary>
        /// Checks whether this package is marked with @flag.
        /// </summary>
        /// <param name="flag">The uint @flag to test</param>
        /// <returns>Whether this package is marked with @flag.</returns>
        [PublicAPI]
        public bool HasPackageFlag(uint flag)
        {
            return (PackageFlags & (PackageFlags)flag) != 0;
        }

        /// <summary>
        /// Tests the packageflags of this UELib.UnrealPackage instance whether it is cooked.
        /// </summary>
        /// <returns>True if cooked or False if not.</returns>
        [PublicAPI]
        public bool IsCooked()
        {
            return HasPackageFlag(Flags.PackageFlags.Cooked) && Version >= VCOOKEDPACKAGES;
        }

        /// <summary>
        /// If true, the package won't have any editor data such as HideCategories, ScriptText etc.
        /// 
        /// However this condition is not only determined by the package flags property.
        /// Thus it is necessary to explicitly indicate this state.
        /// </summary>
        /// <returns>Whether package is cooked for consoles.</returns>
        [PublicAPI]
        public bool IsConsoleCooked()
        {
            return IsCooked() && Build.Flags.HasFlag(BuildFlags.ConsoleCooked);
        }

        /// <summary>
        /// Checks for the Map flag in PackageFlags.
        /// </summary>
        /// <returns>Whether if this package is a map.</returns>
        [PublicAPI]
        public bool IsMap()
        {
            return HasPackageFlag(Flags.PackageFlags.Map);
        }

        /// <summary>
        /// Checks if this package contains code classes.
        /// </summary>
        /// <returns>Whether if this package contains code classes.</returns>
        [PublicAPI]
        public bool IsScript()
        {
            return HasPackageFlag(Flags.PackageFlags.Script);
        }

        /// <summary>
        /// Checks if this package was built using the debug configuration.
        /// </summary>
        /// <returns>Whether if this package was built in debug configuration.</returns>
        [PublicAPI]
        public bool IsDebug()
        {
            return HasPackageFlag(Flags.PackageFlags.Debug);
        }

        /// <summary>
        /// Checks for the Stripped flag in PackageFlags.
        /// </summary>
        /// <returns>Whether if this package is stripped.</returns>
        [PublicAPI]
        public bool IsStripped()
        {
            return HasPackageFlag(Flags.PackageFlags.Stripped);
        }

        /// <summary>
        /// Tests the packageflags of this UELib.UnrealPackage instance whether it is encrypted.
        /// </summary>
        /// <returns>True if encrypted or False if not.</returns>
        [PublicAPI]
        public bool IsEncrypted()
        {
            return HasPackageFlag(Flags.PackageFlags.Encrypted);
        }

        #region IBuffered

        public byte[] CopyBuffer()
        {
            var buff = new byte[HeaderSize];
            Stream.Seek(0, SeekOrigin.Begin);
            Stream.Read(buff, 0, (int)HeaderSize);
            if (Stream.BigEndianCode) Array.Reverse(buff);

            return buff;
        }


        public IUnrealStream GetBuffer()
        {
            return Stream;
        }


        public int GetBufferPosition()
        {
            return 0;
        }


        public int GetBufferSize()
        {
            return (int)HeaderSize;
        }


        public string GetBufferId(bool fullName = false)
        {
            return fullName ? FullPackageName : PackageName;
        }

        #endregion

        /// <inheritdoc/>
        public override string ToString()
        {
            return PackageName;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Console.WriteLine("Disposing {0}", PackageName);

            DisposeStream();
            if (Objects != null && Objects.Any())
            {
                foreach (var obj in Objects)
                {
                    obj.MaybeDisposeBuffer();
                    obj.Dispose();
                }

                Objects.Clear();
                Objects = null;
            }
        }

        private void DisposeStream()
        {
            if (Stream == null)
                return;

            Console.WriteLine("Disposing package stream");
            Stream.Dispose();
        }

        #endregion
    }
}