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
        Task<Booking> GetFromIDAsync(int id);

        Task AddAsync(Booking booking);

        Task<bool> CheckClashAsync(Booking booking);

        Task<bool> CheckCapacityAsync(Booking booking);
    }
}
