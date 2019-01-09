using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspNetCoreRazor;
using AspNetCoreRazor.Data;

namespace AspNetCoreRazor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AspNetCoreRazor.Data.ApplicationDbContext _context;

        public CreateModel(AspNetCoreRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GitHubProject GitHubProject { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GitHubProject.Add(GitHubProject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}