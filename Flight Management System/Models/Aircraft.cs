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
        public string model { get; set; } // input when added in system
        public int totalSeats { get; set; }//input by staff 
        public bool isOperational { get; set; }//default set astrue is airworthy false if grounded for maintanance 
    }
}
