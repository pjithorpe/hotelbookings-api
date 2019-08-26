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

        public async Task<IEnumerable<Room>> ListAsync(string startDate, string endDate, int partySize)
        {
            DateTime sDate, eDate;
            // Check dates and party size are valid
            if (DateTime.TryParse(startDate, out sDate) && DateTime.TryParse(endDate, out eDate) && partySize > 0)
            {
                return await roomRepository.ListAsync(sDate, eDate, partySize);
            }
            // otherwise, just resort to get-all
            return await roomRepository.ListAsync();
        }

        public async Task<Result> SaveAsync(Room room)
        {
            if (await roomRepository.CheckMaxRoomsAsync(room))
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
            return Result.Failure; //TODO: add more error info
        }
    }
}
