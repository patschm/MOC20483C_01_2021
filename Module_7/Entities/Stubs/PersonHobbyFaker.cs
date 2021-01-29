using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Stubs
{
    public class PersonHobbyFaker
    {
        public static ICollection<PersonHobby> GeneratePersonHobbies(int nr, Person[] people, Hobby[] hobbies)
        {
            return new Faker<PersonHobby>()
                .RuleFor(p => p.Hobby, f => f.Random.ArrayElement(hobbies))
                .RuleFor(p => p.Person, f => f.Random.ArrayElement(people))
                .Generate(nr)
                .ToList();
        }
    }
}
