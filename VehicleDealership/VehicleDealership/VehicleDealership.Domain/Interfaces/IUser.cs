using VehicleDealership.Domain.Enums;

namespace VehicleDealership.Domain.Interfaces
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Fullname { get; }
        string Username { get; set; }
        UserRoleEnum Role { get; set; }
    }
}
