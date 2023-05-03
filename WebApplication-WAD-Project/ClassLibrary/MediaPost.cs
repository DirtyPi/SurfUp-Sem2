using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class MediaPost: Post
    {
        public MediaPost() { }
        public string Video { get; set; }

        public MediaPost(string video, string title, string postedOn,Users postedBy,TypeOfPostEnum typeOfPostEnum) : base( title, postedOn, postedBy, typeOfPostEnum)
        {
            this.Video = video;
        }

        public override string ToString()
        {
            return $"{base.ToString()} (Media)";
        }
    }
}
