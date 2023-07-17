using MSPC.Data.Model;
using MSPC.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC //Management System for Pet Clinic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                DisplayLogin();
                char selection = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (selection)
                {
                    case '1':
                        // Handle option 1
                        Console.WriteLine("Option 1 selected");
                        break;
                    case '2':
                        // Handle option 2
                        Console.WriteLine("Option 2 selected");
                        break;
                    case '3':
                        // Handle option 3
                        Console.WriteLine("Option 3 selected");
                        break;
                    case '4':
                        // Handle option 4
                        Console.WriteLine("Option 4 selected");
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

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("----- Menu -----");
            Console.WriteLine("1. Option 1");
            Console.WriteLine("2. Option 2");
            Console.WriteLine("3. Option 3");
            Console.WriteLine("4. Option 4");
            Console.WriteLine("Q. Quit");
            Console.WriteLine("----------------");
            Console.Write("Select an option: ");
        }

        static void DisplayLogin()
        {
            Console.Clear();
            Console.WriteLine("----- Login -----");
        }
    }
}
