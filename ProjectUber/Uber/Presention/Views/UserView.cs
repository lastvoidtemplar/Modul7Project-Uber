using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Presention.Views
{
    public class UserView
    {
        private UserBusiness userBusiness = new UserBusiness();

        public UserView()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "USER MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all users");
            Console.WriteLine("2. Add new user");
            Console.WriteLine("3. Update user");
            Console.WriteLine("4. Fetch user by ID");
            Console.WriteLine("5. Delete user by ID");
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
            User user = new User();
            Console.WriteLine("Enter first name: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            user.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter count orders: ");
            user.CountOrders = int.Parse(Console.ReadLine());
            userBusiness.Add(user);
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Users" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<User> users = userBusiness.GetAll();
            Console.WriteLine(String.Join("\n", users));
        }
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            User user = userBusiness.Get(id);
            if (user != null)
            {
                Console.WriteLine("Enter first name: ");
                user.FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                user.LastName = Console.ReadLine();
                Console.WriteLine("Enter age: ");
                user.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter count orders: ");
                user.CountOrders = int.Parse(Console.ReadLine());
                userBusiness.Update(user);
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            User user = userBusiness.Get(id);
            if (user != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + user.Id);
                Console.WriteLine("First name: " + user.FirstName);
                Console.WriteLine("Last name: " + user.LastName);
                Console.WriteLine("Age: " +user.Age);
                Console.WriteLine("Count orders: " + user.CountOrders);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            userBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
