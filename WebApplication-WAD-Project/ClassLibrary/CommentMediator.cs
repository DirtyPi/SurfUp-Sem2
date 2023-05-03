using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ClassLibrary;



//using WebApplication_WAD_Project.Models;


namespace ClassLibrary
{
    public class CommentMediator : DataAccessLayer
    {
        private DataAccessLayer dataAccessLayer;
        private PostMediator postMediator = new PostMediator();
        private UserMediator userMediator = new UserMediator();

        public void Add(Comment comment)
        {
           
            if (ConnOpen())
            {
                query = "INSERT INTO comment_hristo(comment_text,time,userId,post_id)" +
                    "VALUE(@comment_text,@time,@userId,@post_id)";

                SqlQuery(query);

                AddWithValue("@comment_text", comment.CommentText);
                AddWithValue("@time", comment.CommentedTime);
                AddWithValue("@userId", comment.UserId.Id);
                AddWithValue("@post_id", comment.PostId.PostId);

                NonQueryEx();

                comment.Id = Convert.ToInt32(command.LastInsertedId);
                Close();
                //return true;
            }
            else
            {
                Close();
              //  return false;
            }
        }
        public List<Comment> GetAll()
        {
            List<Comment> comments = new List<Comment>();
            List<Users> users = userMediator.GetAll();
            List<Post> posts = postMediator.GetAll();

            if (ConnOpen())
            {
                try
                {
                    query = "SELECT * FROM comment_hristo ORDER BY id DESC";

                    SqlQuery(query);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Users user = new Users();
                        foreach (Users item in users)
                        {
                            if(item.Id == Convert.ToInt32(dataReader["userId"]))
                                user = item;
                        }
                        Post post = null;
                        foreach(Post p in posts)
                        {
                            if(p.PostId == Convert.ToInt32(dataReader["post_id"]))
                                post = p;
                        }
                        Comment comment = new Comment(dataReader["comment_text"].ToString(),dataReader["time"].ToString(), user, post);
                        comment.Id = Convert.ToInt32(dataReader["id"]);
                        comments.Add(comment);
                    }
                    dataReader.Close();
                    return comments;
                }
                catch(FormatException)
                {
                    Close();
                    return null;
                }
                finally
                {
                    Close();
                }
            }return comments;
        }

        //public List<Comment> GetCommentsByPostID(int postId)
        //{
        //    Post post = postMediator.GetPostByID(postId);
        //    List<Users> users = userMediator.GetAll();
        //    if (ConnOpen())
        //    {
        //        try
        //        {
                   
        //            query = "SELECT * FROM comment_hristo WHERE post_id = @post_id";
                    
        //            SqlQuery(query);
        //            List<Comment> comments = new List<Comment>();
        //            AddWithValue("@post_id", postId);
        //            MySqlDataReader dataReader = command.ExecuteReader();
        //            while (dataReader.Read())
        //            {
        //                Users user = new Users();
        //                foreach (Users  item in users)
        //                {
        //                    if (item.Id == Convert.ToInt32(dataReader["userId"]))
        //                        user = item;
        //                }
        //                Comment comment = new Comment( dataReader["comment_text"].ToString(),
        //                    dataReader["time"].ToString(),
        //                     user,post);
        //                comment.Id = Convert.ToInt32(dataReader["id"]);
        //                comments.Add(comment);
        //            }
        //            Close();
        //            return comments;
        //        }
        //        catch(Exception)
        //        {
        //            Close();
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public void Delete(Comment c)
        {
            if (ConnOpen())
            {
                query = "DELETE FROM comment_hristo WHERE id = @id";
                SqlQuery(query);
                AddWithValue("@id", c.Id);
                NonQueryEx();

                Close();
                //return true;
            }
            else
            {
                Close();
               // return false;
            }
        }
        //public bool DeleteCommentByPostId(int id)
        //{
        //    if (ConnOpen())
        //    {
        //        query = "DELETE FROM comment_hristo WHERE post_id = @post_id";
        //        SqlQuery(query);
        //        AddWithValue("@post_id", id);
        //        NonQueryEx();

        //        Close();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
