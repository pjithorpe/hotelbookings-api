using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingsAPI.Extensions
{
    public static class RoomExtensions
    {
        public static int GetCapacity(this Room room)
        {
            var conversions = new Dictionary<int, int>()
            {
                { (int)RoomType.Single, 1},
                { (int)RoomType.Double, 2},
                { (int)RoomType.Deluxe, 4}
            };
            return conversions[room.Type];
        }
    }
}
