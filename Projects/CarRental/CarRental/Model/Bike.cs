using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Model
{
    /// <summary>
    /// bike class
    /// </summary>
    public class Bike : Vehicle
    {
        public string Model { get; set; }

        public int EngineSize { get; set; }

        public bool Available { get; set; }
    }
}
