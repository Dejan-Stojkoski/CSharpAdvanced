using System;
using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Helpers;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public abstract class User : BaseEntity, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname => $"{FirstName} {LastName}";
        public string Username { get; set; }
        private string Password { get; set; }
        public UserRoleEnum Role { get; set; }

        public User(int id, string prefix, string firstName, string lastName, string username, string password, UserRoleEnum role) : base(id, prefix)
        {
            if (!ValidationHelper.ValidateUsername(username))
            {
                throw new Exception("The username is not valid! The username must be at least 6 characters long and has at least one upper letter.");
            }
            if (!ValidationHelper.ValidatePassword(password))
            {
                throw new Exception("The password is not valid! The password must be at least 7 characters long, has at least one upper letter and one digit.");
            }
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Role = role;
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }

        public void ChangePassword(string newPassword)
        {
            if (!ValidationHelper.ValidatePassword(newPassword))
            {
                throw new Exception("The password did not met the requirements!");
            }

            Password = newPassword;
        }
    }
}
