using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numberList = new List<double>();

            try
            {
                string[] lineArray = File.ReadAllLines("input.txt");
                foreach (string line in lineArray)
                {
                    //double number = double.Parse(line);
                    double number;
                    try
                    {
                        number = double.Parse(line);
                        numberList.Add(number);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Error parsing line {0}", line);
                    }

                    /*
                    if (double.TryParse(line, out number))
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("Error parsing line {0}", line);
                    }
                     */
                }


                double sum = 0;
                for (int i = 0; i < numberList.Count; i++)
                {
                    sum += numberList[i];
                }
                double average = sum / numberList.Count;
                //Console.WriteLine("The average is: {0}", average);
                Console.WriteLine("The sum is: {0}", sum);
                //Console.WriteLine("The sum is: {0}", numbers.Sum());

                Console.WriteLine("The average is: {0}", numberList.Average());
                numberList.Sort();
                foreach (double number in numberList)
                {
                    Console.Write("{0}, ", number);
                }
                double median;
                int middle = numberList.Count / 2;

                if (numberList.Count % 2 == 0)
                {
                    median = (numberList[middle - 1] + numberList[middle]) / 2;
                }
                else
                {
                    median = numberList[middle];
                }
                // double median = numberList.Count % 2 == 0 ? (numberList[middle - 1] + numberList[middle]) / 2 : numberList[middle];
                Console.WriteLine("The median is: {0}", median);
                Console.Write("The numbers smaller than then median are: ");
                foreach (double number in numberList)
                {
                    if (number < median)
                    {
                        Console.Write(number + ",");
                    }
                }

                //File.WriteAllText("ouput.txt", numbers[numbers.Count - 1].ToString());


                double maxValue = numberList[numberList.Count - 1];
                File.WriteAllText("ouput.txt", maxValue.ToString());
                //File.WriteAllText("ouput1.txt", numberList.Max().ToString());
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading or writing a file" + e.Message);
            }
            Console.ReadLine();
        }
    }
}
