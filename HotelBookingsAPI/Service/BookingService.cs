using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using HotelBookingsAPI.App.Services;

namespace Service
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
