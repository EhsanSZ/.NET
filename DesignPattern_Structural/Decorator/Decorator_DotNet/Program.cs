using System;
using System.Net;

namespace Decorator_DotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            //string source= webClient.DownloadString("https://www.google.com");

            WebClientDecorator clientDecorator = new WebClientDecorator(webClient);
            string source = clientDecorator.DownloadString("https://www.google.com");
            Console.WriteLine("Hello World!");
        }

        public class WebClientDecorator : WebClient
        {
            private readonly WebClient _webClient;
            public WebClientDecorator(WebClient webClient)
            {
                _webClient = webClient;
            }

            public string DownloadString(string address)
            {
                if (address.StartsWith("https://Ehsansz.ir"))
                    return _webClient.DownloadString(address);
                else
                    return string.Empty;

            }
        }
    }
}
