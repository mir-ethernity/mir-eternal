namespace ClientPacketSniffer
{
    public class PacketParsed
    {
        public int PID;
        public byte[] Data = Array.Empty<byte>();
        public GamePacketInfo PacketInfo;

        public string Hex
        {
            get
            {
                if(PacketInfo.Length == 0)
                {
                    var output = new byte[Data.Length + 2];
                    Array.Copy(BitConverter.GetBytes((ushort)Data.Length), 0, output, 0, 2);
                    Array.Copy(Data, 0, output, 2, Data.Length);
                    return BitConverter.ToString(output);
                }
                else
                {
                    return BitConverter.ToString(Data, 0, Data.Length);
                }
            }
        }

        public string GMCommand
        {
            get
            {
                return $"@Buffer wiz {Hex}";
            }
        }

        public override string ToString()
        {
            return $"{PacketInfo} - {{{(PacketInfo.Length == 0 ? string.Join(",", BitConverter.GetBytes((ushort)Data.Length).Select(x => x.ToString()).ToArray()) : "")}}} {{{string.Join(",", Data.Select(x => x.ToString()).ToArray())}}}";
        }
    }
}
