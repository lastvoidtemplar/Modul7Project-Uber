using Business;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Presention.Views
{
    public  class UserProfileView
    {
        private UserProfileBusiness userBusiness = new UserProfileBusiness();

        public UserProfileView()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "USER MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all userprofiles");
            Console.WriteLine("2. Add new userprofile");
            Console.WriteLine("3. Update userprofile");
            Console.WriteLine("4. Fetch userprofile by ID");
            Console.WriteLine("5. Delete userprofile by ID");
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
            UserProfile userProfile = new UserProfile();
            Console.WriteLine("Enter  username: ");
            userProfile.Username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            userProfile.Password = Encrypt(Console.ReadLine());
            Console.WriteLine("Enter user id: ");
            userProfile.UserId = int.Parse(Console.ReadLine());          
            userBusiness.Add(userProfile);
        }
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Users" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<User> users =u.GetAll();
            Console.WriteLine(String.Join("\n", users));
        }
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            UserProfile userProfile = userBusiness.Get(id);
            if (userProfile != null)
            {
                Console.WriteLine("Enter  username: ");
                userProfile.Username = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                userProfile.Password = Encrypt(Console.ReadLine());
                Console.WriteLine("Enter user id: ");
                userProfile.UserId = int.Parse(Console.ReadLine());
                userBusiness.Update(userProfile);
            }
            else
            {
                Console.WriteLine("Userprofile not found!");
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
                Console.WriteLine("Age: " + user.Age);
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
        private string Encrypt(string text)
        {
            //TO DO
            return text;
        }
    }
}
