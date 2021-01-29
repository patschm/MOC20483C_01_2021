using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            // TypeNaam varNaam;
            int? age = 0;
            // Bepaalt de scope
            {
                var name = "jan";
                Console.WriteLine(name?.Length);
            }

            Console.WriteLine(age++);

            // Expression:
            // Unary:   1 operand  en een operator
            // Binary:   2 operands en een operator
            // Ternary: 3 operands en een operator
            // Operand is een variable of een literal

            // Jump forward
            if (true)
            {

            }
            else if (true)
            {

            }
            else
            {

            }

            switch (age)
            {
                case 0:
                case 1:

                    //...
                    break;
                default:
                    {
                        //.....
                        break;
                    }

            }

            // Jump back (loop)
            int a = 0;
            for (Console.WriteLine("init"); a < 10; Console.WriteLine("HAHA"))
            {
                a++;
                if (a == 5) break;
                if (a == 6) continue;
                Console.WriteLine("hallo" + a);
            }

            while(false)
            {
                //...
            }

            do
            {

            }
            while (true);




        }
    }
}
