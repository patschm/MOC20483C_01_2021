using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Serializers
{
    [XmlRoot("persoon")]
    public class Person
    {
        private int age;

        [XmlElement("age")]
        public int Age
        {
            get { return age; }
            set { 
                if (age >= 0 && age <123) 
                    age = value; 
            }
        }
        [XmlAttribute("id")]
        public int ID { get; set; }
        [XmlElement("first-name")]
        public string FirstName { get; set; }
        [XmlElement("last-name")]
        public string LastName { get; set; }

        public void Introduce()
        {
            Console.WriteLine($"Hi, I'm {FirstName} {LastName} ({Age})");
        }
    }
}
