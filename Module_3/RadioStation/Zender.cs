using System;
using System.Collections.Generic;
using System.Text;

namespace RadioStation
{
    public delegate void OntvangstMethode(string s);

    class Zender
    {
        //private OntvangstMethode subscribers;
        public event OntvangstMethode Subscribers;
        //{
        //    add
        //    {
        //        subscribers += value;
        //    }
        //    remove
        //    {
        //        subscribers -= value;
        //    }
        //}

        public void Start()
        {
            Console.WriteLine("Zender begint met zenden");
            Subscribers?.Invoke("Hallo allemaal");
        }
    }
}
