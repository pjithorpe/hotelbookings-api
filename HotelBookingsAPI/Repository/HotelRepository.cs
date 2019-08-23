using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class HotelRepository : Repository, IHotelRepository
    {
        public HotelRepository(HotelBookingsAPI.AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            return await dbContext.Hotels.ToListAsync();
        }
    }
}
