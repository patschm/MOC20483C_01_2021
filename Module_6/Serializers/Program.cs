using Bogus;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serializers
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonDemo(false);
            SerializeExercise();
            DeserializeDemo();
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void DeserializeDemo()
        {
            FileStream fs = File.OpenRead("E:\\people.xml");
            XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
            var people = ser.Deserialize(fs) as List<Person>;
            foreach (Person p in people)
            {
                p.Introduce();
            }
        }

        private static void SerializeExercise()
        {
            List<Person> people = CreatePeople();
            //foreach(Person p in people)
            //{
            //    p.Introduce();
            //}
            FileStream fs = File.Create("E:\\people.xml");
            XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
            ser.Serialize(fs, people);
            fs.Close();
        }

        private static List<Person> CreatePeople()
        {
            var faker = new Faker<Person>();
            return faker
                .RuleFor(p=>p.ID, f=>f.IndexFaker)
                .RuleFor(p=>p.Age, f=>f.Random.Int(0, 123))
                .RuleFor(p=>p.FirstName, f=>f.Name.FirstName())
                .RuleFor(p=>p.LastName, f=>f.Name.LastName())
                .Generate(1000)             
                .ToList();
        }

        private static void JsonDemo(bool read)
        {
            if (!read)
            {
                Person p = new Person { FirstName = "Joan", LastName = "Groen", Age = 34 };
                //p.Introduce();

                FileStream fs = File.Create("E:\\person.json");
                StreamWriter writer = new StreamWriter(fs);
                JsonSerializer ser = new JsonSerializer();
                
               ser.ContractResolver =new DefaultContractResolver
               {
                   NamingStrategy = new KebabCaseNamingStrategy()
               };

                ser.Serialize(writer, p);
                writer.Flush();
            }
            else
            {
                FileStream fs = File.OpenRead("E:\\person.json");
                StreamReader rdr = new StreamReader(fs);
                JsonSerializer ser = new JsonSerializer();
                Person p = ser.Deserialize(rdr, typeof(Person)) as Person;
                p.Introduce();
            }

        }
    }
}
