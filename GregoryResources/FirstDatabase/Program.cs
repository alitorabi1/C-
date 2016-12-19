using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDatabase
{
    class Program
    {
        const string CONN_STRING = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ipd\Documents\test1.mdf;Integrated Security=True;Connect Timeout=30";

        static SqlConnection conn;

        static void addPerson(string name, int age)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Person (Name, Age) VALUES (@Name, @Age)");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);            
            cmd.ExecuteNonQuery();
        }

        static void showAllPersons()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Person", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // column by name - the better (preferred) way
                        int id = reader.GetInt32(reader.GetOrdinal("Id"));
                        // column by column number
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);
                        Console.WriteLine("Person[{0}]: {1} is {2} y/o", id, name, age);
                    }
                }
            }
        }

        static void Main(string[] args)
        {            
            conn = new SqlConnection(CONN_STRING);
            conn.Open();

            Console.Write("Enter person's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter person's age: ");
            int age = int.Parse(Console.ReadLine());

            addPerson(name, age);
            showAllPersons();

            Console.WriteLine("Record added successfully");
            Console.ReadKey();
        }
    }
}
