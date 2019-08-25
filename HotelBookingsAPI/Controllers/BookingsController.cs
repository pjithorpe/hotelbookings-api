using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using HotelBookingsAPI.App.Services;
using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.Enums;

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

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Post error"); // TODO: More error information
            }

            Result result = await bookingService.SaveAsync(booking);

            if (result == Result.Failure)
            {
                return BadRequest("Post error");
            }

            return Ok();
        }
    }
}