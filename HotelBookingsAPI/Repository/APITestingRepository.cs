using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class APITestingRepository : Repository
    {
        public APITestingRepository(HotelBookingsAPI.AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> SeedAsync(IEnumerable<Hotel> hotels, IEnumerable<Room> rooms, IEnumerable<Booking> bookings)
        {
            try
            {
                await dbContext.Database.ExecuteSqlCommandAsync("DBCC CHECKIDENT('dbo.Hotel', RESEED, 0)");

                await dbContext.Hotels.AddRangeAsync(hotels);
                await dbContext.SaveChangesAsync();

                await dbContext.Database.ExecuteSqlCommandAsync("DBCC CHECKIDENT('dbo.Room', RESEED, 0)");
                await dbContext.Rooms.AddRangeAsync(rooms);
                await dbContext.SaveChangesAsync();

                await dbContext.Database.ExecuteSqlCommandAsync("DBCC CHECKIDENT('dbo.Booking', RESEED, 0)");
                await dbContext.Bookings.AddRangeAsync(bookings);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ClearAsync()
        {
            try
            {
                var bookings = await dbContext.Bookings.ToListAsync();
                dbContext.Bookings.RemoveRange(bookings);
                await dbContext.SaveChangesAsync();

                var rooms = await dbContext.Rooms.ToListAsync();
                dbContext.Rooms.RemoveRange(rooms);
                await dbContext.SaveChangesAsync();

                var hotels = await dbContext.Hotels.ToListAsync();
                dbContext.Hotels.RemoveRange(hotels);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
