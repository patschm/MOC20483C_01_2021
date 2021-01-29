using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Stubs
{
    public class InMemoryContext
    {
        private ICollection<Person> _people;
        private ICollection<Hobby> _hobbies;
        private ICollection<PersonHobby> _personHobby;

        public ICollection<PersonHobby> PersonHobby
        {
            get { return _personHobby; }
        }
        public ICollection<Hobby> Hobby
        {
            get { return _hobbies; }
        }
        public ICollection<Person> People 
        { 
            get { return _people; } 
        }

        public InMemoryContext(int peoplenr = 100, int hobbynr=10)
        {
            Initialize(peoplenr, hobbynr);
        }

        private void Initialize(int peoplenr, int hobbynr)
        {
            _people = PersonFaker.GeneratePeople(peoplenr);
            _hobbies = HobbyFaker.GenerateHobbies(hobbynr);
            _personHobby = PersonHobbyFaker.GeneratePersonHobbies(peoplenr, _people.ToArray(), _hobbies.ToArray());
        }
    }
}
