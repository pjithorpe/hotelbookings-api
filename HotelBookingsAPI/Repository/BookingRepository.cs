using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using HotelBookingsAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BookingRepository : Repository, IBookingRepository
    {
        public BookingRepository(HotelBookingsAPI.AppDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Booking>> ListAsync()
        {
            return await dbContext.Bookings.ToListAsync();
        }

        public async Task AddAsync(Booking booking)
        {
            await dbContext.Bookings.AddAsync(booking);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckClashAsync(Booking booking)
        {
            // Get bookings for the same room and then compare with new booking to see if there are any clashes
            return !await dbContext.Bookings
                .Where(b => b.RoomID == booking.RoomID)
                .Where(b => b.StartDate < booking.EndDate && booking.StartDate < b.EndDate)
                .AnyAsync();
        }

        public async Task<bool> CheckCapacityAsync(Booking booking)
        {
            Room room = await dbContext.Rooms.FindAsync(booking.RoomID);
            return booking.PartySize <= room.GetCapacity();
        }
    }
}
