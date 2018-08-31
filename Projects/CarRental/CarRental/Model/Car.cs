using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Model
{
    /// <summary>
    /// Car class
    /// </summary>
    public class Car : Vehicle
    {
        public string Model { get; set; }

        public int EngineSize { get; set; }

        public bool Available { get; set; }
    }
}
