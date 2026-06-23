using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
    public class Pilot
    {
        public int pilotId { get; set; } //syste generated 
        public string pilotName { get; set; } // input by Pilot
        public string pilotPhone { get; set; }//input by Pilot
        public string licenseNumber { get; set; }//input by Pilot
        public int flightHours { get; set; }//calculated from every flights
        public bool isAvailable { get; set; }// default value set as true when pilot adedd.
    }
}
