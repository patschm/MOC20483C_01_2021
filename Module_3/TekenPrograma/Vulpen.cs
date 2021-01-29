using System;
using System.Collections.Generic;
using System.Text;

namespace TekenPrograma
{
    class Vulpen : Pen
    {
        private int writeCount = 10;

        public void Refill()
        {
            writeCount = 10;
        }

        public override void Write(string text)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"Vulpen [with linewidth: {LineWidth}] {text}. Kan nu nog {--writeCount} schrijven");
            Console.ResetColor();
        }
    }
}
