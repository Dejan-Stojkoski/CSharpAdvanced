using VehicleDealership.Domain.Enums;
using VehicleDealership.Domain.Models;

namespace VehicleDealership.Domain.Interfaces
{
    public interface IVehicle
    {
        VehicleTypeEnum Type { get; set; }
        string Model { get; set; }
        string BuyVehicle(Buyer buyer);
    }
}
