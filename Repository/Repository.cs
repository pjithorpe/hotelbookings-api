using System;
using System.Collections.Generic;
using System.Text;

using HotelBookingsAPI;

namespace Repository
{
    public abstract class Repository
    {
        protected AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
