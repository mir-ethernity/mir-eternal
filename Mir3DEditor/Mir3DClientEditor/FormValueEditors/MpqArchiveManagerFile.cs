namespace Mir3DClientEditor.FormValueEditors
{
    public class MpqArchiveManagerFile
    {
        public string Path { get; set; }
        public MpqArchiveManager Manager { get; set; }
        public uint FileSize { get; set; }
        public uint Flags { get; set; }
        public DateTime? FileTime { get; set; }
    }
}
