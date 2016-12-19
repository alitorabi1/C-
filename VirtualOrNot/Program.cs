using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOrNot
{
    class Parent
    {
        public void WhoAreYou()
        {
            Console.WriteLine("I am a Parent");
        }
        public virtual void WhoAreYouReally()
        {
            Console.WriteLine("I am a Parent");
        }
    }

    class Child : Parent
    {
        public void WhoAreYou()
        {
            Console.WriteLine("I am a Child");
        }
        public override void WhoAreYouReally()
        {
            Console.WriteLine("I am a Child");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            {
                Parent p = new Parent();
                p.WhoAreYou();
                Child c = new Child();
                c.WhoAreYou();
                Parent px = c; // px is pointing to Child object
                px.WhoAreYou(); // I am a .... ? Parent ?!?
            }
            //
            {
                Parent p = new Parent();
                p.WhoAreYouReally();
                Child c = new Child();
                c.WhoAreYouReally();
                Parent px = c; // px is pointing to Child object
                px.WhoAreYouReally(); // I am a .... Child! Virtual Call.
            }
            //
            Console.ReadKey();
        }
    }
}
