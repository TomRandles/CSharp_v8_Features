using Microsoft.Extensions.Logging;
using System;

namespace Default_Interface_Implementation
{
    interface ILogger2
    {
        // C# 8 regular interface members are classified as abstract and default interface
        // members are designed as virtual and hence declaring them as abstract or virtual
        // doesn't throw any error.

        // Making default interface members as virtual gives the flexibility to extend their
        // implementations based on the requirement.
        abstract void Log(LogLevel level, string message);
        virtual void Log(Exception ex) => Log(LogLevel.Error, ex.ToString());
    }
}