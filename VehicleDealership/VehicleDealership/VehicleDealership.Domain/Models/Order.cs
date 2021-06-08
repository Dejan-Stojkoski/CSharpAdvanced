using VehicleDealership.Domain.Database;
using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public class Order : BaseEntity,IOrder
    {
        public Buyer Buyer { get; set; }
        public Vehicle Vehicle { get; set; }
        public OrderStatusEnum Status { get; set; }
        public double Price { get; set; }

        public Order(Buyer buyer, Vehicle vehicle) : base(LocalDatabase.Orders.GetAll().Count + 1, "O")
        {
            Buyer = buyer;
            Vehicle = vehicle;
            Status = OrderStatusEnum.NotSet;
        }

        public Order(Buyer buyer, Vehicle vehicle, OrderStatusEnum status, double price) : base(LocalDatabase.Orders.GetAll().Count + 1, "O")
        {
            Buyer = buyer;
            Vehicle = vehicle;
            Status = status;
            Price = price;
        }

        public override string GetInfo()
        {
            return $"Order {Id}: Buyer - {Buyer.Fullname}, Vehicle - {Vehicle.Model}, Price - {Price}, Status - {Status}";
        }
    }
}
