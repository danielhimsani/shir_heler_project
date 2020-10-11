using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace shir_heler_project
{
    class DBWrapper
    {
        public static void ExecuteSqlCommand(string database_name, string _command)
        {
            SQLiteConnection conn = new SQLiteConnection(@"data source = " + database_name); //Establish a connection with our created DB

            DataTable temp = selectQuery(_command, conn);
            Console.WriteLine(temp);

            
            

        }


        public static DataTable selectQuery(string query, SQLiteConnection sqlite)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand cmd;
                sqlite.Open();  //Initiate connection to the db
                cmd = sqlite.CreateCommand();
                cmd.CommandText = query;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource
            }
            catch (SQLiteException ex)
            {
                //Add your exception code here.
            }
            sqlite.Close();
            return dt;
        }
    }
}
