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
    public class UserTest
    {
        [TestMethod]
        public void AddUser()
        {
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");
            Users u2 = new Users("test2", "te2st@mail.nl", "t2estfirstname", "te2stlastname", "t2estpassword");
            List<Users> users = new List<Users>();

            MockUserMediator mockUserMediator = new MockUserMediator();
            UserManager userManager = new UserManager(mockUserMediator);
            userManager.CheckIfUserExists(u);
            userManager.CheckIfUserExists(u2);
            users.Add(u);
            users.Add(u2);

            Assert.AreEqual(2, users.Count, userManager.GetAll().Count);
        }
        [TestMethod]
        public void AddUserValidated()
        {
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");
            Users u2 = new Users("test2", "test@mail.nl", "t2estfirstname", "te2stlastname", "t2estpassword");
            List<Users> users = new List<Users>();

            MockUserMediator mockUserMediator = new MockUserMediator();
            UserManager userManager = new UserManager(mockUserMediator);
            userManager.CheckIfUserExists(u);
            userManager.CheckIfUserExists(u2);
            

            Assert.AreEqual(0, users.Count, userManager.GetAll().Count);
        }
        [TestMethod]
        public void GetAllUsers()
        {
            Users u = new Users("test", "test@mail.nl", "testfirstname", "testlastname", "testpassword");
            Users u2 = new Users("test2", "test@mail.nl", "t2estfirstname", "te2stlastname", "t2estpassword");
            List<Users> users = new List<Users>();

            MockUserMediator mockUserMediator = new MockUserMediator();
            UserManager userManager = new UserManager(mockUserMediator);

            users.Add(u);
            users.Add(u2);

            Assert.AreEqual(2, users.Count, userManager.GetAll().Count);
        }

        [TestMethod]
        public void GetAllAdminUsersTest()
        {
            Users u = new Users(1, "test", "test@mail.nl", "testfirstname", "testlastname", "testpassword", UserRoleEnum.AdminUser, UserStatusEnum.Valid);
            Users u2 = new Users(2, "test2", "test@mail.nl", "t2estfirstname", "te2stlastname", "t2estpassword", UserRoleEnum.BaseUser, UserStatusEnum.Ban);

            MockUserMediator mockUserMediator = new MockUserMediator();
            UserManager userManager = new UserManager(mockUserMediator);

            userManager.Add(u);
            userManager.Add(u2);

            Assert.AreEqual(1, userManager.GetAdminUsers().Count);
        }

        [TestMethod]
        public void GetAllBaseUsersTest()
        {
            Users u = new Users(1, "test", "test@mail.nl", "testfirstname", "testlastname", "testpassword", UserRoleEnum.AdminUser, UserStatusEnum.Valid);
            Users u2 = new Users(2, "test2", "test@mail.nl", "t2estfirstname", "te2stlastname", "t2estpassword", UserRoleEnum.BaseUser, UserStatusEnum.Ban);

            MockUserMediator mockUserMediator = new MockUserMediator();
            UserManager userManager = new UserManager(mockUserMediator);

            userManager.Add(u);
            userManager.Add(u2);

            Assert.AreEqual(1, userManager.GetBaseUsers().Count);
        }
        
    }
}
