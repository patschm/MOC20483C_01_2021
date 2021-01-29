using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Confidentiality
{
    class Program
    {
        static void Main(string[] args)
        {
            //Asymmetrisch();
            //Symmetrische();
            Certs();
        }

        private static void Certs()
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            foreach(X509Certificate2 cert in store.Certificates)
            {
                Console.WriteLine(cert.Subject);
                RSA rsa = cert.PrivateKey as RSA;
                Console.WriteLine(rsa == null ? "Niks":rsa.ToString());

            }
            
        }

        private static void Symmetrische()
        {
            // Sender
            string document = "Hello World";
            Aes aes = Aes.Create();
            //aes.Mode = CipherMode.CTS;
             byte[] key = aes.Key;
            byte[] iv = aes.IV;

            byte[] cipher;

            using(MemoryStream mem = new MemoryStream())
            {
                using(CryptoStream cs = new CryptoStream(mem, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using(StreamWriter writer = new StreamWriter(cs))
                    {
                        writer.Write(document);
                    }
                }
                cipher = mem.ToArray();
            }

            // Ontvanger
            Aes aes2 = Aes.Create();
            //aes2.Mode = CipherMode.CTS;
            aes2.Key = key;
            aes2.IV = iv;
            using (MemoryStream m2 = new MemoryStream(cipher))
            {
                using (CryptoStream cs2 = new CryptoStream(m2, aes2.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader rdr = new StreamReader(cs2))
                    {
                        Console.WriteLine(rdr.ReadToEnd());
                    }
                }
            }
        }

        private static void Asymmetrisch()
        {
            // Ontvanger
            RSA rsaOntvanger = RSA.Create();
            byte[] pubKey = rsaOntvanger.ExportRSAPublicKey();
            byte[] privKey = rsaOntvanger.ExportRSAPrivateKey();

            // Sender
            string document = "Hello World";
            byte[] buffer = Encoding.UTF8.GetBytes(document);
            RSA crypt = RSA.Create();
            crypt.ImportRSAPublicKey(pubKey, out int nrRead);
            byte[] cipher = crypt.Encrypt(buffer, RSAEncryptionPadding.Pkcs1);


            // Ontvanger
            rsaOntvanger = RSA.Create();
            //rsaOntvanger.ImportRSAPublicKey(pubKey, out int nr);
            rsaOntvanger.ImportRSAPrivateKey(privKey, out int nrRead2);
            byte[] data = rsaOntvanger.Decrypt(cipher, RSAEncryptionPadding.Pkcs1);
            Console.WriteLine(Encoding.UTF8.GetString(data));
        }
    }
}
