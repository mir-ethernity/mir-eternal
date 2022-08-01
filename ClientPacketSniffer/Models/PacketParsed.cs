namespace ClientPacketSniffer
{
    public class PacketParsed
    {
        public int PID;
        public byte[] Data = Array.Empty<byte>();
        public GamePacketInfo PacketInfo;

        public override string ToString()
        {
            return $"{PacketInfo} - {{{(PacketInfo.Length == 0 ? string.Join(",", BitConverter.GetBytes((ushort)Data.Length).Select(x => x.ToString()).ToArray()) : "")}}} {{{string.Join(",", Data.Select(x => x.ToString()).ToArray())}}}";
        }
    }
}
