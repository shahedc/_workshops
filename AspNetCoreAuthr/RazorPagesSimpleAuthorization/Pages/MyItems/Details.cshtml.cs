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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesSimpleAuthorization.Data.ApplicationDbContext _context;

        public DetailsModel(RazorPagesSimpleAuthorization.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
