using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace ClassLibrary
{
    public class Comment
    {
        public Comment() {}
        public int Id {get; set;}
        
        [Required]
        public string CommentText { get; set; }
        [Required]
        public string CommentedTime { get; set; }
       
        public Users UserId { get; set; }
       
        public Post PostId { get; set; }
       


       
        public Comment(string commentText, string commented, Users userId, Post postId)
        {

            this.CommentText = commentText;
            this.CommentedTime = commented;
            this.UserId = userId;
            this.PostId = postId;
        }
       
 

    }
}
