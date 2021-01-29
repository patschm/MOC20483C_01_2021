using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamingTheHardWay();
            //StreamingInTheHardWay();
            //StreamingEazzyy();
            // StreamingInEasy();
            //CompressTheHardWay();
           // GZipWriteDemo();
            GZipReadDemo();
            Console.ReadLine();
        }

        private static void GZipReadDemo()
        {
            FileStream fstr = File.OpenRead(@"E:\hello.zip");
            GZipStream gzip = new GZipStream(fstr, CompressionMode.Decompress);
            StreamReader reader = new StreamReader(gzip);
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }

            fstr.Close();
        }

        private static void GZipWriteDemo()
        {
            string s = "Hello World ";
            FileStream fstr = File.Create(@"E:\hello.zip");
            GZipStream compStr = new GZipStream(fstr, CompressionMode.Compress);
            StreamWriter writer = new StreamWriter(compStr);
            for (int i = 0; i < 1000; i++)
            {
                writer.WriteLine(s + i);
                
            }
            writer.Flush();
            fstr.Close();

        }

        private static void CompressTheHardWay()
        {
            string s = "Hello World ";
            FileStream fstr = File.Create(@"E:\hello.min");
            DeflateStream compStr = new DeflateStream(fstr, CompressionMode.Compress);

            for (int i = 0; i < 1000; i++)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(s + i + "\n");
                compStr.Write(buffer);
            }
            compStr.Flush();
            fstr.Close();

        }

        private static void StreamingInEasy()
        {
            FileStream fstr = File.OpenRead(@"E:\hello.txt");
            StreamReader reader = new StreamReader(fstr);
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }

            fstr.Close();
        }

        private static void StreamingEazzyy()
        {
            string s = "Hello World ";
            FileStream fstr = File.Create(@"E:\helloeasy.txt");
            StreamWriter writer = new StreamWriter(fstr);
            for (int i = 0; i < 1000; i++)
            {
                writer.WriteLine(s + i);
            }
            writer.Flush();
            fstr.Close();
        }

        private static void StreamingInTheHardWay()
        {
            FileStream fstr = File.OpenRead(@"E:\hello.txt");

            int nrRead = 0;
            byte[] buffer = new byte[100];
            do
            {
                Array.Clear(buffer, 0, buffer.Length);
                nrRead = fstr.Read(buffer, 0, buffer.Length);
                string txt = Encoding.UTF8.GetString(buffer);
                Console.Write(txt);
            }
            while (nrRead > 0);

            fstr.Close();
        }

        private static void StreamingTheHardWay()
        {
            string s = "Hello World ";
            FileStream fstr = File.Create(@"E:\hello.txt");

            for (int i = 0; i < 1000; i++)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(s + i + "\n");
                fstr.Write(buffer);
            }

            fstr.Close();
        }
    }
}
