using System;

namespace Statisch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We beginnen");
            Etage.Elevator.Call(56);

            Etage[] flat = new Etage[40];
            for(int i = 0; i < flat.Length;i++)
            {
                flat[i] = new Etage { EtageNummer = i + 1 };
            }
            //flat[31].Elevator.Call(23);
            flat[31].CallLift();

            foreach(Etage et in flat)
            {
                et.ShowLiftStatus();
            }


        }
    }
}
