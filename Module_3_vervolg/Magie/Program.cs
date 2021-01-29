using System;
using System.Diagnostics;
using System.Text;

namespace Magie
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder(100000);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for(int i = 0; i < 100000; i++)
            {
                s.Append(i.ToString());
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            Point p = new Point { X = 10, Y = 20 };
            Console.WriteLine(p);
            DoeIets(p);
            Console.WriteLine(p);
        }

        private static void DoeIets(Point px)
        {
            px.X = 1000;
            px.Y = 2000;
        }
    }
}
