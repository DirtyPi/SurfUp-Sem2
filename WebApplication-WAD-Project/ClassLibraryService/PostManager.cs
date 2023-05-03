using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using ClassLibraryDAL;
using ClassLibrary;
//using WebApplication_WAD_Project.Models;

namespace ClassLibraryService
{
    public class PostManager
    {
        IMediator<Post> mediator;
        private List<Post> posts;
        private PostMediator postMediator;

        
        public PostManager()
        {
            posts = new List<Post>();
            postMediator = new PostMediator();
        }

        public PostManager(IMediator<Post> imediator)
        {
            posts = new List<Post>();
            this.mediator = imediator;
            postMediator = new PostMediator();
            Load();

        }

        public void Add(Post p)
        {
           
            mediator.Add(p);
        }
        
        public void Delete(Post p)
        {
           
            p.DeleteCommentByPostId(p.PostId);
            mediator.Delete(p);
           
        }
        public List<Post> GetAll()
        {
           
            return mediator.GetAll(); 
        }
        public void Load()
        {
            this.posts = postMediator.GetAll();
        }
        public Post GetPostById(int id)
        {
            //Post p = postMediator.GetPostByID(id);
            // return p;
            foreach (Post m in mediator.GetAll())
            {
                if (m.PostId == id)
                {
                    return m;
                }
            }
            return null;
        }
        public List<Post> GetPostByType(int type)
        {
            List<Post> posts = new List<Post>();
            if (type == 0)
            {
                foreach (Post s in GetAll())
                {
                    // lbPosts.Items.Add(s.ToString());
                   posts.Add(s);
                   
                }
            }
            else if (type == 1)
            {
                foreach (Post m in GetAll())
                {
                    if (m.TypeOfPost == TypeOfPostEnum.MediaPosts)
                    {
                        //lbPosts.Items.Add(m.ToString());
                        posts.Add(m);
                    }

                }
            }
            else if (type == 2)
            {
                foreach (Post a in GetAll())
                {
                    if (a.TypeOfPost == ClassLibrary.TypeOfPostEnum.Annoucements)
                    {
                        //lbPosts.Items.Add(a.ToString());
                        posts.Add(a);
                    }
                }
            }
            else if (type == 3)
            {
                foreach (Post i in GetAll())
                {
                    if (i.TypeOfPost == ClassLibrary.TypeOfPostEnum.ImagePosts)
                    {
                        //lbPosts.Items.Add(i.ToString());
                        posts.Add(i);
                    }
                }
            }
            return posts;
        }
        public List<Post> SearchPost(string item)
        {
            List<Post> posts = GetAll();
            List<Post> foundposts = new List<Post>();
            foreach(Post p in posts)
            {
                if(item == p.PostTitle || item == p.PostId.ToString() || item == p.PostedTime|| item == p.TypeOfPost.ToString() || item == p.PostedBy.ToString())
                {
                    foundposts.Add(p);
                }
            }return foundposts;
        }
    }
}