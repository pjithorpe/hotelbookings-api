using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RoomRepository : Repository, IRoomRepository
    {
        public RoomRepository(HotelBookingsAPI.AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Room>> ListAsync()
        {
            return await dbContext.Rooms.ToListAsync();
        }
    }
}
