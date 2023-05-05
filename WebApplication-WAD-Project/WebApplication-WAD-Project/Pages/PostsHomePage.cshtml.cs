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
    public class PostsHomePageModel : PageModel
    {
        private new Post Post { get; set; }
        [BindProperty]
        private new MediaPost Mpost { get; set; }
        private PostManager postManager;//= new PostManager();
        private PostMediator postMediator = new PostMediator();
        public List<Post> posts { get; set; }
        [BindProperty]
        public Users Users { get; set; }
        public UserManager userManager;//= new UserManager();
        private UserMediator userMediator = new UserMediator();
        public int postType { get; set; }
        public PostsHomePageModel()
        {
            postManager = new PostManager(postMediator);
            userManager = new UserManager(userMediator);
        }
        public IActionResult OnGet(int postType)
        {
            postManager = new PostManager(postMediator);
            if (HttpContext.Session.Get("email") != null)
            {
                string s = HttpContext.Session.GetString("email");
                this.Users = userManager.GetUser(s);
            }
            posts = postManager.GetPostByType(postType);
            if(posts == null)
            {
                RedirectToPage("AccessDenied");
            }
            return Page();
        }
        public void OnPost(int typePost)
        {
            posts = postManager.GetPostByType(postType);   
        }
    }
}