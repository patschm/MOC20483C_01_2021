using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vullis
{
    class UnManaged : IDisposable
    {
        public static bool isOpen = false;
        private FileStream fs;

        public void Open()
        {
            if (!isOpen)
            {
                Console.WriteLine("Open");
                isOpen = true;
                fs = File.OpenRead("E:\\person.json");
            }
            else
            {
                Console.WriteLine("Resource in gerbuik");
            }
        }
        public void Close()
        {
            Console.WriteLine("Closing...");
            isOpen = false;
        }

        public void Dispose()
        {
            Close();
            fs.Dispose();
            GC.SuppressFinalize(this);
        }

        ~UnManaged()
        {
            Close();
        }
    }
}
