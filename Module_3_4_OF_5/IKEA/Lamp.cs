using IEEE;
using System;

namespace IKEA
{
    public class Lamp : IDetectable
    {
        public void Aan()
        {
            throw new Exception("Ooops");
            Console.WriteLine("De lamp gaat aan");
        }

        public void OnDetect()
        {
            Aan();
        }
    }
}
