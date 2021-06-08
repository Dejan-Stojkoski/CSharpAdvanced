using System.Collections.Generic;
using VehicleDealership.Domain.Models;

namespace VehicleDealership.Domain.Interfaces
{
    public interface IBuyer
    {
        List<Order> Orders { get; set; }
        double Balance { get; set; }
    }
}
