using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array
            int[] rij;
            rij = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            rij[0] = 9;

            int[,] matrix = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,,] kubus = new int[3, 3, 3];

            int[][] jagged = new int[3][];
            jagged[0] = new int[10];
            jagged[1] = new int[5];


            for (int i = 0; i < rij.Length; i++)
            {
                int tmp = rij[i];
                Console.WriteLine(tmp);
            }

            foreach(int tmp in rij)
            {
                Console.WriteLine(tmp);
            }

            // Ouwe meuk
            ArrayList olist = new ArrayList();
            olist.Add(1);
            olist.Add("2");

            Queue oqueue = new Queue();
            //oqueue.co

            Stack ostack = new Stack();
            ostack.Push(2);
            var data = ostack.Pop();

            Hashtable odict = new Hashtable();
            odict.Add("een", 1);

            // Nieuwe
            List<int> nlist = new List<int>();

            Queue<int> nqueue = new Queue<int>();
            nqueue.Enqueue(5);
            var d2 = nqueue.Dequeue();
            Stack<int> nstack = new Stack<int>();
            Dictionary<string, int> ndict = new Dictionary<string, int>();

        }
    }
}
