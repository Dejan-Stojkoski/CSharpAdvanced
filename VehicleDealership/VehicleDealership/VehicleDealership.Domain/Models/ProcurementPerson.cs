using System.Collections.Generic;
using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public class ProcurementPerson : Employee, IProcurementPerson
    {
        public delegate void NewVehicleInStockDelegate(List<Vehicle> vehicles);

        public event NewVehicleInStockDelegate NewVehiclesEvent;

        public ProcurementPerson(int id, string firstName, string lastName, string username, string password)
            : base(id, firstName, lastName, username, password, EmployeeRoleEnum.Procurement)
        {

        }

        public void OrderVehiclesEvent(List<Vehicle> vehicles, Buyer buyer)
        {

        }
    }
}
