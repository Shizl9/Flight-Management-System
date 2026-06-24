namespace Flight_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("   Hospital Management System");
                Console.WriteLine("========================================");
                Console.WriteLine(" 1  - ");
                Console.WriteLine(" 2  - ");
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
                    case 1:  break;
                    case 2:  break;
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
