using System;

namespace TheCOmpany
{
    class Program
    {
        static void Main(string[] args)
        {
            // Oerknal

            Patrick patrick = new Patrick();
            ACME acme = new ACME();
            Sietse sietse = new Sietse();
            Bokito bokito = new Bokito();
            acme.Hire(sietse);

            acme.Produceer();

        }
    }
}
