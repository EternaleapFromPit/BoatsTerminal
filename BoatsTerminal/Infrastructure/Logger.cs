namespace BoatsTerminal.Infrastructure
{
    public class Logger : ILogger
    {
        public void Log(string value)
        {
            Console.WriteLine(value);
        }
    }
}
