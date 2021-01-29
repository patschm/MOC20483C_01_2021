using System;
using System.Collections.Generic;
using System.Text;

namespace Statisch
{
    class Etage
    {
        public int EtageNummer { get; set; }
        public static Lift Elevator { get; set; } = new Lift();

        public void CallLift()
        {
            Elevator.Call(this.EtageNummer);
        }
        public void ShowLiftStatus()
        {
            Console.WriteLine($"Lift op de {Elevator.CurrentFloor}e verdieping");
        }

        static Etage()
        {
            Etage.Elevator = new Lift();
        }
    }
}
