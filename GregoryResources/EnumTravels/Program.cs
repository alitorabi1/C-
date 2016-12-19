using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTravels
{
    [Flags]
    enum Continents {
        Nowhere = 0,        // 0000 0000
        Africa = 1,         // 0000 0001
        Antarctica = 2,     // 0000 0010
        Asia = 4,           // 0000 0100
        Australia = 8,      // 0000 1000
        Europe = 16,        // 0001 0000
        NorthAmerica = 32,  // 0010 0000
        SouthAmerica = 64   // 0100 0000
    }

    class Program
    {
        static void Main(string[] args)
        {
            Continents visited = 0;

            string[] linesArray = File.ReadAllLines("travels.txt");
            foreach (string line in linesArray)
            {
                Continents ct;
                if (Enum.TryParse<Continents>(line, out ct))
                {
                    visited |= ct;
                }
                else
                {
                    Console.WriteLine("Ignoring invalid value " + line);
                }
            }
            //
            Console.WriteLine("You visited: " + visited);
            //
            Console.ReadKey();
        }
    }
}
