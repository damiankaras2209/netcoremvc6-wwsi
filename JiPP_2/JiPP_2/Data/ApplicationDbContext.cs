using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JiPP_2.Models;

namespace JiPP_2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<DictionaryModel> Dictionaries { get; set; }
        public DbSet<DictionaryDetailModel> DictionaryDetails { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<RentModel> Rents { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<VehicleModel>()
        //        .HasOne(e => e.Transmission)
        //        .WithMany(e => e.)


        //    base.OnModelCreating(builder);
        //}

    }
}