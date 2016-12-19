using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.Write("What is your name? ");
            name = Console.ReadLine();
            Console.WriteLine("Hi {0}, let's compute!", name);

            while (true)
            {
                Console.WriteLine("What operation would you like to do?");
                Console.WriteLine("1. Add, 2. Subtract, 3. Multiply, 4. Divide, 0. Exit.");
                Console.Write("Your choice:");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Error: invalid choice, try again.");
                    continue;
                }
                if ((choice < 0) || (choice > 4))
                {
                    Console.WriteLine("Error: invalid choice, try again.");
                    continue;
                }
                //
                if (choice == 0)
                {
                    Console.WriteLine("Good bye, {0}!", name);
                    break;
                }
                // The rest goes here...
                int val1, val2;
                Console.Write("Enter the first parameter: ");
                if (!int.TryParse(Console.ReadLine(), out val1))
                {
                    Console.WriteLine("Error: invalid value, try again.");
                    continue;
                }
                Console.Write("Enter the second parameter: ");
                if (!int.TryParse(Console.ReadLine(), out val2))
                {
                    Console.WriteLine("Error: invalid value, try again.");
                    continue;
                }
                //
                switch (choice)
                {
                    case 1: // add
                        Console.WriteLine("Here's your computation, {0}: {1} / {2} = {3}",
                            name, val1, val2, val1 + val2);
                        break;
                    case 2: // sub
                        Console.WriteLine("Here's your computation, {0}: {1} / {2} = {3}",
                            name, val1, val2, val1 - val2);
                        break;
                    case 3: // mul
                        Console.WriteLine("Here's your computation, {0}: {1} / {2} = {3}",
                            name, val1, val2, val1 * val2);
                        break;
                    case 4: // div
                        Console.WriteLine("Here's your computation, {0}: {1} / {2} = {3}",
                            name, val1, val2, val1 / val2);
                        break;
                    default:
                        Console.WriteLine("Oops. I don't know this operation");
                        break;
                }

            }

        }
    }
}
