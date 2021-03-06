using System.Collections.Generic;
using Faml.Business.Business;
using Faml.Business.Models;
using Xunit;

namespace Faml.Tests.Business
{
    public class OrderCalculatorTests
    {
        [Theory]
        [InlineData(10, 20, 30, false, 60)]
        [InlineData(10, 0, 20, false, 30)]
        [InlineData(100, 0, 0, false, 100)]
        public void OrderCalculator_CalculateTotal_WithoutSpeedyShipping(decimal cost1, decimal cost2, decimal cost3, bool isSpeedyShipping, decimal total)
        {
            //arrange
            OrderResult order = new OrderResult { OrderItems = new List<Package>() };

            order.OrderItems.Add(new Package(){Cost = cost1 });
            order.OrderItems.Add(new Package() { Cost = cost2 });
            order.OrderItems.Add(new Package() { Cost = cost3 });

            //Act
            OrderResult result = OrderCalculator.CalculateOrderTotal(order, isSpeedyShipping);


            //assert
            decimal expectedTotalCost = isSpeedyShipping ? total * 2 : total;
            Assert.Equal(total, result.ItemsCost);
            Assert.Equal(0, result.SpeedyShippingCost);
            Assert.Equal(expectedTotalCost, result.TotalCost);
        }

        [Theory]
        [InlineData(10, 20, 30, true, 60)]
        [InlineData(10, 0, 20, true, 30)]
        [InlineData(100, 0, 0, true, 100)]
        public void OrderCalculator_CalculateTotal_WithSpeedyShipping(decimal cost1, decimal cost2, decimal cost3, bool isSpeedyShipping, decimal total)
        {
            //arrange
            OrderResult order = new OrderResult { OrderItems = new List<Package>() };

            order.OrderItems.Add(new Package() { Cost = cost1 });
            order.OrderItems.Add(new Package() { Cost = cost2 });
            order.OrderItems.Add(new Package() { Cost = cost3 });

            //Act
            OrderResult result = OrderCalculator.CalculateOrderTotal(order, isSpeedyShipping);

            //assert
            decimal expectedTotalCost = isSpeedyShipping ? total * 2 : total;
            Assert.Equal(total, result.ItemsCost);
            Assert.Equal(total, result.SpeedyShippingCost);
            Assert.Equal(expectedTotalCost, result.TotalCost);
        }
    }
}
