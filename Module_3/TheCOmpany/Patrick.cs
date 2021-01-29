using System;
using System.Collections.Generic;
using System.Text;

namespace TheCOmpany
{
    class Patrick : Persoon, IContract
    {
        public override void Werkt()
        {
            DoetMaarWat();
        }
        public void DoetMaarWat()
        {
            Console.WriteLine("Patrick klooit wat aan");
        }

        public void BouwIets()
        {
            DoetMaarWat();
        }
    }
}
