using System;
using System.Collections.Generic;
using System.IO;

namespace ReadOnly_Struct_Member
{
    class Program
    {
        static void Main()
        {
            // https://www.c-sharpcorner.com/learn/learn-c-sharp-80/readonly-struct-member
            Console.WriteLine("C# 8 - Readonly Struct Members");
        }

        public static void ExecuteUsingFunction()
        {
            List<string> messages = new List<string>(); messages.Add("Hello C# 8 users!!"); 
            messages.Add("How are you!!"); 
            ExecuteOldUsingFunction(messages); 
            ExecuteNewUsingFunction(messages);
        }
        static void ExecuteOldUsingFunction(IEnumerable<string> lines)
        {
            using (var file = new StreamWriter("file.txt"))
            {
                foreach (string line in lines)
                {
                    if (!line.Contains("C# 8"))
                    {
                        file.WriteLine(line);
                    }
                }
            } // file is disposed here automatically  
        }

        static void ExecuteNewUsingFunction(IEnumerable<string> lines)
        {
            using var file = new StreamWriter("file.txt"); 
            foreach (string line in lines)
            {
                if (!line.Contains("C# 8"))
                {
                    file.WriteLine(line);
                }
            }
            // file is disposed here automatically  
        }
    }

    // Read-only struct members
    public struct Distance
    {
        public double X { get; set; }
        public double Y { get; set; }
        public readonly double PointDistance => Math.Sqrt(X * X + Y * Y);
        public readonly override string ToString() =>
        $"({X}, {Y}) is {PointDistance} from the origin point";
    }
}
