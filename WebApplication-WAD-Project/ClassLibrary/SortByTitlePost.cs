using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SortByTitlePost : IComparer<Post>
    {
        public int Compare(Post x, Post y)
        {
            return x.PostTitle.CompareTo(y.PostTitle);
        }

    }
}
