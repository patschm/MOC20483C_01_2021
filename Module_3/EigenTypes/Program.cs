using System;

namespace EigenTypes
{
    enum WeekDays : ulong
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }

    class Program
    {
        static void Main(string[] args)
        {
            WeekDays weekday = WeekDays.Tuesday;
            weekday = (WeekDays)7;
            Console.WriteLine(weekday);


        }
    }
}
