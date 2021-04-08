using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MultiDealers.Model;
using MultiDealers.Service;

namespace MultiDealers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DealerController : ControllerBase
    {

        private readonly IDealersService _service;

        public DealerController(IDealersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<Dealer>> GetDealers()
        {
            List<Dealer> dealersDb = await _service.GetDealers();
            return dealersDb;
        }


        [HttpGet("{id}")]
        public async Task<Dealer> GetDealerById(int id)
        {
            Dealer dealerDb = await _service.GetDealerById(id);
            return dealerDb;
        }

        [HttpPost]
        public async Task<Dealer> PostDealer(Dealer dealer)
        {
            Dealer dealerDb = await _service.PostDealer(dealer);
            return dealerDb;
        }

        [HttpPut("{id}")]
        public async Task<Dealer> PutDealer(Dealer dealer, int id)
        {
            Dealer dealerDb = await _service.PutDealer(dealer, id);
            return dealerDb;
        }


        [HttpDelete("{id}")]
        public async Task<Dealer> DeleteDealer(int id)
        {
            Dealer dealerDb = await _service.DeleteDealer(id);
            return dealerDb;
        }

        [HttpPost("{id}/Vehicle/{carId}")]
        public async Task PostDealerVehicle(int id, int carId)
        {
            await _service.PostDealerVehicle(id, carId);
        }

        [HttpDelete("{id}/Vehicle/{carId}")]
        public async Task DeleteDealerVehicle(int id, int carId)
        {
            await _service.DeleteDealerVehicle(id, carId);
        }
    }
}
