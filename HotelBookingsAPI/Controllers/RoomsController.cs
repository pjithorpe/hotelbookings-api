using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using HotelBookingsAPI.App.Services;
using HotelBookingsAPI.App.Models;

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
    }
}