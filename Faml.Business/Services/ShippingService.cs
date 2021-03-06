using System.Collections.Generic;
using Faml.Business.Business;
using Faml.Business.Models;

namespace Faml.Business.Services
{
    public class ShippingService
    {
        public List<Package> ProcessList(List<Parcel> parcels)
        {
            List<Package> packages = new List<Package>();

            foreach (var item in parcels)
            {
                packages.Add(ShippingCalculator.CalculatePackageSizeAndCost(item));
            }

            return packages;
        }
    }
}
