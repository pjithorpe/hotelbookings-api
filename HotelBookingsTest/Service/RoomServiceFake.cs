using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Services;
using HotelBookingsAPI.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HotelBookingsTest.Service
{
    public class RoomServiceFake : IRoomService
    {
        private readonly List<Room> rooms;

        public RoomServiceFake()
        {
            rooms = new List<Room>()
            {
                new Room() { RoomID = 1, HotelID = 1, Type = (int)RoomType.Double},
                new Room() { RoomID = 2, HotelID = 1, Type = (int)RoomType.Single},
                new Room() { RoomID = 3, HotelID = 2, Type = (int)RoomType.Single},
                new Room() { RoomID = 6, HotelID = 5, Type = (int)RoomType.Deluxe}
            };
        }

        public async Task<IEnumerable<Room>> ListAsync(string startDate, string endDate, int partySize)
        {
            DateTime sDate, eDate;
            if (DateTime.TryParse(startDate, out sDate) && DateTime.TryParse(endDate, out eDate) && partySize > 0)
            {
                return rooms.GetRange(1, 3);
            }
            return rooms;
        }

        public async Task<Result> SaveAsync(Room room)
        {
            rooms.Add(room);
            return Result.Success;
        }
    }
}
