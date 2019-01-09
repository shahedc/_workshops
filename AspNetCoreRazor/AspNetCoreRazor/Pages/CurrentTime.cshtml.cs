using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreRazor.Pages
{
    public class CurrentTimeModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = $"The current time is {System.DateTime.Now}";
        }
    }
}