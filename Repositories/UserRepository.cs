using System.Collections.Generic;
using System.Linq;
using AuthenticationJWT.models;

namespace AuthenticationJWT.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "Batman", Password = "Batman", Role = "manager" });
            users.Add(new User { Id = 2, Username = "Robin", Password = "Robin", Role = "employee" });
            
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}