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
    [Authorize(Roles = "AdminUser")]
    public class AdminPageModel : PageModel
    {
        [BindProperty]
        public new Users User { get; set; }

     

        //UserManager um = new UserManager();



        //public List<Users> Users { get; set; }



        public void OnGet(int id)
        {
           // Users = um.GetAll();
            //posts = postManager.GetAllPost();
            //Post = postManager.GetPost(id);
        }



        public IActionResult OnPost()
        {
            //  User = new Users(User.Id, User.Username,User.Email, User.Password, User.FirstName, User.LastName, User.Role);
            //usersManager.AddUser(User);

          //  postManager.RemovePost(Post);
             return RedirectToPage("AdminPage");
        }

    }
}
