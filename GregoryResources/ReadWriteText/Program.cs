using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteText
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What do you want to do? 1-reading, 2-writing: ");
            string strChoice = Console.ReadLine();
            try
            {
                switch (strChoice)
                {
                    case "1":
                        {
                            Console.Write("Enter name of file to read: ");
                            string fileName = Console.ReadLine();
                            if (File.Exists(fileName))
                            {
                                string content = File.ReadAllText(fileName);
                                Console.WriteLine("Contents is:");
                                Console.WriteLine(content);
                            }
                            else
                            {
                                Console.WriteLine("File not found");
                            }
                        }
                        break;
                    case "2":
                        {
                            Console.Write("Enter name of file to write: ");
                            string fileName = Console.ReadLine();
                            Console.WriteLine("Enter a line of text:");
                            string line = Console.ReadLine();
                            File.WriteAllText(fileName, line);
                            Console.WriteLine("Your text has been saved in " + fileName);
                        }
                        break;
                    default:
                        Console.WriteLine("Oops. I don't know this option");
                        break;
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
