using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using ClassLibraryDAL;
using ClassLibrary;
//using WebApplication_WAD_Project.Models;

namespace ClassLibraryService
{
    public class UserManager
    {
        IMediator<Users> mediator;
        private UserMediator userMediator;

        public UserManager()
        {
            userMediator = new UserMediator();
        }
        public UserManager(IMediator<Users> imediator)
        {
            this.mediator = imediator;
            userMediator = new UserMediator();
            Load();
        }
        public void Add(Users u)
        {
           mediator.Add(u);
        }
        
        public void UpdateUser(Users u)
        {
           // GetAll();
            userMediator.UpdateUser(u);

        }
      
        public List<Users> GetAll()
        {
            return mediator.GetAll();
        }
        public Users GetUser(string email)
        {
            foreach (Users u in GetAll())
            {
                if (u.Email == email)
                {
                    return u;
                }
            }
            return null;
        }
      
        public Users GetUserByID(int id)
        {
            foreach (Users u in GetAll())
            {
                if (u.Id == id)
                {
                    return u;
                }
            }
            return null;
        }
       
       
            public bool CheckIfUserIsReal(string email, string password)
            {
                return userMediator.CheckUserDetails(email,password);
            }

        public bool CheckIfUserExists(Users user)
        {
            foreach(Users u in GetAll())
            {
                if(user.Email == u.Email)
                {
                    if (user.Username == u.Username && user.Password == u.Password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public List<Users> GetAdminUsers()
        {
            List<Users> users = new List<Users>();
            Load();
            foreach(Users u in GetAll())
            {
                if(u.Role == ClassLibrary.UserRoleEnum.AdminUser)
                {
                    users.Add(u);
                }
            }return users;
        }
        private bool Load()
        {
            if (GetAll() != null)
            {
                return true;
            }
            else { return false; }
        }
        public List<Users> GetBaseUsers()
        {
            List<Users> users = new List<Users>();
            Load();
            foreach (Users u in GetAll())
            {
                if (u.Role == ClassLibrary.UserRoleEnum.BaseUser)
                {
                    users.Add(u);
                }
            }
            return users;
        }
        public void UpdateUserStatus(Users u)
        {
           
            if(u.Status == UserStatusEnum.Valid)
            {
               u.Status = UserStatusEnum.Ban;
               userMediator.UpdateUser(u);

            }
            else
            {
               u.Status = UserStatusEnum.Valid;
               userMediator.UpdateUser(u);

            }

        }
        public void UpdateUserRole(Users u)
        {
            if(u.Role == UserRoleEnum.AdminUser)
            {
                u.Role = UserRoleEnum.BaseUser;
                userMediator.UpdateUser(u);

            }
            else
            {
                u.Role = UserRoleEnum.AdminUser;
                userMediator.UpdateUser(u);
            }
        }
       
    }

}

   

