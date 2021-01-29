using System;

namespace Statisch
{
    class Lift
    {
        private int currentFloor = 0;

        public int CurrentFloor
        {
            get
            {
                return currentFloor;
            }
        }
        public void Call(int target)
        {
            Console.WriteLine($"De lift zoemt naar {target}e verdieping");
            currentFloor = target;
        }
    }
}