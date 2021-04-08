using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDealers.Model
{
    public class Dealer
    {
        public int Id { get; set; }

        [MaxLength(255)]
        [MinLength(0)]
        public string Name { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
