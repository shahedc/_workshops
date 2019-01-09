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
    public class DetailsModel : PageModel
    {
        private readonly AspNetCoreRazor.Data.ApplicationDbContext _context;

        public DetailsModel(AspNetCoreRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public GitHubProject GitHubProject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GitHubProject = await _context.GitHubProject.FirstOrDefaultAsync(m => m.ID == id);

            if (GitHubProject == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
