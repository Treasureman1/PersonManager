using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonManagerTest
{
    public partial class ItemUpdated : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.FirstNameTextBox.Text = Request.QueryString["FirstName"];
            this.LastNameTextBox.Text = Request.QueryString["LastName"];
        }
    }
}