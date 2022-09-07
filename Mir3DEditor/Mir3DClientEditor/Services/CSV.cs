using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Mir3DClientEditor.Services
{
    public class CSV
    {
        private static CsvConfiguration _csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "\t",
            Escape = '"',
            Encoding = Encoding.Unicode,
            NewLine = "\r\n",
            Quote = '"',
            ShouldQuote = (args) => args.Field.Contains("\"") || args.Field.Contains(",") || args.Field.Contains("\t") || args.Field.Contains("\r\n"),
            BadDataFound = null
        };

        public static string[][] Read(string content)
        {
            using var tr = new StringReader(content);
            using var parser = new CsvHelper.CsvParser(tr, _csvConfig);

            var rows = new List<string[]>();

            while (parser.Read())
                rows.Add(parser.Record);

            return rows.ToArray();
        }

        public static string Write(string[][] rows)
        {
            using var writer = new StringWriter();
            using var parser = new CsvHelper.CsvWriter(writer, _csvConfig);

            foreach (var row in rows)
            {
                foreach (var field in row)
                    parser.WriteField(field);

                parser.NextRecord();
            }

            parser.Flush();

            return writer.ToString();
        }
    }
}
