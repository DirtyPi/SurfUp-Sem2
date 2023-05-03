using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using ClassLibraryService;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WadTestProject
{
    [TestClass]
    public class PostTest
    {
        [TestMethod]
        public void AddUser()
        {
            //arrange
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");
            List<Post> posts = new List<Post>();
            Post a = new Annoucement("Testtest","test","16/6/2213",u,TypeOfPostEnum.Annoucements);
            Post m = new MediaPost("Testtest.mp4", "test", "16/6/2233", u, TypeOfPostEnum.MediaPosts);
            Post i = new ImagePost("dsaddsa.jpg", "test", "16/6/2213", u, TypeOfPostEnum.ImagePosts);
            MockPostMediator med = new MockPostMediator();
            PostManager manager = new PostManager(med);
            //act
            
            manager.Add(a);
            manager.Add(m);
            manager.Add(i);
            posts.Add(a);
            posts.Add(m);
            posts.Add(i);
            //assert
            Assert.AreEqual(3, posts.Count, manager.GetAll().Count);
        }

        [TestMethod]
        public void GetPostsTest()
        {
            //arrange
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");

            //List<Post> posts = new List<Post>();
            Post a = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post m = new MediaPost("Testtest.mp4", "test", "16/6/2233", u, TypeOfPostEnum.MediaPosts);
            Post i = new ImagePost("dsaddsa.jpg", "test", "16/6/2213", u, TypeOfPostEnum.ImagePosts);
            MockPostMediator med = new MockPostMediator();
            PostManager manager = new PostManager(med);
            //act
           
            manager.Add(a);
            manager.Add(m);
            manager.Add(i);
            //assert
            Assert.AreEqual(3, manager.GetAll().Count);
        }
        [TestMethod]
        public void GetPostsByTypeTest()
        {
            // should return all types
            //arrange
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");

            List<Post> posts = new List<Post>();
            Post a = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post a2 = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post m = new MediaPost("Testtest.mp4", "test", "16/6/2233", u, TypeOfPostEnum.MediaPosts);
            Post i = new ImagePost("dsaddsa.jpg", "test", "16/6/2213", u, TypeOfPostEnum.ImagePosts);
            int type = 0;

            MockPostMediator med = new MockPostMediator();
            PostManager manager = new PostManager(med);
            //act
            // manager.GetPostByType(type);
            manager.Add(a);
            manager.Add(a2);
            manager.Add(m);
            manager.Add(i); 

            //assert
            Assert.AreEqual(4, manager.GetPostByType(type).Count);
            
        }
        [TestMethod]
        public void GetPostsByTypeTestMedia()
        {
            // should return 1 types
            //arrange
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");

           
            Post a = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post a2 = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post m = new MediaPost("Testtest.mp4", "test", "16/6/2233", u, TypeOfPostEnum.MediaPosts);
            Post i = new ImagePost("dsaddsa.jpg", "test", "16/6/2213", u, TypeOfPostEnum.ImagePosts);
            int type = 1;

            MockPostMediator med = new MockPostMediator();
            PostManager manager = new PostManager(med);
            //act
          
            manager.Add(a);
            manager.Add(a2);
            manager.Add(m);
            manager.Add(i);

            //assert
            Assert.AreEqual(1, manager.GetPostByType(type).Count);

        }
        [TestMethod]
        public void GetPostsByTypeTestAnnoucements()
        {
            // should return 2 types of posts
            //arrange
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");

           
            Post a = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post a2 = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post m = new MediaPost("Testtest.mp4", "test", "16/6/2233", u, TypeOfPostEnum.MediaPosts);
            Post i = new ImagePost("dsaddsa.jpg", "test", "16/6/2213", u, TypeOfPostEnum.ImagePosts);
            int type = 2;

            MockPostMediator med = new MockPostMediator();
            PostManager manager = new PostManager(med);
            //act
            
            manager.Add(a);
            manager.Add(a2);
            manager.Add(m);
            manager.Add(i);

            //assert
            Assert.AreEqual(2, manager.GetPostByType(type).Count);

        }
        [TestMethod]
        public void GetPostsByTypeTestImages()
        {
            // should return 1 types of posts
            //arrange
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");

           
            Post a = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post a2 = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post m = new MediaPost("Testtest.mp4", "test", "16/6/2233", u, TypeOfPostEnum.MediaPosts);
            Post i = new ImagePost("dsaddsa.jpg", "test", "16/6/2213", u, TypeOfPostEnum.ImagePosts);
            int type = 1;

            MockPostMediator med = new MockPostMediator();
            PostManager manager = new PostManager(med);
            //act
       
            manager.Add(a);
            manager.Add(a2);
            manager.Add(m);
            manager.Add(i);

            //assert
            Assert.AreEqual(1, manager.GetPostByType(type).Count);

        }
        [TestMethod]
        public void SearchPostsByItem()
        {
            // should return 1 types of posts
            //arrange
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");


            Post a = new Annoucement("Testtest", "FindMe", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post a2 = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Post m = new MediaPost("Testtest.mp4", "test", "16/6/2233", u, TypeOfPostEnum.MediaPosts);
            Post i = new ImagePost("dsaddsa.jpg", "FindMe", "16/6/2213", u, TypeOfPostEnum.ImagePosts);
            string item = "FindMe";

            MockPostMediator med = new MockPostMediator();
            PostManager manager = new PostManager(med);
            //act

            manager.Add(a);
            manager.Add(a2);
            manager.Add(m);
            manager.Add(i);

            //assert
            Assert.AreEqual(2, manager.SearchPost(item).Count);

        }
        [TestMethod]
        public void DeletePost()
        {
            
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");
            List<Post> posts = new List<Post>();
            Post a = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);

            MockPostMediator mockPostMediator = new MockPostMediator();

            PostManager manager = new PostManager(mockPostMediator);
            manager.Add(a);
            posts.Add(a);

            manager.Delete(a);
            posts.Remove(a);
            CollectionAssert.AreEquivalent(posts,manager.GetAll());

        }
    }
}
