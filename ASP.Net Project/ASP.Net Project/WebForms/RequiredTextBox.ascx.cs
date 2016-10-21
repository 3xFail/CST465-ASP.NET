using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.Net_Project.WebForms
{
    public partial class RequiredTextBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string LabelText
        {
            get { return this.uxLabel.Text; }
            set { this.uxLabel.Text = value; this.uxValidator.ErrorMessage = value + "required"; }
        }

        public string Value
        {
            get { return this.uxTextBox.Text; }
            set { this.uxTextBox.Text = value; }
        }

        public string ValidationGroup
        {
            get { return this.uxValidator.ValidationGroup; }
            set { this.uxTextBox.ValidationGroup = value; }
        }
    }
}