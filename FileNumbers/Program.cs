using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double sum = 0;
                double largest = double.MinValue;
                List<double> list = new List<double>();
                List<double> sortedList = new List<double>();
                if (File.Exists("input.txt"))
                {
                    string[] content = File.ReadAllLines("input.txt");
                    for (int i = 0; i < content.Length; i++)
                    {
                        double number;
                        if (double.TryParse(content[i], out number))
                        {
                            list.Add(number);
                        }
                        else
                        {
                            Console.WriteLine("An error occured in reading file.");
                        }
                    }

                    foreach (double l in list)
                    {
                        sum = sum + l;
                        if (l > largest)
                        {
                            largest = l;
                        }
                    }
                    Console.WriteLine("Sum = " + sum);
                    Console.WriteLine("Average = " + sum / list.Count);
                    
                    // Sorting the list
                    foreach (double d in list)
                    {
                        if(d < largest)
                        {
                            largest = d;
                        }
                    }

                    if (list.Count % 2 == 0)
                    {
                        Console.WriteLine("Median = " + (list[(list.Count / 2) - 1] + list[(list.Count / 2)]) / 2);
                        Console.Write("Numbers below median: ");
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] < (list[(list.Count / 2) - 1] + list[(list.Count / 2)]) / 2)
                            {
                                Console.Write(list[i] + ", ");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Median = " + list[(list.Count / 2)]);
                        Console.Write("Numbers below median: ");
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i] < (list[(list.Count / 2)]))
                            {
                                Console.Write(list[i] + ", ");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found");
                }
                Console.WriteLine("");
                File.WriteAllText("output.txt", largest.ToString());
                Console.WriteLine("Your text has been saved in output.txt file.");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
