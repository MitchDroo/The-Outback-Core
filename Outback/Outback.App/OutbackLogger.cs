using System;

namespace Outback.App
{
    public class OutbackLogger : IOutbackLogger
    {
        public void LogDebug(string text)
        {
            Console.WriteLine($"[DEBUG]: {text}");
        }
    }
}