using System.Collections.Generic;

namespace Faml.Business.Models
{
    public class OrderResult
    {
        public List<Package> OrderItems { get; set; }
        public decimal ItemsCost { get; set; }
        public decimal SpeedyShippingCost { get; set; }
        public decimal TotalCost { get; set; }

    }
}
