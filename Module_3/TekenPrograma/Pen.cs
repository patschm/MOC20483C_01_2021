using System;
using System.Collections.Generic;
using System.Text;

namespace TekenPrograma
{
    class Pen
    {
        private int lineWidth = 100;

        public int LineWidth
        {
            get { return lineWidth; }
            set
            {
                if (value >= 0 && value <= 200)
                {
                    lineWidth = value;
                }
            }
        }
        public ConsoleColor Color { get; set; } = ConsoleColor.Black;

        public virtual void Write(string text)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"[with linewidth: {LineWidth}] {text}");
            Console.ResetColor();
        }

    }
}
