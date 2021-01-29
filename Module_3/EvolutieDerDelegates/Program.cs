using System;

namespace EvolutieDerDelegates
{
    delegate int MathDel(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            // NET 1.0/1.1
            MathDel m1 = new MathDel(Add);
            int result = m1(1, 2);

            // NET 2.0 (2005)
            MathDel m2 = Add;
            result = m2(2, 3);

            int c = 10;
            MathDel m3 = delegate (int a, int b)
            {
                return a + b;
            };
            result = m3(3, 4);

            // NET 3.0
            MathDel m4 = (a, b) => a + b;         
            result = m4(4, 5);

            // Procedures
            Action<string> a1 = (s) => Console.WriteLine(s);
            a1("Hoi");
            // Functions
            Func<int, int, int> m5 = Add;
            result = m5(5, 6);

            // NET 2019
            int InlineAdd(int a, int b)
            {
                return a + b;
            }
            result = InlineAdd(6, 7);
            Console.WriteLine(result);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
