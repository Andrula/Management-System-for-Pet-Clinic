using MSPC.Enums;
using MSPC.Model;
using System;
using System.Collections;
using System.Collections.Generic;


namespace MSPC.View
{
    public class StaffMenuView
    {
        public static void StaffMenuSwitch()
        {
            List<Staff> allStaff = new Staff().GetData();
            bool isRunning = true;

            while (isRunning)
            {
                DisplayStaffMenu();
                char selection = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (selection)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Creating a new staff member:");
                        Console.Write("Enter staff name: ");
                        string name = Console.ReadLine();

                        Console.WriteLine("CEO,\r\nSurgeon,\r\nNurse,\r\nReceptionist,\r\nAssistant");
                        Console.Write("Enter staff position from the given list: ");
                        string position = Console.ReadLine();

                        Console.Write("Enter staff date of birth (YYYY-MM-DD): ");
                        string dateOfBirthString = Console.ReadLine();
                        DateTime dateOfBirth = DateTime.Parse(dateOfBirthString);

                        Console.Write("Enter staff email: ");
                        string email = Console.ReadLine();

                        Console.Write("Enter staff phone: ");
                        string phone = Console.ReadLine();

                        //Staff newStaff = new Staff
                        //{
                        //    Name = name,
                        //    Position = (StaffPosition)Enum.Parse(typeof(StaffPosition), position),
                        //    DateOfBirth = dateOfBirth,
                        //    Email = email,
                        //    Phone = phone
                        //};

                        // Instance that uses constructor.
                        Staff newStaff = new Staff(name, (StaffPosition)Enum.Parse(typeof(StaffPosition), position), dateOfBirth, email, phone);

                        newStaff.AddStaffAndSave(newStaff);

                        Console.WriteLine("New staff member created successfully.");
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Staff list:");
                        foreach (var staff in allStaff)
                        {
                            staff.DisplayInfo();
                        }
                        Console.WriteLine("Press Q to go back.");
                        Console.ReadKey();
                        break;
                    case 'q':
                    case 'Q':
                        // Go out of the loop and return to main menu
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

        static void DisplayStaffMenu()
        {
            Console.Clear();
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("1. Create a new staff");
            Console.WriteLine("2. Show list of staff");
            Console.WriteLine("Q. Back");
            Console.WriteLine("----------------");
            Console.Write("Select an option: ");
        }
    }
}
