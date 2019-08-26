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
    public class HotelServiceFake : IHotelService
    {
        private readonly List<Hotel> hotels;

        public HotelServiceFake() {
            hotels = new List<Hotel>()
            {
                new Hotel() { HotelID = 1, Name = "The Imperial"},
                new Hotel() { HotelID = 2, Name = "Big Dave's Motel"},
                new Hotel() { HotelID = 5, Name = "The Traveller's Rest"}
            };
        }

        public async Task<IEnumerable<Hotel>> ListAsync(string name)
        {
            if (name != "")
            {
                return hotels.Where(h => h.Name == name);
            }
            return hotels;
        }

        public async Task<Result> SaveAsync(Hotel hotel)
        {
            hotels.Add(hotel);
            return Result.Success;
        }
    }
}
