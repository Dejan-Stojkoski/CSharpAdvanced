using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public abstract class Vehicle : BaseEntity, IVehicle
    {
        public VehicleTypeEnum Type { get; set; }
        public string Model { get; set; }
        public double Price { get; protected set; }

        public Vehicle(int id, string model, double price, VehicleTypeEnum type) : base(id, "V")
        {
            Type = type;
            Model = model;
            Price = price;
        }

        public override string GetInfo()
        {
            return $"ID:[{Id}]. {Model} <{Type}> - |Price : {Price}|";
        }

        public abstract string BuyVehicle(Buyer buyer);
    }
}
