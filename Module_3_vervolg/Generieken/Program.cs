using System;

namespace Generieken
{
    class Point<T, U> where T: struct
    {
        public T X { get; set; }
        public U Y { get; set; }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point<float, float> p1 = new Point<float, float>();
            float x = 10.3F;
            float y = 20.5F;
            Swap(ref x, ref y);
            Console.WriteLine($"x = {x}, y = {y}");
        }

        static void Swap<T>(ref T a, ref T b) where T: struct, IFormattable
        {
            T tmp = a;
            a = b;
            b = tmp;
        }
        //static void Swap(ref int a, ref int b)
        //{
        //    int tmp = a;
        //    a = b;
        //    b = tmp;
        //}
    }
}
