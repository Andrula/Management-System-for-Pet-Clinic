using MSCP.Interface;
using MSPC.Data.Database;
using MSPC.Enums;
using MSPC.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace MSPC.View
{
    public class StaffMenuView
    {
        private IStaffRepository MyDataGetter;
        List<Staff> staffList;

        public void StaffMenuSwitch()
        {
            MyDataGetter = new StaffRepository();
            LoadData();

            StaffRepository staffInstance = new StaffRepository();

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

                        Console.Write("Enter staff address: ");
                        string address = Console.ReadLine();

                        Staff newStaff = new Staff(name, (StaffPosition)Enum.Parse(typeof(StaffPosition), position), dateOfBirth, address, email, phone);

                        StaffRepository staffRepository = new StaffRepository();
                        staffRepository.Add(newStaff);
                        LoadData();

                        Console.WriteLine("New staff member created successfully.");
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Staff list:");
                        foreach (var staff in staffList)
                        {
                            staff.DisplayInfo();
                        }
                        Console.WriteLine("Press Q to go back.");
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.Write("Enter staff ID: ");
                        int findStaffId = Convert.ToInt32(Console.ReadLine());
                        StaffRepository findStaffInstance = new StaffRepository();
                        Staff foundStaff = findStaffInstance.GetById(findStaffId);
                        if (foundStaff != null)
                        {
                            foundStaff.DisplayInfo();
                        }
                        else
                        {
                            Console.WriteLine("Staff with the specified ID was not found.");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Clear();
                        Console.Write("Enter staff ID: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteStaffId))
                        {
                            Staff staffResult = staffInstance.GetById(deleteStaffId);
                            if (staffResult != null)
                            {
                                Console.WriteLine("Are you sure you want to delete the following staff?");
                                Console.WriteLine($"ID: {staffResult.ID} Name: {staffResult.Name} Email: {staffResult.Email}");
                                Console.WriteLine("Press (Y)es or (N)o ");

                                char response = Char.ToLower(Console.ReadKey().KeyChar);
                                Console.WriteLine(); // Move to a new line after reading the response.

                                if (response == 'y')
                                {
                                    staffInstance.Delete(deleteStaffId);
                                    LoadData();
                                    Console.WriteLine("Staff successfully deleted.");
                                }
                                else if (response == 'n')
                                {
                                    DisplayStaffMenu();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid response.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Staff not found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid staff ID.");
                        }
                        Console.Write("Press enter to return: ");
                        Console.ReadLine();

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
            Console.WriteLine("3. Find staff");
            Console.WriteLine("4. Delete staff");
            Console.WriteLine("Q. Back");
            Console.WriteLine("----------------");
            Console.Write("Select an option: ");
        }

        public void LoadData()
        {
             staffList = MyDataGetter.GetAll();
        }
    }
}
