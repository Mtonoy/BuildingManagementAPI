using BuildingManagement.API.Data.Entity;

namespace BuildingManagement.API.Services.Interfaces
{
    public interface IBuildingService
    {
        Task<IEnumerable<Building>> GetAllBuilding();
        Task<IEnumerable<Objects>> GetAllObjects();
        Task<IEnumerable<DataField>> GetAllDataField();
        Task<List<Reading>> GetReadings(int BuildingId, int? ObjectId, int? DataFieldId, DateTime startTime, DateTime endTime);
    }
}
