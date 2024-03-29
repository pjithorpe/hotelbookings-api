﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;

namespace HotelBookingsAPI.App.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> ListAsync();

        Task<IEnumerable<Hotel>> ListAsync(string name);

        Task AddAsync(Hotel hotel);
    }
}
