using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04._02._2025
{
    public interface ILog
    {
        void Log(string message);
        void Save(string filePath);
    }
}
