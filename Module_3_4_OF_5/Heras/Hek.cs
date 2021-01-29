using IEEE;
using System;

namespace Heras
{
    public class Hek : IDetectable
    {
        public void OnDetect()
        {
            Open();
        }

        public void Open()
        {
            Console.WriteLine("Het hek gaat open");
        }
    }
}
