using Entities;
using Entities.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LingToObjects
{
    class Program
    {
        static InMemoryContext context = new InMemoryContext(100, 10);

        static void Main(string[] args)
        {
            //ShowPeople(context.People);
            var q1 = context.People.Where(p => p.FirstName.StartsWith("A"));
            var q2 = context.People.OrderByDescending(p => p.Age);
            var q3 = context.People.Select(p=>new  { First = p.FirstName, Last = p.LastName });
            var q4 = context.People.GroupBy(p => p.Age);

            var q6 = from p in context.People where p.FirstName.StartsWith("A") select p;
            ShowPeople(q6.Take(2).ToList());
            //var q5 = context.People.Take(10);
            //ShowPeople(q5.ToList());
            //q5 = context.People.Skip(10).Take(10);
            //ShowPeople(q5.ToList());

            //Console.WriteLine(context.People.Sum(p=>p.Age));

            //foreach(var item in q4)
            //{
            //    Console.WriteLine($"{item.Key}");
            //    foreach(var sub in item)
            //    {
            //        Console.WriteLine($"\t{sub.FirstName} {sub.LastName}");
            //    }
            //}

            //foreach(var d in q3)
            //{
            //    Console.WriteLine(d.First);
            //}

            // Trigger functies
            // ToList, ToArray, ToDictionary, foreach, First(OrDefault)
            //ShowPeople(q2.ToList());
        }

        private static void ShowPeople(ICollection<Person> people)
        {
            foreach(Person p in people)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName} ({p.Age})");
            }
        }
    }
}
