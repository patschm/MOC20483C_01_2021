using System;

namespace HetCern
{
    class Program
    {
        static void Main(string[] args)
        {
            WillemKlein wk = new WillemKlein();
            SimonVDMeer sm = new SimonVDMeer();
            //wk.Bereken(sm.Add, 2, 3);
            //wk.Bereken(sm.Subtract, 4, 5);

            MathDel m1 = sm.Add;
            m1 += sm.Add;
            m1 += sm.Subtract;
            m1 -= sm.Add;
            m1 += sm.Subtract;

            foreach(var fn in m1.GetInvocationList())
            {
                Console.WriteLine(fn.Method.Name);
            }

            Console.WriteLine(m1(1,2));

        }
    }
}
