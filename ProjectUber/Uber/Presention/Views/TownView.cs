using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Presention.Views
{
    public class TownView
    {
        private TownBusiness townBusiness = new TownBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public TownView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "TOWN MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all towns");
            Console.WriteLine("2. Add new town");
            Console.WriteLine("3. Update town");
            Console.WriteLine("4. Fetch town by ID");
            Console.WriteLine("5. Delete town by ID");
            Console.WriteLine("6. Back to MAIN MENU");
        }

        /// <summary>
        /// Converts the input and does the selected command.
        /// </summary>
        private void Input()
        {

            int command = 0;
            int closedCommandId = 6;
            do
            {
                ShowMenu();
                command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default: break;
                }
            } while (command != closedCommandId);
        }

        /// <summary>
        /// Aks the user for town parameters and creates a town with those parameters, after that adds that town to the table Towns.
        /// </summary>
        private void Add()
        {
            Town town = new Town();
            Console.WriteLine("Enter name: ");
            town.Name = Console.ReadLine();
            Console.WriteLine("Enter country: ");
            town.Country = Console.ReadLine();
            Console.WriteLine("Enter zipcode: ");
            town.ZipCode = int.Parse(Console.ReadLine());
            townBusiness.Add(town);
        }

        /// <summary>
        /// Lists all towns from the table Towns.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Towns" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<Town> towns = townBusiness.GetAll();
            Console.WriteLine("Id || Name || Country || Zipcode");
            foreach (Town town in towns)
            {
                Console.WriteLine($"{town.Id} || {town.Name} || {town.Country} || {town.ZipCode}");
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Aks the user for id, after that gets the town with that id and asks for changes.
        /// </summary>
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Town town = townBusiness.Get(id);
            if (town != null)
            {
                Console.WriteLine("Enter name: ");
                town.Name = Console.ReadLine();
                Console.WriteLine("Enter country: ");
                town.Country = Console.ReadLine();
                Console.WriteLine("Enter zipcode: ");
                town.ZipCode = int.Parse(Console.ReadLine());
                townBusiness.Update(town);
            }
            else
            {
                Console.WriteLine("Town not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the town with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Town town = townBusiness.Get(id);
            if (town != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + town.Id);
                Console.WriteLine("Name: " + town.Name);
                Console.WriteLine("Country: " + town.Country);
                Console.WriteLine("Zipcode: " + town.ZipCode);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Town not found!");
            }
        }

        /// <summary>
        /// Aks the user for id, after that deletes the town with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            townBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
