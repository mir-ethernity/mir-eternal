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

    public sealed partial class UnrealPackage
    {
        // TODO: Move to UnrealBuild.cs
        public sealed class GameBuild : object
        {
            [UsedImplicitly]
            [AttributeUsage(AttributeTargets.Field)]
            private sealed class BuildDecoderAttribute : Attribute
            {
                private readonly Type _BuildDecoder;

                public BuildDecoderAttribute(Type buildDecoder)
                {
                    _BuildDecoder = buildDecoder;
                }

                public IBufferDecoder CreateDecoder()
                {
                    return (IBufferDecoder)Activator.CreateInstance(_BuildDecoder);
                }
            }

            [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
            private sealed class BuildAttribute : Attribute
            {
                private readonly int _MinVersion;
                private readonly int _MaxVersion;
                private readonly uint _MinLicensee;
                private readonly uint _MaxLicensee;

                public readonly BuildGeneration Generation;
                public readonly BuildFlags Flags;

                private readonly bool _VerifyEqual;

                public BuildAttribute(int minVersion, uint minLicensee,
                    BuildGeneration gen = BuildGeneration.Undefined)
                {
                    _MinVersion = minVersion;
                    _MinLicensee = minLicensee;
                    Generation = gen;
                    _VerifyEqual = true;
                }


                public BuildAttribute(int minVersion, uint minLicensee,
                    BuildFlags flags,
                    BuildGeneration gen = BuildGeneration.Undefined)
                {
                    _MinVersion = minVersion;
                    _MinLicensee = minLicensee;
                    Flags = flags;
                    Generation = gen;
                    _VerifyEqual = true;
                }

                public BuildAttribute(int minVersion, int maxVersion, uint minLicensee, uint maxLicensee,
                    BuildGeneration gen = BuildGeneration.Undefined)
                {
                    _MinVersion = minVersion;
                    _MaxVersion = maxVersion;
                    _MinLicensee = minLicensee;
                    _MaxLicensee = maxLicensee;
                    Generation = gen;
                }

                public BuildAttribute(int minVersion, int maxVersion, uint minLicensee, uint maxLicensee,
                    BuildFlags flags,
                    BuildGeneration gen = BuildGeneration.Undefined)
                {
                    _MinVersion = minVersion;
                    _MaxVersion = maxVersion;
                    _MinLicensee = minLicensee;
                    _MaxLicensee = maxLicensee;
                    Flags = flags;
                    Generation = gen;
                }

                public bool Verify(GameBuild gb, UnrealPackage package)
                {
                    return _VerifyEqual
                        ? package.Version == _MinVersion && package.LicenseeVersion == _MinLicensee
                        : package.Version >= _MinVersion && package.Version <= _MaxVersion
                                                         && package.LicenseeVersion >= _MinLicensee
                                                         && package.LicenseeVersion <= _MaxLicensee;
                }
            }

            // Note: Some builds use the EngineVersion to represent as the LicenseeVersion, e.g Unreal2 and DCUO.
            public enum BuildName
            {
                Unset,
                Default,
                Unknown,

                /// <summary>
                /// Standard
                /// 61/000
                /// </summary>
                [Build(61, 0)] Unreal1,

                /// <summary>
                /// Standard, Unreal Tournament & Deus Ex
                /// 68:69/000
                /// </summary>
                [Build(68, 69, 0u, 0u)] UT,

                /// <summary>
                /// Deus Ex: Invisible War
                /// Missing support for custom classes such as BitfieldProperty and BitfieldEnum among others.
                /// 95/69
                /// </summary>
                [Build(95, 69, BuildGeneration.Thief)] DeusEx_IW,

                /// <summary>
                /// Thief: Deadly Shadows
                /// 95/133
                /// </summary>
                [Build(95, 133, BuildGeneration.Thief)]
                Thief_DS,

                /// <summary>
                /// 99:117/005:008
                /// Latest patch? Same structure as UT2004's UE2.5
                /// 121/029 (Overlapped with UT2004)
                /// </summary>
                [Build(99, 117, 5u, 8u)] UT2003,

                /// <summary>
                /// 100/058
                /// </summary>
                [Build(100, 58)] XIII,

                /// <summary>
                /// 110/2609
                /// </summary>
                [Build(110, 2609)] Unreal2,

                /// <summary>
                /// Tom Clancy's Rainbow Six 3: Raven Shield
                /// 118/011:014
                /// </summary>
                [Build(118, 118, 11u, 14u)] R6RS,

                /// <summary>
                /// Unreal II: eXpanded MultiPlayer
                /// 126/000
                /// </summary>
                [Build(126, 0)] Unreal2XMP,

                /// <summary>
                /// 118:128/025:029
                /// (Overlaps latest UT2003)
                /// </summary>
                [Build(118, 128, 25u, 29u, BuildGeneration.UE2_5)]
                UT2004,

                /// <summary>
                /// Built on UT2004
                /// Represents both AAO and AAA
                /// 128/032:033
                /// </summary>
                [Build(128, 128, 32u, 33u, BuildGeneration.UE2_5)]
                AA2,

                // IrrationalGames/Vengeance - 129:143/027:059

                /// <summary>
                /// Tribes: Vengeance
                /// </summary>
                [Build(130, 27, BuildGeneration.Vengeance)]
                Tribes_VG,

                /// <summary>
                /// 129/027
                /// </summary>
                [Build(129, 27, BuildGeneration.Vengeance)]
                Swat4,

                /// <summary>
                /// BioShock 1 & 2
                /// 130:143/056:059
                /// </summary>
                [Build(130, 143, 56u, 59u, BuildGeneration.Vengeance)]
                BioShock,

                /// <summary>
                /// The Chronicles of Spellborn
                /// 
                /// Built on UT2004
                /// 159/029
                /// Comes with several new non-standard UnrealScript features, these are however not supported.
                /// </summary>
                [Build(159, 29u, BuildGeneration.UE2_5)]
                Spellborn,

                /// <summary>
                /// 369/006
                /// </summary>
                [Build(369, 6)] RoboBlitz,

                /// <summary>
                /// 421/011
                /// </summary>
                [Build(421, 11)] MOHA,

                /// <summary>
                /// 472/046
                /// </summary>
                [Build(472, 46, BuildFlags.ConsoleCooked)]
                MKKE,

                /// <summary>
                /// 490/009
                /// </summary>
                [Build(490, 9)] GoW1,

                /// <summary>
                /// 512/000
                /// </summary>
                [Build(512, 0)] UT3,

                /// <summary>
                /// 536/043
                /// </summary>
                [Build(536, 43)] MirrorsEdge,

                /// <summary>
                /// 539/091
                /// </summary>
                [Build(539, 91)] AlphaProtcol,

                /// <summary>
                /// 547/028:032
                /// </summary>
                [Build(547, 547, 28u, 32u)] APB,

                /// <summary>
                /// 575/000
                /// Xenon is enabled here, because the package is missing editor data, the editor data of UStruct is however still serialized.
                /// </summary>
                [Build(575, 0, BuildFlags.XenonCooked)]
                GoW2,

                /// <summary>
                /// 576/005
                /// </summary>
                [Build(576, 5)] CrimeCraft,

                /// <summary>
                /// 576/021
                /// 
                /// No Special support, but there's no harm in recognizing this build.
                /// </summary>
                [Build(576, 21)] Batman1,

                /// <summary>
                /// 576/100
                /// </summary>
                [Build(576, 100)] Homefront,

                /// <summary>
                /// Medal of Honor (2010)
                /// Windows, PS3, Xbox 360
                /// Defaulting to ConsoleCooked.
                /// XenonCooked is required to read the Xbox 360 packages.
                /// 581/058
                /// </summary>
                [Build(581, 58, BuildFlags.ConsoleCooked)]
                MOH,

                /// <summary>
                /// 584/058
                /// </summary>
                [Build(584, 58)] Borderlands,

                /// <summary>
                /// 584/126
                /// </summary>
                [Build(584, 126)] Singularity,

                /// <summary>
                /// 590/001
                /// </summary>
                [Build(590, 1, BuildFlags.XenonCooked)]
                ShadowComplex,

                /// <summary>
                /// 610/014
                /// </summary>
                [Build(610, 14)] Tera,

                /// <summary>
                /// 648/6405
                /// </summary>
                [Build(648, 6405)] DCUO,

                [Build(687, 111)] DungeonDefenders2,

                /// <summary>
                /// 727/075
                /// </summary>
                [Build(727, 75)] Bioshock_Infinite,

                /// <summary>
                /// 742/029
                /// </summary>
                [Build(742, 29, BuildFlags.ConsoleCooked)]
                BulletStorm,

                /// <summary>
                /// 801/030
                /// </summary>
                [Build(801, 30)] Dishonored,

                /// <summary>
                /// 828/000
                /// </summary>
                [Build(788, 1, BuildFlags.ConsoleCooked)]
                [Build(828, 0, BuildFlags.ConsoleCooked)]
                InfinityBlade,

                /// <summary>
                /// 828/000
                /// </summary>
                [Build(828, 0, BuildFlags.ConsoleCooked)]
                GoW3,

                /// <summary>
                /// 832/021
                /// </summary>
                [Build(832, 21)] RememberMe,

                /// <summary>
                /// 832/046
                /// </summary>
                [Build(832, 46)] Borderlands2,

                /// <summary>
                /// 842/001
                /// </summary>
                [Build(842, 1, BuildFlags.ConsoleCooked)]
                InfinityBlade2,

                /// <summary>
                /// 845/059
                /// </summary>
                [Build(845, 59)] XCOM_EU,

                /// <summary>
                /// 845/120
                /// </summary>
                [Build(845, 120)] XCOM2WotC,

                /// <summary>
                /// 846/181
                /// </summary>
                [Build(511, 039)] // The Bourne Conspiracy
                [Build(511, 145)] // Transformers: War for Cybertron (PC version)
                [Build(511, 144)] // Transformers: War for Cybertron (PS3 and XBox 360 version)
                [Build(537, 174)] // Transformers: Dark of the Moon
                [Build(846, 181, 2, 1)]
                // FIXME: The serialized version is false, needs to be adjusted.
                // Transformers: Fall of Cybertron
                Transformers,

                /// <summary>
                /// 860/004
                /// </summary>
                [Build(860, 4)] Hawken,

                /// <summary>
                /// 805-6/101-3
                /// 807/137-8
                /// 807/104
                /// 863/32995
                /// </summary>
                [Build(805, 101, BuildGeneration.Batman2)]
                [Build(806, 103, BuildGeneration.Batman3)]
                [Build(807, 807, 137, 138, BuildGeneration.Batman3)]
                [Build(807, 104, BuildGeneration.Batman3MP)]
                [Build(863, 32995, BuildGeneration.Batman4)]
                BatmanUDK,

                /// <summary>
                /// 867/009:032
                /// Requires third-party decompression and decryption
                /// </summary>
                [Build(867, 868, 9u, 32u)] RocketLeague,

                /// <summary>
                /// 904/009
                /// </summary>
                [Build(904, 904, 09u, 014u)] SpecialForce2,
            }

            public BuildName Name { get; }

            public uint Version { get; }
            public uint LicenseeVersion { get; }

            /// <summary>
            /// Is cooked for consoles.
            /// </summary>
            [Obsolete("See BuildFlags", true)]
            public bool IsConsoleCompressed { get; }

            /// <summary>
            /// Is cooked for Xenon(Xbox 360). Could be true on PC games.
            /// </summary>
            [Obsolete("See BuildFlags", true)]
            public bool IsXenonCompressed { get; }

            public BuildGeneration Generation { get; }

            public readonly BuildFlags Flags;

            public GameBuild(UnrealPackage package)
            {
                if (UnrealConfig.Platform == UnrealConfig.CookedPlatform.Console) Flags |= BuildFlags.ConsoleCooked;

                var gameBuilds = (BuildName[])Enum.GetValues(typeof(BuildName));
                foreach (var gameBuild in gameBuilds)
                {
                    var gameBuildMember = typeof(BuildName).GetMember(gameBuild.ToString());
                    if (gameBuildMember.Length == 0)
                        continue;

                    object[] attribs = gameBuildMember[0].GetCustomAttributes(false);
                    var game = attribs.OfType<BuildAttribute>().SingleOrDefault(attr => attr.Verify(this, package));
                    if (game == null)
                        continue;

                    Version = package.Version;
                    LicenseeVersion = package.LicenseeVersion;
                    Flags = game.Flags;
                    Generation = game.Generation;

                    Name = (BuildName)Enum.Parse(typeof(BuildName), Enum.GetName(typeof(BuildName), gameBuild));
                    if (package.Decoder != null) break;

                    var buildDecoderAttr =
                        attribs.SingleOrDefault(attr => attr is BuildDecoderAttribute) as BuildDecoderAttribute;
                    if (buildDecoderAttr == null)
                        break;

                    package.Decoder = buildDecoderAttr.CreateDecoder();
                    break;
                }

                if (Name == BuildName.Unset)
                    Name = package.LicenseeVersion == 0 ? BuildName.Default : BuildName.Unknown;
            }

            public static bool operator ==(GameBuild b, BuildName i)
            {
                return b != null && b.Name == i;
            }

            public static bool operator !=(GameBuild b, BuildName i)
            {
                return b != null && b.Name != i;
            }

            /// <inheritdoc/>
            public override bool Equals(object obj)
            {
                return Name == (BuildName)obj;
            }

            /// <inheritdoc/>
            public override int GetHashCode()
            {
                return (int)Name;
            }

            public bool HasFlags(BuildFlags flags)
            {
                return (Flags & flags) == flags;
            }
        }

    }
}