using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public abstract class Post
    {
        private CommentMediator commentMediator = new CommentMediator();
       
        public Post()
        {

        }
       
        public int PostId {get; set;}
        [Required]
        public string PostTitle { get; set; }

        private List<Comment> comments = new List<Comment>();
        public string PostedTime { get; set; }

       
        public Users PostedBy { get;  set; }
        
        public TypeOfPostEnum TypeOfPost { get; set; }


        public Post( string postTitle, string postedTime, Users postedBy, TypeOfPostEnum typeOfPostEnum)
        {
           
            this.PostTitle = postTitle;
            this.PostedTime = postedTime;
            this.PostedBy = postedBy;
            this.TypeOfPost = typeOfPostEnum;
            
        }


        public override string ToString()
        {
           return $"{this.PostId}  Title: {this.PostTitle}  Posted:{this.PostedTime} ";
        }

        public void Add(Comment c)
        {
            comments.Add(c);
            commentMediator.Add(c);
        }
        public void DeleteCommentByPostId(int id)
        {
           // commentMediator.DeleteCommentByPostId(id);
            foreach(Comment c in GetAll())
            {
                if(c.PostId.PostId == id)
                {
                    Delete(c);
                }
            }
        }
        public void Delete(Comment c)
        {
            commentMediator.Delete(c);
        }
        public List<Comment> GetAll()
        {
            comments = commentMediator.GetAll();
            return comments;
        }
        public void Load()
        {
            comments = commentMediator.GetAll();
           
        }
        public Comment GetComment(int id)
        {
            foreach (Comment c in GetAll())
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }
        public List<Comment> GetCommentByPost(int id)
        {
           
            List<Comment> comments = new List<Comment>();
            foreach(Comment c in GetAll())
            {
                if(c.PostId.PostId == id)
                {
                    comments.Add(c);
                }
            }return comments;
        }
        public bool CheckIfCommentExists(int id)
        {

            foreach (Comment c in GetAll())
            {
                if (c.Id == id)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
