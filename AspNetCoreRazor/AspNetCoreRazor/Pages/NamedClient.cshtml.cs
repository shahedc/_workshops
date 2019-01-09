using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreRazor.Pages
{
    public class NamedClientModel : PageModel
    {
        public string ApiResult { get; set; }
        IHttpClientFactory _httpClientFactory;

        public NamedClientModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var namedGitHubClient = _httpClientFactory.CreateClient("github");
            ApiResult = await namedGitHubClient.GetStringAsync("/orgs/dotnet/repos");
        }
    }
}