using System;
using System.Collections.Generic;
using System.Linq;

using HotelBookingsAPI.App.Models;
using System.Threading.Tasks;
using HotelBookingsAPI.Enums;

namespace HotelBookingsAPI.App.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> ListAsync();

        Task<Result> SaveAsync(Room room);
    }
}
