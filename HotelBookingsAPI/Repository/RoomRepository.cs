using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(Room room)
        {
            await dbContext.Rooms.AddAsync(room);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckMaxRoomsAsync(Room room)
        {
            int roomCount = await dbContext.Rooms.CountAsync(r => r.HotelID == room.HotelID);
            return roomCount < 6;
        }
    }
}
