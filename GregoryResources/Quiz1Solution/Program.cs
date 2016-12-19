using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Solution
{
    class Program
    {
        private static string[] linesArray;

        static void Main(string[] args)
        {
            
            try
            {
                linesArray = File.ReadAllLines("sprints.txt");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading file: " + e.Message);
                return;
            }
            // * What is the average time of all runs of all runners?
            {
                int timeCount = 0;
                double sum = 0;
                foreach (string line in linesArray)
                {
                    double time;
                    if (double.TryParse(line, out time))
                    {
                        sum += time;
                        timeCount++;
                    }
                }
                Console.WriteLine("Average run time for all runners was {0:0.000}",
                    sum / timeCount);
            }
            // * What is the fastest time of all runs?
            {
                double fastest = double.MaxValue;
                foreach (string line in linesArray)
                {
                    double time;
                    if (double.TryParse(line, out time))
                    {
                        if (time < fastest)
                        {
                            fastest = time;
                        }
                    }
                }
                Console.WriteLine("The fastest ran was  {0:0.000}", fastest);
            }
            // * How many times has each runner run?
            {
                string currentRunner = "";
                int runsCount = 0;
                foreach (string line in linesArray)
                {
                    double time;
                    if (double.TryParse(line, out time))
                    {
                        runsCount++;
                    }
                    else
                    {
                        if (currentRunner != "")
                        {
                            Console.WriteLine("{0} ran {1} time(s)", currentRunner, runsCount);
                        }
                        currentRunner = line;
                        runsCount = 0;
                    }
                }
                Console.WriteLine("{0} ran {1} time(s)", currentRunner, runsCount);
            }
            // * What is the average run time of each runner?
            {
                string currentRunner = "";
                int runsCount = 0;
                double sum = 0;
                foreach (string line in linesArray)
                {
                    double time;
                    if (double.TryParse(line, out time))
                    {
                        runsCount++;
                        sum += time;
                    }
                    else
                    {
                        if (currentRunner != "")
                        {
                            Console.WriteLine("{0}'s average is {1:0.000}",
                                currentRunner, sum / runsCount);
                        }
                        currentRunner = line;
                        runsCount = 0;
                        sum = 0;
                    }
                }
                Console.WriteLine("{0}'s average is {1:0.000}",
                                currentRunner, sum / runsCount);
            }
            // * How many runners were there?
            {
                int runnerCount = 0;
                foreach (string line in linesArray)
                {
                    double time;
                    if (!double.TryParse(line, out time))
                    {
                        runnerCount++;
                    }
                }
                Console.WriteLine("There were {0} runners in total", runnerCount);
            }
            //
            Console.ReadKey();
        }
    }
}
