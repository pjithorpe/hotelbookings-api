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
    public class HotelsController : Controller
    {
        private IHotelService hotelService;

        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            var hotels = await hotelService.ListAsync();
            return hotels;
        }
    }
}