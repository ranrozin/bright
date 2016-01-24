using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bright
{
    class Log
    {
        static string _localLogFile = "brightLog.txt";
        public static void AddEntry(string line)
        {
            //string filePath = Path.Combine(Directory.GetCurrentDirectory(), _localLogFile);
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(dir, _localLogFile);
            using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                writer.WriteLine(string.Format("time: {0} - {1}",DateTime.UtcNow, line));
            }
        }
    }
}
