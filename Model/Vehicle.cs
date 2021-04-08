using MultiDealers.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDealers.Model
{
    public class Vehicle
    {
        public int Id { get; set; }

        [ForeignKey("Dealers")]
        public int DealerId { get; set; }

        [MaxLength(8)]
        [MinLength(0)]
        public string Plate { get; set; }

        [MaxLength(100)]
        [MinLength(0)]
        public string Model { get; set; }

        [MaxLength(4)]
        [MinLength(0)]
        public string Year { get; set; }

        [MaxLength(100)]
        [MinLength(0)]
        public string Manufacturer { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public decimal Price { get; set; }

        public virtual Dealer Dealers { get; set; }
    }
}
