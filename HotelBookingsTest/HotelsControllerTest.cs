using HotelBookingsAPI.App.Models;
using HotelBookingsAPI.App.Services;
using HotelBookingsAPI.Controllers;
using HotelBookingsTest.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HotelBookingsTest
{
    public class HotelsControllerTest
    {
        HotelsController controller;
        IHotelService service;

        public HotelsControllerTest()
        {
            service = new HotelServiceFake();
            controller = new HotelsController(service);
        }

        [Fact]
        public async void GetAllAsync_WhenCalled_ReturnsAllHotels()
        {
            // Act
            var hotels = await controller.GetAllAsync();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Hotel>>(hotels);
            Assert.Equal(3, hotels.ToList().Count);
        }

        [Fact]
        public async void GetAllAsync_WhenCalledWithName_ReturnsNamedHotel()
        {
            // Act
            var hotels = await controller.GetAllAsync("The Imperial");

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Hotel>>(hotels);
            Assert.Equal("The Imperial", hotels.FirstOrDefault().Name);
        }

        [Fact]
        public async void GetAllAsync_WhenCalledWithUnknownName_ReturnsEmptyList()
        {
            // Act
            var hotels = await controller.GetAllAsync("xaxaxa");

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Hotel>>(hotels);
            Assert.Empty(hotels.ToList());
        }

        [Fact]
        public async void PostAsync_WhenCalledWithValidModel_ReturnsOk()
        {
            // Act
            var result = await controller.PostAsync(new Hotel() { Name = "A Hotel" });

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
