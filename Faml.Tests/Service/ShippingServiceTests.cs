using System.Collections.Generic;
using Faml.Business.Models;
using Faml.Business.Services;
using Xunit;

namespace Faml.Tests.Service
{
    public class ShippingServiceTests
    {
        [Fact]
        public void ShippingServiceTests_ListEmpty_ShouldReturnEmptyList()
        {
            //arrange
            var list = new List<Parcel>( );

            //Act
            ShippingService service = new ShippingService();
            List<Package> result = service.ProcessList(list);

            //assert
            Assert.Empty(result);
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

            var list = new List<Parcel> { item };

            //Act
            ShippingService service = new ShippingService();
            List<Package> result = service.ProcessList(list);

            //assert
            Assert.NotEmpty(result);
            Assert.Single(result);
        }

        [Fact]
        public void ShippingServiceTests_ListWithMoreThanOneItem_ShouldReturnMoreThanOneItem()
        {
            //arrange
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

            var list = new List<Parcel> { item, item2 };

            //Act
            ShippingService service = new ShippingService();
            List<Package> result = service.ProcessList(list);

            //assert
            Assert.NotEmpty(result);
            Assert.Equal(list.Count, result.Count);
        }
    }
}
