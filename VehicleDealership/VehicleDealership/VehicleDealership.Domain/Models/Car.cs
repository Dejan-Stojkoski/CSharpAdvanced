using System;
using VehicleDealership.Domain.Database;
using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public class Car : Vehicle, ICar
    {
        public EngineTypeEnum EngineType { get; set; } = EngineTypeEnum.Petrol;

        public Car(int id, string model, double price)
            : base(id, model, price, VehicleTypeEnum.Car)
        {
        }

        public override string BuyVehicle(Buyer buyer)
        {
            if(EngineType == EngineTypeEnum.Diesel)
            {
                Price += Price / 10 / 2;
            }

            if(EngineType == EngineTypeEnum.Hybrid)
            {
                Price += Price / 10 + Price / 10 / 2; 
            }

            Order order = new Order(buyer, this, OrderStatusEnum.Pending, Price);
            LocalDatabase.Orders.Insert(order);
            buyer.Orders.Add(order);
            return $"Your order has been placed Total amount: {Price}!";
        }

        public double GetDieselPrice()
        {
            double price = Price;
            return price += Price / 10 / 2;
        }

        public double GetHybridPrice()
        {
            double price = Price;
            return price += Price / 10 + Price / 10 / 2;
        }
    }
}
