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

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public UserView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
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
        /// Aks the user for user parameters and creates an user with those parameters, after that adds that user to the table Users.
        /// </summary>
        private void Add()
        {
            User user = new User();
            Console.WriteLine("Enter first name: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            user.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter orders count: ");
            user.CountOrders = int.Parse(Console.ReadLine());
            userBusiness.Add(user);
        }

        /// <summary>
        /// Lists all users from the table Users.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Users" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<User> users = userBusiness.GetAll();
            Console.WriteLine("Id || First name || Last name || Age || Orders count");
            foreach (User user in users)
            {
                Console.WriteLine($"{user.Id} || {user.FirstName} || {user.LastName} || {user.Age} || {user.CountOrders}");
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Aks the user for id, after that gets the user with that id and asks for changes.
        /// </summary>
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
                Console.WriteLine("Enter orders count: ");
                user.CountOrders = int.Parse(Console.ReadLine());
                userBusiness.Update(user);
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the user with that id.
        /// </summary>
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
                Console.WriteLine("Orders count: " + user.CountOrders);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }

        /// <summary>
        /// Aks the user for id, after that deletes the user with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            userBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
