using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class SortByID : IComparer<Post>
    {
        public int Compare(Post x, Post y)
        {
            return x.PostId.CompareTo(y.PostId);
        }

    }
}
