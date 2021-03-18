using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Presention.Views
{
    public class OrderView
    {
        private OrderBusiness orderBusiness = new OrderBusiness();
        private DriverProfileBusiness driverProfileBusiness = new DriverProfileBusiness();
        private UserProfileBusiness userProfileBusiness = new UserProfileBusiness();
        private TownBusiness townBusiness = new TownBusiness();

        public OrderView()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "Order MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all orders");
            Console.WriteLine("2. Add new order");
            Console.WriteLine("3. Update order");
            Console.WriteLine("4. Fetch order by ID");
            Console.WriteLine("5. Delete order by ID");
            Console.WriteLine("6. Back to MAIN MENU");
        }
        private void Input()
        {
            if (userProfileBusiness.GetAll().Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Table UserProfiles is empty! Enter userProfile first.");
                Console.WriteLine();
            }
            else if (driverProfileBusiness.GetAll().Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Table DriverProfiles is empty! Enter driverProfile first.");
                Console.WriteLine();
            }
            else if (townBusiness.GetAll().Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Table Towns is empty! Enter town first.");
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
        private void Add()
        {
            Order order = new Order();
            Console.WriteLine("Enter date: ");
            int[] date = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            order.Date = new DateTime(date[2], date[1], date[0]);
            Console.WriteLine("Enter price: ");
            order.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter user profile id: ");
            order.UserProfileId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter driver profile id: ");
            order.DriverProfileId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter town id: ");
            order.TownId = int.Parse(Console.ReadLine());
            orderBusiness.Add(order);
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 17) + "ORDERS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            List<Order> orders = orderBusiness.GetAll();
            Console.WriteLine("Id || Date || Price || UserProfileId || DriverProfileId || TownId");
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.Id} || {order.Date} || {order.Price} || {order.UserProfileId} || {order.DriverProfileId} || {order.TownId}");
            }
            Console.WriteLine(new string('-', 40));
        }
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Order order = orderBusiness.Get(id);
            if (order != null)
            {
                Console.WriteLine("Enter date: ");
                int[] date = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                order.Date = new DateTime(date[2], date[1], date[0]);
                Console.WriteLine("Enter price: ");
                order.Price = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter user profile id: ");
                order.UserProfileId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter driver profile id: ");
                order.DriverProfileId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter town id: ");
                order.TownId = int.Parse(Console.ReadLine());
                orderBusiness.Update(order);
            }
            else
            {
                Console.WriteLine("Order not found!");
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Order order = orderBusiness.Get(id);
            if (order != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + order.Id);
                Console.WriteLine("Date: " + order.Date);
                Console.WriteLine("Price: " + order.Price);
                Console.WriteLine(order.UserProfile);
                Console.WriteLine(order.DriverProfile);
                Console.WriteLine(order.Town);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Order not found!");
            }
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            orderBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
