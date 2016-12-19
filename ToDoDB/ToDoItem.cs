using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDB
{
    class ToDoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int IsDone { get; set; }
    }
    class Database
    {
        const string CONN_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\ToDoDB.mdf;Integrated Security=True;Connect Timeout=30";
        private SqlConnection conn;
        public Database()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }

        // During prototyping stage we make methods that are not yet implemented throw new NotImplementedException();
        public void AddItem(ToDoItem t)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO ToDoItem (Description, DueDate, IsDone) VALUES (@Description, @DueDate, @IsDone)");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Description", t.Description);
            cmd.Parameters.AddWithValue("@DueDate", t.DueDate);
            cmd.Parameters.AddWithValue("@IsDone", t.IsDone);
            cmd.ExecuteNonQuery();
        }

        public List<ToDoItem> GetAllItems()
        {
            List<ToDoItem> tList = new List<ToDoItem>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ToDoItem", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // column by name - the better (preferred) way
                        int id = reader.GetInt32(reader.GetOrdinal("Id"));
                        // column by column number
                        string description = reader.GetString(reader.GetOrdinal("Description"));
                        DateTime dueDate = reader.GetDateTime(reader.GetOrdinal("DueDate"));
                        int isDone = reader.GetInt32(reader.GetOrdinal("IsDone"));
                        tList.Add(new ToDoItem() { Id = id, Description = description, DueDate = dueDate, IsDone = isDone });
                    }
                }
            }
            return tList;
        }

        public ToDoItem GetItemsById(int Id)
        {
            ToDoItem t = new ToDoItem();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ToDoItem WHERE Id = @Id", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // column by name - the better (preferred) way
                        t.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        // column by column number
                        t.Description = reader.GetString(reader.GetOrdinal("description"));
                        t.DueDate = reader.GetDateTime(reader.GetOrdinal("dueDate"));
                        t.IsDone = reader.GetInt32(reader.GetOrdinal("isDone"));
                    }
                }
            }
            return t;
        }

        public void DeleteItemsById(int Id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM ToDoItem WHERE Id = " + Id, conn);
            cmd.ExecuteReader();
        }

        public void UpdateItems(ToDoItem t)
        {
            SqlCommand cmd = new SqlCommand("UPDATE ToDoItem SET Description=@Description, DueDate=@DueDate, IsDone=@IsDone WHERE (Id = " + t.Id + ")");
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Description", t.Description);
            cmd.Parameters.AddWithValue("@DueDate", t.DueDate);
            cmd.Parameters.AddWithValue("@IsDone", t.IsDone);
            cmd.ExecuteNonQuery();
        }
    }

}
