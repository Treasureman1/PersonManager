﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void InsertPersonLink_Click(object sender, EventArgs e)
    {
        //Response.Redirect("EditPersonTest.aspx?Mode=New");
        Response.Redirect("InsertPerson.aspx");

    }
}