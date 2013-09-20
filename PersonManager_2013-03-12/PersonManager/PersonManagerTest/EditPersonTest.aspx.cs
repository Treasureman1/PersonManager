using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
//using

////using System.Web.UI.Page;
// System.Web.HttpResponse;
public partial class EditPersonTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.IsPostBack)
        {
            if (Request.QueryString != null)
            {


                switch (Request.QueryString["Mode"])
                {


                    case "View":
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnDelete.Visible = false;

                        LoadPerson();

                        txtPersonID.Enabled = false;
                        txtFirstName.Enabled = false;
                        txtLastName.Enabled = false;

                        break;


                    case "New":
                        btnDone.Visible = false;
                        btnSave.Visible = true;
                        btnDelete.Visible = false;

                        txtPersonID.Enabled = false;
                        txtFirstName.Enabled = true;
                        txtLastName.Enabled = true;

                        txtPersonID.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        break;


                    case "Edit":
                        btnDone.Visible = false;
                        btnSave.Visible = true;
                        btnDelete.Visible = false;

                        LoadPerson();

                        txtPersonID.Enabled = false;
                        txtFirstName.Enabled = true;
                        txtLastName.Enabled = true;
                        break;


                    case "Delete":
                        btnDone.Visible = false;
                        btnSave.Visible = false;
                        btnDelete.Visible = true;

                        LoadPerson();

                        txtPersonID.Enabled = false;
                        txtFirstName.Enabled = false;
                        txtLastName.Enabled = false;


                        break;

                    default: break;


                }

                //string queryString;
                //queryString = this.Page.Request.QueryString.Get("Mode");
                //string mode_value;
                //mode_value = this.Page.Request.QueryString.Get("mode");

            }

            else
            {
                Response.Redirect("FetchPersonName.aspx");
            }

        }
 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //switch Request.QueryString.
    }

   

    private void LoadPerson()
    {
       
        int personID = Convert.ToInt32(Request.QueryString.Get("Mode"));
       

       

        //Dim da As New DataManager.DataAccess()
        //Dim ds As DataSet

        //ds = da.FetchPerson(personID)

        //txtPersonID.Text = ds.Tables(0).Rows(0).Item("PersonID")
        //txtFirstName.Text = ds.Tables(0).Rows(0).Item("FirstName")
        //txtLastName.Text = ds.Tables(0).Rows(0).Item("LastName")

    }
}

