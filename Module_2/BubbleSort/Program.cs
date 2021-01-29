using System;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 4, 5, 3, 8, 4, 6, 2, 1, 9, 7, 6, 5 };
            Sort(list);
            ShowList(list);
        }

        private static void ShowList(int[] list)
        {
            foreach(int nr in list)
            {
                Console.Write(nr + ", ");
            }
            Console.WriteLine();
        }

        static void Sort(int[] list)
        {
            bool hasSwapped = false;
            do
            {
                hasSwapped = ProcessList(list);
            }
            while (hasSwapped);
            
        }

        private static bool ProcessList(int[] list)
        {
            bool isSwap = false;
            for (int i = 0; i < list.Length - 1; i++)
            {
                bool needSwap = NeedSwap(ref list[i], ref list[i + 1]);
                if (needSwap)
                {
                    isSwap = true;
                    Swap(ref list[i], ref list[i + 1]);
                }
            }
            return isSwap;
        }

        private static void Swap(ref int v1, ref int v2)
        {
            int tmp = v1;
            v1 = v2;
            v2 = tmp;
        }

        private static bool NeedSwap(ref int v1, ref int v2)
        {
            return v1 > v2;
         }
    }
}
