using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreRazor.Pages
{
    public class TypedClientModel : PageModel
    {
        private GitHubService _ghService;
        public string ApiResult { get; private set; }

        public TypedClientModel(GitHubService ghService)
        {
            _ghService = ghService;
        }

        public async Task OnGet()
        {
            ApiResult = await _ghService.Client.GetStringAsync("/repos/aspnet/Home/issues");
        }
    }
}