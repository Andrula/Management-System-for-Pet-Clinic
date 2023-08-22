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
        public static void AppointmentMenuSwitch()
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
                        Console.WriteLine("Appointment list.");
                        PrintAllAppointments(Appointment.GetAllAppointments());
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        CreateAppointment();
                        break;
                    case '3':
                        Console.Write("Enter appointment ID: ");
                        if (int.TryParse(Console.ReadLine(), out int appointmentId))
                        {
                            Appointment existingAppointment = Appointment.FindAppointmentByID(Appointment.GetAllAppointments(), appointmentId);

                            if (existingAppointment != null)
                            {
                                Console.Write("Enter new date: ");
                                DateTime newDate = DateTime.Parse(Console.ReadLine());

                                // Call the Reschedule method or update the DateAndTime property
                                existingAppointment.Reschedule(newDate); // Assuming Reschedule method exists

                                Console.WriteLine("Appointment rescheduled successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Appointment not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid appointment ID.");
                        }

                        Console.ReadKey();

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
            Console.WriteLine("3. Reschedule appointment");
            Console.WriteLine("4. Finish appointment");
            Console.WriteLine("Q. Back");
            Console.WriteLine("----------------");
            Console.Write("Select an option: ");
        }

        static void CreateAppointment()
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

                Staff staff = Staff.FindStaffByName(Staff.GetStaffList(), staffName);

                Pet pet = Pet.FindPetByName(Pet.GetAllPets(), staffName);

                if (staff == null)
                {
                    Console.WriteLine("Staff not found.");
                    return;
                }

                if (pet == null)
                {
                    Console.WriteLine("Pet not found");
                    return;
                }

                Console.Write("Enter purpose: ");
                string purpose = Console.ReadLine();

                Appointment newAppointment = new Appointment();
                newAppointment.Schedule(dateAndTime, duration, pet, staff, purpose);

                Appointment.AddAppointment(newAppointment);

                Console.WriteLine("Appointment created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create appointment. Reason: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void PrintAllAppointments(List<Appointment> appointmentList)
        {
            foreach (var appointment in appointmentList)
            {
                appointment.PrintAppointmentDetails();
            }
            Console.ReadLine();
        }

    }
}
