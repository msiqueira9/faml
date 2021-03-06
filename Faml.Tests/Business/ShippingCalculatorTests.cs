using System.Collections.Generic;
using Faml.Business.Business;
using Faml.Business.Models;
using Xunit;

namespace Faml.Tests.Business
{
    public class ShippingCalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3, 3, PackageType.Small)]
        [InlineData(2, 2, 2, 3, PackageType.Small)]
        [InlineData(5, 2, 1, 3, PackageType.Small)]
        public void ShippingCalculator_ParcelSizeLessThan10_ExpectingSmallPackageAndCost(int height, int depth, int length, decimal cost, PackageType type)
        {
            //arrange
            var item = new Parcel
            {
                Height = height,
                Depth = depth,
                Length = length
            };


            //Act
            Package result = ShippingCalculator.CalculatePackageSizeAndCost(item);

            //assert
            Assert.NotNull(result);
            Assert.Equal(cost, result.Cost);
            Assert.Equal(type, result.Type);
        }

        [Theory]
        [InlineData(3, 4, 1, 8, PackageType.Medium)]
        [InlineData(4, 4, 3, 8, PackageType.Medium)]
        [InlineData(25, 2, 1, 8, PackageType.Medium)]
        public void ShippingCalculator_ParcelSizeLessThan50_ExpectingMediumPackageAndCost(int height, int depth, int length, decimal cost, PackageType type)
        {
            //arrange
            var item = new Parcel
            {
                Height = height,
                Depth = depth,
                Length = length
            };


            //Act
            Package result = ShippingCalculator.CalculatePackageSizeAndCost(item);

            //assert

            Assert.NotNull(result);
            Assert.Equal(cost, result.Cost);
            Assert.Equal(type, result.Type);
        }

        [Theory]
        [InlineData(3, 17, 1, 15, PackageType.Large)]
        [InlineData(4, 4, 4, 15, PackageType.Large)]
        [InlineData(3, 3, 11, 15, PackageType.Large)]
        public void ShippingCalculator_ParcelSizeLessThan100_ExpectingLargePackageAndCost(int height, int depth, int length, decimal cost, PackageType type)
        {
            //arrange
            var item = new Parcel
            {
                Height = height,
                Depth = depth,
                Length = length
            };


            //Act
            Package result = ShippingCalculator.CalculatePackageSizeAndCost(item);

            //assert

            Assert.NotNull(result);
            Assert.Equal(cost, result.Cost);
            Assert.Equal(type, result.Type);
        }

        [Theory]
        [InlineData(27, 2, 2, 25, PackageType.ExtraLarge)]
        [InlineData(8, 8, 2, 25, PackageType.ExtraLarge)]
        [InlineData(9, 10, 12, 25, PackageType.ExtraLarge)]
        public void ShippingCalculator_ParcelSizeGreaterThan100_ExpectingExtraLargePackageAndCost(int height, int depth, int length, decimal cost, PackageType type)
        {
            //arrange
            var item = new Parcel
            {
                Height = height,
                Depth = depth,
                Length = length
            };


            //Act
            Package result = ShippingCalculator.CalculatePackageSizeAndCost(item);

            //assert

            Assert.NotNull(result);
            Assert.Equal(cost, result.Cost);
            Assert.Equal(type, result.Type);
        }
    }
}
