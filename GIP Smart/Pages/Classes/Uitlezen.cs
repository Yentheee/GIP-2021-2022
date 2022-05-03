using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace GIP_Smart.Pages.Classes
{
    public class Uitlezen
    {
        string query;
        public string waarde;

        public void lezen()
        {
            query = "SELECT test FROM Tabel1 WHERE id = (SELECT max(id) FROM Tabel1);";
            DisplayData(connStrings.connString, query);
        }

        protected void DisplayData(string connstring, string query)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = connstring;

            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    waarde = reader[0].ToString();
                }
            }

            catch (OleDbException error)
            {
                Console.WriteLine(error.Message);

            }

            finally
            {
                connection.Close();
            }

        }
    }
}