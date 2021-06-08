using VehicleDealership.Domain.Database;
using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public class Van : Vehicle, IVan
    {
        public int LoadCapacity { get; set; }

        public Van(int id, string model, double price, int loadCapacity)
            : base(id, model, price, VehicleTypeEnum.Van)
        {
            LoadCapacity = loadCapacity;
        }

        public override string BuyVehicle(Buyer buyer)
        {
            Order order = new Order(buyer, this, OrderStatusEnum.Pending, Price);
            LocalDatabase.Orders.Insert(order);
            buyer.Orders.Add(order);
            return $"Your order has been placed Total amount: {Price}!";
        }
    }
}
