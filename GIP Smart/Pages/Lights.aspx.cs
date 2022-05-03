using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OleDb;

namespace GIP_Smart.Pages
{
    public partial class Lights : System.Web.UI.Page
    {
        Pages.Classes.Netwerkcommunicatie netwerkcommunicatie = new Pages.Classes.Netwerkcommunicatie();

        string query;
        string connstring = connStrings.connString;


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

            
            netwerkcommunicatie.Network();
            netwerkcommunicatie.mqttClient.MqttMsgPublishReceived += netwerkcommunicatie.client_receivedMessage;

            ProgressText.InnerText = "0%";

            query = "SELECT Temperatuur FROM Verlichting WHERE id = (SELECT max(id) FROM Verlichting);";
            DisplayData(connstring, query);

        }

        private void CalculateActiveUsersAngle(int TotalUser)
        {
            if (TotalUser == 0)
            {
                Val2 = "90deg";
                Val1 = "90deg";
                ColorCode = "#ffffff";
            }
            else if (TotalUser < 50 && TotalUser > 0)
            {
                double percentageOfWholeAngle = 360 * (Convert.ToDouble(TotalUser) / 100);
                Val2 = (90 + percentageOfWholeAngle).ToString() + "deg";
                Val1 = "90deg";
                ColorCode = "#ffffff";
            }
            else if (TotalUser > 50 && TotalUser < 100)
            {
                double percentage = 360 * (Convert.ToDouble(TotalUser) / 100);
                Val1 = (percentage - 270).ToString() + "deg";
                Val2 = "270deg";
                ColorCode = "#18bc9c";
            }
            else if (TotalUser == 50)
            {
                Val1 = "-90deg";
                Val2 = "270deg";
                ColorCode = "#18bc9c";
            }
            else if (TotalUser >= 100)
            {
                Val1 = "90deg";
                Val2 = "270deg";
                ColorCode = "#18bc9c";
            }

            ProgressText.InnerText = TotalUser + "%";
        }

        protected void btn_On_Click(object sender, EventArgs e)
        {
            if (netwerkcommunicatie.mqttClient != null && netwerkcommunicatie.mqttClient.IsConnected)
            {
                netwerkcommunicatie.mqttClient.Publish("topic1", Encoding.UTF8.GetBytes("on"));
            }
        }

        protected void btn_Off_Click(object sender, EventArgs e)
        {
            if (netwerkcommunicatie.mqttClient != null && netwerkcommunicatie.mqttClient.IsConnected)
            {
                netwerkcommunicatie.mqttClient.Publish("topic1", Encoding.UTF8.GetBytes("off"));
            }
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
                    CalculateActiveUsersAngle(Convert.ToInt32(reader[0]));
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