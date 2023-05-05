using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using WebApplication_WAD_Project.Models;
using ClassLibrary;
using ClassLibraryService;
//using ClassLibraryDAL;



namespace WebApplication_WAD_Project.Pages
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public Users users { get; set; }
        public UserManager userManager;
        private UserMediator userMediator = new UserMediator();

        public SignInModel()
        {
            userManager = new UserManager(userMediator);
        }

        public void OnGet()
        {
        }     

        public IActionResult OnPost()
        {
            
            if (ModelState.IsValid)
            {
                if(userManager.CheckIfUserExists(users) == false)
                {
                    //"BaseUser"'s don't have admin privileges!
                    
                    users.Role = UserRoleEnum.BaseUser;
                    users.Status = UserStatusEnum.Valid;
                    //  if (userManager.AddUser(users))
                    //   {
                    userManager.Add(users);
                        return new RedirectResult("login");
                //    }
                    //else
                    //{
                    //    ViewData["Message"] = "Unseccessful signup";

                    //    return Page();
                    //}
                }
                else
                {
                    ViewData["Message"] = "Invalid Email";

                    return Page();
                }
            }
            else

            {

                ViewData["Message"] = "Please enter all data fields!";

                return Page();

            }

        }
    }
}
