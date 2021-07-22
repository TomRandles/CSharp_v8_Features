using Microsoft.Extensions.Logging;
using System;

namespace Default_Interface_Implementation
{
    public class CustomLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            Console.WriteLine($"{level.ToString()}: Hello, this is a C# 8 feature!! {message}");
        }
    }
}