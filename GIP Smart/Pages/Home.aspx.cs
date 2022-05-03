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

            ProgressText.InnerText = "0°";

            query = "SELECT Temperatuur FROM StopContact WHERE id = (SELECT max(id) FROM StopContact);";
            DisplayData(connstring, query);

        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
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

        private void DisplayData(string connstring, string query)
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