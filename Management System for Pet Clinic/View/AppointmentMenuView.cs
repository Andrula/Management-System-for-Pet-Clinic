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
                        CreateAppointment(appointmentList);
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

        static void CreateAppointment(List<Appointment> appointmentList, List<Pet> petsList, List<Staff> staffList)
        {
            try
            {
                Console.Write("Enter date and time (YYYY-MM-DD HH:mm): ");
                DateTime dateAndTime = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter duration in minutes: ");
                int duration = int.Parse(Console.ReadLine());

                Console.Write("Enter patient name: ");
                string patientName = Console.ReadLine();

                Console.Write("Enter responsible staff name: ");
                string staffName = Console.ReadLine();

                Staff staff = Staff.FindStaffByName(staffList, staffName);

                Pet pet = Pet.FindPetByName(petsList, staffName);

                if (staff == null)
                {
                    Console.WriteLine("Staff not found.");
                    return;
                }

                Console.Write("Enter purpose: ");
                string purpose = Console.ReadLine();

                Appointment newAppointment = new Appointment();
                newAppointment.Schedule(dateAndTime, duration, pet, staff, purpose);

                appointmentList.Add(newAppointment);

                Console.WriteLine("Appointment created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create appointment. Reason: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
