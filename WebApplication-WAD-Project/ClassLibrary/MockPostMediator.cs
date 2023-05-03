using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MockPostMediator : IMediator<Post>
    {
        List<Post> posts = new List<Post>();
        public void Add(Post p)
        {
           
            posts.Add(p);
        }
        public List<Post> GetAll()
        {
           
            return posts;
        }
        public void Delete(Post p)
        {
           
            posts.Remove(p);
        }
    }
}
