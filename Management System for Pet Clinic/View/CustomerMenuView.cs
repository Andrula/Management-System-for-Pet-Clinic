using MSCP.Interface;
using MSPC.Data.Database;
using MSPC.Enums;
using MSPC.Model;
using MSPC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MSPC.View
{
    public class CustomerMenuView
    {

        private ICustomerRepository MyDataGetter;
        List<Customer> customerList;

        public void CustomerMenuSwitch()
        {
            MyDataGetter = new CustomerRepository();
            LoadData();
            
            CustomerRepository customerInstance = new CustomerRepository();
            PetRepository petRepositoryInstance = new PetRepository();

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

                        customerInstance.Add(newCustomer);
                        LoadData();

                        Console.WriteLine("New customer member created successfully.");
                        Console.ReadKey();

                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Customer list.");

                        foreach (var customer in customerList)
                        {
                            customer.DisplayInfo();
                        }
                        Console.WriteLine("Press Q to go back.");
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.Write("Enter customer ID: ");
                        int findCustomerId = Convert.ToInt32(Console.ReadLine());
                        Customer foundCustomer = customerInstance.GetById(findCustomerId);

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

                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Write("Enter customer ID: ");
                        int customerID = Convert.ToInt32(Console.ReadLine());

                        CustomerRepository customerRepository = new CustomerRepository();
                        Customer owner = customerRepository.GetById(customerID);

                        if (owner != null)
                        {
                            Console.WriteLine($"Pets of {owner.Name}:");

                            List<Pet> pets = petRepositoryInstance.GetPetsByOwnerId(owner.ID);

                            foreach (var pet in pets)
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
                    case '5':
                        Console.Clear();
                        Console.Write("Enter customer ID: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteCustomer))
                        {
                            Customer customerResult = customerInstance.GetById(deleteCustomer);
                            if (customerResult != null)
                            {
                                Console.WriteLine("Are you sure you want do delete the following customer?:");
                                Console.WriteLine($"ID: {customerResult.ID} Name: {customerResult.Name} Email: {customerResult.Email}");
                                Console.WriteLine("Press (Y)es or (N)o");

                                char charResult = Console.ReadKey().KeyChar;
                                if (charResult == 'y')
                                {
                                    customerInstance.Delete(deleteCustomer);
                                    LoadData();

                                    Console.WriteLine("Customer succesfully deleted.");
                                    Console.ReadKey();
                                }
                                else if (charResult == 'n')
                                {
                                    DisplayMenu();
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
            Console.WriteLine("5. Delete customer");
            Console.WriteLine("Q. Back");
            Console.WriteLine("----------------");
            Console.Write("Select an option: "); 
        }

        public void LoadData()
        {
            customerList = MyDataGetter.GetAll();
        }
    }
}
