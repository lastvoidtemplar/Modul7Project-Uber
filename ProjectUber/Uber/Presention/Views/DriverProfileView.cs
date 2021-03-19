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
        private DriverBusiness driverBusiness = new DriverBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public DriverProfileView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
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
            Console.WriteLine("6. Back to MAIN MENU");
        }

        /// <summary>
        /// Converts the input and does the selected command. Also checks if table Drivers is empty.
        /// </summary>
        private void Input()
        {
            if (driverBusiness.GetAll().Count == 0) 
            {
                Console.WriteLine();
                Console.WriteLine("Table Drivers is empty! Enter driver first.");
                Console.WriteLine();
            }
            else
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
        }

        /// <summary>
        /// Aks the user for driver profile parameters and creates a driver profile with those parameters, after that adds that driver profile to the table DriverProfiles.
        /// </summary>
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

        /// <summary>
        /// Lists all driver profiles from the table DriverProfiles.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 8) + "DRIVER PROFILES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            List<DriverProfile> driverProfiles = driverProfileBusiness.GetAll();
            Console.WriteLine("Id || Username || Password || DriverId");
            foreach(DriverProfile driverProfile in driverProfiles)
            {
                Console.WriteLine($"{driverProfile.Id} || {driverProfile.Username} || {driverProfile.Password} || {driverProfile.Driver}");                
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Aks the user for id, after that gets the driver profile with that id and asks for changes.
        /// </summary>
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

        /// <summary>
        /// Asks the user for id, after that lists the driver profile with that id.
        /// </summary>
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

        /// <summary>
        /// Aks the user for id, after that deletes the driver profile with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            driverProfileBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        /// <summary>
        /// Encrypts the password so that hackers can not steel your password.
        /// </summary>
        /// <param name="text">The password</param>
        /// <returns>The encrypted password</returns>
        private string Encrypt(string text)
        {
            //TO DO
            return text;
        }
    }
}
