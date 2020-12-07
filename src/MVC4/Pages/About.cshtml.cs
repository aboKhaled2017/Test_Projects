using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MVC4.Pages
{
    public class AboutModel : PageModel
    {
        public string descript { get; set; } = "this is section describe about us";
        public void OnGet()
        {
        }
    }
}
