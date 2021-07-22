using System;

namespace Default_Interface_Implementation
{
    public class DefaultInterfaceImplementation
    {
        public static void DoDivide()
        {
            try
            {
                int a = 3;
                int b = 0;
                int c = a / b;
            }
            catch (DivideByZeroException ex)
            {
                ILogger logger = new CustomLogger(); // Converting to interface                 
                logger.Log(ex); // Calling new Log overload  

                CustomLogger loggerAlt = new CustomLogger();
                // logger2.Log(ex);
                // Compile time error: "There is no argument given that corresponds to the
                // required formal parameter 'message' of 'CustomLogger.Log(LogLevel, string)"
                // simpy because CustomLogger class has no information about default interface
                // members.

                ILogger2 logger2 = new CustomLogger2(); // Converting to interface                 
                logger2.Log(ex); // Calling new Log overload  

            }
        }
    }
}