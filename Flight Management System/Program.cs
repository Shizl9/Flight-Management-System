using Flight_Management_System.Models;
using System.Numerics;
using System.Threading.Channels;

namespace Flight_Management_System
{
    public class Program
    {
        // adding system storage
        public static FlightContext context = new FlightContext
        {
            passengers = new List<Passenger>(),
            pilots = new List<Pilot>(),
            aircrafts = new List<Aircraft>(),
            flights = new List<Flight>(),
            bookings = new List<Booking>()
        };

        //register passenger:
        public static void RegisterPassenger(List<Passenger> passengers)
        {
            Console.WriteLine("\n=== Add New Passenger ===");

            Console.WriteLine("Enter passenger name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Email:");
            string Email= Console.ReadLine();

            Console.WriteLine("Enter phone number:");
            string phoneNumber= Console.ReadLine();

            Console.WriteLine("Enter Passport number:");
            string passportNumber= Console.ReadLine();

            Console.WriteLine("Enter nationality:");
            string nationality= Console.ReadLine();

            //generate passenger id:
            int passengerId = context.passengers.Count + 1;


            //add passenger:
            context.passengers.Add(new Passenger
            {
                passengerId=passengerId,
                passengerName=name,
                passengerEmail=Email,
                passengerPhone=phoneNumber,
                passportNumber=passportNumber,
                nationality=nationality
            });

            Console.WriteLine(" passenger added successfuly with Id:"+ passengerId);
        }

        //Add an Aircraft
        public static void AddanAircraft(List<Aircraft> aircrafts)
        {
            Console.WriteLine("\n=== Add New Aircraft ===");

            Console.WriteLine("Enter model of Aircraft:");
            string model = Console.ReadLine();

            Console.WriteLine("Enter total seats:");
            int totalSeats = int.Parse(Console.ReadLine());

            // generate Aircraft Id:
            int aicraftId = context.aircrafts.Count + 1;

            //add aircraft:
            context.aircrafts.Add(new Aircraft
            {
                model=model,
                aircraftId=aicraftId,
                totalSeats=totalSeats,
                isOperational=true
            });
            Console.WriteLine($"Aircraft added successfully. Assigned ID: {aicraftId}");
        }

        //Register a Pilot:
        public static void RegisterPilot(List<Pilot> pilots)
        {
            Console.WriteLine("\n=== Add New Pilot ===");
            Console.WriteLine("Enter Pilot name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Pilot phone number:");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter license number:");
            string licenseNumber = Console.ReadLine();

            Console.WriteLine("Enter number of flight Hours:");
            int flightHours = int.Parse(Console.ReadLine());

            //generate passenger id:
            int pilotId = context.pilots.Count + 1;

            //add pilot:
            context.pilots.Add(new Pilot
            {
                pilotId=pilotId,
                pilotName=name,
                pilotPhone=phoneNumber,
                licenseNumber=licenseNumber,
                flightHours=flightHours,
                isAvailable=true
            });

            Console.WriteLine($"Pilot added successfully. Assigned ID: {pilotId}");
        }

        //04 View All Flights
        public static void  ViewAllFlights(List<Flight>flights)
        {
            Console.WriteLine("\n=== All Registered flights ===");
            //if no flights found print:
            if (context.flights.Count == 0)
            {
                Console.WriteLine(" No flights available. ");
                return;
            }
            //view all flights:
            foreach(Flight f in flights)
            {
                f.printFlight();
            }
        }

        //add flight:
        public static void ScheduleFlight(FlightContext context)
        {


            Console.WriteLine("\n=== Register New Flight ===");


            Console.Write("Enter aircraft Id: ");
            int aircraftId = int.Parse(Console.ReadLine());

            //vaidation for aircaraft id:
            Aircraft airplane = context.aircrafts.FirstOrDefault(a => a.aircraftId == aircraftId);
            
            if(airplane==null)
            {
                Console.WriteLine("aircraft not found.");
                return;
            }


            //vaidation for pilot id:
            Console.Write("Enter pilot Id: ");
            int pilotId = int.Parse(Console.ReadLine());

            Pilot pilot = context.pilots.FirstOrDefault(p => p.pilotId == pilotId);

            if (pilot == null)
            {
                Console.WriteLine("No pilots found .");
                return;
            }

            //user must input :
            Console.Write("Enter Departure city: ");
            string origin = Console.ReadLine();

            Console.Write("Enter destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter Scheduled departure date: ");
            string departureDate = Console.ReadLine();

            Console.Write("Enter Scheduled departure time: ");
            string departureTime = Console.ReadLine();

            Console.Write("Enter flight Duration ");
            int flightDuration = int.Parse(Console.ReadLine());

            Console.Write("Enter Ticket Price: ");
            decimal TicketPrice = decimal.Parse(Console.ReadLine());

            //generate flite id:
            int flightId = context.flights.Count + 1;

            //generate flite code:
            string flightCode = "OA-" + flightId;

            

            //add flight:
            context.flights.Add(new Flight
            {
                flightId = flightId,
                flightCode = flightCode,
                aircraftId = aircraftId,
                pilotId = pilotId,
                origin = origin,
                destination = destination,
                departureDate = departureDate,
                departureTime = departureTime,
                flightDuration = flightDuration,
                ticketPrice = TicketPrice,
                availableSeats = airplane.totalSeats,
                status = "Scheduled"//set as scheduled
            });

            Console.WriteLine(" flight added successfully with Id:" + flightId + "flight code:" + flightCode);

        }

