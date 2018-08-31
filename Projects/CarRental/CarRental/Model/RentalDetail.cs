using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Model
{
    public class RentalDetail
    {
        public Member Member { get; set; }

        public Vehicle Vehicle { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
