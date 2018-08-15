
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace huilv
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = HttpConnectToServer("https://www.okex.com/api/v1/exchange_rate.do");
            Console.WriteLine("Core2.0:"+msg);
            Console.ReadKey();
        }
        private static string HttpConnectToServer(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            string res = string.Empty;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return res;
        }
    }

}
