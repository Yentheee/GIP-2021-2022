using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Data.OleDb;

using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace GIP_Smart.Pages.Classes
{
    public class Netwerkcommunicatie
    {
        Settings settings = new Settings();

        public MqttClient mqttClient;

        string broker;
        string topic;

        string query;
        string connstring = connStrings.connString;

        public Netwerkcommunicatie()
        {
            this.topic = settings.GetTopic;
            this.broker = settings.GetBroker;

        }
        public void Network()
        {
            mqttClient = new MqttClient("test.mosquitto.org");

            

            //string clientId = Guid.NewGuid().ToString();

            //mqttClient.Connect(clientId);
            //TextBox1.Text = "subscriber: arduino/simple";
            mqttClient.Subscribe(new string[] { "topic1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            mqttClient.Connect("test.mosquitto.org");

        }
        public void client_receivedMessage(object sender, MqttMsgPublishEventArgs e)
        {

            var message = System.Text.Encoding.Default.GetString(e.Message);

            query = string.Format("INSERT INTO Verlichting(Temperatuur, Tijd) VALUES ({0}, '{1}');", message, DateTime.Now);
            UitvoerenQuery(connstring, query);



            //TextBox1.Text += "message received: " + message;
            //Label1.Text = "message received: " + message;
            Debug.WriteLine(message);
        }

        static void UitvoerenQuery(string connstring, string query)
        {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = connstring;

            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = query;

                command.ExecuteNonQuery();
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