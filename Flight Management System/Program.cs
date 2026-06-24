using Flight_Management_System.Models;
using System.Numerics;

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
                Console.WriteLine(" 3  - ");
                Console.WriteLine(" 4  - ");
                Console.WriteLine(" 5  - ");
                Console.WriteLine(" 6  - ");
                Console.WriteLine(" 7  - ");
                Console.WriteLine(" 8  - ");
                Console.WriteLine(" 9  - ");
                Console.WriteLine(" 10 - ");
                Console.WriteLine(" 0  - Exit");
                Console.WriteLine("========================================");
                Console.Write("Select option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1: RegisterPassenger(context.passengers); break;
                    case 2: AddanAircraft(context.aircrafts); break;
                    case 3:  break;
                    case 4:  break;
                    case 5:  break;
                    case 6:  break;
                    case 7:  break;
                    case 8:  break;
                    case 9:  break;
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
