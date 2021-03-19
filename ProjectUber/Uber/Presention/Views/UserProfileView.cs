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
        private UserProfileBusiness userProfileBusiness = new UserProfileBusiness();
        private UserBusiness userBusiness = new UserBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public UserProfileView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 12) + "USERPROFILES MENU" + new string(' ', 11));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all userprofiles");
            Console.WriteLine("2. Add new userprofile");
            Console.WriteLine("3. Update userprofile");
            Console.WriteLine("4. Fetch userprofile by ID");
            Console.WriteLine("5. Delete userprofile by ID");
            Console.WriteLine("6. Back to MAIN MENU");
        }

        /// <summary>
        /// Converts the input and does the selected command. Also checks if tables Users is empty.
        /// </summary>
        private void Input()
        {
            if (userBusiness.GetAll().Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Table Users is empty! Enter user first.");
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
        /// Aks the user for user profile parameters and creates an user profile with those parameters, after that adds that user profile to the table UserProfiles.
        /// </summary>
        private void Add()
        {
            UserProfile userProfile = new UserProfile();
            Console.WriteLine("Enter  username: ");
            userProfile.Username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            userProfile.Password = Encrypt(Console.ReadLine());
            Console.WriteLine("Enter user id: ");
            userProfile.UserId = int.Parse(Console.ReadLine());          
            userProfileBusiness.Add(userProfile);
        }

        /// <summary>
        /// Lists all user profiles from the table UserProfiles.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 14) + "UserProfiles" + new string(' ', 14));
            Console.WriteLine(new string('-', 40));
            List<UserProfile> usersProfiles =userProfileBusiness.GetAll();
            Console.WriteLine("Id || Username || Password || UserProfileId");
            foreach (UserProfile userProfile in usersProfiles)
            {
                Console.WriteLine($"{userProfile.Id} || {userProfile.Username} || {userProfile.Password} || {userProfile.UserId}");
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Aks the user for id, after that gets the user profile with that id and asks for changes.
        /// </summary>
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            UserProfile userProfile = userProfileBusiness.Get(id);
            if (userProfile != null)
            {
                Console.WriteLine("Enter  username: ");
                userProfile.Username = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                userProfile.Password = Encrypt(Console.ReadLine());
                Console.WriteLine("Enter user id: ");
                userProfile.UserId = int.Parse(Console.ReadLine());
                userProfileBusiness.Update(userProfile);
            }
            else
            {
                Console.WriteLine("Userprofile not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the user profile with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            UserProfile userProfile = userProfileBusiness.Get(id);
            if (userProfile != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + userProfile.Id);
                Console.WriteLine("Username: " + userProfile.Username);
                Console.WriteLine("Password: " + userProfile.Password);
                Console.WriteLine(userProfile.User);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Userprofile not found!");
            }
        }

        /// <summary>
        /// Aks the user for id, after that deletes the user profile with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            userProfileBusiness.Delete(id);
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
