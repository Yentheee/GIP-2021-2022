using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GIP_Smart.Pages
{
    public partial class Settings : System.Web.UI.Page
    {
        private string topic;
        private string broker;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                
        }

        public string GetTopic
        {
            get { return topic; }
            set { topic = ddl_topic.Text; }
        }
        public string GetBroker
        {
            get { return broker; }
            set { broker = ddl_broker.Text; }
        }
    }
}