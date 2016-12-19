using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAgain
{
    public class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == "")
                {
                    throw new InvalidOperationException(
                        "Name must not be empty");
                }
                name = value;
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if ((value < 0) || (value > 150))
                {
                    throw new InvalidOperationException(
                        "Age must be between 0 and 150");
                }
                age = value;
            }
        }
        public override string ToString()
        {
            return String.Format("Person: {0}, {1} y/o", Name, Age);
        }

    }

    public class Student : Person
    {
        private double gpa;
        private string Program;
        public Student(string name, int age, double gpa, string program)
            : base(name, age)
        {
            Gpa = gpa;
            Program = program;
        }
        public double Gpa
        {
            get { return gpa; }
            set
            {
                if ((value < 0) || (value > 4.3))
                {
                    throw new InvalidOperationException(
                        "GPA must be between 0 and 4.3");
                }
                gpa = value;
            }
        }
        public override string ToString()
        {
            return String.Format("Student: {0}, {1} y/o, GPA {2:0.00} studying {3}",
                Name, Age, Gpa, Program);
        }
    }

    public class Teacher : Person
    {
        Teacher(string name, int age, string subject, int exp)
            : base(name, age)
        {
            Subject = subject;
            ExperienceYears = exp;
        }

        public string Subject;
        public int ExperienceYears;

        public override string ToString()
        {
            return String.Format("Teacher: {0}, {1} y/o, {2} years of experience in {3}",
                Name, Age, ExperienceYears, Subject);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            people.Add(new Person("jerry", 33));
            people.Add(new Student("Jessica", 33, 3.9, "PhysEd"));

            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }
    }
}
