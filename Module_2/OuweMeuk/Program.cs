using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace OuweMeuk
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //EventViewDemo();
            PerfMonDemo();
        }

        private static void PerfMonDemo()
        {
            if (!PerformanceCounterCategory.Exists("AAA"))
            {
                CounterCreationData up = new CounterCreationData();
                up.CounterName = "total";
                up.CounterType = PerformanceCounterType.NumberOfItems32;
                CounterCreationDataCollection cdata = new CounterCreationDataCollection();
                cdata.Add(up);
                PerformanceCounterCategory.Create("AAA", "Hellup", 
                    PerformanceCounterCategoryType.SingleInstance, 
                    cdata);
            }

            PerformanceCounter ctr = new PerformanceCounter("AAA", "total", false);
            for(int i = 0; i < 100; i++)
            {
                ctr.Increment();
                Thread.Sleep(500);
            }
            for (int i = 0; i < 100; i++)
            {
                ctr.Decrement();
                Thread.Sleep(500);
            }
        }

        private static void EventViewDemo()
        {
            EventLog.CreateEventSource("ikke", "tja");
            EventLog.WriteEntry("ikke", "Hallo");
        }
    }
}
