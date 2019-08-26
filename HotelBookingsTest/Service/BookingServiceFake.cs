using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Services;
using HotelBookingsAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingsTest.Service
{
    public class BookingServiceFake : IBookingService
    {
        private readonly List<Booking> bookings;

        public BookingServiceFake()
        {
            bookings = new List<Booking>()
            {
                new Booking() { BookingID = 1, RoomID = 1, StartDate = DateTime.Parse("2019-12-19T00:00:00"), EndDate = DateTime.Parse("2019-12-26T00:00:00"), PartySize = 2 },
                new Booking() { BookingID = 2, RoomID = 4, StartDate = DateTime.Parse("2020-08-23T00:00:00"), EndDate = DateTime.Parse("2021-02-01T00:00:00"), PartySize = 1 },
                new Booking() { BookingID = 5, RoomID = 8, StartDate = DateTime.Parse("2021-01-03T00:00:00"), EndDate = DateTime.Parse("2021-04-26T00:00:00"), PartySize = 4 },
            };
        }

        public async Task<IEnumerable<Booking>> ListAsync(int id)
        {
            if (id > -1)
            {
                return bookings.Where(b => b.BookingID == id);
            }
            return bookings;
        }

        public async Task<Result> SaveAsync(Booking booking)
        {
            bookings.Add(booking);
            return Result.Success;
        }
    }
}
