using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1DelegatesSolution
{
    class Program
    {

        delegate void SomePrinter(string n, int v1, int v2, int r);

        static void printResultNormal(string n, int v1, int v2, int r)
        {
            Console.WriteLine("Here's your computation, {0}: {1} / {2} = {3}", n, v1, v2, r);
        }

        static void printResultFancy(string n, int v1, int v2, int r)
        {
            Console.WriteLine("!!!###!!!--------------");
            Console.WriteLine("{0}: {1} / {2} = {3}", n, v1, v2, r);
            Console.WriteLine("!!!###!!!--------------");
        }

        static void Main(string[] args)
        {
            SomePrinter printer = null;

            string name;
            Console.Write("What is your name? ");
            name = Console.ReadLine();
            Console.WriteLine("Hi {0}, let's compute!", name);

            Console.WriteLine("Would you like to see results as 0) no output 1) normal 2) fancy output? or 3) both?");
            int printChoice = int.Parse(Console.ReadLine());
            switch (printChoice)
            {
                case 0:
                    break;
                case 1:
                    printer = printResultNormal;
                    break;
                case 2:
                    printer = printResultFancy;
                    break;
                case 3:
                    printer = printResultNormal;
                    printer += printResultFancy;
                    break;
                default:
                    printer = printResultNormal;
                    break;
            }


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
                        if (printer != null)
                        {
                            printer(name, val1, val2, val1 + val2);
                        }
                        break;
                    case 2: // sub
                        if (printer != null)
                        {
                            printer(name, val1, val2, val1 - val2);
                        }
                        break;
                    case 3: // mul
                        if (printer != null)
                        {
                            printer(name, val1, val2, val1 * val2);
                        }
                        break;
                    case 4: // div
                        if (printer != null)
                        {
                            printer(name, val1, val2, val1 / val2);
                        }
                        break;
                    default:
                        Console.WriteLine("Oops. I don't know this operation");
                        break;
                }

            }

        }

    }
}
