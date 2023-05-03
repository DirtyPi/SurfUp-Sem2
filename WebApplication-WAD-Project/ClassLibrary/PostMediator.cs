using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
//using WebApplication_WAD_Project.Models;
using ClassLibrary;


namespace ClassLibrary 
{ 
    public class PostMediator : DataAccessLayer,IMediator<Post>
    {
        private DataAccessLayer dataAccessLayer;
        private UserMediator userMediator = new UserMediator();
        
        

       
       public void Add(Post post)
        {
            
            if (ConnOpen())
            {
                if(post is Annoucement)
                {
                    Annoucement annoucement = (Annoucement)post;


                    query = "INSERT INTO posts_hristo (id,title,contains,time,postedBy,typeOfPost)" +
                    " VALUE (@id,@title,@contains,@time,@postedBy,@typeOfPost)";
                    SqlQuery(query);
                    AddWithValue("@id", annoucement.PostId);
                    AddWithValue("@contains", annoucement.Description);
                    AddWithValue("@title", annoucement.PostTitle);
                    
                    AddWithValue("@time", annoucement.PostedTime);
                    AddWithValue("@postedBy", annoucement.PostedBy.Id);
                    AddWithValue("@typeOfPost", annoucement.TypeOfPost);

                    NonQueryEx();
                    post.PostId = Convert.ToInt32(command.LastInsertedId);
                    Close();
                    //return true;
                }
                else if(post is MediaPost)
                {
                    MediaPost mediaPost = (MediaPost)post;
                    query = "INSERT INTO posts_hristo (id,title,time,postedBy,contains,typeOfPost)" +
                    " VALUE (@id,@title,@time,@postedBy,@contains,@typeOfPost)";
                    SqlQuery(query);
                    AddWithValue("@id", mediaPost.PostId);
                    AddWithValue("@contains", mediaPost.Video + ".mp4");
                    AddWithValue("@title", mediaPost.PostTitle);

                    AddWithValue("@time", mediaPost.PostedTime);
                    AddWithValue("@postedBy", mediaPost.PostedBy.Id);
                    AddWithValue("@typeOfPost", mediaPost.TypeOfPost);

                    NonQueryEx();
                    post.PostId = Convert.ToInt32(command.LastInsertedId);
                    Close();
                   // return true;
                }
                else if (post is ImagePost)
                {
                    ImagePost imagePost = (ImagePost)post;
                    query = "INSERT INTO posts_hristo (id,title,time,postedBy,contains,typeOfPost)" +
                    " VALUE (@id,@title,@time,@postedBy,@contains,@typeOfPost)";
                    SqlQuery(query);
                    AddWithValue("@id", imagePost.PostId);
                    AddWithValue("@contains", imagePost.Image + ".jpg");
                    AddWithValue("@title", imagePost.PostTitle);

                    AddWithValue("@time", imagePost.PostedTime);
                    AddWithValue("@postedBy",imagePost.PostedBy.Id);
                    AddWithValue("@typeOfPost", imagePost.TypeOfPost);


                    NonQueryEx();
                    post.PostId = Convert.ToInt32(command.LastInsertedId);
                    Close();
                   // return true;
                }
                else
                {
                    Close();
                    // return false;
                     
                }

            }
            else
            {
                Close();
                //return false;
            }
        }
        public void Delete(Post post)
        {
            if (ConnOpen())
            {
                try
                {
                    if (post is Annoucement)
                    {
                        Annoucement annoucement = (Annoucement)post;
                        query = "DELETE FROM posts_hristo WHERE id = @id";
                        SqlQuery(query);
                        AddWithValue("@id", post.PostId);
                        NonQueryEx();

                        Close();
                        //return true;
                    }
                    else if(post is MediaPost)
                    {
                        MediaPost mediaPost = (MediaPost)post;
                        query = "DELETE FROM posts_hristo WHERE id = @id";
                        SqlQuery(query);
                        AddWithValue("@id", post.PostId);
                        NonQueryEx();

                        Close();
                        //return true;
                    }
                    else if (post is ImagePost)
                    {
                        ImagePost imagePost = (ImagePost)post;
                        query = "DELETE FROM posts_hristo WHERE id = @id";
                        SqlQuery(query);
                        AddWithValue("@id", post.PostId);
                        NonQueryEx();

                        Close();
                        //return true;
                    }
                    else
                    {
                        Close();
                      //  return false;
                    }



                }
                catch (FormatException)
                {
                    Close();
                    //return false;

                }

            }
            else { Close();/*return false;*/ }
        }



       

