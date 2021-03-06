using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Presention.Views
{
    public class DriverView
    {
        private DriverBusiness driverBusiness = new DriverBusiness();
        private VehicleBusiness vehicleBusiness = new VehicleBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public DriverView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "Driver MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all drivers");
            Console.WriteLine("2. Add new driver");
            Console.WriteLine("3. Update driver");
            Console.WriteLine("4. Fetch driver by ID");
            Console.WriteLine("5. Delete driver by ID");
            Console.WriteLine("6. Back to MAIN MENU");
        }

        /// <summary>
        /// Converts the input and does the selected command. Also checks if table Vehicles is empty.
        /// </summary>
        private void Input()
        {
            if (vehicleBusiness.GetAll().Count == 0) 
            {
                Console.WriteLine();
                Console.WriteLine("Table Vehecles is empty! Enter vehicle first.");
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
        /// Aks the user for driver parameters and creates a driver with those parameters, after that adds that driver to the table Drivers.
        /// </summary>
        private void Add()
        {
            Driver driver = new Driver();
            Console.WriteLine("Enter first name: ");
            driver.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            driver.LastName = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            driver.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter orders count: ");
            driver.CountOrders = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter rating: ");
            driver.Rating = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter vehicle id: ");
            driver.VehicleId = int.Parse(Console.ReadLine());
            driverBusiness.Add(driver);
        }

        /// <summary>
        /// Lists all drivers from the table Drivers.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "DRIVERS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            List<Driver> drivers = driverBusiness.GetAll();
            Console.WriteLine("Id || First name || Last name || Age || Orders count || Rating || VehicleId");
            foreach(Driver driver in drivers)
            {
                Console.WriteLine($"{driver.Id} || {driver.FirstName} || {driver.LastName} || {driver.Age} || {driver.CountOrders} || {driver.Rating} || {driver.VehicleId}");               
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Aks the user for id, after that gets the driver with that id and asks for changes.
        /// </summary>
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Driver driver = driverBusiness.Get(id);
            if (driver != null)
            {
                Console.WriteLine("Enter first name: ");
                driver.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                driver.LastName = Console.ReadLine();
                Console.WriteLine("Enter age: ");
                driver.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter orders count: ");
                driver.CountOrders = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter rating: ");
                driver.Rating = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter vehicle id: ");
                driver.VehicleId = int.Parse(Console.ReadLine());
                driverBusiness.Update(driver);
            }
            else
            {
                Console.WriteLine("Driver not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the driver with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Driver driver = driverBusiness.Get(id);
            if (driver != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + driver.Id);
                Console.WriteLine("First name: " + driver.FirstName);
                Console.WriteLine("Last name: " + driver.LastName);
                Console.WriteLine("Age: " + driver.Age);
                Console.WriteLine("Orders count: " + driver.CountOrders);
                Console.WriteLine("Rating: " + driver.Rating);
                Console.WriteLine(driver.Vehicle);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Driver not found!");
            }
        }

        /// <summary>
        /// Aks the user for id, after that deletes the driver with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            driverBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
