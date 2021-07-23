using System;
using System.Linq;

namespace Ranges_And_Indices
{
    class Program
    {
        // https://www.c-sharpcorner.com/learn/learn-c-sharp-80/ranges-and-indices

        private readonly static string[] weeks = new string[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };
        static void Main()
        {
            Console.WriteLine("C# v8 ranges and Indices examples");

            ExecuteOldRangeIndicesHandling();
            ExecuteNewRangeIndicesHandling();
            ExecuteUnboundedRange();
        }

        public static void ExecuteOldRangeIndicesHandling()
        {
            // Traditional approach
            Console.WriteLine($"Third element of an array is: {weeks[2]}");
            Console.WriteLine($"Second last element of an array is: {weeks[weeks.Length-2]}");

            var midWeeks = weeks.ToList().GetRange(2, 3);
            Console.WriteLine("Elements of midWeeks array are:");

            foreach (var week in midWeeks)
            {
                Console.WriteLine(week);
            }
            var endofWeeks = weeks.ToList().GetRange(5, 2);
            Console.WriteLine("Elements of endofWeeks array are:");

            foreach (var week in endofWeeks)
            {
                Console.WriteLine(week);
            }
        }
        public static void ExecuteNewRangeIndicesHandling()
        {
            Index idx = 2;
            Console.WriteLine($"\nThird element of an array is: {weeks[idx]}");
            Console.WriteLine($"Second last element of an array is: {weeks[^2]}");
            Range range = 2..5;

            //Start from 2nd index and goes before 5th index means index 2, 3 and 4  
            var midWeeks = weeks[range]; 
            Console.WriteLine("Elements of midWeeks array are:"); 
            foreach (var week in midWeeks)
            {
                Console.WriteLine(week);
            }

            Console.WriteLine("Elements of endofWeeks array are:");
            var endofWeeks = weeks[^2..^0]; 
            foreach (var week in endofWeeks)
            {
                Console.WriteLine(week);
            }
        }
        public static void ExecuteUnboundedRange()
        {
            var midWeeks = weeks[..3]; 
            // Start from 0th and goes before 3rd index means index 0, 1 and 2  
            Console.WriteLine("First three elements of midWeeks array are:");
            foreach (var week in midWeeks)
            {
                Console.WriteLine(week);
            }
            Console.WriteLine("last two elements of endofWeeks array are:");
            var endofWeeks = weeks[^2..];
            foreach (var week in endofWeeks)
            {
                Console.WriteLine(week);
            }
        }
    }
}