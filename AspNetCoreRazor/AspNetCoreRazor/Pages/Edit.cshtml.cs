using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRazor;
using AspNetCoreRazor.Data;

namespace AspNetCoreRazor.Pages
{
    public class EditModel : PageModel
    {
        private readonly AspNetCoreRazor.Data.ApplicationDbContext _context;

        public EditModel(AspNetCoreRazor.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GitHubProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GitHubProjectExists(GitHubProject.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GitHubProjectExists(int id)
        {
            return _context.GitHubProject.Any(e => e.ID == id);
        }
    }
}
