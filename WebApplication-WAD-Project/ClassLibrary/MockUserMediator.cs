using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ClassLibrary
{
   public class MockUserMediator : IMediator<Users>
    {
        List<Users> users = new List<Users>();
        public void Add(Users u)
        {
            
            users.Add(u);
        }
        public List<Users> GetAll()
        {
            return users;
        }
        
void IMediator<Users>.Delete(Users t)
        {
            throw new NotImplementedException();
        }
    }
}
