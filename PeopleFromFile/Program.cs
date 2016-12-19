using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleFromFile
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
                    //Console.WriteLine("Age must be between 0 and 150");
                }
                else
                {
                    age = value;
                }
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
            : base(name, age)
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

            string[] content = File.ReadAllLines("people.txt");
            try
            {
                foreach (string str in content)
                {
                    string[] type = str.Split(';');
                    switch (type[0])
                    {
                        case "Person":
                            people.Add(new Person(type[1], int.Parse(type[2])));
                            break;
                        case "Teacher":
                            people.Add(new Teacher(type[1], int.Parse(type[2]), int.Parse(type[3]), type[4]));
                            break;
                        case "Student":
                            people.Add(new Student(type[1], int.Parse(type[2]), double.Parse(type[3]), type[4]));
                            break;
                        default:
                            if (type[0] == "")
                            {
                                throw new InvalidOperationException("Class is not defined!");
                            }
                            if (type[0] != "Person" || type[0] != "Teacher" || type[0] != "Student")
                            {
                                throw new InvalidOperationException("Class " + type[0] + " can not be found!");
                            }
                            Console.WriteLine("There is a problem in reading people.txt file");
                            break;
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            foreach (Person p in people)
            {
                Console.WriteLine(p.ToString());
            }

            Console.ReadKey();
        }
    }
}
