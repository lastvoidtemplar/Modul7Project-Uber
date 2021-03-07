using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Presention.Views
{
    public class DriverProfileView
    {
        private DriverProfileBusiness driverProfileBusiness = new DriverProfileBusiness();

        public DriverProfileView()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 11) + "Driver Profile MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all driver profiels");
            Console.WriteLine("2. Add new driver profile");
            Console.WriteLine("3. Update driver profile");
            Console.WriteLine("4. Fetch driver profile by ID");
            Console.WriteLine("5. Delete driver profile by ID");
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
            DriverProfile driverProfile = new DriverProfile();
            Console.WriteLine("Enter username: ");
            driverProfile.Username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            driverProfile.Password = Console.ReadLine();
            Console.WriteLine("Enter driver id: ");
            driverProfile.DriverId = int.Parse(Console.ReadLine());
            driverProfileBusiness.Add(driverProfile);
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "DRIVER PROFILES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            List<DriverProfile> driverProfiles = driverProfileBusiness.GetAll();
            foreach(DriverProfile driverProfile in driverProfiles)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + driverProfile.Id);
                Console.WriteLine("Username: " + driverProfile.Username);
                Console.WriteLine("Password: " + driverProfile.Password);
                Console.WriteLine(driverProfile.Driver);                
            }
            Console.WriteLine(new string('-', 40));
        }
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            DriverProfile driverProfile = driverProfileBusiness.Get(id);
            if (driverProfile != null)
            {
                Console.WriteLine("Enter username: ");
                driverProfile.Username = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                driverProfile.Password = Encrypt(Console.ReadLine());
                Console.WriteLine("Enter driver id: ");
                driverProfile.DriverId = int.Parse(Console.ReadLine());
                driverProfileBusiness.Update(driverProfile);
            }
            else
            {
                Console.WriteLine("Driver profile not found!");
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            DriverProfile driverProfile = driverProfileBusiness.Get(id);
            if (driverProfile != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + driverProfile.Id);
                Console.WriteLine("Username: " + driverProfile.Username);
                Console.WriteLine("Password: " + driverProfile.Password);
                Console.WriteLine(driverProfile.Driver);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Driver profile not found!");
            }
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            driverProfileBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private string Encrypt(string a)
        {
            return a;
        }
    }
}
