﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.Models;

namespace HotelBookingsAPI.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> ListAsync();
    }
}