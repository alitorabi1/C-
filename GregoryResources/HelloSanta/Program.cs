using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("What is your name? ");
                string name = Console.ReadLine();
                Console.Write("What is your age? ");
                string ageStr = Console.ReadLine();
                int age;
                if (!int.TryParse(ageStr, out age))
                {
                    Console.WriteLine("Invalid age");
                    return;
                }
                // int age = int.Parse(Console.ReadLine());
                if (name == "Santa")
                {
                    Console.WriteLine("Wow. Santa.");
                }
                else
                {
                    Console.WriteLine("Hi {0}, you are {1}.", name, age);
                }
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
