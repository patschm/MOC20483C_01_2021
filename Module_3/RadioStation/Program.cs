using System;

namespace RadioStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Zender r538 = new Zender();

            r538.Subscribers += ViaKabel;
            r538.Subscribers += ViaEther;
            r538.Subscribers += ViaSMS;
            r538.Subscribers += ViaPostduif;
            r538.Subscribers += ViaEmail;
            r538.Subscribers += ViaKabel;
            r538.Subscribers += ViaEther;
            r538.Subscribers += ViaSMS;
            r538.Subscribers += ViaPostduif;
            r538.Subscribers += ViaEmail;
            r538.Subscribers += ViaKabel;
            r538.Subscribers += ViaEther;
            r538.Subscribers += ViaSMS;
            r538.Subscribers += ViaPostduif;
            r538.Subscribers += ViaEmail;

            r538.Start();
        }

        static void ViaKabel(string msg)
        {
            Console.WriteLine($"Via kabel ontvangen: {msg}");
        }
        static void ViaEmail(string msg)
        {
            Console.WriteLine($"Via email ontvangen: {msg}");
        }
        static void ViaEther(string msg)
        {
            Console.WriteLine($"Via ether ontvangen: {msg}");
        }
        static void ViaSMS(string msg)
        {
            Console.WriteLine($"Via sms ontvangen: {msg}");
        }
        static void ViaPostduif(string msg)
        {
            Console.WriteLine($"Via postduif ontvangen: {msg}");
        }
    }
}
