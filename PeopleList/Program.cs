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
        string name;
        int age;
    }

    class PeopleList
    {
        static void Main(string[] args)
        {
            /*
            In the main method ask user repeatedly for
            name and age of a person and then instantiate
            class type Person with data provided.
            Add newly created object to List<Person>.
            Do this until name of person entered is empty.

            Using for-each loop display name and age of every person.
            Find the oldest person and display their name and age.
            */
            try
            {
                List<Person> people = new List<Person>();
                while (true)
                {
                        Console.Write("What is your name? ");
                        string name = Console.ReadLine();
                        if(name=="")
                        {
                            break;
                        }
                        Console.Write("What is your age? ");
                        string ageStr = Console.ReadLine();
                        int age;
                        if (!int.TryParse(ageStr, out age))
                        {
                            Console.WriteLine("Invalid age");
                            return;
                        }
                        Person p = new Person(name, age);
                        people.Add(p);
                }
                foreach(Person prsn in people)
                {
                    Console.WriteLine(people[prsn]);
                }
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
