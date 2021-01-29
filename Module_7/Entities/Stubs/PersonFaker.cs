using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Stubs
{
    public static class PersonFaker
    {
        public static ICollection<Person> GeneratePeople(int nr)
        {
            return  new Faker<Person>()
               // .RuleFor(p => p.ID, f => f.UniqueIndex)
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Age, f => f.Random.Int(0, 123))
                .Generate(nr)
                .ToList();
        }
    }
}
