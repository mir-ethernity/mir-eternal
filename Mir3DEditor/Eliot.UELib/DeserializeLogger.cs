using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UELib
{
    public class DeserializeLogger
    {
        private static List<string> _logs = new List<string>();

        public static void Log(string message)
        {
            _logs.Add(message);
        }

        public static void Save()
        {
            var content = string.Join("\n", _logs);
            File.WriteAllText("./logs.txt", content);
        }
    }
}
