using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace CoreCats.Pages
{
    public class TypedCatsModel : PageModel
    {
        private CatsService _cService;

        public string CatImageURL { get; set; }

        public TypedCatsModel(CatsService service)
        {
            _cService = service;
        }
        public async Task OnGetAsync()
        {
            String TimeStamp = DateTime.Now.ToString();
            var query = "/api/images/get?format=json&type=gif&timestamp=" + TimeStamp;
            var APIResult = await _cService.Client.GetStringAsync(query);
            List<CatApiResponse> DeserializedResult = JsonConvert.DeserializeObject<List<CatApiResponse>>(APIResult);
            CatImageURL = DeserializedResult[0].Url;
        }
        public class CatApiResponse
        {
            public string id { get; set; }
            public string Url { get; set; }
            public string SourceURL { get; set; }
        }
    }
}