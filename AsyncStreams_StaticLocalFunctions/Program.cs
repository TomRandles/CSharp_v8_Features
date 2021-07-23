using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncStreams_StaticLocalFunctions
{
    class Program
    {
        static async void Main(string[] args)
        {
            // https://www.c-sharpcorner.com/learn/learn-c-sharp-80/async-streams-static-local-functions
            Console.WriteLine("C# 8 Async Streams and Static Local Functions");
            await ExecuteAsyncStream();

            ExecuteLocalFunction();
        }

        // Async streams
        public static async Task ExecuteAsyncStream()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine($"The square of number {number.Number} is: {number.Square}");
            }
        }
        public static async IAsyncEnumerable<SquareNumber> GenerateSequence()
        {
            for (int i = 1; i <= 10; i++)
            {
                await Task.Delay(200);
                yield return new SquareNumber
                {
                    Number = i,
                    Square = i * i
                };
            }
        }

        // Static Local Functions
        public static void ExecuteLocalFunction()
        {
            Console.WriteLine(InstanceLocalMethod());
            Console.WriteLine(StaticLocalMethod());
        }
        static int InstanceLocalMethod()
        {
            int x = 7;
            return Square();
            int Square() => x * x;
        }
        static int StaticLocalMethod()
        {
            int x = 7;
            return Square(x);
            static int Square(int num) => num * num;
        }
    }

    public class SquareNumber
    {
        public int Number { get; set; }
        public int Square { get; set; }
    }
}