using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
    public class Passenger
    {
        public int passengerId { get; set; } //system generated 
        public string passengerName { get; set;  } // input by passenger
        public string passengerEmail { get; set; }//input by passenger
        public string passengerPhone { get; set; }//input by passenger
        public string passportNumber { get; set; }//input by passenger
        public string nationality { get; set; }//input by passenger
    }
}
