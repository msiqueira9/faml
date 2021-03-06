using System.Linq;
using Faml.Business.Models;

namespace Faml.Business.Business
{
    public static class OrderCalculator
    {
        public static OrderResult CalculateOrderTotal(OrderResult orderResult, bool isSpeedyShipping)
        {
            orderResult.ItemsCost = orderResult.OrderItems.Any() ? orderResult.OrderItems.Sum(o => o.Cost) : 0;
            

            if (isSpeedyShipping)
            {
                orderResult.SpeedyShippingCost = orderResult.ItemsCost;
            }

            orderResult.TotalCost = orderResult.ItemsCost + orderResult.SpeedyShippingCost;

            return orderResult;
        }
    }
}
