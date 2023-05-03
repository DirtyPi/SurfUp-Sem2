using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using ClassLibraryService;

namespace WadTestProject
{
    [TestClass]
    public class CommentTest
    {
        [TestMethod]
        public void Addcomment()
        {
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");
            Post a = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Comment c = new Comment("Text", "12.11.2222 12:21", u, a);
            MockCommentMediator mockUserMediator = new MockCommentMediator();
            List<Comment> comments = new List<Comment>();


            comments.Add(c);

            Assert.AreEqual(1, comments.Count, mockUserMediator.GetAll().Count);
        }
        [TestMethod]
        public void GetAllCommentsTest()
        {
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");
            Post a = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            List<Comment> comments = new List<Comment>();
            Comment c = new Comment("Text", "12.11.2222 12:21", u, a);

            MockCommentMediator mockUserMediator = new MockCommentMediator();
            comments.Add(c);

            Assert.AreEqual(1, comments.Count, mockUserMediator.GetAll().Count);
        }
        [TestMethod]
        public void DeleteCommentTest()
        {

            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");
            List<Comment> comments = new List<Comment>();
            Post a = new Annoucement("Testtest", "test", "16/6/2213", u, TypeOfPostEnum.Annoucements);
            Comment c = new Comment("Text", "12.11.2222 12:21", u, a);

            MockPostMediator mockPostMediator = new MockPostMediator();

            MockCommentMediator mockUserMediator = new MockCommentMediator();
            mockPostMediator.Add(c.PostId);
            comments.Add(c);

            mockPostMediator.Delete(c.PostId);
            comments.Remove(c);
            CollectionAssert.AreEquivalent(comments, mockPostMediator.GetAll());

        }
    }
}
