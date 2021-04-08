using Microsoft.EntityFrameworkCore;
using MultiDealers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDealers.Service
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _context;

        public VehicleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> DeleteVehicle(int id)
        {
            Vehicle vehicleDb = await _context.Vehicles
                  .SingleOrDefaultAsync(d => d.Id == id);

            if (vehicleDb is null)
            {
                throw new Exception("Vechicle not found");
            }

            _context.Remove(vehicleDb);
            await _context.SaveChangesAsync();

            return vehicleDb;
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            Vehicle vehicle = await _context.Vehicles
               .Include(d => d.Dealers)
               .SingleOrDefaultAsync(d => d.Id == id);

            return vehicle;
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            List<Vehicle> vehicles = await _context.Vehicles.ToListAsync();

            return vehicles;
        }

        public async Task<Vehicle> PostVehicle(Vehicle vehicle)
        {
            Vehicle vehicleDb = await _context.Vehicles
               .SingleOrDefaultAsync(d => d.Plate == vehicle.Plate);

            if(vehicleDb != null)
            {
                throw new Exception("Vehicle already registered");
            }
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<Vehicle> PutVehicle(Vehicle vehicle, int id)
        {

            Vehicle vehicleDb = await _context.Vehicles
                 .SingleOrDefaultAsync(d => d.Id == id);

            if (vehicleDb is null)
            {
                throw new Exception("Vehicle not found");
            }

            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return vehicle;
        }
    }
}
