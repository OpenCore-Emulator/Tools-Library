using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardNet.Helpers
{
    public sealed class Persistence
    {
        private static Persistence _instance;
        
        public static Persistence Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Persistence();
                }
                return _instance;
            }
        }
        
        private readonly object _syncLock = new object();
        private static SQLiteConnection  Connection { get; }  = new SQLiteConnection ($"Data Source=BlizzardNet.db;Version=3;New=True;Compress=True;");

        private Persistence()
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.OpenAsync();
            }
        }
        
        // Create method for insert prevent lock database
        public void CreateTable(ConcurrentDictionary<string, List<string>> tables)
        {
            StringBuilder str = new StringBuilder();
            
            // Parallel foreach for create table
            Parallel.ForEach(tables, (table) =>
            {
                str.Append($"CREATE TABLE IF NOT EXISTS {table.Key} (");
                
                Parallel.ForEach(table.Value, (column) =>
                {
                    str.Append($"{column} TEXT,");
                });
                str.Remove(str.Length - 1, 1);
                str.Append(");");
                lock (_syncLock)
                {
                    using (var command = new SQLiteCommand(str.ToString(), Connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                str.Clear();
            });
            
            Connection.Close();
        }

        /*public void Create(string name, string email, string password)
        {
            using (var db = new SQLiteCommand("Data Source=database.db"))
            {
                db.Open();
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO users (name, email, password) VALUES (@name, @email, @password)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
            }
        }
        
        public void Update(string name, string email, string password)
        {
            using (var db = new SqliteConnection("Data Source=database.db"))
            {
                db.Open();
                var cmd = db.CreateCommand();
                cmd.CommandText = "UPDATE users SET name = @name, email = @email, password = @password WHERE id = 1";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.ExecuteNonQuery();
            }
        }
        
        public void Delete()
        {
            using (var db = new SQLiteCommand("Data Source=database.db"))
            {
                db.Open();
                var cmd = db.CreateCommand();
                cmd.CommandText = "DELETE FROM users WHERE id = 1";
                cmd.ExecuteNonQuery();
            }
        }
        
        public string Select(string column)
        {
            using (var db = new SqliteConnection("Data Source=database.db"))
            {
                db.Open();
                var cmd = db.CreateCommand();
                cmd.CommandText = "SELECT " + column + " FROM users WHERE id = 1";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
            }
            return null;
        }
        
        // This method convert class to table for sqlLite database
        public void ConvertClassToTable<T>(T obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            var tableName = type.Name;
            var columns = new List<string>();
            
            foreach (var property in properties)
            {
                var columnName = property.Name;
                var columnType = property.PropertyType.Name;
                columns.Add(columnName + " " + columnType);
            }
            
            var columnsString = string.Join(", ", columns);
            
            using (var db = new SqliteConnection("Data Source=database.db"))
            {
                db.Open();
                var cmd = db.CreateCommand();
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " (" + columnsString + ")";
                cmd.ExecuteNonQuery();
            }
        }
        */

        // create method for get if table exist
        public bool TableExist(string tableName)
        {
            var sql = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'";
            using (var command = new SQLiteCommand(sql, Connection))
            {
                Connection.Open();
                SQLiteDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    return true;
                }
                Connection.Close();
            }
            return false;
        }
    }
}