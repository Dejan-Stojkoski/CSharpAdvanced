using System.Collections.Generic;
using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public class SalesPerson : Employee, ISalesPerson
    {
        public List<Vehicle> SoldVehicles { get; set; }
        public SalesPerson(int id, string firstName, string lastName, string username, string password)
            : base(id, firstName, lastName, username, password, EmployeeRoleEnum.Sales)
        {
            SoldVehicles = new List<Vehicle>();
        }
    }
}
