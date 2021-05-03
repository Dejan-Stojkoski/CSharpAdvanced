using System;

namespace Models
{
    public abstract class User
    {
        public int ID { get; private set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }
        public RoleEnum Role { get; private set; }

        public User(int id, string fullname, string username, string password, RoleEnum role)
        {
            ID = id;
            FullName = fullname;
            Username = username;
            Password = password;
            Role = role;
        }

        public User Login(string username, string password)
        {
            if(Username != username)
            {
                return null;
            }

            if(Password != password)
            {
                throw new Exception("Wrong password!");
            }

            return this;
        }
    }
}
