using MSPC.Enums;
using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Management_System_for_Pet_Clinic.View
{
    public class CustomerMenuView
    {
        public static void CustomerMenuSwitch()
        {
            Customer instance = new Customer();

            List<Customer> list = instance.GetData();

            bool isRunning = true;

            while (isRunning)
            {
                DisplayMenu();
                char selection = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (selection)
                {
                    case '1':

                        Console.Clear();
                        Console.WriteLine("Creating a new Customer:");
                        Console.Write("Enter customer name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter customer email: ");
                        string email = Console.ReadLine();

                        Console.Write("Enter customer phone: ");
                        string phone = Console.ReadLine();

                        Console.Write("Enter customer address: ");
                        string address = Console.ReadLine();

                        Customer newCustomer = new Customer(name, email, phone);

                        newCustomer.AddCustomerAndSave(newCustomer);

                        Console.WriteLine("New customer member created successfully.");
                        Console.ReadKey();

                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Customer list.");

                        foreach (var customer in list)
                        {
                            customer.DisplayInfo();
                        }
                        Console.WriteLine("Press Q to go back.");
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Write("Enter customer ID: ");
                        if (int.TryParse(Console.ReadLine(), out int customerId))
                        {
                            Customer foundCustomer = Customer.FindCustomerById(list, customerId);
                            if (foundCustomer != null)
                            {
                                Console.Clear();
                                Console.WriteLine("Found customer:");
                                foundCustomer.DisplayInfo();
                            }
                            else
                            {
                                Console.WriteLine("Customer not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid customer ID.");
                        }
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Write("Enter owner's name: ");
                        string ownerName = Console.ReadLine();

                        Customer owner = Customer.FindCustomerByName(list, ownerName);

                        if (owner != null)
                        {
                            Console.WriteLine($"Pets of {owner.Name}:");
                            foreach (var pet in owner.Pets)
                            {
                                pet.DisplayInfo();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Owner not found.");
                        }

                        Console.ReadKey();
                        break;
                    case 'q':
                    case 'Q':
                        // Go out of the loop and return to main menu
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
        }

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("1. Create new customer");
            Console.WriteLine("2. List all customers");
            Console.WriteLine("3. Find customer by ID");
            Console.WriteLine("4. List pets belonging to a specific customer");
            Console.WriteLine("Q. Back");
            Console.WriteLine("----------------");
            Console.Write("Select an option: "); 
        }
    }
}
