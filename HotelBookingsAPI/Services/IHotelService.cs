using System;
using System.Collections.Generic;
using System.Linq;

using HotelBookingsAPI.Models;
using System.Threading.Tasks;

namespace HotelBookingsAPI.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> ListAsync();
    }
}
