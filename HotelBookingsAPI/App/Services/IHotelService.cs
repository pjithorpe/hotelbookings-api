using System;
using System.Collections.Generic;
using System.Linq;

using HotelBookingsAPI.App.Models;
using System.Threading.Tasks;
using HotelBookingsAPI.Enums;

namespace HotelBookingsAPI.App.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> ListAsync(string name);

        Task<Result> SaveAsync(Hotel hotel);
    }
}
