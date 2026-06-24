using Flight_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System
{
    //adding system storage
    public class FlightContext
    {
        public List <Passenger> passengers { get; set; }
        public List<Pilot> pilots{ get; set; }
        public List<Aircraft> aircrafts { get; set; }
        public List<Flight> flights  { get; set; }
        public List<Booking> bookings { get; set; }
    }
}
