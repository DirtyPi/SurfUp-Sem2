using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public class Users
    {
        public Users() { }

            public int Id { get; set; }
            //idSeeder++
            [Required(ErrorMessage = "Please type your Username")]
            public string Username { get; set; }
            [Required(ErrorMessage = "Please type a valid email")]
            [DataType(DataType.EmailAddress)]
            [EmailAddress(ErrorMessage ="This isn't a valid Email")]
            public string Email { get; set; }
            [Required (ErrorMessage ="Please type a password in the space")]
            //[RegularExpression(@"^(?:.*[a-z]){5,}$",ErrorMessage = "Password must be at least 5 charecters long!")]
            [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
             [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        public string Password { get; set; }
           // [Required(ErrorMessage = "Please type a confirmation password in the space")]
          //  [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            //public string Password2 { get; set; }
            //[Required (ErrorMessage ="Please type your first name!")]
            public string FirstName { get; set; }
            [Required(ErrorMessage ="Please type ypur last name!")]
            public string LastName { get; set; }
            public UserRoleEnum Role { get; set; }
            public UserStatusEnum Status { get; set; }
            public Users(string email, string password)
            {
            this.Email = email;
            this.Password = password;
            }
            public Users(string username, string email, string firstName, string lastName,string password)
            {
                this.Username = username;
                this.Email = email;
                this.Password = password;
                this.FirstName = firstName;
                this.LastName = lastName;
                //this.Password2 = password2;
            
            }

        public Users(int id)
        {
            this.Id = id;

        }
        public Users(int id,string username, string email, string password, string firstName, string lastName, UserRoleEnum role,UserStatusEnum status)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.Status = status;
        }

        public void Update(string username, string firstName, string lastName, string password)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
        }

        public string ToString()
        {
            return $"{this.Id} {this.FirstName}";
        }
        public string GetUserName()
        {
            return $"{this.Username}";
        }


    }
}
