using System;

namespace Delen
{
    class Program
    {
        static void Main(string[] args)
        {
            Mystery m = new Mystery { Value = 100 };
            m.Show();
            m.DoeIets();

       }
    }


    partial class Mystery
    {
        //partial void Init()
        //{
        //    Console.WriteLine("Initialize");
        //}
        public void DoeIets()
        {
            Console.WriteLine($"Val = {Value}");
        }
    }
}
