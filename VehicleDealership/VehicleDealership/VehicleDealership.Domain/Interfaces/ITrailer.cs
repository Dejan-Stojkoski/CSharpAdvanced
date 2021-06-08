using System;
namespace VehicleDealership.Domain.Interfaces
{
    public interface ITrailer
    {
        string Model { get; set; }
        int Length { get; set; }
    }
}
