using System;

namespace Models
{
    public class User
    {
        public string Username { get; set; }
        private string Password { get; set; }
        public RoleEnum Role { get; private set; }

        public User(string username, string password, RoleEnum role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public User LogIn(string username, string password)
        {
            if(Username != username)
            {
                return null;
            }

            if(Password != password)
            {
                throw new Exception("Invalid username or password!");
            }

            return this;
        }
    }
}
