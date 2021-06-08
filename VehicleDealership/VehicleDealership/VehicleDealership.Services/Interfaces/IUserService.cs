using VehicleDealership.Domain.Models;

namespace VehicleDealership.Services.Interfaces
{
    public interface IUserService<T> where T : User
    {
        T Login(string username, string password);
        T Register(T user);
        string ChangePassword(string id, string oldPassword, string newPassword);
    }
}
