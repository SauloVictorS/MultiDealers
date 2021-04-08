using MultiDealers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDealers.Service
{
    public interface IDealersService
    {
        Task<List<Dealer>> GetDealers();
        Task<Dealer> GetDealerById(int id);
        Task<Dealer> PostDealer(Dealer dealer);
        Task<Dealer> PutDealer(Dealer dealer, int id);
        Task<Dealer> DeleteDealer(int id);
        Task PostDealerVehicle(int dealerId, int vehicleId);
        Task DeleteDealerVehicle(int dealerId, int vehicleId);
        
    }
}
