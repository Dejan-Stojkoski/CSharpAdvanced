using System.Collections.Generic;
using VehicleDealership.Domain.Models;

namespace VehicleDealership.Domain.Interfaces
{
    public interface ITruck
    {
        List<Trailer> NumberOfTrailers { get; }
    }
}
