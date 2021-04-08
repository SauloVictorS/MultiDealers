using Microsoft.EntityFrameworkCore;
using MultiDealers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiDealers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
