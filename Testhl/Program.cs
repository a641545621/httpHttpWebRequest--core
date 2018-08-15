using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Testhl
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg= HttpConnectToServer("https://www.okex.com/api/v1/exchange_rate.do");
            Console.WriteLine("framework: "+msg);
            Console.ReadKey();
        }
        private static string HttpConnectToServer(string url)
        {
            //创建请求
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.AllowAutoRedirect = false;
            //读取返回消息
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
                return null;
                //连接服务器失败
            }
            return res;
        }
    }
}
