using BuildingManagement.API.Data;
using BuildingManagement.API.Data.Entity;
using BuildingManagement.API.Models.Building;
using BuildingManagement.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.API.Services
{
    public class BuildingService: IBuildingService
    {
        private readonly ApplicationDbContext _context;

        public BuildingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Building>> GetAllBuilding()
        {
            return await _context.Building.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<Objects>> GetAllObjects()
        {
            return await _context.Objects.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<DataField>> GetAllDataField()
        {
            return await _context.DataField.AsNoTracking().ToListAsync();
        }

        public async Task<List<Reading>> GetReadings(int BuildingId, int? ObjectId, int? DataFieldId, DateTime startTime, DateTime endTime)
        {
            var buildingIdParam = new SqlParameter("@BuildingId", BuildingId);
            var objectIdParam = new SqlParameter("@ObjectId", ObjectId ?? (object)DBNull.Value);
            var dataFieldIdParam = new SqlParameter("@DataFieldId", DataFieldId ?? (object)DBNull.Value);
            var startTimeParam = new SqlParameter("@startTime", startTime);
            var endTimeParam = new SqlParameter("@endTime", endTime);

            return await _context.Reading
                .FromSqlRaw("EXEC SP_GET_Reading @BuildingId, @ObjectId, @DataFieldId, @startTime, @endTime",
                    buildingIdParam, objectIdParam, dataFieldIdParam, startTimeParam, endTimeParam)
                .ToListAsync();
        }
    }
}
