using BuildingManagement.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagement.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }

        [HttpGet("GetBuildings")]
        public async Task<IActionResult> GetBuildings()
        {
            return new OkObjectResult( await buildingService.GetAllBuilding());
        }

        [HttpGet("GetObjects")]
        public async Task<IActionResult> GetObjects()
        {
            return new OkObjectResult(await buildingService.GetAllObjects());
        }

        [HttpGet("GetDataFields")]
        public async Task<IActionResult> GetDataField()
        {
            return new OkObjectResult(await buildingService.GetAllDataField());
        }

        [HttpGet("GetReadings/{BuildingId}/{ObjectId}/{DataFieldId}/{startTime}/{endTime}")]
        public async Task<IActionResult> GetReadings(int BuildingId,int? ObjectId,int? DataFieldId,DateTime startTime,DateTime endTime)
        {
            return new OkObjectResult(await buildingService.GetReadings(BuildingId, ObjectId, DataFieldId, startTime, endTime));
        }
    }
}
