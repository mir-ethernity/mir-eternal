namespace ClientPacketSniffer
{
    public struct GamePacketInfo
    {
        public byte Source;
        public string Name;
        public ushort Id;
        public ushort Length;

        public override string ToString()
        {
            return $"{(Source == 0 ? "C->S" : "S-C")}: {Id} ({Name}) - Len: {Length}";
        }
    }
}
