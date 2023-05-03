using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace ClassLibrary { 
    public class DataAccessLayer
    {
        protected MySqlConnection connection;
        protected MySqlCommand command;
        protected MySqlDataReader dataReader;
        protected string query = "";

        


        public DataAccessLayer()
        {
            string database = "Server=studmysql01.fhict.local;Uid=dbi463896;Database=dbi463896;Pwd=VuiManqk; SSL Mode=None;";

            this.connection = new MySqlConnection(database);
        }


        public void AddWithValue(string parameterName, object value)
        {
            this.command.Parameters.AddWithValue(parameterName, value);
        }

        public void NonQueryEx()
        {
            this.command.ExecuteNonQuery();
        }

        public void Close()
        {
            this.connection.Close();
        }
        public bool ConnOpen()
        {
            try
            {
                this.connection.Open();
                return true;
            }
            catch (MySqlException)
            {

                return false;
            }
        }

        public void SqlQuery(string queryText)
        {
            this.command = new MySqlCommand(queryText, this.connection);
        }
    }
}
