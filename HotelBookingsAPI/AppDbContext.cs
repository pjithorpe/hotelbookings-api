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
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Hotel>().ToTable("Hotel");
            builder.Entity<Hotel>().HasKey(h => h.HotelID);
            builder.Entity<Hotel>().Property(h => h.HotelID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Hotel>().Property(h => h.Name).IsRequired().HasMaxLength(200);

            builder.Entity<Room>().ToTable("Room");
            builder.Entity<Room>().HasKey(r => r.RoomID);
            builder.Entity<Room>().Property(r => r.RoomID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Room>().Property(r => r.HotelID).IsRequired();
            builder.Entity<Room>().Property(r => r.Type).IsRequired();

            builder.Entity<Booking>().ToTable("Booking");
            builder.Entity<Booking>().HasKey(b => b.BookingID);
            builder.Entity<Booking>().Property(b => b.BookingID).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Booking>().Property(b => b.RoomID).IsRequired();
            builder.Entity<Booking>().Property(b => b.StartDate).IsRequired();
            builder.Entity<Booking>().Property(b => b.EndDate).IsRequired();
            builder.Entity<Booking>().Property(b => b.PartySize).IsRequired();
        }
    }
}
