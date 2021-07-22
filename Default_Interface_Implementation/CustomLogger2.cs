using Microsoft.Extensions.Logging;
using System;

namespace Default_Interface_Implementation
{
    public class CustomLogger2 : ILogger2
    {
        public void Log(LogLevel level, string message)
        {
            Console.WriteLine($"{level.ToString()}: Hello C# 8!! {message}");
        }

        // override keyword has not been added
        public void Log(Exception message)
        {
            Console.WriteLine($"From: Overridden method: Hello C# 8!! {message}");
        }
    }
}