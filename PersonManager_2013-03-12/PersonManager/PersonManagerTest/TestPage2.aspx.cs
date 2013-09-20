using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PersonManagerTest
{
    public partial class TestPage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtBox1.Text = Request.QueryString["Name"];
            this.txtBox2.Text = Request.QueryString["LastName"];

        }
    }
}