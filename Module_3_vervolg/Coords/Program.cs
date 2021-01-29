using System;

namespace Coords
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point { X = 10, Y = 20 };
            Point p2 = new Point { X = 100, Y = 200 };

            Point p3 = p1 + p2;

            Console.WriteLine(p3);
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Point operator+(Point px, Point py)
        {
            return new Point { X = px.X + py.X, Y = px.Y + py.Y };
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
