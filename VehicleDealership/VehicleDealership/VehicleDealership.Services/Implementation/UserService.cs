using System;
using System.Linq;
using VehicleDealership.Domain.Database;
using VehicleDealership.Domain.Interfaces;
using VehicleDealership.Domain.Models;
using VehicleDealership.Services.Interfaces;

namespace VehicleDealership.Services.Implementation
{
    public class UserService<T> : IUserService<T> where T : User
    {
        private IDbTable<T> table;

        public UserService()
        {
            if(typeof(T) == typeof(Buyer))
            {
                table = (IDbTable <T>) LocalDatabase.Buyers;
            }

            if(typeof(T) == typeof(SalesPerson))
            {
                table = (IDbTable<T>)LocalDatabase.SalesPeople;
            }

            if (typeof(T) == typeof(ProcurementPerson))
            {
                table = (IDbTable<T>)LocalDatabase.ProcurementPeople;
            }
        }

        public T Login(string password, string username)
        {
            T user = table.GetAll().FirstOrDefault(x => x.Username == username && x.CheckPassword(password));

            if(user == null)
            {
                throw new Exception("Invalid username or password!");
            }

            return user;
        }

        public T Register(T user)
        {
            table.Insert(user);
            return user;
        }

        public string ChangePassword(string id, string oldPassword, string newPassword)
        {
            T user = table.GetAll().FirstOrDefault(x => x.Id == id);

            if(user == null)
            {
                throw new Exception($"There is no user with id {id} found.");
            }

            if (!user.CheckPassword(oldPassword))
            {
                throw new Exception("Invalid password!");
            }

            if(oldPassword == newPassword)
            {
                throw new Exception("New password can not be same as the old password!");
            }

            user.ChangePassword(newPassword);
            return $"Password changed successfully!";
        }
    }
}
