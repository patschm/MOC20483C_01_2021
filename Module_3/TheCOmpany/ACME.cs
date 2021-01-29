using System;
using System.Collections.Generic;
using System.Text;

namespace TheCOmpany
{
    class ACME
    {
        private IContract werknemer { get; set; }

        public void Hire(IContract p)
        {
            werknemer = p;
        }

        public void Produceer()
        {
            Console.WriteLine("ACME gaat aan de slag");
            werknemer.BouwIets();
        }
    }
}
