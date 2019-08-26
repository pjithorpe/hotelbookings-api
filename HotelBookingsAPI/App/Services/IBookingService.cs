using System;
using System.Collections.Generic;
using System.Linq;

using HotelBookingsAPI.App.Models;
using System.Threading.Tasks;
using HotelBookingsAPI.Enums;

namespace HotelBookingsAPI.App.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> ListAsync(int id);

        Task<Result> SaveAsync(Booking booking);
    }
}
