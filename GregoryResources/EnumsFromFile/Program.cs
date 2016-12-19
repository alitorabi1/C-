using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsFromFile
{
    enum CoffeeOption
    {
        None, Sugar, Milk, Cream, Decaf, Splenda
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<CoffeeOption> options = new List<CoffeeOption>();
            string[] linesArray = File.ReadAllLines("coffee.txt");
            foreach (string line in linesArray)
            {
                CoffeeOption opt;
                if (Enum.TryParse<CoffeeOption>(line, out opt))
                {
                    options.Add(opt);
                }
                else
                {
                    Console.WriteLine("Ignoring invalid value " + line);
                }
            }
            //            
            Console.WriteLine("Your coffee: " + string.Join(", ", options));
            //
            Console.ReadKey();
        }
    }
}
