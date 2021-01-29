using System;
using System.Collections.Generic;
using System.Text;

namespace Laziness
{
    delegate void DelIets();

    class Sietse
    {
        public void VoerUit(DelIets functie)
        {
            Console.WriteLine("Sietse krijgt een opdracht");
            functie();
        }
    }
}
