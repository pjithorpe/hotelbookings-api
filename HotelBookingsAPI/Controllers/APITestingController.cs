using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelBookingsAPI.Enums;

namespace HotelBookingsAPI.Controllers
{
    public class APITestingController : Controller
    {
        private Service.APITestingService service;

        public APITestingController(Service.APITestingService service)
        {
            this.service = service;
        }

        [Route("/api/seed")]
        [HttpGet]
        public async Task<IActionResult> SeedDatabaseAsync()
        {
            Result result = await service.SeedDbAsync();

            if (result == Result.Failure)
            {
                return BadRequest("Error while seeding db");
            }

            return Ok("Db seeding successful");
        }

        [Route("/api/reset")]
        [HttpGet]
        public async Task<IActionResult> ResetDatabaseAsync()
        {
            Result result = await service.ClearDbAsync();

            if (result == Result.Failure)
            {
                return BadRequest("Error while clearing db");
            }

            return Ok("Db cleared successfully");
        }
    }
}
