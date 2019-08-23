using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelBookingsAPI;
using HotelBookingsAPI.Models;

namespace Repository
{
    public class HotelRepository : Repository
    {
        public HotelRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            return await dbContext.Hotels.ToListAsync();
        }
    }
}
