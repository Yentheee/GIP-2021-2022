using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace GIP_Smart.Pages
{
    public partial class Home : System.Web.UI.Page
    {

        string query;
        string connstring = Pages.connStrings.connString;

        int Status1;
        int Status2;

        int read1;
        int read2;

        private string val1verbruik = "90deg";

        public string Val1Verbruik
        {
            get { return val1verbruik; }
            set { val1verbruik = value; }
        }

        private string val2verbruik = "90deg";

        public string Val2Verbruik
        {
            get { return val2verbruik; }
            set { val2verbruik = value; }
        }

        private string colorCodeverbruik = "#ffffff";

        public string ColorCodeVerbruik
        {
            get { return colorCodeverbruik; }
            set { colorCodeverbruik = value; }
        }
        //----------------------------------------------------------------------------------
        private string val1 = "90deg";

        public string Val1
        {
            get { return val1; }
            set { val1 = value; }
        }

        private string val2 = "90deg";

        public string Val2
        {
            get { return val2; }
            set { val2 = value; }
        }

        private string colorCode = "#ffffff";

        public string ColorCode
        {
            get { return colorCode; }
            set { colorCode = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Pages.Classes.Netwerkcommunicatie netwerkcommunicatie = new Pages.Classes.Netwerkcommunicatie();
            netwerkcommunicatie.Network();
            netwerkcommunicatie.mqttClient.MqttMsgPublishReceived += netwerkcommunicatie.client_receivedMessage;

            ProgressTextTemperature.InnerText = "0°C";
            query = "SELECT Temperatuur FROM StopContact WHERE id = (SELECT max(id) FROM StopContact);";
            DisplayDataTemperature(connstring, query);


            ProgressTextVerbruik.InnerText = "0%";
            query = "SELECT Stroom FROM StopContact WHERE id = (SELECT max(id) FROM StopContact);";
            DisplayDataVerbruik(connstring, query);

            query = "SELECT Status temp sensor 1 FROM Verlichting WHERE id = (SELECT max(id) FROM Verlichting);";
            Status1 = DisplayDataStatus1(connstring, query);

            query = "SELECT Status temp sensor 2 FROM Verlichting WHERE id = (SELECT max(id) FROM Verlichting);";
            Status2 = DisplayDataStatus2(connstring, query);

            if (Status1 == 0)
            {
                StatusTemperature1.InnerText = "Sensor is kapot";
            }
            else
            {
                StatusTemperature1.InnerText = "Sensor werkt";
            }

            if(Status2 == 0)
            {
                StatusTemperature2.InnerText = "Sensor is kapot";
            }
            else
            {
                StatusTemperature2.InnerText = "Sensor werkt";
            }
        }
        private int DisplayDataStatus1(string connstring, string query)
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
                    read1 = Convert.ToInt32(reader[0]);
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

            return read1;
        }
        private int DisplayDataStatus2(string connstring, string query)
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
                    read2 = Convert.ToInt32(reader[0]);
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
            return read2;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }


        private void CalculateActiveUsersAngleVerbruik(double TotalUser)
        {
            ProgressTextVerbruik.InnerText = TotalUser + "%";

            int totaluser = Convert.ToInt32(TotalUser);

            if (totaluser == 0)
            {
                Val2Verbruik = "90deg";
                Val1Verbruik = "90deg";
                ColorCodeVerbruik = "#ffffff";
            }
            else if (totaluser < 50 && totaluser > 0)
            {
                double percentageOfWholeAngle = 10 * (Convert.ToDouble(totaluser));
                Val2Verbruik = (90 + percentageOfWholeAngle).ToString() + "deg";
                Val1Verbruik = "90deg";
                ColorCodeVerbruik = "#ffffff";
            }
            else if (totaluser > 50 && totaluser < 100)
            {
                double percentage = 360 * (Convert.ToDouble(totaluser) / 100);
                Val1Verbruik = (percentage - 270).ToString() + "deg";
                Val2Verbruik = "270deg";
                ColorCodeVerbruik = "#18bc9c";
            }
            else if (totaluser == 50)
            {
                Val1Verbruik = "-90deg";
                Val2Verbruik = "270deg";
                ColorCodeVerbruik = "#18bc9c";
            }
            else if (totaluser >= 100)
            {
                Val1Verbruik= "90deg";
                Val2Verbruik = "270deg";
                ColorCodeVerbruik = "#18bc9c";
            }

        }

        private void DisplayDataVerbruik(string connstring, string query)
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
                    CalculateActiveUsersAngleVerbruik(Convert.ToDouble(reader[0]));
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

        private void CalculateActiveUsersAngleTemperature(double TotalUser)
        {         
            ProgressTextTemperature.InnerText = TotalUser + "°C";
            
            int totaluser = Convert.ToInt32(TotalUser);

            if (totaluser == 0)
            {
                Val2 = "90deg";
                Val1 = "90deg";
                ColorCode = "#ffffff";
            }
            else if (totaluser < 50 && totaluser > 0)
            {
                double percentageOfWholeAngle = 360 * (Convert.ToDouble(totaluser) / 100);
                Val2 = (90 + percentageOfWholeAngle).ToString() + "deg";
                Val1 = "90deg";
                ColorCode = "#ffffff";
            }
            else if (totaluser > 50 && totaluser < 100)
            {
                double percentage = 360 * (Convert.ToDouble(totaluser) / 100);
                Val1 = (percentage - 270).ToString() + "deg";
                Val2 = "270deg";
                ColorCode = "#18bc9c";
            }
            else if (totaluser == 50)
            {
                Val1 = "-90deg";
                Val2 = "270deg";
                ColorCode = "#18bc9c";
            }
            else if (totaluser >= 100)
            {
                Val1 = "90deg";
                Val2 = "270deg";
                ColorCode = "#18bc9c";
            }    
        }

        private void DisplayDataTemperature(string connstring, string query)
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
                    CalculateActiveUsersAngleTemperature(Convert.ToDouble(reader[0]));
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