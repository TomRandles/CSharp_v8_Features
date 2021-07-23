using System;

namespace NullableReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# v8 Nullable Reference Types");

            ExecuteNonNullableReferenceType();
            ExecuteNullableReferenceType();
            ExecuteNullableReferenceType2();
        }

        public static void ExecuteNonNullableReferenceType()
        {
            #nullable enable
            string name = null;
            var myName = name.ToString();
            #nullable restore
        }

        public static void ExecuteNullableReferenceType()
        {
            #nullable enable
            string? name = null;
            var myName = name.ToString();
            #nullable restore
        }
        public static void ExecuteNullableReferenceType2()
        {
            #nullable enable
            string? name = null;
            var myName = name!.ToString(); // Null Forgiving Operator   
            #nullable restore
        }


    }
}