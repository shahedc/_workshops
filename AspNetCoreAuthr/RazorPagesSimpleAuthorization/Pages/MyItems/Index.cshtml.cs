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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesSimpleAuthorization.Data.ApplicationDbContext _context;

        public IndexModel(RazorPagesSimpleAuthorization.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MyItem> MyItem { get;set; }

        public async Task OnGetAsync()
        {
            MyItem = await _context.MyItem.ToListAsync();
        }
    }
}
