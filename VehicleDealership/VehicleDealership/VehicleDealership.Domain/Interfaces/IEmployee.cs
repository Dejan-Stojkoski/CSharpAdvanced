using VehicleDealership.Domain.Enums;

namespace VehicleDealership.Domain.Interfaces
{
    public interface IEmployee
    {
        EmployeeRoleEnum Position { get; set; }
    }
}
