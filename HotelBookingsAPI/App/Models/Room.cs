using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBookingsAPI.App.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int HotelID { get; set; }
        public int Type { get; set; }
    }
}
