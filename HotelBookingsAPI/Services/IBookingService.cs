using System;
using System.Collections.Generic;
using System.Linq;

using HotelBookingsAPI.Models;
using System.Threading.Tasks;

namespace HotelBookingsAPI.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> ListAsync();
    }
}
