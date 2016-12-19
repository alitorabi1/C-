using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Enums
{

    [Flags]
    enum WeekDays { Monday = 1, Tuesday = 2, Wednesday = 4, Thursday = 8, Friday = 16, Saturday = 32, Sunday = 64 }

    class Program
    {
        static void Main(string[] args)
        {
            WeekDays days = 0;
            string[] lineArray;
            try
            {
                lineArray = File.ReadAllLines("staffing.txt");
            } catch (IOException ex)
            {
                throw ex;
            }
            foreach (string line in lineArray)
            {
                WeekDays wd;
                string[] justDays = line.Split(',');
                for (int i = 0; i < justDays.Length; i++)
                {
                    if (justDays[0].Contains(':'))
                    {
                        string[] firstDayArray = justDays[0].Split(':');
                        justDays[0] = firstDayArray[1];
                    }
                    if (Enum.TryParse<WeekDays>(justDays[i], out wd))
                    {
                        days |= wd;
                    }
                    else
                    {
                        Console.WriteLine("Ignoring invalid line " + line);
                    }
                }
            }
            Console.WriteLine("Office is staffed on " + days);

            Console.ReadKey();
        }
    }
}
