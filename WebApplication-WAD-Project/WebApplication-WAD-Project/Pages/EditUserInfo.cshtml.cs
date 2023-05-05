using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ClassLibrary;
using ClassLibraryService;

namespace WebApplication_WAD_Project.Pages
{
    [Authorize]
    public class EditUserInfoModel : PageModel
    {
        //[BindProperty]
        public Users Users { get; set; }
        public UserManager userManager;//= new UserManager();
        private UserMediator userMediator = new UserMediator();
        private int Id { get; set; }

        public EditUserInfoModel()
        {
            userManager = new UserManager(userMediator);
        }
        public void OnGet(int id)
        {
            
            if (HttpContext.Session.Get("email") != null)
            {
                string s = HttpContext.Session.GetString("email");
                this.Users = userManager.GetUser(s);
            }
            if(Users.Id != id)
            {
                 RedirectToPage("/AccessDenied");
            }
            

            //this.Users = userManager.GetUserByID(id);



        }

        public IActionResult OnPost()
        {
            if (HttpContext.Session.Get("email") != null)
            {
                string s = HttpContext.Session.GetString("email");
                this.Users = userManager.GetUser(s);
            }
            Users.Update(Users.Username, Users.FirstName, Users.LastName, Users.Password);
               userManager.UpdateUser(Users);
            return RedirectToPage("userprofile");
            //if (ModelState.IsValid)
            //{
            //    Users Users = userManager.GetUserByID(id);
            //    Users.Update(Users.Username, Users.FirstName, Users.LastName, Users.Password);
            //    userManager.UpdateUser(Userss);
            //    ViewData["Message"] = "Successful update!";
            //    return RedirectToPage("userprofile");
            //}
            //else
            //{
            //    ViewData["Message"] = "Unsuccessful update!";
            //    return Page();
            //}



        }
    }
}
