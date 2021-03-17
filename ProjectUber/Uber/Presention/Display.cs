using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Presention.Views;

namespace Uber.Presention
{
    public class Display
    {
        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "MAIN MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Towns");
            Console.WriteLine("2. Users");
            Console.WriteLine("3. UserProflies");
            Console.WriteLine("4. Vehicles");
            Console.WriteLine("5. Drivers");
            Console.WriteLine("6. DriversProflies");
            Console.WriteLine("7. Orders");
            Console.WriteLine("8. Exit");
        }
        private void Input()
        {

            int command = 0;
            int closedCommandId = 8;
            do
            {
                ShowMenu();
                command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1: Towns(); break;
                    case 2: Users(); break;
                    case 3: UserProflies(); break;
                    case 4: Vehicles(); break;
                    case 5: Drivers(); break;
                    case 6: DriverProfiles(); break;
                    case 7: Orders(); break;
                    default: break;
                }
            } while (command != closedCommandId);
        }
        private void Towns()
        {
            TownView townView = new TownView();
        }
        private void Users()
        {
            UserView userView = new UserView();
        }
        private void UserProflies()
        {
            UserProfileView userProfileView = new UserProfileView();
        }
        private void Vehicles()
        {
            VehicleView vehicle = new VehicleView();
        }
        private void Drivers()
        {
            DriverView driverView = new DriverView();
        }
        private void DriverProfiles()
        {
            DriverProfileView driverProfileView = new DriverProfileView();
        }
        private void Orders()
        {
            OrderView orderView = new OrderView();
        }
    }
}
