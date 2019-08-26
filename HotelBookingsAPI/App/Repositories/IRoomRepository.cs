using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;

namespace HotelBookingsAPI.App.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> ListAsync();

        Task<IEnumerable<Room>> ListAsync(DateTime startDate, DateTime endDate, int partySize);

        Task AddAsync(Room room);

        Task<bool> CheckMaxRoomsAsync(Room room);
    }
}
