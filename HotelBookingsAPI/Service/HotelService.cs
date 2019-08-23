using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using HotelBookingsAPI.App.Services;

namespace Service
{
    public class HotelService : IHotelService
    {
        private IHotelRepository hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            return await hotelRepository.ListAsync();
        }
    }
}
