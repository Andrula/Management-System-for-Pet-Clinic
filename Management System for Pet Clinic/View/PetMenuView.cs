using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_System_for_Pet_Clinic.View
{
    public class PetMenuView
    {
        public static void PetMenuSwitch()
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

                        Console.Clear();
                        Console.WriteLine("Creating a new pet:");
                        Console.Write("Enter pet name: ");
                        string petName = Console.ReadLine();

                        Console.Write("Enter species: ");
                        string petSpecies = Console.ReadLine();

                        Console.Write("Enter pet age: ");
                        int petAge = int.Parse(Console.ReadLine());

                        Console.Write("Enter owner's : ");
                        string ownerName = Console.ReadLine();

                        Customer owner = Customer.FindCustomerByName(Customer.GetAllCustomers(), ownerName);

                        if (owner != null)
                        {
                            Pet pet = new Pet(petName,petSpecies, petAge, owner);
                            owner.AddPet(pet);
                            Pet.AddPet(pet);

                            Console.WriteLine("New pet created and added to the owner's list.");
                        }
                        else
                        {
                            Console.WriteLine("Owner not found.");
                        }

                        Console.WriteLine("New pet was created successfully.");
                        Console.ReadKey();

                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Pet list.");
                        foreach (var pet in Pet.GetAllPets())
                        {
                            pet.DisplayInfo();
                        }
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Write("Enter pet ID: ");
                        if (int.TryParse(Console.ReadLine(), out int petID))
                        {
                            Pet foundPet = Pet.FindPetByID(Pet.GetAllPets(), petID);
                            if (foundPet != null)
                            {
                                Console.Clear();
                                Console.WriteLine("Found pet!:");
                                foundPet.DisplayInfo();
                            }
                            else
                            {
                                Console.WriteLine("Pet not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid customer ID.");
                        }
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
            }
        }

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("1. Create new pet");
            Console.WriteLine("2. List all pets");
            Console.WriteLine("3. Find pet by ID");
            Console.WriteLine("Q. Back");
            Console.WriteLine("----------------");
            Console.Write("Select an option: ");
        }
    }
}
