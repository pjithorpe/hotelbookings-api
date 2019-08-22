using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.Models;
using HotelBookingsAPI.Repositories;
using HotelBookingsAPI.Services;

namespace Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Booking>> ListAsync()
        {
            return await bookingRepository.ListAsync();
        }
    }
}
