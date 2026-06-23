using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
    public class Aircraft
    {
        public int aircraftId { get; set; } //syste generated 
        public string model { get; set; } // input by Pilot
        public string pilotPhone { get; set; }//input by Pilot
        public string licenseNumber { get; set; }//input by Pilot
    }
}
