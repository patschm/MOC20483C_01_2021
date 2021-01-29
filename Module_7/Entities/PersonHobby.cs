using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PersonHobby
    {
        public int PersonID { get; set; }
        public int HobbyID { get; set; }

        public Person Person { get; set; }
        public Hobby Hobby { get; set; }
    }
}
