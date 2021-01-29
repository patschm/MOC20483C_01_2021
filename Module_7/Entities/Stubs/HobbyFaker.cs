using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Stubs
{
    public class HobbyFaker
    {
        public static ICollection<Hobby> GenerateHobbies(int nr)
        {
            return new Faker<Hobby>()
                //.RuleFor(p => p.ID, f => f.UniqueIndex)
                .RuleFor(p => p.Description, f=>f.Lorem.Sentence(3))
                .Generate(nr)
                .ToList();
        }
    }
}
