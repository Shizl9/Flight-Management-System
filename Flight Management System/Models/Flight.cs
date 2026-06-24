using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Management_System.Models
{
    public class Flight
    {
        public int flightId { get; set; } //syste generated 
        public string flightCode { get; set; } //System Generated
        public int aircraftId { get; set; }// From List
        public int pilotId { get; set; }// From List
        public string origin { get; set; }// User Input
        public string destination { get; set; }// User Input 
        public string departureDate { get; set; } // User Input
        public string departureTime { get; set; } // User Input
        public int flightDuration { get; set; } // User Input
        public decimal ticketPrice { get; set; }// User Input
        public int availableSeats { get; set; }//calculated
        public string status { get; set; }// devault status: Scheduled | Departed | Cancelled

        public void printFlight()
        {
            Console.WriteLine($"ID: {flightId} | Code: {flightCode} | Aircraft ID: {aircraftId} | Pilot ID: {pilotId}");
            Console.WriteLine($"Origin: {origin} | Destination: {destination}");
            Console.WriteLine($"Departure: {departureDate} | {departureTime}");
            Console.WriteLine($"Duration: {flightDuration} | Price: {ticketPrice}");
            Console.WriteLine($"Available Seats: {availableSeats} | Status: {status}");
        }
    }
}
