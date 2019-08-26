using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.Enums;

namespace Service
{
    public class APITestingService
    {
        private Repository.APITestingRepository repository;

        public APITestingService(Repository.APITestingRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result> SeedDbAsync()
        {
            var hotelData = new List<Hotel>() {
                new Hotel() { Name = "Dakota Glasgow" },
                new Hotel() { Name = "The Z Hotel" },
                new Hotel() { Name = "Glasgow Marriott" },
                new Hotel() { Name = "Kimpton Blythswood" },
                new Hotel() { Name = "Grand Central Hotel" },
                new Hotel() { Name = "Malmaison" },
            };

            var roomData = new List<Room>()
            {
                new Room() { HotelID = 1, Type = (int)RoomType.Single },
                new Room() { HotelID = 1, Type = (int)RoomType.Double },
                new Room() { HotelID = 2, Type = (int)RoomType.Deluxe },
                new Room() { HotelID = 3, Type = (int)RoomType.Single },
                new Room() { HotelID = 4, Type = (int)RoomType.Single },
                new Room() { HotelID = 4, Type = (int)RoomType.Deluxe },
                new Room() { HotelID = 5, Type = (int)RoomType.Double },
                new Room() { HotelID = 6, Type = (int)RoomType.Double },
            };

            var bookingData = new List<Booking>()
            {
                new Booking() { RoomID = 1, StartDate = DateTime.Parse("2019-12-19T00:00:00"), EndDate = DateTime.Parse("2019-12-26T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 1, StartDate = DateTime.Parse("2020-08-23T00:00:00"), EndDate = DateTime.Parse("2021-02-01T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 2, StartDate = DateTime.Parse("2021-01-03T00:00:00"), EndDate = DateTime.Parse("2021-04-26T00:00:00"), PartySize = 2 },
                new Booking() { RoomID = 3, StartDate = DateTime.Parse("2019-12-19T00:00:00"), EndDate = DateTime.Parse("2019-12-26T00:00:00"), PartySize = 4 },
                new Booking() { RoomID = 4, StartDate = DateTime.Parse("2020-08-23T00:00:00"), EndDate = DateTime.Parse("2021-02-01T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 5, StartDate = DateTime.Parse("2021-01-03T00:00:00"), EndDate = DateTime.Parse("2021-04-26T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 6, StartDate = DateTime.Parse("2019-12-19T00:00:00"), EndDate = DateTime.Parse("2019-12-26T00:00:00"), PartySize = 2 },
                new Booking() { RoomID = 7, StartDate = DateTime.Parse("2020-08-23T00:00:00"), EndDate = DateTime.Parse("2021-02-01T00:00:00"), PartySize = 1 },
                new Booking() { RoomID = 8, StartDate = DateTime.Parse("2021-01-03T00:00:00"), EndDate = DateTime.Parse("2021-04-26T00:00:00"), PartySize = 2 },
                new Booking() { RoomID = 8, StartDate = DateTime.Parse("2023-07-09T00:00:00"), EndDate = DateTime.Parse("2023-07-10T00:00:00"), PartySize = 1 }
            };

            if (await repository.SeedAsync(hotelData, roomData, bookingData))
            {
                return Result.Success;
            }
            return Result.Failure;
        }

        public async Task<Result> ClearDbAsync()
        {
            if (await repository.ClearAsync())
            {
                return Result.Success;
            }
            return Result.Failure;
        }
    }
}
