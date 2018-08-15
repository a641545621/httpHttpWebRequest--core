using System;
using System.IO;
using System.Net;
using System.Text;

namespace core2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = HttpConnectToServer("https://www.okex.com/api/v1/exchange_rate.do");
            Console.WriteLine("Core2.1:" + msg);
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
