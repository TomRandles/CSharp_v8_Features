using System;

namespace Switch_Expressions_And_Pattern_Matching
{
    class Program
    {
        // Code samples taken from: 
        // https://www.c-sharpcorner.com/learn/learn-c-sharp-80/switch-expressions-and-pattern-matching
        static void Main(string[] args)
        {
            Console.WriteLine("C# 8 Switch expressions and pattern matching updates");

            Console.ReadKey(); 
            Console.WriteLine("Traditional switch: ");
            PrimaryColor colour = PrimaryColor.Red;
            ExecuteNewSwitch(colour);

            Console.ReadKey();
            Console.WriteLine("New switch: "); 
            colour = PrimaryColor.Blue;
            ExecuteNewSwitch(colour);

            Console.ReadKey();
            Console.WriteLine("Execute property pattern");
            ExecutePropertyPattern();

            Console.ReadKey();
            Console.WriteLine("Execute tuple pattern");
            ExecuteTuplePattern();

            Console.ReadKey();
            Console.WriteLine("Execute positional pattern");
            ExecutePositionalPattern();
        }

        private static RGBColor ExecuteOldSwitch(PrimaryColor color)
        {
            switch (color)
            {
                case PrimaryColor.Red:
                    return new RGBColor(0xFF, 0x00, 0x00);
                case PrimaryColor.Green:
                    return new RGBColor(0x00, 0xFF, 0x00);
                case PrimaryColor.Blue:
                    return new RGBColor(0x00, 0x00, 0xFF);
                default:
                    throw new ArgumentException(message: "invalid color", paramName: nameof(color));
            };
        }

        // The summary of changes can be put together as follows:
        // 1. The variable name comes before the switch.
        // 2. The case and : elements are replaced with =>.
        // 3. The default case has been replaced with a _ discard.
        // 4. The bodies are no more statements but expressions.

        private static RGBColor ExecuteNewSwitch(PrimaryColor color) => color switch
        {
            PrimaryColor.Red => new RGBColor(0xFF, 0x00, 0x00),
            PrimaryColor.Green => new RGBColor(0x00, 0xFF, 0x00),
            PrimaryColor.Blue => new RGBColor(0x00, 0x00, 0xFF),
            _ => throw new ArgumentException(message: "invalid color", paramName: nameof(color))
        };

        // Property Pattern
        // Property pattern helps you to compare the properties of the object.
        public static void ExecutePropertyPattern()
        {
            Address address = new Address { State = "MN" }; 
            Console.WriteLine($"Overall price (including tax) of { address.State} is: { ComputeOverallPrice(address, 2.4M)}");  
}
        private static decimal ComputeOverallPrice(Address location, decimal price)
        =>
        location switch
        {
            { State: "MN" } => price + price * 0.78M,
            { State: "MI" } => price + price * 0.06M,
            { State: "WA" } => price + price * 0.07M,
            _ => 0M
        };

        // Tuple Pattern
        // Now let's have a look at the tuple pattern, it’s like property pattern with a difference in that it
        // uses tuple values to compare.

        public static void ExecuteTuplePattern()
        {
            (string, string, string) counties = ("India", "Australia", "England");

            var team1 = counties.Item1.ToString();
            var team2 = counties.Item3.ToString();
            Console.WriteLine($"Result of the match between {team1} and {team2} is: {ReturnWinner(team1, team2)}");
        }

        private static string ReturnWinner(string team1, string team2)
        => (team1, team2) switch
        {
            ("India", "Australia") => "Australia is covered by India. India wins.",
            ("Australia", "England") => "Australia breaks England. Australia wins.",
            ("India", "England") => "India covers England. India wins.",
            (_, _) => "tie"
        };

        // Positional Pattern
        // Apart from properties and tuples, patterns can be matches even for positions.Positional pattern matching
        // works with the help of deconstructor introduced in C# 7.

        public static void ExecutePositionalPattern()
        {
            Point point = new Point(5, 10);
            Console.WriteLine($"Quadrant of point {point.X} and {point.Y} is: {FindQuadrant(point)}");
        }

        private static Quadrant FindQuadrant(Point point) => point switch
        {
            (0, 0) => Quadrant.Origin,
            var (x, y) when x > 0 && y > 0 => Quadrant.One,
            var (x, y) when x < 0 && y > 0 => Quadrant.Two,
            var (x, y) when x < 0 && y < 0 => Quadrant.Three,
            var (x, y) when x > 0 && y < 0 => Quadrant.Four,
            var (_, _) => Quadrant.OnBorder,
            _ => Quadrant.Unknown
        };
    }
}