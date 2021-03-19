using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Presention.Views
{
    public class VehicleView
    {
        private VehicleBusiness vehicleBusiness = new VehicleBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public VehicleView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "Vehicle MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all vehicles");
            Console.WriteLine("2. Add new vehicle");
            Console.WriteLine("3. Update vehicle");
            Console.WriteLine("4. Fetch vehicle by ID");
            Console.WriteLine("5. Delete vehicle by ID");
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
        /// Aks the user for vehicle parameters and creates a vehicle with those parameters, after that adds that vehicle to the table Towns.
        /// </summary>
        private void Add()
        {
            Vehicle vehicle = new Vehicle();
            Console.WriteLine("Enter model: ");
            vehicle.Model = Console.ReadLine();
            Console.WriteLine("Enter horsepowers: ");
            vehicle.HorsePower = int.Parse(Console.ReadLine());
            vehicleBusiness.Add(vehicle);
        }

        /// <summary>
        /// Lists all vehicles from the table Vehicles.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "VEHICLES" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            List<Vehicle> vehicles = vehicleBusiness.GetAll();
            Console.WriteLine("Id || Model || HorsePowers");
            foreach(Vehicle vehicle in vehicles)
            {
                Console.WriteLine($"{vehicle.Id} || {vehicle.Model} || {vehicle.HorsePower}");               
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Aks the user for id, after that gets the vehicle with that id and asks for changes.
        /// </summary>
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Vehicle vehicle = vehicleBusiness.Get(id);
            if (vehicle != null)
            {
                Console.WriteLine("Enter model: ");
                vehicle.Model = Console.ReadLine();
                Console.WriteLine("Enter horsepowers: ");
                vehicle.HorsePower = int.Parse(Console.ReadLine());
                vehicleBusiness.Update(vehicle);
            }
            else
            {
                Console.WriteLine("Vehicale not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the vehicle with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Vehicle vehicle = vehicleBusiness.Get(id);
            if (vehicle != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + vehicle.Id);
                Console.WriteLine("Model: " + vehicle.Model);
                Console.WriteLine("HorsePowers: " + vehicle.HorsePower);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Vehicle not found!");
            }
        }

        /// <summary>
        /// Aks the user for id, after that deletes the vehicle with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            vehicleBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
