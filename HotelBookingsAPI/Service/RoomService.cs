using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using HotelBookingsAPI.App.Services;

namespace Service
{
    public class RoomService : IRoomService
    {
        private IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> ListAsync()
        {
            return await roomRepository.ListAsync();
        }
    }
}
