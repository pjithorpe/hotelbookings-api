using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
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
    }
}
