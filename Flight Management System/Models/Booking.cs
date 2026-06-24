using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
    public class Booking
    {
        public int bookingId { get; set; } //syste generated Unique identifier for each booking 
        public int passengerId { get; set; } // ID of the passenger who made the booking
        public int flightId { get; set; }// ID of the  flight being booked
        public string seatNumber { get; set; }//  Seat label assigned at booking (e.g. 14A)
        public string bookingDate { get; set; }//  Date the booking was made
        public decimal totalPrice { get; set; }// Price paid — taken from the flight's ticket price at the time of booking
        public string status { get; set; } // Scheduled Booking status: Confirmed | Cancelled
    }
}
