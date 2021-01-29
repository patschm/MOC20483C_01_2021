using System;
using System.Collections.Generic;
using System.Text;

namespace HetCern
{
    public delegate int MathDel(int x, int bliep);


    class WillemKlein
    {
        public void Bereken(MathDel calc, int a, int b)
        {
            Console.WriteLine("Willem klein gaat rekenen");
            int result = calc(a, b);



            Console.WriteLine($"Willem kraait: Het antwoord is {result}");
        }
    }
}
