using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIP_Smart.Pages
{
    public partial class Wall_Outler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pages.Classes.Netwerkcommunicatie netwerkcommunicatie = new Pages.Classes.Netwerkcommunicatie();
            netwerkcommunicatie.Network();
            netwerkcommunicatie.mqttClient.MqttMsgPublishReceived += netwerkcommunicatie.client_receivedMessage;
        }
    }
}