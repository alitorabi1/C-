using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleList
{
    class Person
    {
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public string name;
        public int age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                Console.Write("What is your name? ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    break;
                }
                Console.Write("What is your age? ");
                int age;
                if (int.TryParse(Console.ReadLine(), out age))
                {
                    Person p = new Person(name, age);
                    people.Add(p);
                }
            }
            if (people.Count == 0)
            {
                Console.WriteLine("List empty");
            }
            else
            {
                // Using for-each loop display name and age of every person.
                foreach (Person p in people)
                {
                    Console.WriteLine("{0} is {1}", p.name, p.age);
                }
                // Find the oldest person and display their name and age.
                Person oldest = people[0]; // people.get(0);
                foreach (Person p in people)
                {
                    if (p.age > oldest.age)
                    {
                        oldest = p;
                    }
                }
                Console.WriteLine("The oldest is {0} who is {1} years old",
                    oldest.name, oldest.age);
                //
            }
            Console.ReadKey();
        }        
    }
}
