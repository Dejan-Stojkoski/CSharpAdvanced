using System.Collections.Generic;
using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public class Buyer : User, IBuyer
    {
        public double Balance { get; set; }
        public List<Order> Orders { get; set; }

        public Buyer(int id, string firstName, string lastName, string username, string password, double balance)
            : base(id, "B", firstName, lastName, username, password, UserRoleEnum.Buyer)
        {
            Orders = new List<Order>();
            Balance = balance;
        }

        public override string GetInfo()
        {
            return $"[{Id}]. {Fullname}";
        }

        public void NewVehiclesInStockSubscriber()
        {

        }
    }
}
