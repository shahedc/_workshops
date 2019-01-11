using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleAuthorization.Data;
using RazorPagesSimpleAuthorization.Models;

namespace RazorPagesSimpleAuthorization.Pages.MyItems
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesSimpleAuthorization.Data.ApplicationDbContext _context;

        public EditModel(RazorPagesSimpleAuthorization.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MyItem MyItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyItem = await _context.MyItem.FirstOrDefaultAsync(m => m.Id == id);

            if (MyItem == null)
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

            _context.Attach(MyItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyItemExists(MyItem.Id))
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

        private bool MyItemExists(int id)
        {
            return _context.MyItem.Any(e => e.Id == id);
        }
    }
}
