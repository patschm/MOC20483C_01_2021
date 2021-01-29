using System;

namespace ALib
{
    public class Person
    {
        private int age;

        public int Age
        {
            get { return age; }
            set { if (value >= 0 && value < 123) age = value; }
        }

        public string Name { get; set; }

        public void Introduce()
        {
            Console.WriteLine($"Hello, I'm {Name} ({Age} years old)");
        }
    }
}
