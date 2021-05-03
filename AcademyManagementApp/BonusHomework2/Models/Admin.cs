using System;
using System.Linq;
using Models.DB;

namespace Models
{
    public class Admin : User
    {
        public Admin(int id, string fullname, string username, string password) : base(id, fullname, username, password, RoleEnum.Admin)
        {
        }

        public string DeleteUser(User user)
        {
            if(user == this)
            {
                throw new Exception("Fatal error! You can't remove yourself from the list.");
            }

            foreach (User u in Database.Users)
            {
                if(u == user)
                {
                    Database.Users.Remove(u);
                    return $"User {u.FullName} successfully deleted!";
                }
            }
            return $"The user can not be found!";

        }

        public string AddUser(User user)
        {
            if(Database.Users.Any(x => x == user)){
                return $"This user already exist!";
            }

            Database.Users.Add(user);

            return $"User added successfully!";
        }

        public string GetAllUsers()
        {
            string info = "\nThis are all the current users of the academy:";

            foreach(User user in Database.Users)
            {
                if (user.FullName == FullName && user.ID == ID)
                {
                    info += $"\n{ID}. {FullName} (ME)";
                }
                else
                {
                    info += $"\n{user.ID}. {user.FullName} - {user.Role}";
                }
            }

            return info;
        }
    }
}
