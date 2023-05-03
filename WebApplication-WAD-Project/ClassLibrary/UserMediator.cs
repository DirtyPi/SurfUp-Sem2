using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ClassLibrary;
using System.Security.Cryptography;

namespace ClassLibrary
{
    public class UserMediator : DataAccessLayer, IMediator<Users>
    {
        private DataAccessLayer dataAccessLayer;

        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        public void Add(Users users)
        {


            string hPassword = ComputeHash(users.Password, new SHA256CryptoServiceProvider());
            List<Users> listusers = new List<Users>();
            if (ConnOpen())
            {
                query = "INSERT INTO users_hristo(username,password,first_name,last_name,email,role,Status)" +
                    "VALUE (@username,@password,@firstName,@lastName,@email,@role,@Status)";
                SqlQuery(query);

                AddWithValue("@username", users.Username);
                AddWithValue("@password", hPassword);
                AddWithValue("@firstName", users.FirstName);
                AddWithValue("@lastName", users.LastName);
                AddWithValue("@email", users.Email);
                AddWithValue("@role", users.Role.ToString());
                     AddWithValue("@Status", users.Status.ToString());

                NonQueryEx();

                users.Id = Convert.ToInt32(command.LastInsertedId);
                Close();
                //return true;
                listusers.Remove(users);

            }
            else
            {
                Close();
               // return false;
            }
        }

        public List<Users> GetAll()
        {
            List<Users> users = new List<Users>();
            if (ConnOpen())
            {
                
                query = "SELECT * FROM users_hristo";

                   
                    SqlQuery(query);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {

                            Users user = new Users(
                            Convert.ToInt32(dataReader["id"]),
                               
                            dataReader["username"].ToString(),
                            dataReader["email"].ToString(),
                            dataReader["password"].ToString(),
                            dataReader["first_name"].ToString(),
                            dataReader["last_name"].ToString(),
                           (UserRoleEnum)Enum.Parse(typeof(UserRoleEnum), dataReader["role"].ToString()),
                           (UserStatusEnum)Enum.Parse(typeof(UserStatusEnum), dataReader["Status"].ToString()));

                            users.Add(user);
                    }
                        Close();
                        return users; 
            }
            else
            {
                Close();
                return null;
            }

            
        }

        public bool CheckUserDetails(string email, string password)
        {
            if (ConnOpen())
            {
                string hashed = ComputeHash(password, new SHA256CryptoServiceProvider());
                query = "SELECT * FROM users_hristo where email = @email and password = @password";
                SqlQuery(query);
                AddWithValue("@email", email);
                AddWithValue("@password", hashed);
               

                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {

                    Close();
                    return true;
                }
                Close();

                return false;
            }
            else
            {
                Close();
                return false;
                
            }

            
        }
       

        
        public bool UpdateUser(Users users)
        {
            if (ConnOpen())
            {
                query = "UPDATE users_hristo SET " +
                    "username = @username," +
                    " first_name = @first_name, " +
                    "last_name = @last_name , role = @role , Status = @Status,password = @password" +
                    " WHERE id = @id";

                SqlQuery(query);
                AddWithValue("@id", users.Id);

                AddWithValue("@username", users.Username);
                AddWithValue("@first_name", users.FirstName);
                AddWithValue("@last_name", users.LastName);
                AddWithValue("@role", users.Role.ToString());
                AddWithValue("@Status", users.Status.ToString());
                AddWithValue("@password", users.Password);



                NonQueryEx();

                Close();
                return true;

            }
            else
            {
                Close();
                return false;
            }
        }
        public Users GetUserByID(int id)
        {
            Users user = new Users();
            if (ConnOpen())
            {
                query = "SELECT * FROM users_hristo WHERE id = @id";
                SqlQuery(query);
                AddWithValue("@id", id);
               // NonQueryEx();
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    user.Id = Convert.ToInt32(dataReader["id"]);
                }
                Close();
                return user;
            }
            else
            {
                return null;
            }
        }

        public void Delete(Users t)
        {
            throw new NotImplementedException();
        }
    }
}
