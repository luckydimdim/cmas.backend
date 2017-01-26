using System.Collections.Generic;

namespace cmas.backend.Authentication
{
    public class UserModel
    {
        public  int Id;
        public string Login;
        public string FirstName;
        public string LastName;
        public string Password;
        public List<UserRole> UserRole;

        public UserModel()
        {
            UserRole = new List<UserRole>();
        }
    }
}