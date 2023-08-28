using System;
using MSPC.Model;
using System.Collections.Generic;
using MSPC.View;
using MSPC.Enums;
using MSCP.Interface;
using MSPC.Data.Database;

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
                        //Object iniziation and reference
                        CustomerMenuView customerMenuView = new CustomerMenuView();
                        customerMenuView.CustomerMenuSwitch();
                        break;
                    case '2':
                        //Object iniziation and reference
                        PetMenuView petMenuView = new PetMenuView();
                        petMenuView.PetMenuSwitch();
                        break;
                    case '3':
                        //Object iniziation and reference
                        AppointmentMenuView appointmentMenuView = new AppointmentMenuView();
                        appointmentMenuView.AppointmentMenuSwitch();
                        break;
                    case '4':
                        //Object iniziation and reference
                        StaffMenuView staffMenuView = new StaffMenuView();
                        staffMenuView.StaffMenuSwitch();
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
            Console.WriteLine("1. Customer Menu");
            Console.WriteLine("2. Pet Menu");
            Console.WriteLine("3. Appointment Menu");
            Console.WriteLine("4. Staff Menu");
            Console.WriteLine("Q. Quit");
            Console.WriteLine("----------------");
            Console.Write("Select an option: ");
        }
    }
}
