using DoomsdayPreppers;
using Heras;
using IKEA;
using Infrac;
using System;

namespace Oprijlaan
{
    class Program
    {
        static void Main(string[] args)
        {
            DetectieLus lus = new DetectieLus();
            Hek hek = new Hek();
            Lamp tl = new Lamp();
            Valkuil kuil = new Valkuil();
            lus.Connect(hek.Open);
            lus.Connect(tl.Aan);
            lus.Connect(kuil.Open);

            lus.Detect();    
        }
    }
}
