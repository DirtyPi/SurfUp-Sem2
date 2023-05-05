using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
//using WebApplication_WAD_Project.Models;
using ClassLibrary;
using ClassLibraryService;
//using ClassLibraryDAL;
namespace WebApplication_WAD_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }       
      //  public string UsernameFromCookie;
        public string EmailFromSession;
        public Users u;
        public UserManager um = new UserManager();
        public void OnGet()
        {
            // if (Request.Cookies.ContainsKey("Testname"))
            //{ UsernameFromCookie = Request.Cookies["Testname"]; }
            //else
            //{ UsernameFromCookie = "Guest"; }
            /*HttpContext.Session.Remove("key"); // Removes specific session
            HttpContext.Session.Clear(); // Removes all sessions*/
            //if (Request.Cookies.ContainsKey("username"))
            //{ UsernameFromCookie = Request.Cookies["username"]; }
            //else
            //{ UsernameFromCookie = "Guest"; }

            if (HttpContext.Session.Get("email") != null)
            { EmailFromSession = HttpContext.Session.GetString("email"); }
            else
            { EmailFromSession = "Guest"; }

            //u = um.GetUser();
        }
    }
}
