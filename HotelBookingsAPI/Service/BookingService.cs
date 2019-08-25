using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using HotelBookingsAPI.App.Services;
using HotelBookingsAPI.Enums;

namespace Service
{
    public class BookingService : IBookingService
    {
        private IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<IEnumerable<Booking>> ListAsync()
        {
            return await bookingRepository.ListAsync();
        }

        public async Task<Result> SaveAsync(Booking booking)
        {
            // Check end date is after start date
            if (booking.StartDate < booking.EndDate)
            {
                // Check for booking clashes
                if (await bookingRepository.CheckClashAsync(booking))
                {
                    // Check that party will fit into the room's capacity
                    if (await bookingRepository.CheckCapacityAsync(booking))
                    {
                        try
                        {
                            await bookingRepository.AddAsync(booking);
                            return Result.Success;
                        }
                        catch
                        {
                            return Result.Failure;
                        }
                    }
                }
            }
            return Result.Failure; //TODO: better error info
        }
    }
}
