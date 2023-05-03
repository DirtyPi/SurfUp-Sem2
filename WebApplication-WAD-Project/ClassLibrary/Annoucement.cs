using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Annoucement : Post
    {
       
            public Annoucement() { }
        public string Description { get; set; }
        public Annoucement(string description,string title , string postedOn, Users postedBy, TypeOfPostEnum typeOfPostEnum) : base (title, postedOn, postedBy, typeOfPostEnum)
        {
            this.Description = description;
        }
        public override string ToString()
        {
            return $"{base.ToString()} (Annoucement)";
        }
    }
}
