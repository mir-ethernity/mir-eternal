using ICSharpCode.SharpZipLib.BZip2;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mir3DClientEditor.Services
{
    public class INIValue
    {
        public string Category { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public static class INI
    {
        public static List<INIValue> Read(string content)
        {
            var list = new List<INIValue>();

            var lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var category = string.Empty;

            foreach (var line in lines)
            {
                if (line[0] == ';') continue;

                var match = Regex.Match(line.Trim(), @"^\[(.+?)\]$");
                if (match.Success)
                {
                    category = match.Groups[1].Value;
                    continue;
                }

                match = Regex.Match(line, @"^(.+?)[=](.*?)$");

                if (!match.Success)
                    throw new ApplicationException("Invalid value");

                list.Add(new INIValue
                {
                    Category = category,
                    Key = match.Groups[1].Value.Trim(),
                    Value = SanitizeValue(match.Groups[2].Value)
                });
            }

            return list;
        }

        public static string Write(List<INIValue> values)
        {
            var groups = values.GroupBy(x => x.Category).ToList();
            var sb = new StringBuilder();

            foreach (var category in groups)
            {
                sb.AppendLine($"[{category.Key}]");
                foreach (var value in category)
                {
                    sb.AppendLine($"{value.Key} = \"{value.Value}\"");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static string SanitizeValue(string value)
        {
            value = value.Trim();
            value = value.Trim('"');
            return value;
        }

        public static byte[] BZip2Decompress(byte[] input, int skip)
        {
            using (var inputStream = new MemoryStream(input, skip, input.Length - skip))
            using (var outputStream = new MemoryStream())
            {
                BZip2.Decompress(inputStream, outputStream, false);
                return outputStream.ToArray();
            }
        }

        public static byte[] Deflate(byte[] input, int skip)
        {
            // see http://george.chiramattel.com/blog/2007/09/deflatestream-block-length-does-not-match.html
            // and possibly http://connect.microsoft.com/VisualStudio/feedback/details/97064/deflatestream-throws-exception-when-inflating-pdf-streams
            // for more info on why we have to skip two extra bytes because of ZLIB
            using (var inputStream = new MemoryStream(input, 2 + skip, input.Length - 2 - skip)) // skip ZLIB bytes 
            using (var deflate = new DeflateStream(inputStream, CompressionMode.Decompress))
            using (var outputStream = new MemoryStream())
            {
                var buffer = new byte[1024];
                var read = deflate.Read(buffer, 0, buffer.Length);

                while (read == buffer.Length)
                {
                    outputStream.Write(buffer, 0, read);
                    read = deflate.Read(buffer, 0, buffer.Length);
                }

                outputStream.Write(buffer, 0, read);
                return outputStream.ToArray();
            }
        }
    }
}
