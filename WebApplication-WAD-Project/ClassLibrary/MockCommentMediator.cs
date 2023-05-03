using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class MockCommentMediator
    {
        List<Comment> comments = new List<Comment>();
        public void Add(Comment c)
        {
            comments.Add(c);
        }
        public List<Comment> GetAll()
        {
            return comments;
        }
        public void Delete(Comment c)
        {
            comments.Remove(c);
        }
    }
}
