using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaCall
{
    class Program
    {
        static void LogNormal(string message)
        {
            Console.WriteLine("Message: " + message);
        }

        static void LogFancy(string message)
        {
            Console.WriteLine("!!!***<<<[[[ " + message);
        }

        static void LogDouble(string m, string y)
        {

        }

        public delegate void LogIt(string m);

        public delegate void LogIt2(string a, string b);

        static void Main(string[] args)
        {
            LogIt log = null;
            
            if (log != null)
            {
                log("initial");            
            }
            // INVALID: log = LogDouble;
            // log = new LogIt(LogFancy);            
            log = LogFancy;
            log += LogNormal;
            if (log != null)
            {
                log("blablabla");
            }
            log -= LogFancy;
            if (log != null)
            {
                log("another");
            }


            Console.ReadKey();
        }
    }
}
