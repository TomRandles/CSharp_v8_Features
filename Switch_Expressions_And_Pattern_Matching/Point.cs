using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Switch_Expressions_And_Pattern_Matching
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y) => (X, Y) = (x, y); public void Deconstruct(out int x, out int y)
        {
            (x, y) = (X, Y);
        }
    }
}