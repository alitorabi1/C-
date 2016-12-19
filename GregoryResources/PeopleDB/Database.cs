using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB
{
    // Entity
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Database
    {
        const string CONN_STRING = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ipd\Documents\peopledb1.mdf;Integrated Security=True;Connect Timeout=30";

        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }

        // during prototyping stage we make methods that are
        // not yet implemented throw new NotImplementedException();
        public void AddPerson(Person p)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Person (Name, Age) VALUES (@Name, @Age)"))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Age", p.Age);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Person> GetAllPersons()
        {
            List<Person> list = new List<Person>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Person", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // column by name - the better (preferred) way
                        int id = reader.GetInt32(reader.GetOrdinal("Id"));
                        string name = reader.GetString(reader.GetOrdinal("Name"));
                        int age = reader.GetInt32(reader.GetOrdinal("Age"));
                        Person p = new Person() { Id = id, Name = name, Age = age };
                        list.Add(p);
                        // Console.WriteLine("Person[{0}]: {1} is {2} y/o", id, name, age);
                    }
                }
            }
            return list;
        }

        public Person GetPersonById(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeletePersonById(int Id)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Person WHERE Id=@Id", conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePerson(Person p)
        {
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Person SET Name = @Name, Age = @Age WHERE Id=@Id", conn))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Age", p.Age);
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
