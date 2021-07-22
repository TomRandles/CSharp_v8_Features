using System;

namespace Default_Interface_Implementation
{
    class Program
    {
        // https://www.c-sharpcorner.com/learn/learn-c-sharp-80/default-interface-implementation
        // 
        // Default interface implementation helps to add default implementation without
        // disturbing existing contracts.
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstration of the C#8 Default interface implementation \n\n");

            DefaultInterfaceImplementation.DoDivide();

            Console.ReadKey();

        }
    }
}
