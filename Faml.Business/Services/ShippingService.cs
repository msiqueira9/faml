using System.Collections.Generic;
using Faml.Business.Business;
using Faml.Business.Models;

namespace Faml.Business.Services
{
    public class ShippingService
    {
        public OrderResult ProcessList(IncomingOrder incomingOrder)
        {
            OrderResult order = new OrderResult {OrderItems = new List<Package>()};

            foreach (var item in incomingOrder.OrderItems)
            {
                order.OrderItems.Add(ShippingCalculator.CalculatePackageSizeAndIndividualCost(item));
            }

            
            return OrderCalculator.CalculateOrderTotal(order, incomingOrder.IsSpeedyDeliver);
        }
    }
}
