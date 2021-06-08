using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Models;

namespace VehicleDealership.Domain.Interfaces
{
    public interface IOrder
    {
        Buyer Buyer { get; set; }
        Vehicle Vehicle { get; set; }
        OrderStatusEnum Status {get;set;}
        double Price { get; set; }
    }
}
