using System;
using System.Collections.Generic;
using System.Text;

namespace Delen
{
    // Gegenereerde code
    partial class Mystery
    {
        public int Value { get; set; }

        partial void Init();

        public void Show()
        {
            Console.WriteLine($"De waarde is {Value}" );
            Init();
        }
    }
}
