using Entities;
using Entities.Stubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;

namespace DataBaseProgram
{
    class Program
    {
        private static string conStr = @"Server=.\sqlexpress;Database=MyPeopleDB;Trusted_Connection=True;MultipleActiveResultSets=true;";

        static void Main(string[] args)
        {
            DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
            bld.UseSqlServer(conStr, opts => {
                opts.MaxBatchSize(32);
                opts.CommandTimeout(20);
            });

            MyContext ctx = new MyContext(bld.Options);
            //VulDatabase(ctx);
            QueryData(ctx);
           // ctx.Database.EnsureCreated();

            Console.WriteLine("Done");
            Console.ReadLine();

        }

        private static void QueryData(MyContext ctx)
        {
            var query = ctx.People
                .Include(x => x.Hobbies)
                    .ThenInclude(ph => ph.Hobby);

            foreach(Person p in query.AsNoTracking())
            {
               // p.FirstName = "Marieke";
                //var pe = ctx.Entry(p);
                
                Console.WriteLine($"{p.FirstName} {p.LastName}");
                //ctx.Entry(p).Collection(e => e.Hobbies).Load();
                foreach(PersonHobby ph in p.Hobbies)
                {
                    //ctx.Entry(ph).Reference(e => e.Hobby).Load();
                    Console.WriteLine($"\t{ph.Hobby?.Description}");
                }
            }
        }

        private static void VulDatabase(MyContext ctx)
        {
            InMemoryContext imc = new InMemoryContext(1000, 50);

            //foreach(var p in imc.People )
            //{
            //    ctx.People.Add(p);
            //}
            //foreach(var h in imc.Hobby)
            //{
            //    ctx.Hobbies.Add(h);
            //}

            var phs = PersonHobbyFaker.GeneratePersonHobbies(100, ctx.People.ToArray(), ctx.Hobbies.ToArray());
            
            foreach (var ph in phs.Distinct())
            {
                ctx.PersonHobbies.Add(ph);
            }

            try
            {
                ctx.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
