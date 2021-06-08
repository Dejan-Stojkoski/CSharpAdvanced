using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public abstract class Employee : User, IEmployee
    {
        public EmployeeRoleEnum Position { get; set; }

        public Employee(int id, string firstName, string lastName, string username, string password, EmployeeRoleEnum position)
            : base(id, "E", firstName, lastName, username, password, UserRoleEnum.Employee)
        {
            Position = position;
        }

        public override string GetInfo()
        {
            return $"[{Id}]. {Fullname} - <{Position}>";
        }
    }
}
