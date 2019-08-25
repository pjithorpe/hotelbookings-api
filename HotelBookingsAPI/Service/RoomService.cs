using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using HotelBookingsAPI.App.Services;
using HotelBookingsAPI.Enums;

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

        public async Task<Result> SaveAsync(Room room)
        {
            try
            {
                await roomRepository.AddAsync(room);
                return Result.Success;
            }
            catch
            {
                return Result.Failure;
            }
        }
    }
}
