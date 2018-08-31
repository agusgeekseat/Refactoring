using CarRental.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Service
{
    /// <summary>
    /// Rental service
    /// </summary>
    public class RentalService
    {
        /// <summary>
        /// Rent function
        /// </summary>
        /// <param name="member">member</param>
        /// <param name="vehicle"vehicle></param>
        /// <param name="days">dayys</param>
        /// <returns>detail</returns>
        public RentalDetail Rent(Member member, Vehicle vehicle, int days)
        {
            if (vehicle.Available)
            {
                //check for expiry membership
                var sd = member.StartDate;
                var ed = 0;

                switch (member.Membership)
                {
                    case Membership.NonMember:
                        throw new Exception("Membership is not valid.");
                    case Membership.Silver:
                        ed = 180;
                        break;
                    case Membership.Gold:
                        ed = 360;
                        break;
                    case Membership.Platinum:
                        ed = 360;
                        break;
                }

                var expiryDate = sd.AddDays(ed);

                if (expiryDate > DateTime.Now)
                {
                    //check return date
                    var today = DateTime.Now;
                    var rd = today.AddDays(days);

                    if (expiryDate > rd)
                    {
                        RentalDetail d = new RentalDetail();

                        d.Member = member;
                        d.Vehicle = vehicle;
                        d.StartDate = DateTime.Now;
                        d.EndDate = d.StartDate.AddDays(days);

                        if (member.Membership == Membership.Silver)
                        {
                            d.Price = CalculatePriceSilver(d.Vehicle, days);
                        }

                        else if (member.Membership == Membership.Gold)
                        {
                            d.Price = CalculatePriceGold(d.Vehicle, days);
                        }

                        else if (member.Membership == Membership.Platinum)
                        {
                            d.Price = CalculatePricePlatimun(d.Vehicle, days);
                        }

                        else
                        {
                            throw new Exception("Membership is not valid.");
                        }

                        vehicle.Available = false;

                        return d;
                    } 
                    else
                    {
                        throw new Exception("Membership is going to be expired when returning vehicle. Please renew your membership.");
                    }
                }
                else
                {
                    throw new Exception("Membership is already expired.");
                }
            }
            else
            {
                throw new Exception("Vehicle is not available.");
            }
        }

        /// <summary>
        /// Calculate price silver
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        private decimal CalculatePriceSilver(Vehicle vehicle, int days)
        {
            if (vehicle.EngineSize > 1500)
                throw new Exception("Please upgrade your membership to rent this vehicle");

            var basePrice = 100;
            var multiplier = vehicle.EngineSize / 100;
            
            return basePrice * multiplier * days;
        }

        /// <summary>
        /// Calculate price platinum
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        private decimal CalculatePricePlatimun(Vehicle vehicle, int days)
        {
            decimal result = 0;

            var basePrice = 80;
            var multiplier = vehicle.EngineSize / 100;

            var eligibleForDiscountDays = days > 5;
            var discountDays = 1;

            if (!eligibleForDiscountDays)
                result = basePrice * multiplier * days;
            else
                result = basePrice * multiplier * (days - discountDays);

            return result;
        }

        /// <summary>
        /// Calculate Price gold
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        private decimal CalculatePriceGold(Vehicle vehicle, int days)
        {
            decimal result = 0;

            if (vehicle.EngineSize > 2500)
                throw new Exception("Please upgrade your membership to rent this vehicle");

            var basePrice = 90;
            var multiplier = vehicle.EngineSize / 100;

            var eligibleForDiscountDays = days > 10;
            var discountDays = 1;

            if (!eligibleForDiscountDays)
                result = basePrice * multiplier * days;
            else
                result = basePrice * multiplier * (days - discountDays);

            return result;
        }
    }
}
