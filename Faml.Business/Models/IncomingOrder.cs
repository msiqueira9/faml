using System.Collections.Generic;

namespace Faml.Business.Models
{
    public class IncomingOrder
    {
        public List<Parcel> OrderItems { get; set; }

        public bool IsSpeedyDeliver { get; set; }
    }
}
