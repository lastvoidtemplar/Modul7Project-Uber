using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
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
    }
}
