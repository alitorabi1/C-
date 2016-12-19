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
            try
            {
                Console.Write("What is your name? ");
                string name = Console.ReadLine();
                Console.WriteLine("Hi {0}, let's compute!", name);
                Console.WriteLine("What operation would you like to do?");
                Console.WriteLine("1.Add, 2.Subtract, 3.Multiply, 4.Divide, 0.Exit.");
                int operate;
                while (true)
                {
                    Console.Write("Your choice: ");
                    string operateStr = Console.ReadLine();
                    if ((!int.TryParse(operateStr, out operate)) || (operate < 0) || (operate > 4))
                    {
                        Console.WriteLine("invalid choice, try again.");
                        continue;
                    }
                    else if (operate == 0)
                    {
                        Console.WriteLine("Good bye, {0}!", name);
                        return;
                    }
                    else break;
                }
                int num1;
                while (true)
                {
                    Console.Write("Enter the first parameter: ");
                    string num1Str = Console.ReadLine();
                    if (!int.TryParse(num1Str, out num1))
                    {
                        Console.WriteLine("invalid number, try again.");
                        continue;
                    }
                    else break;
                }

                int num2;
                while (true)
                {
                    Console.Write("Enter the second parameter: ");
                    string num2Str = Console.ReadLine();
                    if (!int.TryParse(num2Str, out num2))
                    {
                        Console.WriteLine("invalid number, try again.");
                        continue;
                    }
                    else break;
                }
                // Calculate and write the result
                switch (operate)
                {
                    case 1:
                        Console.WriteLine("Here's your computation, {0}: {1} + {2} = {3}", name, num1, num2, num1 + num2);
                        break;
                    case 2:
                        Console.WriteLine("Here's your computation, {0}: {1} - {2} = {3}", name, num1, num2, num1 - num2);
                        break;
                    case 3:
                        Console.WriteLine("Here's your computation, {0}: {1} x {2} = {3}", name, num1, num2, num1 * num2);
                        break;
                    case 4:
                        Console.WriteLine("Here's your computation, {0}: {1} : {2} = {3}", name, num1, num2, num1 / num2);
                        break;
                    default:
                        Console.WriteLine("Unknown error!");
                        break;
                }
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
