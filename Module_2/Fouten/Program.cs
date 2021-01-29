using System;
using System.Diagnostics;

namespace Fouten
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new TextWriterTraceListener(@"E:\data.log"));
            Trace.AutoFlush = true;
            try
            {
                int nr = VraagNaarGetal();
                ToonTafel(nr);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oeps. Er ging iets fout");
            }
        }

        static int VraagNaarGetal()
        {
            do
            {
                Console.WriteLine("Geef een tafelnummer:");
                string sNummer = Console.ReadLine();
                try
                {
                    int nr = int.Parse(sNummer);
                    return nr;
                }
                catch (FormatException e)
                {
                    Debug.WriteLine(e);
                    Trace.WriteLine(e);
                    Console.WriteLine("Input is niet juist.");
                    throw; // alleen vanuit BL
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine("Getal te groot of te klein");
                    throw oe; // Breekt de stacktrace af
                }
                finally
                {
                    // resources opruimen
                    Console.WriteLine("Tenslotte...");
                }
            }
            while (true);
        }

        static void ToonTafel(int tafel)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{i,-2} x {tafel} = {checked(i * tafel)}");
            }
        }
    }
}
