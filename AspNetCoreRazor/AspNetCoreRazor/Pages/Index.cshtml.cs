using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRazor;
using AspNetCoreRazor.Data;

namespace AspNetCoreRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AspNetCoreRazor.Data.ApplicationDbContext _context;

        public IndexModel(AspNetCoreRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<GitHubProject> GitHubProject { get;set; }

        public async Task OnGetAsync()
        {
            GitHubProject = await _context.GitHubProject.ToListAsync();
        }
    }
}
