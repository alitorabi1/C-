using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Results
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*
                Average run time for all runners was 9.65
                The fastest ran was 8.7
                Jerry ran 3 time(s)
                Tom ran 1 time(s)
                Larisa ran 2 time(s)
                Jerry's average is 9.27
                Tom's average is 12.12
                Larisa's average is 8.99
                There were 3 runners in total.
                */
                double sum = 0;
                double largest = double.MinValue;
                List<double> recordList = new List<double>();
                List<string> nameList = new List<string>();
                List<int> recordCountArr = new List<int>();
                string[] content = File.ReadAllLines("sprints.txt");
                int recordCount = 0;
                for (int i = 0; i < content.Length; i++)
                {
                    double number;
                    if (!double.TryParse(content[i], out number))
                    {
                        recordCountArr.Add(recordCount);
                        nameList.Add(content[i]);
                        recordCount = 0;
                    }
                    else
                    {
                        recordList.Add(number);
                        recordCount++;
                    }

                }

                foreach (double l in recordList)
                {
                    Console.WriteLine(l);
                }

                foreach (string s in nameList)
                {
                    Console.WriteLine(s);
                }

                foreach (double l in recordList)
                {
                    sum = sum + l;
                    if (l > largest)
                    {
                        largest = l;
                    }
                }
                Console.WriteLine("Average run time for all runners was " + sum / recordList.Count);
                // Sorting the list
                foreach (double d in recordList)
                {
                    if (d < largest)
                    {
                        largest = d;
                    }
                }
                Console.WriteLine("The fastest ran was " + largest);

                foreach(int i in recordCountArr)
                {
                    Console.WriteLine(i);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
