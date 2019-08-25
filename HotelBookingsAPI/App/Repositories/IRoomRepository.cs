﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;

namespace HotelBookingsAPI.App.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> ListAsync();

        Task AddAsync(Room room);
    }
}
