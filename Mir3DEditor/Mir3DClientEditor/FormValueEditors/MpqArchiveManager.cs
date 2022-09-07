using StormLibSharp;

namespace Mir3DClientEditor.FormValueEditors
{
    public class MpqArchiveManager
    {
        public string FilePath { get; set; }
        public MpqArchive Archive { get; set; }
        public MpqArchiveManagerFile[] ListFiles { get; internal set; }
    }
}
