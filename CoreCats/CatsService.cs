using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace CoreCats
{
    public class CatsService
    {
        public HttpClient Client { get; set; }

        public CatsService (HttpClient client)
        {
            client.BaseAddress = new System.Uri("https://thecatapi.com/");
            
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClient-Sample");

            this.Client = client;
        }
    }
}
