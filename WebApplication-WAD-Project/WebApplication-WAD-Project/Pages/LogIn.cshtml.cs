using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
//using WebApplication_WAD_Project.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using ClassLibrary;
using ClassLibraryService;
//using ClassLibraryDAL;

namespace WebApplication_WAD_Project.Pages.Shared
{
    public class LogInModel : PageModel
    {
        public UserManager um;// = new UserManager();
        private UserMediator userMediator = new UserMediator();
      
        //public Users u { get; set; }

        [BindProperty]
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindProperty]
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
      
        public LogInModel()
        {
            um = new UserManager(userMediator);
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string returnUrl)
        {
            if (ModelState.IsValid)
            {
               // Users u = um.GetUserByLogIn(Email, Password);
                if(um.CheckIfUserIsReal(Email, Password))
                  {
                      //um.GetAllUsers();
                      Users u = um.GetUser(Email);
                      if (u != null && u.Status != UserStatusEnum.Ban)
                      {
                       
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim(ClaimTypes.Name, Email));
                            //  claims.Add(new Claim("id", "1"));
                            if (u.Role == ClassLibrary.UserRoleEnum.AdminUser)
                            { claims.Add(new Claim(ClaimTypes.Role, "AdminUser")); }
                            else
                            { claims.Add(new Claim(ClaimTypes.Role, "BaseUser")); }
                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                            HttpContext.Session.SetString("email", u.Email);
                            if (!String.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return RedirectToPage("profilecard");
                            }
                      }
                      else
                      {
                          ViewData["Message"] = "User does not have access to the web site!";
                          return Page();
                      }
                  }
                  else
                  {
                      ViewData["Message"] = "Invalid log in wrong email/Something went wrong!";
                      return Page();
                  }

              }
              else
            {
                ViewData["Message"] = "The supplied username and / or password is invalid";
            
                  return Page();
            }

            //if (ModelState.IsValid)
            //{
            //    um.GetAllUsers();
            //    if(um.CheckIfUserExists(u) == true)
            //    {
                  
            //        List<Claim> claims = new List<Claim>();
            //        claims.Add(new Claim(ClaimTypes.Name, Email));
            //        //  claims.Add(new Claim("id", "1"));
            //        if (u.Role == "BaseUser")
            //        { claims.Add(new Claim(ClaimTypes.Role, "BaseUser")); }
            //        else
            //        { claims.Add(new Claim(ClaimTypes.Role, "AdminUser")); }
            //        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
            //        HttpContext.Session.SetString("email", u.Email);
            //        if (!String.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            //        {
            //            return Redirect(returnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToPage("HomePage");
            //        }
            //    }
            //    else
            //    {
            //        ViewData["Message"] = "Invalid log in ";
            //        return Page();
            //    }
            //}
            //else
            //{
            //    ViewData["Message"] = "Invalid log in wrong email/Something went wrong!";
            //    return Page();
            //}

        }
    }
}
