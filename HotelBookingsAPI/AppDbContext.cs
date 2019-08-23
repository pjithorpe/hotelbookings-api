using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBookingsAPI.App.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingsAPI
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Hotel>().ToTable("Hotel");
            builder.Entity<Hotel>().HasKey(h => h.HotelID);
            builder.Entity<Hotel>().Property(h => h.HotelID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Hotel>().Property(h => h.Name).IsRequired().HasMaxLength(200);
        }
    }
}
