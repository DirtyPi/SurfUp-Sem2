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
    public class PostPageModel : PageModel
    {
        private PostManager postManager;//= new PostManager();
        private PostMediator postMediator = new PostMediator();
        private UserManager userManager;//= new UserManager();
        private UserMediator userMediator = new UserMediator();        
        public MediaPost Mpost { get; set; }
    
        public ImagePost Ipost{ get; set; }
       
        public Post Post { get; set; }
       
        public Annoucement APost { get; set; }
        [BindProperty]
        public Comment Comment { get; set; }
        [BindProperty]
        public Users Users { get; set; }
        public List<Comment> Comments = new List<Comment>();
        //public List<string> commenters = new List<string>();
        public int PostID { get; set; }
        public int CommentID { get; set; }
        public PostPageModel()
        {
            
            postManager = new PostManager(postMediator);
            userManager = new UserManager(userMediator);
            // Post = new Post(commentMediator);

        }
        public void OnGet(int id)
        {
          
            postManager = new PostManager(postMediator);
            userManager = new UserManager(userMediator);
            Users = userManager.GetUser(HttpContext.Session.GetString("email"));
            Post = postManager.GetPostById(id);            
                if (Post is Annoucement)
                {
                    APost = (Annoucement)(postManager.GetPostById(id) as Post);
                
            }
                else if (Post is MediaPost)
                {
                    Mpost = (MediaPost)(postManager.GetPostById(id) as Post);
                }
                else if (Post is ImagePost)
                {
                    Ipost = (ImagePost)(postManager.GetPostById(id) as Post);
                }               
                
                if (Post.GetCommentByPost(id).Count != 0)
                {
                    Comments = Post.GetCommentByPost(id);

                }
            if (Post == null )
            {
                RedirectToPage("AccessDenied");
            }

             Page();
        }
        public IActionResult OnPost()
        {

            if(Comment.CommentText == null)
            {
                return Page();
            }
            else
            {
                string userC = "";
                if (HttpContext.Session.Get("email") != null)
                {
                    userC = HttpContext.Session.GetString("email");
                }
                this.PostID = Convert.ToInt32(Request.Form["Post.PostId"]);
                Post post = postManager.GetPostById(PostID);
                Users = userManager.GetUser(userC) as Users;
                Comment.CommentedTime = DateTime.Now.ToString("g");
                Comment = new Comment(Comment.CommentText, Comment.CommentedTime, Users, post);
                //  commentManager.AddCommentToPost(Comment);
                post.Add(Comment);
                return RedirectToPage("postpage");
            }
              
            
         

        }
        public IActionResult OnPostDelete(int id)
        {
            Post = postManager.GetPostById(id);
            this.CommentID = Convert.ToInt32(Request.Form["comment.Id"]);
            if (Post.CheckIfCommentExists(CommentID))
            {
                Comment c = Post.GetComment(CommentID);
                Post.Delete(c);
                return RedirectToPage("postpage");
            }
            else
            {
                return Page();

            }

        }
    }
}
