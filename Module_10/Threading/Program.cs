using System;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            //SyncLongAdd();
            //AsyncAddOldStyle();
            //AsyncViaTask();
            AsyncErrors();
            //AsyncSjiek();
            //AsyncHip();
            Console.WriteLine("The end");
            Console.ReadLine();
        }

        private static async Task AsyncHip()
        {
            Task<decimal> t1 = new Task<decimal>(() => LongAdd(2, 5));
            t1.Start();
            decimal result = await t1;
            Console.WriteLine(result);
            result = await LongAddAsync(7,9);
            Console.WriteLine(result);
            
        }

        private static void AsyncSjiek()
        {
            LongAddAsync(6, 7)
                .ContinueWith(pt => Console.WriteLine(pt.Result));
        }

        private static async void AsyncErrors()
        {
            try
            {
                await Task.Run(() =>
                {
                    throw new Exception("oops");
                });
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
                
            //    .ContinueWith(pt=> { 
            //    if(pt.Exception != null)
            //    {
            //        Console.WriteLine(pt.Exception?.InnerException?.Message);
            //    }
            //});
        }

        private static void AsyncViaTask()
        {
            //Task<decimal> t1 = new Task<decimal>(() => {          
            Task<decimal> t1 = Task.Run(() =>
            {
                decimal result = LongAdd(1, 2);
                return result;
            });
            t1.ContinueWith(prevTask =>
            {
                decimal result = prevTask.Result;
                Console.WriteLine(result);
            });

            //t1.Start();

        }

        private static void AsyncAddOldStyle()
        {
            // APM pattern
            Func<decimal, decimal, decimal> del = LongAdd;

            //var tx = Task.Factory.FromAsync<decimal>(del.BeginInvoke(3,4, null, null), del.EndInvoke);
            //tx.Start();
            //Console.WriteLine(tx.Result);
            IAsyncResult ar = del.BeginInvoke(3, 4, TheCallback, del);
            Console.WriteLine("En we gaan doooorrrrrr");
        }

        private static void TheCallback(IAsyncResult ar)
        {
            Func<decimal, decimal, decimal> del = ar.AsyncState as Func<decimal, decimal, decimal>;
            decimal result = del.EndInvoke(ar);
            Console.WriteLine(result);
        }

        private static void SyncLongAdd()
        {
            decimal result = LongAdd(1, 2);
            Console.WriteLine(result);
        }

        static decimal LongAdd(decimal a, decimal b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
        static Task<decimal> LongAddAsync(decimal a, decimal b)
        {
            return Task.Run(() => LongAdd(a, b));
        }
    }
}
