using System;
using System.Collections.Generic;
using System.Text;

namespace TheCOmpany
{
    class Sietse : Persoon, IContract
    {
        public override void Werkt()
        {
            KanIets();
        }
        public void KanIets()
        {
            Console.WriteLine("Sietse kan goed verkopen");
        }

        public void BouwIets()
        {
            KanIets();
        }
    }
}
