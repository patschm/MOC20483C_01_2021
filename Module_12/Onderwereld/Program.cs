using System;
using System.Reflection;

namespace Onderwereld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p = new Person { Name = "Jan", Age = 45 };
            //p.Introduce();

            //Onderzoek();
            BetereHackwerk();
        }

        private static void BetereHackwerk()
        {
            Assembly asm = Assembly.LoadFrom(@"E:\Bieb.dll");
            Type pers = asm.GetType("Bieb.Person");

            dynamic p1 = Activator.CreateInstance(pers);
            p1.Name = "Marieke";
            p1.Age = 34;
            p1.Introduce();


            object p = Activator.CreateInstance(pers);

            PropertyInfo pName = pers.GetProperty("Name");
            pName.SetValue(p, "Kees");

            //PropertyInfo pAge = pers.GetProperty("Age");
            //pAge.SetValue(p, -42);

            FieldInfo fAge = pers.GetField("age", BindingFlags.Instance | BindingFlags.NonPublic);
            fAge.SetValue(p, -42);

            MethodInfo intro = pers.GetMethod("Introduce");
            intro.Invoke(p, new object[] { });
        }

        private static void Onderzoek()
        {
            Assembly asm = Assembly.LoadFrom(@"E:\Bieb.dll");
            Console.WriteLine(asm.FullName);

            foreach(Type tp in asm.GetTypes())
            {
                Console.WriteLine(tp.FullName);
                foreach(MemberInfo mem in tp.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    Console.WriteLine(mem.Name);
                }
                foreach (var mem in tp.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    Console.WriteLine(mem.Name);
                }
            }

        }
    }
}
