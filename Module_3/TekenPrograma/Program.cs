using System;

namespace TekenPrograma
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pen p = new Pen { Color = ConsoleColor.Blue, LineWidth = 20 };
            //p.Write("Hello pen");

            Pen p2 = new Vulpen { Color = ConsoleColor.DarkGreen, LineWidth = 5 };
            p2.Write("Hallo Vulpen");
        }
    }
}
