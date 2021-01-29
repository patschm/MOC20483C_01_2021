using System;
using System.Linq;

namespace Subs
{
    class Program
    {
        static void Main(string[] args)
        {

            int res = TelOp(1,2,3,4,5, 6 );
            ShowNumber(b:56, a:2);

            int a;
            DoeIets(out a);
            Console.WriteLine(a);


        }

        static void DoeIets(out int x)
        {
            x = 100;
        }

        // Procedures: Geven niks terug
        static void ShowNumber(int a = 42, int b = 20)
        {
            Console.WriteLine($"b={b}");
            Console.WriteLine($"Het getal is {a}");
        }

        // Functions: Geven altijd iets terug
        static int TelOp(params int[] nrs)
        {
            return nrs.Sum();
        }

    }
}
