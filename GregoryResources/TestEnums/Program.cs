using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEnums
{

    class StarBucks
    {        
        [Flags]
        public enum CoffeeOption
        {
            Sugar = 1,
            Cream = 2,
            Milk = 4,
            Decaf = 8
        }
    }




    class Logger
    {
        static Level minLogLevel = Level.Error;

        public static void log(Level level, String msg)
        {
            if (level >= minLogLevel)
            {
                // TODO: write message to log
            }
        }

        public enum Level : int
        {
            None = -1,
            Debug = 101,
            Info = 102,
            Warning = 205,
            Error = 400,
            Critical = 500,
            WTF = 999 // What a terrible failure
        };
    }



    class Program
    {
        static void Main(string[] args)
        {

            StarBucks.CoffeeOption coffeeOptions = 0;

            // these two lines are equivalent
            coffeeOptions = coffeeOptions | StarBucks.CoffeeOption.Sugar;
            coffeeOptions |= StarBucks.CoffeeOption.Sugar;
            //
            coffeeOptions |= StarBucks.CoffeeOption.Cream;
            coffeeOptions |= StarBucks.CoffeeOption.Cream;

            Console.WriteLine("Coffe 1: " + coffeeOptions);

            //
            List<StarBucks.CoffeeOption> listOfCoffeeOptions = new List<StarBucks.CoffeeOption>();
            listOfCoffeeOptions.Add(StarBucks.CoffeeOption.Cream);
            listOfCoffeeOptions.Add(StarBucks.CoffeeOption.Cream);
            listOfCoffeeOptions.Add(StarBucks.CoffeeOption.Cream);
            listOfCoffeeOptions.Add(StarBucks.CoffeeOption.Sugar);

            string options = string.Join(", ", listOfCoffeeOptions);
            Console.WriteLine("Gregory's coffee order: " + options);



            Logger.Level[] levelArray = new Logger.Level[10000];

            Logger.log(Logger.Level.Warning, "I am sneezing");
            Logger.log(Logger.Level.Critical, "I am burning up, really!");

            Logger.Level l = Logger.Level.Critical;

            Console.WriteLine("Level is: " + l); // or l.ToString()
            Console.WriteLine("Level is: " + (int)l);

            // Logger.Level v = (Logger.Level) Enum.Parse(typeof(Logger.Level), "Terrible");

            Console.ReadKey();
        }
    }
}
