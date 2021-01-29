using System;

namespace TafelsVan10
{
    class Program
    {
        static void Main(string[] args)
        {
           for(int tafel = 1; tafel <=10; tafel++)
            {
                Console.WriteLine($"De tafel van {tafel}");
                for (int teller = 1; teller <= 10; teller++)
                {
                    int res = teller * tafel;
                    Console.WriteLine($"{teller, -2} x {tafel} = {res}");
                    //Console.WriteLine("{0} x {1} = {2}", teller, tafel, res);
                }
            }
        }
    }
}
