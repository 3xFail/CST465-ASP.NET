using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.Net_Project.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        public void uxSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder string_to_build = new StringBuilder();
            string_to_build.Append(uxName.Text + "<br />");
            string_to_build.Append(uxPriority.Text + "<br />");
            string_to_build.Append(uxSubject.Text + "<br />");
            string_to_build.Append(uxDescription.Text + "<br />");
            uxFormOutput.Text = string_to_build.ToString();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            uxEventOutput.Text = "OnInit<br />";
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            uxEventOutput.Text = "Onload<br />";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            uxEventOutput.Text = "OnPreRender<br />";
        }
    }
}