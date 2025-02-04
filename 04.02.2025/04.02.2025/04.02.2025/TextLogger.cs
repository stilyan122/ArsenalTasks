using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._02._2025
{
    public class TextLogger : ILog
    {
        private List<string> logs = new List<string>();

        public void Log(string message)
        {
            logs.Add(message);
        }

        public void Save(string filePath)
        {
            File.WriteAllLines("../../../Output/"+filePath, logs);
        }
    }
}
