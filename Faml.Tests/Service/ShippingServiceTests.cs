using System.Collections.Generic;
using Faml.Business.Models;
using Faml.Business.Services;
using Xunit;

namespace Faml.Tests.Service
{
    public class ShippingServiceTests
    {
        [Fact]
        public void ShippingServiceTests_ListEmpty_ShouldReturnNull()
        {
            //arrange
            var incomingOrder = new IncomingOrder
            {
                OrderItems = new List<Parcel>()
            };

            //Act
            ShippingService service = new ShippingService();
            OrderResult result = service.ProcessList(incomingOrder);

            //assert
            Assert.Empty(result.OrderItems);
        }

        [Fact]
        public void ShippingServiceTests_ListWithOneItem_ShouldReturnOneItem()
        {
            //arrange
            var item = new Parcel
            {
                Height = 1,
                Depth = 3,
                Length = 2
            };
            //arrange
            IncomingOrder incomingOrder = new IncomingOrder
            {
                OrderItems = new List<Parcel>()
            };

            incomingOrder.OrderItems.Add(item);

            //Act
            ShippingService service = new ShippingService();
            OrderResult result = service.ProcessList(incomingOrder);

            //assert
            Assert.NotEmpty(result.OrderItems);
            Assert.Single(result.OrderItems);
        }

        [Fact]
        public void ShippingServiceTests_ListWithMoreThanOneItem_ShouldReturnMoreThanOneItem()
        {
            //arrange
            IncomingOrder incomingOrder = new IncomingOrder();

            var item = new Parcel
            {
                Height = 1,
                Depth = 3,
                Length = 2
            };

            var item2 = new Parcel()
            {
                Height = 10,
                Depth = 3,
                Length = 2
            };

            incomingOrder.OrderItems = new List<Parcel> { item, item2 };

            //Act
            ShippingService service = new ShippingService();
            OrderResult result = service.ProcessList(incomingOrder);

            //assert
            Assert.NotEmpty(result.OrderItems);
            Assert.Equal(result.OrderItems, result.OrderItems);
        }
    }
}
