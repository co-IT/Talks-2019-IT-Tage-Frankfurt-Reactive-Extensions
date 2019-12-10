using System;
using System.Net;
using System.Net.Http;
using SmartGateIn.Properties;

namespace SmartGateIn.SapWebservices
{
    internal class BackendClient
    {
        internal HttpClient Connect()
        {
            var client =
                new HttpClient(new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                    })
                    { BaseAddress = new Uri(Settings.Default.BaseAddress), Timeout = TimeSpan.FromSeconds(10) };

#if Debug
                client.Timeout = TimeSpan.FromSeconds(60);
#endif
            return client;
        }
    }
}