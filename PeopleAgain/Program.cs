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
                    throw new InvalidOperationException("Name can not be empty");
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
                    throw new InvalidOperationException("Age must be between 0 and 150");
                }
                age = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Person: {0}, {1} y/o", Name, Age);
        }
    }

    public class Student : Person
    {
        public Student(string name, int age, double gpa, string program)
            : base (name, age)
        {
            Name = name;
            Age = age;
            GPA = gpa;
            Program = program;
        }
        private double gpa;
        public double GPA
        {
            get
            {
                return gpa;
            }
            set
            {
                if ((value < 0) || (value > 4.5))
                {
                    throw new InvalidOperationException("GPA must be between 0 and 4.5");
                }
                gpa = value;
            }
        }

        private string program;
        public string Program
        {
            get { return program; }
            set
            {
                if (value == "")
                {
                    throw new InvalidOperationException("Program can not be empty");
                }
                program = value;
            }
        }
        public override string ToString()
        {
            return string.Format("Student: {0}, {1} y/o, with grade of {2} in {3}", Name, Age, GPA, Program);
        }
    }

    public class Teacher : Person
    {
        public Teacher(string name, int age, int experienceYears, string subject)
            : base(name, age)
        {
            Name = name;
            Age = age;
            ExperienceYears = experienceYears;
            Subject = subject;
        }

        private int experienceYears;
        public int ExperienceYears
        {
            get
            {
                return experienceYears;
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("ExperienceYears can not be 0");
                }
                experienceYears = value;
            }

        }

        private string subject;
        string Subject
        {
            get { return subject; }
            set
            {
                if (value == "")
                {
                    throw new InvalidOperationException("Subject can not be empty");
                }
                subject = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Teacher: {0}, {1} y/o, {2} years of experience in {3}", Name, Age, ExperienceYears, Subject);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            Person p1 = new Person("jerry", 33);
            Person p2 = new Person("Terry", 21);
            Teacher t1 = new Teacher("Marry", 32, 2, "Geography");
            Teacher t2 = new Teacher("Barry", 43, 5, "Physics");
            Student s1 = new Student("Carry", 17, 3.8, "Mathematics");
            Student s2 = new Student("Parry", 19, 4.3, "Electricity");

            people.Add(p1);
            people.Add(p2);
            people.Add(t1);
            people.Add(t2);
            people.Add(s1);
            people.Add(s2);

            foreach(Person p in people)
            {
                Console.WriteLine(p.ToString());
            }

            Console.ReadKey();
        }
    }

}