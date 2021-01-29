using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Netwerken
{
    
    class Program
    {
        //static HttpClientFactory factory;
        static void Main(string[] args)
        {
            //OldFashion();
            BetereVersie();
        }

        private static void BetereVersie()
        {
            HttpClientHandler hnd = new HttpClientHandler
            {
                //Credentials = new NetworkCredential;
            };

            HttpClient client = HttpClientFactory.Create(hnd);
            //HttpClient client = new HttpClient(hnd);
            client.BaseAddress = new Uri("https://www.nu.nl/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            HttpResponseMessage resp = client.GetAsync("rss").Result;
            if (resp.IsSuccessStatusCode)
            {
                HttpContent ct = resp.Content;
                string data = ct.ReadAsStringAsync().Result;
                Console.WriteLine(data);
            }

            client.Dispose();
            //HttpContent cdata = new StringContent("Hallo");
            //client.PostAsync("rss", )

        }

        private static void OldFashion()
        {
            //WebRequest req
            HttpWebRequest req = WebRequest.Create(@"https://www.nu.nl/rss") as HttpWebRequest;
            req.Headers.Add("accept", "application/json, application/xml, */*");
            //req.Credentials = CredentialCache.DefaultCredentials

            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            if (response.StatusCode==HttpStatusCode.OK)
            {
                Console.WriteLine(response.Headers);
                Stream str = response.GetResponseStream();
                StreamReader rdr = new StreamReader(str);
                Console.WriteLine(rdr.ReadToEnd());
            }


            //FtpWebRequest;
            //FileWebRequest;

            //WebResponse;
        }
    }
}