        public List<Post> GetAll()
        {
            List<Users> users = userMediator.GetAll();

            if (ConnOpen())
            {
                query = "SELECT * FROM posts_hristo ORDER BY id DESC";
                SqlQuery(query);
                List<Post> posts = new List<Post>();
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Users user = new Users();
                    foreach (Users item in users)
                    {
                        if (item.Id == Convert.ToInt32(dataReader["postedBy"]))
                            user = item;
                    }
                    if (Convert.ToInt32(dataReader["typeOfPost"]) == 1)
                    {
                        MediaPost mediaPost = new MediaPost(
                         dataReader["contains"].ToString(),
                         dataReader["title"].ToString(),
                         dataReader["time"].ToString(),

                        user,
                         //new Users(Convert.ToInt32(dataReader["postedBy"])),
                         (TypeOfPostEnum)Enum.Parse(typeof(TypeOfPostEnum), dataReader["typeOfPost"].ToString()));

                        mediaPost.PostId = Convert.ToInt32(dataReader["id"]);
                        posts.Add(mediaPost);
                    }
                    else if (dataReader["typeOfPost"].ToString() == "2")
                    {
                       Annoucement annoucement = new Annoucement(
                       dataReader["contains"].ToString(),
                       dataReader["title"].ToString(),
                       dataReader["time"].ToString(),
                       user,
                     // userMediator.GetUserByID(Convert.ToInt32(dataReader["postedBy"])),
                       //(Convert.ToInt32(dataReader["postedBy"])),
                       (TypeOfPostEnum)Enum.Parse(typeof(TypeOfPostEnum), dataReader["typeOfPost"].ToString()));

                        annoucement.PostId = Convert.ToInt32(dataReader["id"]);
                        posts.Add(annoucement);
                    }
                    else if (dataReader["typeOfPost"].ToString() == "3")
                    {
                        ImagePost image = new ImagePost(


                       dataReader["contains"].ToString(),
                       
                       dataReader["title"].ToString(),
                       dataReader["time"].ToString(),
                       user,
                        //userMediator.GetUserByID(Convert.ToInt32(dataReader["postedBy"])),
                       // Convert.ToInt32(dataReader["postedBy"]),
                       (TypeOfPostEnum)Enum.Parse(typeof(TypeOfPostEnum), dataReader["typeOfPost"].ToString()));

                        image.PostId = Convert.ToInt32(dataReader["id"]);
                        posts.Add(image);
                    }
                   
                }
                Close();
                return posts;
            }
            else
            {
                Close();
                return null;
            }
        }



        public Post GetPostByID(int id)
        {

            List<Users> users = userMediator.GetAll();
            if (ConnOpen())
            {

                query = "SELECT * FROM posts_hristo WHERE id = @id";
                SqlQuery(query);
                AddWithValue("@id", id);
                //NonQueryEx();

                Post post = null;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Users user = new Users();
                    foreach (Users item in users)
                    {
                        if (item.Id == Convert.ToInt32(dataReader["postedBy"]))
                            user = item;
                    }
                    if (Convert.ToInt32(dataReader["typeOfPost"]) == 1)
                    {
                        post = new MediaPost(
                         dataReader["contains"].ToString(),
                         dataReader["title"].ToString(),
                         dataReader["time"].ToString(),

                        user,
                         //new Users(Convert.ToInt32(dataReader["postedBy"])),
                         (TypeOfPostEnum)Enum.Parse(typeof(TypeOfPostEnum), dataReader["typeOfPost"].ToString()));

                        post.PostId = Convert.ToInt32(dataReader["id"]);

                    }
                    else if (dataReader["typeOfPost"].ToString() == "2")
                    {
                        post = new Annoucement(
                        dataReader["contains"].ToString(),
                        dataReader["title"].ToString(),
                        dataReader["time"].ToString(),
                        user,
                        // userMediator.GetUserByID(Convert.ToInt32(dataReader["postedBy"])),
                        //(Convert.ToInt32(dataReader["postedBy"])),
                        (TypeOfPostEnum)Enum.Parse(typeof(TypeOfPostEnum), dataReader["typeOfPost"].ToString()));

                        post.PostId = Convert.ToInt32(dataReader["id"]);

                    }
                    else if (dataReader["typeOfPost"].ToString() == "3")
                    {
                        post = new ImagePost(
                       dataReader["contains"].ToString(),

                       dataReader["title"].ToString(),
                       dataReader["time"].ToString(),
                       user,
                       //userMediator.GetUserByID(Convert.ToInt32(dataReader["postedBy"])),
                       // Convert.ToInt32(dataReader["postedBy"]),
                       (TypeOfPostEnum)Enum.Parse(typeof(TypeOfPostEnum), dataReader["typeOfPost"].ToString()));

                        post.PostId = Convert.ToInt32(dataReader["id"]);

                    }

                }
          

                Close();
                return post;

            }
            else
            {
                Close();
                return null;
            }
        }
    }
}
