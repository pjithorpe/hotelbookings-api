using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;

namespace HotelBookingsAPI.App.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> ListAsync();

        Task AddAsync(Booking booking);

        Task<bool> CheckBookingAsync(Booking booking);
    }
}
