using VehicleDealership.Domain.Enums;

namespace VehicleDealership.Domain.Interfaces
{
    public interface ICar
    {
        EngineTypeEnum EngineType { get; set; }
    }

}
