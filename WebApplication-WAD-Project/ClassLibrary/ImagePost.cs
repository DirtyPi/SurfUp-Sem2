using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ImagePost: Post
    {
        public ImagePost() { }
        public string Image { get; set; }
        public ImagePost(string image, string title, string postedOn, Users postedBy, TypeOfPostEnum typeOfPostEnum) : base(title, postedOn, postedBy, typeOfPostEnum)
        {
            this.Image = image;
        }

        public override string ToString()
        {
            return $"{base.ToString()} (Image)";
        }
    }
}
