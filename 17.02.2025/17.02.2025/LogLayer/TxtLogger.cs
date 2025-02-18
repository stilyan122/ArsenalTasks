namespace LogLayer
{
    public class TxtLogger : ILogger
    {
        public void Log(List<string> logs, string filePath)
        {
            File.AppendAllLines(filePath, logs);
            logs.Clear();
        }
    }
}
