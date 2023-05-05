using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlX.XDevAPI;

namespace WebApplication_WAD_Project.Pages
{
    [Authorize]
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.SignOutAsync();       
            HttpContext.Session.Remove("email");
            HttpContext.Session.Clear();
            return RedirectToPage("index");
           
        }
    }
}
