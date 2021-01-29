using System;
using System.IO;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            //StaticDemo();
            InstanceDemo();
        }

        private static void InstanceDemo()
        {
            FileInfo fi = new FileInfo("E:\\bliep.txt");
            if (!fi.Exists)
            {
                fi.Create().Close();
                Console.WriteLine(fi.Attributes);
            }
            else
            {
                fi.Delete();
            }
        }

        private static void StaticDemo()
        {
            string path = "E:\\bla.log";
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
           else
            {
                File.Delete(path);
            }

        }
    }
}
