using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mir3DClientEditor
{
    public static class BufferExtensions
    {
        public static Encoding GetPosibleEncoding(this byte[] buffer)
        {
            var posibleEncoding = BitConverter.ToUInt16(buffer, 0);

            switch (posibleEncoding)
            {
                case 0xFFFE:
                    return Encoding.BigEndianUnicode;
                case 0xFEFF:
                    return Encoding.Unicode;
                default:
                    return Encoding.UTF8;
            }
        }

        public static string GetStringExcludeBOMPreamble(this Encoding encoding, byte[] bytes)
        {
            var preamble = encoding.GetPreamble();
            if (preamble?.Length > 0 && bytes.Length >= preamble.Length && bytes.Take(preamble.Length).SequenceEqual(preamble))
                return encoding.GetString(bytes, preamble.Length, bytes.Length - preamble.Length);
            else
                return encoding.GetString(bytes);
        }

        public static string DecodeString(this byte[] buffer, out Encoding encoding)
        {
            var posibleEncoding = BitConverter.ToInt16(buffer, 0);

            switch (posibleEncoding)
            {
                case -2:
                    encoding = Encoding.BigEndianUnicode;
                    return encoding.GetString(buffer, 2, buffer.Length - 2);
                case -257:
                    encoding = Encoding.Unicode;
                    return encoding.GetString(buffer, 2, buffer.Length - 2);
                default:
                    encoding = Encoding.UTF8;
                    return encoding.GetString(buffer);
            }
        }

        public static byte[] EncodeString(this string content, Encoding encoding)
        {
            var data = encoding.GetBytes(content);

            if (encoding == Encoding.BigEndianUnicode)
            {
                var buffer = new byte[2 + data.Length];
                Array.Copy(BitConverter.GetBytes((short)-2), buffer, 2);
                Array.Copy(data, 0, buffer, 2, data.Length);
                return buffer;
            }
            else if (encoding == Encoding.Unicode)
            {
                var buffer = new byte[2 + data.Length];
                Array.Copy(BitConverter.GetBytes((short)-257), buffer, 2);
                Array.Copy(data, 0, buffer, 2, data.Length);
                return buffer;
            }
            else
            {
                return data;
            }
        }
    }
}
