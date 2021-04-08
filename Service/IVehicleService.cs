using MultiDealers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDealers.Service
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehicles();
        Task<Vehicle> GetVehicleById(int id);
        Task<Vehicle> PostVehicle(Vehicle vehicle);
        Task<Vehicle> PutVehicle(Vehicle vehicle, int id);
        Task<Vehicle> DeleteVehicle(int id);
    }
}
