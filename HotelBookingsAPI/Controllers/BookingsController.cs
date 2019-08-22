using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using HotelBookingsAPI.Services;
using HotelBookingsAPI.Models;

namespace HotelBookingsAPI.Controllers
{
    [Route("/api/[controller]")]
    public class BookingsController : Controller
    {
        private IBookingService bookingService;

        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            var bookings = await bookingService.ListAsync();
            return bookings;
        }
    }
}