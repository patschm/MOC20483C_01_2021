using IEEE;
using System;

namespace DoomsdayPreppers
{
    public class Valkuil : IDetectable
    {
        public void OnDetect()
        {
            Open();
        }

        public void Open()
        {
            Console.WriteLine("De valkuil opent");
        }
    }
}
