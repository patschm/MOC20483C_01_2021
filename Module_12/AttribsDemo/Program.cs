using Bieb;
using System;
using System.Linq;

namespace AttribsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();
            DoeIets(p);
        }

        private static void DoeIets(object p)
        {
            Type tp = p.GetType();
            var attrs = tp.GetCustomAttributes(typeof(MyAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                MyAttribute ma = attrs.FirstOrDefault() as MyAttribute;
                if (ma.Age > 50)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }

    [My(Age = 67)]
    class Point
    {
    }

}
