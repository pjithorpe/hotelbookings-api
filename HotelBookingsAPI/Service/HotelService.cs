using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using HotelBookingsAPI.App.Services;
using HotelBookingsAPI.Enums;

namespace Service
{
    public class HotelService : IHotelService
    {
        private IHotelRepository hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Hotel>> ListAsync(string name = "")
        {
            if (name != "")
            {
                return await hotelRepository.ListAsync(name);
            }
            return await hotelRepository.ListAsync();
        }

        public async Task<Result> SaveAsync(Hotel hotel)
        {
            try
            {
                await hotelRepository.AddAsync(hotel);
                return Result.Success;
            }
            catch
            {
                return Result.Failure;
            }
        }
    }
}
