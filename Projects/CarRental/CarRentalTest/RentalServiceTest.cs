using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Service;
using CarRental.Model;

namespace CarRentalTest
{
    [TestClass]
    public class RentalServiceTest
    {
        private RentalService _service = new RentalService();

        [TestMethod]
        public void Rent_InvalidMembership_Error()
        {
            var member = new Member();
            var vehicle = new Vehicle { Available = true };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 0), "Membership is not valid.");
        }

        [TestMethod]
        public void Rent_VehicleNotAvailable_Error()
        {
            var member = new Member(Membership.Silver) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = false };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 0), "Vehicle is not available.");
        }

        [TestMethod]
        public void Rent_SilverExpired_Error()
        {
            var member = new Member(Membership.Silver) { StartDate = DateTime.Now.AddDays(-181) };
            var vehicle = new Vehicle { Available = true };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 0), "Membership is already expired.");
        }

        [TestMethod]
        public void Rent_GoldExpired_Error()
        {
            var member = new Member(Membership.Gold) { StartDate = DateTime.Now.AddDays(-361) };
            var vehicle = new Vehicle { Available = true };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 0), "Membership is already expired.");
        }

        [TestMethod]
        public void Rent_PlatinumExpired_Error()
        {
            var member = new Member(Membership.Platinum) { StartDate = DateTime.Now.AddDays(-361) };
            var vehicle = new Vehicle { Available = true };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 0), "Membership is already expired.");
        }

        [TestMethod]
        public void Rent_SilverExpiredWhenReturningVehicle_Error()
        {
            var member = new Member(Membership.Silver) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 181), "Membership is going to be expired when returning vehicle. Please renew your membership.");
        }

        [TestMethod]
        public void Rent_GoldExpiredWhenReturningVehicle_Error()
        {
            var member = new Member(Membership.Gold) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 361), "Membership is going to be expired when returning vehicle. Please renew your membership.");
        }

        [TestMethod]
        public void Rent_PlatinumExpiredWhenReturningVehicle_Error()
        {
            var member = new Member(Membership.Platinum) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 361), "Membership is going to be expired when returning vehicle. Please renew your membership.");
        }

        [TestMethod]
        public void Rent_SilverNoPrivilege_Error()
        {
            var member = new Member(Membership.Silver) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true, EngineSize = 2000 };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 0), "Please upgrade your membership to rent this vehicle");
        }

        [TestMethod]
        public void Rent_GoldNoPrivilege_Error()
        {
            var member = new Member(Membership.Gold) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true, EngineSize = 3000 };

            Assert.ThrowsException<Exception>(() => _service.Rent(member, vehicle, 0), "Please upgrade your membership to rent this vehicle");
        }

        [TestMethod]
        public void Rent_Silver_Success()
        {
            var member = new Member(Membership.Silver) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true, EngineSize = 1000 };

            var detail = _service.Rent(member, vehicle, 1);

            Assert.AreEqual(false, vehicle.Available);
            Assert.AreEqual(1000, detail.Price);
        }

        [TestMethod]
        public void Rent_Gold_Success()
        {
            var member = new Member(Membership.Gold) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true, EngineSize = 2000 };

            var detail = _service.Rent(member, vehicle, 1);

            Assert.AreEqual(false, vehicle.Available);
            Assert.AreEqual(1800, detail.Price);
        }

        [TestMethod]
        public void Rent_Platinum_Success()
        {
            var member = new Member(Membership.Platinum) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true, EngineSize = 3000 };

            var detail = _service.Rent(member, vehicle, 1);

            Assert.AreEqual(false, vehicle.Available);
            Assert.AreEqual(2400, detail.Price);
        }

        [TestMethod]
        public void Rent_GoldDiscountedDays_Success()
        {
            var member = new Member(Membership.Gold) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true, EngineSize = 2000 };

            var detail = _service.Rent(member, vehicle, 11);

            Assert.AreEqual(false, vehicle.Available);
            Assert.AreEqual(18000, detail.Price);
        }

        [TestMethod]
        public void Rent_PlatinumDiscountedDays_Success()
        {
            var member = new Member(Membership.Platinum) { StartDate = DateTime.Now };
            var vehicle = new Vehicle { Available = true, EngineSize = 3000 };

            var detail = _service.Rent(member, vehicle, 6);

            Assert.AreEqual(false, vehicle.Available);
            Assert.AreEqual(12000, detail.Price);
        }
    }
}
