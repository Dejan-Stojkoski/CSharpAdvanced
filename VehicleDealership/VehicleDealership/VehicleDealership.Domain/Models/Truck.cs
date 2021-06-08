using System;
using System.Collections.Generic;
using VehicleDealership.Domain.Database;
using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Interfaces;

namespace VehicleDealership.Domain.Models
{
    public class Truck : Vehicle, ITruck
    {
        public List<Trailer> NumberOfTrailers { get; private set; }

        public Truck(int id, string model, double price)
            : base(id, model, price, VehicleTypeEnum.Truck)
        {
            NumberOfTrailers = new List<Trailer>();
        }

        public override string BuyVehicle(Buyer buyer)
        {
            if(NumberOfTrailers.Count < 1)
            {
                throw new Exception("You must choose a tralior before buying the truck.");
            }

            double totalTrailersPrice = NumberOfTrailers[0].Price;

            if(NumberOfTrailers.Count == 2)
            {
                double discountPrice = NumberOfTrailers[1].Price - (NumberOfTrailers[1].Price / 10);
                totalTrailersPrice += discountPrice;
            }

            Price += totalTrailersPrice;
            Order order = new Order(buyer, this, OrderStatusEnum.Pending, Price);
            LocalDatabase.Orders.Insert(order);
            buyer.Orders.Add(order);
            return $"Your order has been placed Total amount: {Price}!";
        }

        public void AddTrailer(Trailer trailer)
        {
            if(NumberOfTrailers.Count == 2)
            {
                throw new Exception("You could not buy more than 2 Trailers per Truck.");
            }

            LocalDatabase.Trailers.RemoveById(trailer.Id);
            NumberOfTrailers.Add(trailer);
        }
    }
}
