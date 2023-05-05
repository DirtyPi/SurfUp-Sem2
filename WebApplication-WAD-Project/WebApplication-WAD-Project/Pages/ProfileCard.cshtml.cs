using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
//using WebApplication_WAD_Project.Models;
using Microsoft.AspNetCore.Http;
using ClassLibrary;
using ClassLibraryService;

namespace WebApplication_WAD_Project.Pages
{
    [Authorize]
    public class ProfileCardModel : PageModel
    {
        public Users Users { get; set; }
        public UserManager userManager;
        private UserMediator userMediator = new UserMediator();
        private int id { get; set; }

        public ProfileCardModel()
        {
            userManager = new UserManager(userMediator);
        }
        public void OnGet()
        {
            if (HttpContext.Session.Get("email") != null)
            {
                string s = HttpContext.Session.GetString("email");
                this.Users = userManager.GetUser(s);
                //this.id = Convert.ToInt32(Users.Id);

            }
        }
    }
}
