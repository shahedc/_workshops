using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesSimpleAuthorization.Data;
using RazorPagesSimpleAuthorization.Models;

namespace RazorPagesSimpleAuthorization.Pages.MyItems
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesSimpleAuthorization.Data.ApplicationDbContext _context;

        public CreateModel(RazorPagesSimpleAuthorization.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MyItem MyItem { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MyItem.Add(MyItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}