        //06 Book a Flight
        public static void BookFlight(FlightContext context)
        {
            Console.WriteLine("\n=== Book Flight ===");


            Console.Write("Enter passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());

            //validation for passenger id:
            Passenger passenger = context.passengers.FirstOrDefault(p => p.passengerId == passengerId);
            
            if (passenger == null)
            {
                Console.WriteLine(" passenger Id not found.");
                return;
            }

            //choose destination
            Console.WriteLine("Enter destination:");
            string destintation = Console.ReadLine();

            //search destination
             List<Flight> flight = context.flights.Where(f => f.destination == destintation && f.availableSeats > 0)
                                                  .ToList();

            //if there is no flights matched this destination print:
            if (flight.Count == 0)
            {
                Console.WriteLine("No flights for ths destination");
                return;
            }

            //print that flight 
            Console.WriteLine($"\nAvailable Flights for this destination. {destintation}:");
            flight.ForEach(s =>s.printFlight());

            //create booking:
            Console.WriteLine("Enter flight Id:");
            int flightId = int.Parse(Console.ReadLine());

            //validation for selected flight id :
            Flight selectedflight = context.flights.FirstOrDefault(sf => sf.flightId == flightId);
            
            if (selectedflight == null)
            {
                Console.WriteLine("Not found flight.");
                return;
            }

            //generate seat number:

            int bookingId = context.bookings.Count + 1;
            string seatNumber = bookingId + "A";

            //determine total booking price:
            decimal totalPrice = selectedflight.ticketPrice;

            //update available seats decresed by 1:
            selectedflight.availableSeats = selectedflight.availableSeats - 1;

            //enter booking date:
            Console.WriteLine("Enter booking date:");
            string bookingDate = Console.ReadLine();

            //confirm booking:

            context.bookings.Add(new Booking
            {
                bookingId=bookingId,
                passengerId=passengerId,
                flightId=flightId,
                seatNumber=seatNumber,
                bookingDate=bookingDate,
                totalPrice=totalPrice,
                status="confirmed"
            });

            Console.WriteLine($"Flighit booked successfully! Flight ID: {flightId} , Booking Id: {bookingId}" +
                              $" | Date: {bookingDate} | Seat Number: {seatNumber}");
        }

        //07 Cancel a Booking
        public static void CancelBooking(FlightContext context)
        {
            Console.WriteLine("\n=== Cancel an Booking ===");

            Console.Write("Enter Booking ID to cancel: ");
            int bookingId = int.Parse(Console.ReadLine());

            //validation:
            Booking booking = context.bookings.FirstOrDefault(b => b.bookingId == bookingId); 

            if (booking == null)
            {
                Console.WriteLine(" Booking id not found.");
                return;
            }

            //make sure that booking not cancelled
            if (booking.status == "Cancelled")
            {
                Console.WriteLine("This booking is already cancelled.");
                return;
            }


            //set booking as cancelled:
            booking.status = "Cancelled";

            // seat is returned to the flight
            Flight flight = context.flights.FirstOrDefault(f => f.flightId == booking.flightId);
            flight.availableSeats = flight.availableSeats + 1;


            Console.WriteLine($"Booking {bookingId} has been cancelled and the flights is now available again.");
        }

        //08 Depart a Flight
        public static void DepartFlight(FlightContext context)
        {
            Console.WriteLine("\n=== Depart a Flight ===");

            Console.Write("Enter Flight ID to cancel: ");
            int flightId = int.Parse(Console.ReadLine());

            //validation 
            Flight flight = context.flights.FirstOrDefault(f => f.flightId == flightId);

            if (flight == null)
            {
                Console.WriteLine("not founded flight");
                return;
            }
            // make sure that the flight is not departed
            if (flight.status == "departed")
            {
                Console.WriteLine(" Flight is alrady departed ");
                return;
            }

            //set flight as departed
            flight.status = "departed";

            //update flighthours of pilot:
            Pilot pilot = context.pilots.FirstOrDefault(p => p.flightHours == p.flightHours);
            pilot.flightHours = pilot.flightHours + flight.flightDuration;


            //prevent any Bookings or Cancellations after departed flight:
            if (flight.status =="departed")
            {
                Console.WriteLine("You cannot book this flight becase it's alrady departed.");
                Console.WriteLine("You cannot Cancell a departed flight.");
                return;
            }

            Console.WriteLine("The flight departed successfully.");
        }

        // 09 Cancel a Flight:
        public static void CancelFlight(FlightContext context)
        {
            Console.WriteLine("\n=== Cancel Flight ===");

            //find flight:
            Console.Write("Enter Flight ID : ");
            int flightId = int.Parse(Console.ReadLine());

            //validation view if there is this flight
           Flight flight = context.flights.FirstOrDefault(a => a.flightId == flightId);


            //if flight not found print this:
            if (flight == null)
            {
                Console.WriteLine("No flights founded.");
                return;
            }


            //make sure that the flight not cancelled before
            if (flight.status == "Cancelled")
            {
                Console.WriteLine("This flight already cancelled. ");
                return;
            }

            //update to cancel flight
            flight.status = "Cancelled";

            //cancel all bookings confirmed for this flight:
            List<Booking> AllConfirmedBookings = context.bookings.Where(a => a.flightId == flightId && a.status == "confirmed")
                                                                 .ToList();
            foreach(Booking booking in AllConfirmedBookings)
            {
                booking.status="cancelled";
            }

            //find pilot:
            Console.WriteLine("Enter pilot id:");
            int pilotId = int.Parse(Console.ReadLine());

            //validation view pilot
            List<Pilot> pilot = context.pilots.Where(p => p.pilotId == pilotId && p.isAvailable == false).ToList();

            // number of affected bookings:
            int affectedBookings = AllConfirmedBookings.Count;

            Console.WriteLine("Flight cancelled , pilot is available now , number of affected bookings are:" + affectedBookings);
            
        }

        //10 Passenger Booking History
        public static void PassengerBookingHistory(FlightContext context)
        {
            Console.WriteLine("\n=== Create Passenger Booking History ===");

            Console.Write("Enter Passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());

            // Validate passenger
            Passenger passenger = context.passengers.FirstOrDefault(p => p.passengerId == passengerId);

            if (passenger == null)
            {
                Console.WriteLine("passenger not found.");
                return;
            }

            //view all bookings for this passenger:
            List<Booking> booking = context.bookings.Where(b => b.passengerId == passengerId)
                                                   .ToList();
            
            //if there is no bookings:
            if (booking.Count == 0)
            {
                Console.WriteLine("No booking history found.");
                return;
            }

            Console.Write("Enter Flight ID: ");
            int flightId = int.Parse(Console.ReadLine());

            //validation 
            Flight flight = context.flights.FirstOrDefault(f => f.flightId == flightId);


            Console.Write("Enter booking ID: ");
            int bookingId = int.Parse(Console.ReadLine());

            //validation 
            Booking bookId = context.bookings.FirstOrDefault(I => I.bookingId == bookingId);

            decimal totalSpent = 0;
            //view every booking info
            foreach (Booking b in booking)
            {
                Console.WriteLine($" code: {flight.flightCode}, Origin:{flight.origin},Destination:{flight.destination},Departure Date: {flight.departureDate},Seat:{b.seatNumber}, paid price:{bookId.totalPrice},{b.status}");
                Console.WriteLine("=====================================================");

                //calculat paid price that status confirmed:
                if (b.status == "confirmed")
                {
                     totalSpent = +b.totalPrice;
                    Console.WriteLine(totalSpent);
                }
            }
            Console.WriteLine($" total amount this passenger has spent is:{totalSpent}" );
        }

        static void Main(string[] args)
        {
            

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("   Flight Management System");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1  -Register Passenger");
                Console.WriteLine(" 2  -Add Aircraft ");
                Console.WriteLine(" 3  -Register Pilot ");
                Console.WriteLine(" 4  -Schedule Flight ");
                Console.WriteLine(" 5  -View All Flights ");
                Console.WriteLine(" 6  -Book Flight ");
                Console.WriteLine(" 7  -Cancel a Booking ");
                Console.WriteLine(" 8  -Depart Flight ");
                Console.WriteLine(" 9  -Cancel Flight ");
                Console.WriteLine(" 10 - ");
                Console.WriteLine(" 0  - Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: RegisterPassenger(context.passengers); break;
                    case 2: AddanAircraft(context.aircrafts); break;
                    case 3: RegisterPilot(context.pilots); break;
                    case 4: ScheduleFlight(context); break;
                    case 5: ViewAllFlights(context.flights); break;
                    case 6: BookFlight(context); break;
                    case 7: CancelBooking(context); break;
                    case 8: DepartFlight(context); break;
                    case 9: CancelFlight(context); break;
                    case 10: break;
                    case 0: exit = true; break;
                    default: Console.WriteLine("Invalid option. Please try again."); break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
