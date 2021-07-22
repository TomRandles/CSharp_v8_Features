using System;
using Microsoft.Extensions.Logging;

namespace Default_Interface_Implementation
{
    interface ILogger
    {
        void Log(LogLevel level, string message);
        void Log(Exception ex) => Log(LogLevel.Error, ex.ToString());
    }
}
