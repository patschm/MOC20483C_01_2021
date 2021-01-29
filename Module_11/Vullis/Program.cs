using System;

namespace Vullis
{
    class Program
    {
        static UnManaged m1 = new UnManaged();
        static UnManaged m2 = new UnManaged();
        
        static void Main(string[] args)
        {
            using(UnManaged m3 = new UnManaged())
            {
                m3.Open();
            }

            using (m1)
            {
                m1.Open();
                m1 = null;
            }



            try
            {
                m2.Open();
            }
            finally
            {
                m2.Dispose();
            }
            
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
