using MultiDealers.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDealers.Service
{
    public class DealersService : IDealersService
    {
        private readonly ApplicationDbContext _context;
        public DealersService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Dealer> DeleteDealer(int id)
        {
            Dealer dealerDb = await _context.Dealers
                  .SingleOrDefaultAsync(d => d.Id == id);

            if (dealerDb is null)
            {
                throw new Exception("Dealer not found");
            }

            _context.Remove(dealerDb);
            await _context.SaveChangesAsync();

            return dealerDb;
        }

        public async Task DeleteDealerVehicle(int dealerId, int vehicleId)
        {
            Dealer dealerDb = await _context.Dealers
                  .SingleOrDefaultAsync(d => d.Id == dealerId);

            Vehicle vehicleDb = await _context.Vehicles
                  .SingleOrDefaultAsync(d => d.Id == vehicleId);

            if (dealerDb is null || vehicleDb is null)
            {
                throw new Exception("Dealer or Vehicle not found");
            }

            if (vehicleDb.DealerId == default)
            {
                throw new Exception("Vehicle it's not associated to a Dealer");
            }


            vehicleDb.DealerId = default;

            _context.Entry(vehicleDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<Dealer> GetDealerById(int id)
        {
            Dealer dealer = await _context.Dealers
                .Include(d => d.Vehicles)
                .SingleOrDefaultAsync(d => d.Id == id);

            return dealer;
        }

        public async Task<List<Dealer>> GetDealers()
        {
            List<Dealer> dealers = await _context.Dealers.ToListAsync();

            return dealers;
        }

        public async Task<Dealer> PostDealer(Dealer dealer)
        {
            Dealer dealerDb = await _context.Dealers
                   .SingleOrDefaultAsync(d => d.Name == dealer.Name);

            if (dealerDb != null)
            {
                throw new Exception("Dealer already registered");
            }

            _context.Dealers.Add(dealer);
            await _context.SaveChangesAsync();
            return dealer;
        }

        public async Task PostDealerVehicle(int dealerId, int vehicleId)
        {
            Dealer dealerDb = await _context.Dealers
                  .SingleOrDefaultAsync(d => d.Id == dealerId);

            Vehicle vehicleDb = await _context.Vehicles
                  .SingleOrDefaultAsync(d => d.Id == vehicleId);

            if (dealerDb is null || vehicleDb is null)
            {
                throw new Exception("Dealer or Vehicle not found");
            }

            if(vehicleDb.DealerId != default)
            {
                throw new Exception("Vehicle aready associated to another Dealer");
            }

            vehicleDb.DealerId = dealerDb.Id;

            _context.Entry(vehicleDb).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<Dealer> PutDealer(Dealer dealer, int id)
        {
            Dealer dealerDb = await _context.Dealers
                .SingleOrDefaultAsync(d => d.Id == id);

            if (dealerDb is null)
            {
                throw new Exception("Dealer not found");
            }

            _context.Entry(dealer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return dealer;
        }

    }
}
