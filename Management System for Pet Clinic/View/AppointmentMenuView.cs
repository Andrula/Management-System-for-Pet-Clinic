using MSPC.Enums;
using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.View
{
    public class AppointmentMenuView
    {
        public static void AppointmentMenuSwitch(List<Appointment> appointmentList)
        {
            bool isRunning = true;

            while (isRunning)
            {
                DisplayAppointmentMenu();
                char selection = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (selection)
                {
                    case '1':
                        Console.Clear();
                        
                        
                        break;
                    case '2':
                       
                        break;
                    case '3':

                        break;
                    case 'q':
                    case 'Q':
                        // Quit the program
                        Console.WriteLine("Exiting the program...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void DisplayAppointmentMenu()
        {
            Console.Clear();
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("1. Appointments");
            Console.WriteLine("2. Schedule appointment");
            Console.WriteLine("3. Change appointment");
            Console.WriteLine("4. Finish appointment");
            Console.WriteLine("Q. Back");
            Console.WriteLine("----------------");
            Console.Write("Select an option: ");
        }
    }
}
