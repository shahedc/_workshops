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
    public class DeleteModel : PageModel
    {
        private readonly AspNetCoreRazor.Data.ApplicationDbContext _context;

        public DeleteModel(AspNetCoreRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GitHubProject = await _context.GitHubProject.FindAsync(id);

            if (GitHubProject != null)
            {
                _context.GitHubProject.Remove(GitHubProject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
