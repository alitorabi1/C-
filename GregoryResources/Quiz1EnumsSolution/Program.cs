using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1EnumsSolution
{
    class Program
    {

        [Flags]
        enum DaysOfWeek {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64
        }

        static void Main(string[] args)
        {
            DaysOfWeek staffedDays = 0;

            string[] linesArray = File.ReadAllLines("staffing.txt");
            foreach (string line in linesArray)
            {
//                string[] data = line.Split(new char[] { ':', ',' },
//                    StringSplitOptions.None);
                string[] data = line.Split(':');
                if (data.Length != 2)
                {
                    Console.WriteLine("Ignoring invalid line " + line);
                    continue;
                }
                string[] daysList = data[1].Split(',');
                foreach (string day in daysList)
                {
                    DaysOfWeek staffDay;
                    if (Enum.TryParse<DaysOfWeek>(day, out staffDay))
                    {
                        staffedDays |= staffDay;
                    }
                    else
                    {
                        Console.WriteLine("Ignoring invalid line " + line);
                        break;
                    }
                }
                
            }
            //
            Console.WriteLine("Office is staffed on " + staffedDays + ".");
            //
            Console.ReadKey();
        }
    }
}
