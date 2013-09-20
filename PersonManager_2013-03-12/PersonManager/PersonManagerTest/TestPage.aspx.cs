using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonManagerTest
{

    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestPage2.aspx?Name=" +
            this.txtName.Text + "&LastName=" +
            this.txtLastName.Text);

            
        }
    }
}