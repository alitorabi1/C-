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
        private int ID;
        protected static int count;

        public int getUniqueID() { return ID; }

        public static int getTotalPersonCount() { return count; }

        public Person(string name, int age)
        {
            count++;
            ID = count;
            try
            {
                Name = name;
                Age = age;
            }
            catch (Exception e)
            {
                count--;
                throw e;
            }
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
            // possibly bad style with parameters displayed out of order
            return String.Format("Person[{2}]: {0}, {1} y/o",
                Name, Age, getUniqueID());
        }

    }

    public class Student : Person
    {
        private double gpa;
        private string Program;
        public Student(string name, int age, double gpa, string program)
            : base(name, age)
        {
            try { 
                Gpa = gpa;
                Program = program;
            }
            catch (Exception e)
            {
                count--;
                throw e;
            }
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
            return String.Format("Student[{4}]: {0}, {1} y/o, GPA {2:0.00} studying {3}",
                Name, Age, Gpa, Program, getUniqueID());
        }
    }

    public class Teacher : Person
    {
        public Teacher(string name, int age, int exp, string subject)
            : base(name, age)
        {
            try
            {
                Subject = subject;
                ExperienceYears = exp;
            }
            catch (Exception e)
            {
                count--;
                throw e;
            }
        }

        public string Subject;
        public int ExperienceYears;

        public override string ToString()
        {
            return String.Format("Teacher[{4}]: {0}, {1} y/o, {2} years of experience in {3}",
                Name, Age, ExperienceYears, Subject, getUniqueID());
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string[] linesArray;

            try
            {
                linesArray = File.ReadAllLines("people.txt");
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading file ({0}). Exiting.", e.Message);
                return;
            }
            //
            foreach (String line in linesArray)
            {
                try
                {
                    string[] data = line.Split(';');
                    switch (data[0])
                    {
                        case "Person":
                            {
                                if (data.Length != 3)
                                {
                                    Console.WriteLine("Error parsing: Person required 3 fields");
                                    continue;
                                }
                                string name = data[1];
                                int age = int.Parse(data[2]);
                                Person p = new Person(name, age);
                                people.Add(p);
                            }
                            break;
                        case "Student":
                            {
                                if (data.Length != 5)
                                {
                                    throw new InvalidOperationException
                                        ("Error parsing: Student required 5 fields");
                                    
                                }
                                string name = data[1];
                                int age = int.Parse(data[2]);
                                double gpa = double.Parse(data[3]);
                                string program = data[4];
                                Student s = new Student(name, age, gpa, program);
                                people.Add(s);
                            }
                            break;
                        case "Teacher":
                            {
                                if (data.Length != 5)
                                {
                                    throw new InvalidOperationException
                                        ("Error parsing: Teacher required 5 fields");

                                }
                                string name = data[1];
                                int age = int.Parse(data[2]);
                                int yoe = int.Parse(data[3]);
                                string subject = data[4];
                                Teacher t = new Teacher(name, age, yoe, subject);
                                people.Add(t);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid line: " + line);
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine("Error parsing ({0}), skipping line: {1}",
                        e.Message, line);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error parsing ({0}), skipping line: {1}",
                        e.Message, line);
                }
            }
            //
            foreach (Person p in people)
            {
                Console.WriteLine(p);
            }
            //
            Console.WriteLine("Total Persons count " +
                Person.getTotalPersonCount());
            Console.ReadKey();
        }
    }
}
