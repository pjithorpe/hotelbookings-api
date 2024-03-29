﻿using System;
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
    public class HotelsController : Controller
    {
        private IHotelService hotelService;

        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IEnumerable<Hotel>> GetAllAsync([FromQuery]string name = "")
        {
            var hotels = await hotelService.ListAsync(name);
            return hotels;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Post error"); // TODO: More error information
            }

            Result result = await hotelService.SaveAsync(hotel);

            if (result == Result.Failure)
            {
                return BadRequest("Post error");
            }

            return Ok();
        }
    }
}