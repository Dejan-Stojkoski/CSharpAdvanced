using System;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public class Trailer : BaseEntity, ITrailer
    {
        public string Model { get; set; }
        public int Length { get; set; }
        public double Price { get; private set; }

        public Trailer(int id, string model, int length, double price) : base(id, "T")
        {
            Model = model;
            Length = length;
            Price = price;
        }

        public override string GetInfo()
        {
            return $"[{Id}]. Trailer Model: {Model}   |   Length: {Length}   |   Price: {Price}.";
        }
    }
}
