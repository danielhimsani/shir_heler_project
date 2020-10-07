using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace shir_heler_project
{
    class DBWrapper
    {
        public static void ExecuteSqlCommand(string database_name, string _command)
        {
            SQLiteConnection dbConnection;
            dbConnection = new SQLiteConnection("Data Source=" + database_name);
            dbConnection.Open();

            SQLiteCommand command = new SQLiteCommand(_command, dbConnection);
            command.ExecuteNonQuery();

            SQLiteDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader["name"]);
            }

        }
    }
}
