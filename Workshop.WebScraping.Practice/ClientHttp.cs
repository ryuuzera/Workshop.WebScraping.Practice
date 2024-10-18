using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.WebScraping.Practice
{
    internal class ClientHttp : IDisposable
    {
        private readonly HttpClient httpClient;

        private readonly CookieContainer cookieContainer;

        private static ClientHttp currentInstance;
        public ClientHttp()
        {
            if (currentInstance == null)
            {
                cookieContainer = new CookieContainer();

                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieContainer
                };

                httpClient = new HttpClient(handler)
                {
                    Timeout = TimeSpan.FromSeconds(15)
                };
            }
        }

        public static HttpClient New()
        {
            if (currentInstance == null)
            {
                currentInstance = new ClientHttp();
            }

            return currentInstance.httpClient;
        }
        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
