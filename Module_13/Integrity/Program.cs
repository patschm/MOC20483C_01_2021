using System;
using System.Security.Cryptography;
using System.Text;

namespace Integrity
{
    class Program
    {
        static void Main(string[] args)
        {
            //KaleHash();
            //HMACDemo();
            RSADemo();
        }

        private static void RSADemo()
        {
            string document = "Hello World";
            // Sender
            SHA1 alg = SHA1.Create();
            byte[] buffer = Encoding.UTF8.GetBytes(document);
            byte[] hashSender = alg.ComputeHash(buffer);
            RSA crypt = RSA.Create();
            byte[] pubKey = crypt.ExportRSAPublicKey();
            byte[] signature = crypt.SignHash(hashSender, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);

            // ED
            document += ".";

            // Ontvanger
            SHA1 alg2 = SHA1.Create();      
            byte[] buffer2 = Encoding.UTF8.GetBytes(document);
            byte[] hashReceiver = alg2.ComputeHash(buffer2);
            RSA cr2 = RSA.Create();
            cr2.ImportRSAPublicKey(pubKey, out int nrRead);
            bool isOK = cr2.VerifyHash(hashReceiver, signature, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            Console.WriteLine(isOK ? "Prima": "Boee");
        }

        private static void HMACDemo()
        {
            byte[] key;
            string document = "Hello World";
            // Sender
            HMACSHA1 alg = new HMACSHA1();
            key = alg.Key;
            byte[] buffer = Encoding.UTF8.GetBytes(document);
            byte[] hashSender = alg.ComputeHash(buffer);

            // ED
            // document += ".";

            // Ontvanger
            HMAC alg2 = new HMACSHA1();
            alg2.Key = key;
            byte[] buffer2 = Encoding.UTF8.GetBytes(document);
            byte[] hashReceiver = alg2.ComputeHash(buffer2);

            Console.WriteLine(Convert.ToBase64String(hashSender));
            Console.WriteLine(Convert.ToBase64String(hashReceiver));

        }

        private static void KaleHash()
        {
            string document = "Hello World";
            // Sender
            SHA1 alg = SHA1.Create();
            byte[] buffer = Encoding.UTF8.GetBytes(document);
            byte[] hashSender = alg.ComputeHash(buffer);

            // ED
           // document += ".";

            // Ontvanger
            SHA1 alg2 = SHA1.Create();
            byte[] buffer2 = Encoding.UTF8.GetBytes(document);
            byte[] hashReceiver = alg2.ComputeHash(buffer2);

            Console.WriteLine(Convert.ToBase64String(hashSender));
            Console.WriteLine(Convert.ToBase64String(hashReceiver));

        }
    }
}
