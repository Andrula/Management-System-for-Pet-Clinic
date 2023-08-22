using System;
using MSPC.Model;
using System.Collections.Generic;
using MSPC.View;
using Management_System_for_Pet_Clinic.View;
using MSPC.Enums;

namespace MSPC
{
    public class Program
    {

        static void Main(string[] args)
        {
            bool isRunning = true;

            InitiazeDummyData();
            
            while (isRunning)
            {
                DisplayMenu();
                char selection = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (selection)
                {
                    case '1':
                        // Reference
                        CustomerMenuView.CustomerMenuSwitch();
                        break;
                    case '2':
                        // Reference
                        PetMenuView.PetMenuSwitch();
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
            Console.WriteLine("1. Customer Menu");
            Console.WriteLine("2. Pet Menu");
            Console.WriteLine("3. Appointment Menu");
            Console.WriteLine("4. Staff Menu");
            Console.WriteLine("Q. Quit");
            Console.WriteLine("----------------");
            Console.Write("Select an option: ");
        }

        #region Dummy data

        static void InitiazeDummyData()
        {
           // Customer customer1 = new Customer
           // {
           //     Name = "Customer",
           //     Email = "john@example.com",
           //     Phone = "20202020",
           //     Address = "Randersgade"
           // };

           // Customer customer2 = new Customer
           // {
           //     Name = "Jane",
           //     Email = "jane@example.com",
           //     Phone = "90293812",
           //     Address = "Jyllandsgade"
           // };

           // Customer customer3 = new Customer
           // {
           //     Name = "John",
           //     Email = "michael@example.com",
           //     Phone = "55512345",
           //     Address = "Bogensegade"
           // };

           // Customer.AddCustomer(customer1);
           // Customer.AddCustomer(customer2);
           // Customer.AddCustomer(customer3);

           // Create pets for each customer

           //Pet pet1 = new Pet("Pet", "Dog", 5, customer1);
           // Pet pet2 = new Pet("Whiskers", "Cat", 3, customer1);

           // Pet pet3 = new Pet("Fluffy", "Cat", 2, customer2);
           // Pet pet4 = new Pet("Rex", "Dog", 7, customer2);

           // Pet pet5 = new Pet("Max", "Dog", 4, customer3);
           // Pet pet6 = new Pet("Charlie", "Rabbit", 1, customer3);

           // Add pets to the petList
           // Pet.AddPet(pet1);
           // Pet.AddPet(pet2);
           // Pet.AddPet(pet3);
           // Pet.AddPet(pet4);
           // Pet.AddPet(pet5);
           // Pet.AddPet(pet6);



           // Staff staff4 = new Staff
           // {
           //     Name = "Alice CEO",
           //     Email = "alice@example.com",
           //     Phone = "20201919",
           //     Position = StaffPosition.CEO,
           //     DateOfBirth = new DateTime(1975, 12, 5)
           // };

           // Staff.AddStaff(staff1);
           // Staff.AddStaff(staff2);
           // Staff.AddStaff(staff3);
           // Staff.AddStaff(staff4);

           // Appointment appointment = new Appointment();
           // {
           //     appointment.Patient = pet1;
           //     appointment.Purpose = "Operaion";
           //     appointment.DateAndTime = new DateTime(2024, 01, 01, 09, 30, 00);
           //     appointment.ResponsibleStaff = staff1;
           //     appointment.DurationInMinutes = 30;
           //     appointment.Status = "Underway";
           //     appointment.Note = "The custome rhas complained that his dog cannot walk properly any longer";
           // }

           // Appointment.AddAppointment(appointment);
        }
            #endregion
    }
}
