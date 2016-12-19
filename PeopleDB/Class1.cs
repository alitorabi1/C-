using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB
{
    // Entity
    class Person
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Database
    {
        const string CONN_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\peopledb1.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;
        public Database()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }

        // During prototyping stage we make methods that are not yet implemented throw new NotImplementedException();
        public void AddPerson(Person p)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Person (Name, Age) VALUES (@Name, @Age)");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Age", p.Age);
            cmd.ExecuteNonQuery();
        }

        public List<Person> GetAllPersons () {
            List<Person> pList = new List<Person>();
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
                        string name = reader.GetString(reader.GetOrdinal("Name"));
                        int age = reader.GetInt32(reader.GetOrdinal("Age"));
                        pList.Add(new Person() {Id = id, Name = name, Age = age});
                    }
                }
            }
            return pList;
        }

        public Person GetPersonsById (int Id) {
            Person p = new Person();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Person WHERE Id = @Id", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // column by name - the better (preferred) way
                        p.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        // column by column number
                        p.Name = reader.GetString(1);
                        p.Age = reader.GetInt32(2);
                    }
                }
            }
            return p;
        }

        public void  DeletePersonsById (int Id) {
            SqlCommand cmd = new SqlCommand("DELETE FROM Person WHERE Id = " + Id, conn);
            cmd.ExecuteReader();
        }

        public void UpdatePersons(Person p)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Person SET Name=@Name, Age=@Age WHERE (Id = " + p.Id + ")");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Age", p.Age);
            cmd.ExecuteNonQuery();
        }
    }
}
