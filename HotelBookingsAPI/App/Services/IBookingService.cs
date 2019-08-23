using System;
using System.Collections.Generic;
using System.Linq;

using HotelBookingsAPI.App.Models;
using System.Threading.Tasks;

namespace HotelBookingsAPI.App.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> ListAsync();
    }
}
