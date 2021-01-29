using System;
using System.Threading;
using System.Threading.Tasks;

namespace MiscStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            //ParellelDemo();
            //MoreParallel();
            //EchtParallel();
            //MeerOrkesten();
            //Rommel();
            Funny();

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void Funny()
        {
            CancellationTokenSource nikko = new CancellationTokenSource();

            CancellationToken bommetje = nikko.Token;
            Task.Run(() => {
                for (int i = 0; i < 1000; i++)
                {
                    Task.Delay(500).Wait();
                    Console.WriteLine(i);
                    //bommetje.ThrowIfCancellationRequested();
                    if (bommetje.IsCancellationRequested)
                    {
                        return;
                    }
                }
            }).ContinueWith(pt => {
                Console.WriteLine(pt.Status);
            });


            Console.ReadLine();
            nikko.Cancel();
        }

        static object stokje = new object();

        private static void Rommel()
        {
            int counter = 0;
            Parallel.For(0, 10, idx => {
                //Monitor.Enter(stokje);
                lock (stokje)
                {
                    int TMP = counter;
                    Task.Delay(1000).Wait();
                    counter = ++TMP;
                    Console.WriteLine(counter);
                }
                //Monitor.Exit(stokje);
            });
            Console.WriteLine(counter);
        }

        private static void MeerOrkesten()
        {
            Random rnd = new Random();
            Semaphore sem = new Semaphore(10, 10);

            Parallel.For(0, 100, idx => {
                Console.WriteLine($"Auto {idx} wacht voor de slagboom");
                sem.WaitOne();
                Console.WriteLine($"Auto {idx} rijdt naar binnen");
                Task.Delay(rnd.Next(15, 20) * 1000).Wait();
                sem.Release();
                Console.WriteLine($"Auto {idx} rijdt eruit");
            });


            Barrier bar = new Barrier(11);
            CountdownEvent ce = new CountdownEvent(10);
            
            for(int i = 0; i < 10; i++)
            {
                Task.Run(() => {
                    bar.SignalAndWait();
                    //bar.AddParticipant();
                    Task.Delay(100).Wait();
                    Console.WriteLine(i);
                    //ce.Signal();
                   
                 });
            }

            //ce.Wait();
            Console.ReadLine();
            bar.SignalAndWait();
            Console.WriteLine("HA!");
           

        }

        private static async void EchtParallel()
        {
            ManualResetEvent zl1 = new ManualResetEvent(false);
            ManualResetEvent zl2 = new ManualResetEvent(false);

            int result = 0;
            var t1 = Task.Run(() => {
                Task.Delay(2000).Wait();
                result += 40;
                //zl1.Set(); // Task hebben hun eigen zaklamp
            });
            var t2 =  Task.Run(() => {
                Task.Delay(1000).Wait();
                result += 60;
                //zl2.Set();
            });

            // Blocking
            //WaitHandle.WaitAny(new WaitHandle[] { zl1, zl2 });
            await Task.WhenAll(t1, t2);
            Console.WriteLine(result);
        }

        private static async Task MoreParallel()
        {
            var res = await Task.FromResult("Hallo");
            Console.Write(res);
            res = await Task.FromResult("World");
            Console.Write(res);
            res = await Task.FromResult("!!!!!");
            Console.WriteLine(res);
        }

        private static void ParellelDemo()
        {
            Parallel.For(0, 10, idx => {
                Console.WriteLine($"Taak {idx}");
                Console.WriteLine($"ThreadID: {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine("En verder...");
        }
    }
}
