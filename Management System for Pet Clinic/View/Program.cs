using System;
using MSPC.Model;
using System.Collections.Generic;
using MSPC.View;

namespace MSPC
{
    public class Program
    {

        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                DisplayMenu();
                char selection = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (selection)
                {
                    case '1':

                        break;
                    case '2':

                        break;
                    case '3':
                        // Reference
                        AppointmentMenuView.AppointmentMenuSwitch();
                        break;
                    case '4':
                        // Reference
                        StaffMenuView.StaffMenuSwitch();
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

        // View for the user..
        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("1. Staff Menu");
            Console.WriteLine("3. Appointment Menu");
            Console.WriteLine("4. Option 4");
            Console.WriteLine("Q. Quit");
            Console.WriteLine("----------------");
            Console.Write("Select an option: ");
        }
    }
}
