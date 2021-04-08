using Microsoft.AspNetCore.Mvc;
using MultiDealers.Model;
using MultiDealers.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDealers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Vehicle>> GetVehicles()
        {
            List<Vehicle> vehiclesDb = await _service.GetVehicles();
            return vehiclesDb;
        }

        [HttpGet("{id}")]
        public async Task<Vehicle> GetVehicleById(int id)
        {
            Vehicle vehicleDb = await _service.GetVehicleById(id);
            return vehicleDb;
        }

        [HttpPost]
        public async Task<Vehicle> PostDealer(Vehicle vehicle)
        {
            Vehicle vehicleDb = await _service.PostVehicle(vehicle);
            return vehicleDb;
        }

        [HttpPut("{id}")]
        public async Task<Vehicle> PutVehicle(Vehicle vehicle, int id)
        {
            Vehicle vehicleDb = await _service.PutVehicle(vehicle, id);
            return vehicleDb;
        }

        [HttpDelete("{id}")]
        public async Task<Vehicle> DeleteVehicle(int id)
        {
            Vehicle vehicleDb = await _service.DeleteVehicle(id);
            return vehicleDb;
        }
    }
}
