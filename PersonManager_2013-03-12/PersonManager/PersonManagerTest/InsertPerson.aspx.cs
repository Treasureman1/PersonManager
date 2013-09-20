using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace PersonManagerTest
{
    public partial class InsertPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSave_Click1(object sender, EventArgs e)
        {
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            DataManager.DataAccess da = new DataManager.DataAccess();
            // Here we are declaring a variable for PersonID and calling the new InsertPerson2 method (remember that the new
            // method returns a value where the old method did not)
            object personID = da.InsertPerson2(FirstName, LastName);

            txtID.Text = personID.ToString();


            SuccessLabel.Visible = true;


            NameDisplayLabel.Text = FirstName + ' ' + LastName;
            txtFirstName.Text = "";
            txtLastName.Text = "";



            txtFirstName.Text = FirstName;
            txtLastName.Text = LastName;
            btnSave.Visible = false;

            AddButton.Visible = true;

            // This is how a queryString when there are 2 values
           // Response.Redirect("TestPage2.aspx?Name=" +
           //this.txtName.Text + "&LastName=" +
           //this.txtLastName.Text);


            
            Response.Redirect("EditPerson.aspx?PersonID=" +
           this.txtID.Text + "&Mode=Edit");

        }


        protected void gvPersonName_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a coonversoin.   Cast this as a data row view, we have to cast this. 
                DataRow dr = (DataRow)drv.Row;
                Label lblPersonID = (Label)e.Row.FindControl("lblPersonID");
                Label lblFirstName = (Label)e.Row.FindControl("lblFirstName");
                Label lblLastName = (Label)e.Row.FindControl("lblLastName");
                LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");

                lblPersonID.Text = dr["PersonID"].ToString();
                lblFirstName.Text = dr["FirstName"].ToString();
                lblLastName.Text = dr["LastName"].ToString();

                btnView.CommandArgument = dr["PersonID"].ToString();
                btnEdit.CommandArgument = dr["PersonID"].ToString();
                btnDelete.CommandArgument = dr["PersonID"].ToString();
            }
        }

        protected void FetchPersonsButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchPersons.aspx");
        }

        protected void NameButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchPersonName.aspx");
        }

        protected void PersonIDButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchPersonID.aspx");
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
  

        }

       

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //Cancel will leave direct you to the insert person page with the text values of the text boxes set to empty strings
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPerson.aspx");
        }

        protected void MenuButton_Click(object sender, EventArgs e)
        {

        }

        protected void SearchNameButton_Click(object sender, EventArgs e)
        {

        }
    }
}