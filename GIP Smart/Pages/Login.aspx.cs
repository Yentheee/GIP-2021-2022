using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace GIP_Smart.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pages.Classes.Netwerkcommunicatie netwerkcommunicatie = new Pages.Classes.Netwerkcommunicatie();
            netwerkcommunicatie.Network();
            netwerkcommunicatie.mqttClient.MqttMsgPublishReceived += netwerkcommunicatie.client_receivedMessage;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            int resultaat;

            LoginClass signUp = new LoginClass(username, password);

            resultaat = signUp.Instruction();

            Debug.WriteLine(resultaat);
            if (resultaat > 0)
            {
                HttpCookie loginCookie = new HttpCookie("Login");
                //Set the Cookie value.
                loginCookie.Values["Name"] = tbUsername.Text;
                loginCookie.Values["Password"] = tbPassword.Text;
                loginCookie.Path = Request.ApplicationPath;
                //Set the Expiry date.
                loginCookie.Expires = DateTime.Now.AddDays(1);
                //Add the Cookie to Browser.
                Response.Cookies.Add(loginCookie);
                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}