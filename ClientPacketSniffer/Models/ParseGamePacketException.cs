namespace ClientPacketSniffer
{
    public class ParseGamePacketException : ApplicationException
    {
        public byte PacketSource { get; set; }
        public ushort PacketId { get; set; }
        public byte[] PacketRaw { get; set; }

        public ParseGamePacketException(byte source, ushort id, byte[] raw) : base($"FALTAL!! PACKET ID NOT FOUND {id} IN SOURCE: {source}")
        {
            PacketId = id;
            PacketSource = source;
            PacketRaw = raw;
        }
    }
}
