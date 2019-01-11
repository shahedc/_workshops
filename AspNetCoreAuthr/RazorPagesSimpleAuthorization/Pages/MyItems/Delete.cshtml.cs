using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSimpleAuthorization.Data;
using RazorPagesSimpleAuthorization.Models;

namespace RazorPagesSimpleAuthorization.Pages.MyItems
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesSimpleAuthorization.Data.ApplicationDbContext _context;

        public DeleteModel(RazorPagesSimpleAuthorization.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyItem = await _context.MyItem.FindAsync(id);

            if (MyItem != null)
            {
                _context.MyItem.Remove(MyItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
