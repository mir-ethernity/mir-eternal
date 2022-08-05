using ClientPacketSniffer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPacketSniffer.Services
{
    public class ManualDecodePacketService
    {
        public static void WaitEntry()
        {
            Console.WriteLine("Please, type in hex packet you want to decode, ex: ");
            Console.WriteLine("C:ee03231ab481");

            var info = Console.ReadLine();

            if (string.IsNullOrEmpty(info))
            {
                WaitEntry();
                return;
            }

            info = info.Trim().Replace(" ", "");

            var parts = info.Split(':');

            if (parts.Length != 2)
            {
                Console.WriteLine("Wrong format, expected <source>:<packet_hex>");
                WaitEntry();
                return;
            }

            var source = parts[0].ToLowerInvariant();
            var hex = parts[1];

            if (source != "c" && source != "s")
            {
                Console.WriteLine($"Unknown source: {source}, expected S => Server or C => Client");
                WaitEntry();
                return;
            }

            byte[] buffer;

            try
            {
                buffer = Enumerable.Range(0, hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                     .ToArray();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid packet, expected in HEX");
                WaitEntry();
                return;
            }

            var packetId = BitConverter.ToUInt16(buffer, 0);
            GamePacketInfo packetInfo;

            switch (source)
            {
                case "c":
                    if (!GamePacketInfoRepository.Instance.ClientPackets.TryGetValue(packetId, out packetInfo))
                    {
                        Console.WriteLine($"Packet id '{packetId}' not found in client packets");
                        WaitEntry();
                        return;
                    }
                    break;
                case "s":
                    if (!GamePacketInfoRepository.Instance.ServerPackets.TryGetValue(packetId, out packetInfo))
                    {
                        Console.WriteLine($"Packet id '{packetId}' not found in server packets");
                        WaitEntry();
                        return;
                    }
                    break;
                default:
                    WaitEntry();
                    return;
            }

            ushort length = packetInfo.Length != 0
                ? packetInfo.Length
                : BitConverter.ToUInt16(buffer, 2);

            if (buffer.Length < length)
            {
                Console.WriteLine($"Expected length {length}, but buffer has {buffer.Length} bytes");
                WaitEntry();
            }

            var decoded = new byte[buffer.Length];
            Array.Copy(buffer, decoded, buffer.Length);

            for (var i = 4; i < decoded.Length; i++)
                decoded[i] ^= 129;

            Console.WriteLine($"Packet {packetInfo.Id} ({packetInfo.Name})");
            Console.WriteLine($"Enc Data: {BitConverter.ToString(buffer)}");
            Console.WriteLine($"Dec Data: {BitConverter.ToString(decoded)}");

            WaitEntry();
        }
    }
}
