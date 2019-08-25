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
    public class RoomsController : Controller
    {
        private IRoomService roomService;

        public RoomsController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            var rooms = await roomService.ListAsync();
            return rooms;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Post error"); // TODO: More error information
            }

            Result result = await roomService.SaveAsync(room);

            if (result == Result.Failure)
            {
                return BadRequest("Post error");
            }

            return Ok();
        }
    }
}