using Faml.Business.Models;

namespace Faml.Business.Business
{
    public static class ShippingCalculator
    {
        public static Package CalculatePackageSizeAndIndividualCost(Parcel parcelItem)
        {
            //assuming we wont allow negative values and there will be some validation before it gets here
            int cubicMetre = parcelItem.Depth * parcelItem.Height * parcelItem.Length;

            Package package = new Package()
            {
                Cost = 0,
                Type = PackageType.Undefined
            };

            if (cubicMetre > 0 && cubicMetre <= 10)
            {
                package.Cost = 3;
                package.Type = PackageType.Small;
                return package;
            }

            if (cubicMetre > 10 && cubicMetre <= 50)
            {
                package.Cost = 8;
                package.Type = PackageType.Medium;
                return package;
            }

            if (cubicMetre > 50 && cubicMetre < 100)
            {
                package.Cost = 15;
                package.Type = PackageType.Large;
                return package;
            }

            if (cubicMetre >= 100)
            {
                package.Cost = 25;
                package.Type = PackageType.ExtraLarge;
                return package;
            }

            return package;
        }
    }
}
