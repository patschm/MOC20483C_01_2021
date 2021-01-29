using System;
using System.Collections.Generic;
using System.Text;

namespace Bieb
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyAttribute : Attribute
    {
        public int Age { get; set; }
        public void DoeIets()
        {
            Console.WriteLine("Bla");
        }
    }
}
