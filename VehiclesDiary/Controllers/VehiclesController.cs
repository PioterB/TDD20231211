using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using VehicleDiary.Logic;
using VehiclesDiary.Logic;
using VehiclesDiary.Tools;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IRepository<string, Vehicle> _vehiclesRepository;
        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(IRepository<string, Vehicle> _vehiclesRepository, IVehiclesService vehiclesService)
        {
            this._vehiclesRepository = _vehiclesRepository;
            this._vehiclesService = vehiclesService;
        }

        [HttpGet]
        public IEnumerable<VehiclePreview> Get()
        {
            return _vehiclesRepository.GetAll().Select(item => new VehiclePreview(item));
        }

        [HttpPost]
        public IActionResult Add(VehicleCreationRequest input)
        {
            if (input == null)
            {
                return BadRequest();
            }

            Result<Vehicle> result = _vehiclesService.Add(input);
            return result.Fail ? (IActionResult)BadRequest() : Ok(result.Value);
        }

        [HttpDelete]
        public IStatusCodeActionResult Del(string name)
        {
            throw new NotImplementedException();
        }
    }
}