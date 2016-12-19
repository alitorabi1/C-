using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Delegates
{
    class Program
    {
        static void printResultNormal(string n, int v1, string operation, int v2, int r)
        {
            Console.WriteLine("Here's your computation, {0}: {1} {2} {3} = {4}", n, v1, operation, v2, r);
        }

        static void printResultFancy(string name, int v1, string operation, int v2, int r)
        {
            Console.WriteLine("!!!###!!!--------------");
            Console.WriteLine("{0}: {1} {2} {3} = {4}", name, v1, operation, v2, r);
            Console.WriteLine("!!!###!!!--------------");
        }

        public delegate void DeligatePrintResults(string dn, int dv1, string operation, int dv2, int dr);

        static void Main(string[] args)
        {
            //
            DeligatePrintResults dPrintResults = null;
            //
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
                int val1, val2, printType;
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
                Console.WriteLine("Would you like to see results as 0) no output 1) normal 2) fancy output? or 3) both.");
                Console.Write("Your choice:");
                if (!int.TryParse(Console.ReadLine(), out printType))
                {
                    printType = 1;
                    continue;
                }
                //
                switch (printType)
                {
                    case 0:
                        return;
                    case 1:
                        {
                            dPrintResults = printResultNormal;
                            switch (choice)
                            {
                                case 1: // add
                                    dPrintResults(name, val1, " + ", val2, val1 + val2);
                                    break;
                                case 2: // sub
                                    dPrintResults(name, val1, " - ", val2, val1 - val2);
                                    break;
                                case 3: // mul
                                    dPrintResults(name, val1, " X ", val2, val1 * val2);
                                    break;
                                case 4: // div
                                    dPrintResults(name, val1, " / ", val2, val1 / val2);
                                    break;
                                default:
                                    Console.WriteLine("Oops. I don't know this operation");
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {
                            dPrintResults = printResultFancy;
                            switch (choice)
                            {
                                case 1: // add
                                    dPrintResults(name, val1, " + ", val2, val1 + val2);
                                    break;
                                case 2: // sub
                                    dPrintResults(name, val1, " - ", val2, val1 - val2);
                                    break;
                                case 3: // mul
                                    dPrintResults(name, val1, " X ", val2, val1 * val2);
                                    break;
                                case 4: // div
                                    dPrintResults(name, val1, " / ", val2, val1 / val2);
                                    break;
                                default:
                                    Console.WriteLine("Oops. I don't know this operation");
                                    break;
                            }
                            break;
                        }
                    case 3:
                        {
                            dPrintResults = printResultNormal;
                            dPrintResults += printResultFancy;
                            switch (choice)
                            {
                                case 1: // add
                                    dPrintResults(name, val1, " + ", val2, val1 + val2);
                                    break;
                                case 2: // sub
                                    dPrintResults(name, val1, " - ", val2, val1 - val2);
                                    break;
                                case 3: // mul
                                    dPrintResults(name, val1, " X ", val2, val1 * val2);
                                    break;
                                case 4: // div
                                    dPrintResults(name, val1, " / ", val2, val1 / val2);
                                    break;
                                default:
                                    Console.WriteLine("Oops. I don't know this operation");
                                    break;
                            }
                            break;
                        }
                }
            }
        }
    }
}
