using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{

    class Car : IComparable<Car>
    {
        public Car(string makeModel, int yop, double lp100km,
            double zeroTo100secs)
        {
            this.MakeModel = makeModel;
            this.Yop = yop;
            this.Lp100km = lp100km;
            this.ZeroTo100secs = zeroTo100secs;
        }
        public string MakeModel;
        public int Yop;
        public double Lp100km;
        public double ZeroTo100secs;
        public override string ToString()
        {
            return string.Format(
                "{0}, made in {1}, {2} l/100km, 0-100km/h in {3} seconds",
                MakeModel, Yop, Lp100km, ZeroTo100secs);
        }

        public int CompareTo(Car other)
        {
            return this.MakeModel.CompareTo(other.MakeModel);
        }
    }
    
    class CarCompareByFuelEconomy : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            return x.Lp100km.CompareTo(y.Lp100km);           
        }
    }
    class Program
    {
        static List<Car> parking = new List<Car>();
        static void Main(string[] args)
        {
            parking.Add(new Car("Toyota Corolla", 2011, 7.8, 11.2));
            parking.Add(new Car("BMW X5", 2015, 12.1, 8.0));
            parking.Add(new Car("Ford Fiesta", 2012, 6.7, 8.5));
            parking.Add(new Car("VW Jetta", 2000, 7.2, 7.8));
            parking.Add(new Car("Nissan Altima", 2014, 8.9, 8.1));
            // TODO sort by MakeModel and display one per line
            Console.WriteLine("============== BY NAME:");
            parking.Sort();
            foreach(Car c in parking) {
                Console.WriteLine(c);
            }
            // TODO: Using IComparer sort Cars by fuel economy and display the list
            Console.WriteLine("============== BY FUEL ECONOMY:");
            parking.Sort(new CarCompareByFuelEconomy());
            foreach (Car c in parking)
            {
                Console.WriteLine(c);
            }
            // TODO: Using Lamba Expression sort by accelleration
            Console.WriteLine("============== BY FUEL ACCELLERATION:");
            parking.Sort( 
                    (x, y) => x.ZeroTo100secs.CompareTo(y.ZeroTo100secs)
                );
            foreach (Car c in parking)
            {
                Console.WriteLine(c);
            }
            // TODO: Using LINQ Expression sort by year of production
            Console.WriteLine("============== BY YEAR OF PRODUCTION:");
            List<Car> carsByYear = parking.OrderBy(c => c.Yop).ToList();
            foreach (Car c in carsByYear)
            {
                Console.WriteLine(c);
            }
            //
            Console.ReadKey();
        }
    }
}
