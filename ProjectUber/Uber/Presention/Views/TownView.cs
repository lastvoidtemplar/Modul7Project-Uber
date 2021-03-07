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

        public TownView()
        {
            Input();
        }

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
            Console.WriteLine("6. Exit");
        }
        private void Input()
        {

            int command = 0;
            int closedCommandId = 0;
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
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Towns" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<Town> towns = townBusiness.GetAll();
            foreach (Town town in towns)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + town.Id);
                Console.WriteLine("Name: " + town.Name);
                Console.WriteLine("Country: " + town.Country);
                Console.WriteLine("Zipcode: " + town.ZipCode);
                Console.WriteLine(new string('-', 40));
            }
            Console.WriteLine(new string('-', 40));
        }
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
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            townBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
