using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PersonManagerTest
{
    public partial class EditPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

            if (txtID.Text != "")
            {

                //DataManager.DataAccess da = new DataManager.DataAccess();
                //DataSet ds = new DataSet();

                //int PersonID = Convert.ToInt32(txtID.Text);
                //ds = da.FetchPersonPhonesGrid(PersonID);
                //gvPersonPhoneNumber.DataSource = ds;
                //gvPersonPhoneNumber.DataBind();

            }

            if (Request.QueryString["Mode"] == null)
            {
                //  Request.QueryString["Mode"] = "New";
                Response.Redirect("EditPerson.aspx?Mode=New");
            }

            if (!IsPostBack)
            {

                if (Request.QueryString != null)
                {

                    string mode = Request.QueryString["Mode"];
                    // if mode = null then mode = new
                    //one other way would be to get rid of the test and in the switch statement  view edit delete and instead of case new
                    // change that so that you are doing it to false      whenmode is new, view,   a default case   would be new
                    switch (mode)
                    {

                        case "View":
                            btnDone.Visible = true;
                            btnSave.Visible = false;
                            btnDelete.Visible = false;

                            LoadPerson();

                            txtID.Enabled = false;
                             txtFirstName.Enabled = false;
                            txtLastName.Enabled = false;
                            btnCancel.Visible = false;
                            fillPhoneGrid();
                          fillAddressGrid();
                            fillEmail();

                            break;

                        case "New":

                            btnDone.Visible = false;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;

                            // LoadPerson();

                            txtID.Enabled = false;
                            txtFirstName.Enabled = true;
                            txtLastName.Enabled = true;
                            btnAddPhoneNum.Visible = false;
                           

                            break;

                        case "Edit":

                            btnDone.Visible = true;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;

                            LoadPerson();

                            txtID.Enabled = false;
                            txtFirstName.Enabled = true;
                            txtLastName.Enabled = true;

                            btnAddPhoneNum.Visible = true;
                            btnDone.Visible = false;
                            fillPhoneGrid();
                           fillAddressGrid();
                            fillEmail();


                            break;

                        case "Delete":


                            btnDone.Visible = false;
                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            NameDisplayLabel.Visible = false;


                            LoadPerson();

                            txtID.Enabled = false;
                            txtFirstName.Enabled = false;
                            txtLastName.Enabled = false;

                            btnAddPhoneNum.Visible = false;


                            break;
                    }

                 

                }
                    
                else
                {
                    Response.Redirect("FetchPerson.aspx");
                }

                // fillPhoneGrid();

            }
           // fillPhoneGrid();
        }


        
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchPerson.aspx");
        }

        protected void MenuButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Menu.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchPersonName.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(txtID.Text);
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            DataManager.DataAccess da = new DataManager.DataAccess();
            da.DeletePerson(PersonID);
            Response.Redirect("FetchPerson.aspx");
        }

        private void LoadPerson()
        {
            this.txtID.Text = Request.QueryString["PersonID"];
            int PersonID = Convert.ToInt32(txtID.Text);

            DataManager.DataAccess da = new DataManager.DataAccess();

            DataSet ds = da.FetchPerson(PersonID);

            object pi = ds.Tables[0].Rows[0]["PersonID"];
            object fn = ds.Tables[0].Rows[0]["FirstName"];
            object ln = ds.Tables[0].Rows[0]["LastName"];
            txtID.Text = pi.ToString();
            txtFirstName.Text = fn.ToString();
            txtLastName.Text = ln.ToString();

            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            // add an else, set the NameDisplayLabel to empty string, and i
            NameDisplayLabel.Text = FirstName + " " + LastName + " has been added to the database.";
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            DataManager.DataAccess da = new DataManager.DataAccess();
            switch (Request.QueryString["Mode"])
            {

                case "Edit":
                    txtID.Enabled = true;
                    int PersonID = Convert.ToInt32(txtID.Text);
                    FirstName = txtFirstName.Text;
                    LastName = txtLastName.Text;
                   
                    da.UpdatePerson(PersonID, FirstName, LastName);
                    Response.Redirect("EditPerson.aspx?PersonID=" +
            this.txtID.Text + "&Mode=Edit");
                    
                    //Response.Redirect("EditPerson.aspx?Mode=Edit");
                    btnDone.Enabled = true;
                    btnDone.Visible = true;
                    break;


                case "New":

                    FirstName = txtFirstName.Text;
                    LastName = txtLastName.Text;
                    DataManager.DataAccess da2 = new DataManager.DataAccess();
                    object personID = da2.InsertPerson2(FirstName, LastName);
                   
                    txtID.Text = personID.ToString();
                    PersonID = Convert.ToInt32(txtID.Text);
                    txtFirstName.Text = FirstName;
                    txtLastName.Text = LastName;

                    Response.Redirect("EditPerson.aspx?PersonID=" +
          this.txtID.Text + "&Mode=Edit");
                    break;

            }
        }

        protected void gvPersonPhoneNumber_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a conversoin.   Cast this as a data row view, we have to cast this. 
                DataRow dr = (DataRow)drv.Row;
                Label lblPhoneID = (Label)e.Row.FindControl("lblPhoneID");
                Label lblAreaCode = (Label)e.Row.FindControl("lblAreaCode");
                Label lblPhoneNumber = (Label)e.Row.FindControl("lblPhoneNumber");
                Label lblExtension = (Label)e.Row.FindControl("lblExtension");
                Label lblPhoneTypeID = (Label)e.Row.FindControl("lblPhoneTypeID");
                LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");

                lblPhoneID.Text = dr["PhoneID"].ToString();
                lblAreaCode.Text = dr["AreaCode"].ToString();
                lblPhoneNumber.Text = dr["PhoneNumber"].ToString();
                lblExtension.Text = dr["Extension"].ToString();
                lblPhoneTypeID.Text = dr["PhoneTypeID"].ToString();

                btnView.CommandArgument = dr["PhoneID"].ToString();
                btnEdit.CommandArgument = dr["PhoneID"].ToString();
                btnDelete.CommandArgument = dr["PhoneID"].ToString();
            }
        }

        protected void gvPersonAddresses_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a conversoin.   Cast this as a data row view, we have to cast this. 
                DataRow dr = (DataRow)drv.Row;
                Label lblAddressID = (Label)e.Row.FindControl("lblAddressID");
                Label lblStreet1 = (Label)e.Row.FindControl("lblStreet1");
                Label lblStreet2 = (Label)e.Row.FindControl("lblStreet2");
                Label lblCity= (Label)e.Row.FindControl("lblCity");
                Label lblState = (Label)e.Row.FindControl("lblState");
                Label lblZip = (Label)e.Row.FindControl("lblZip");
                LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");


                lblAddressID.Text = dr["AddressID"].ToString();
                lblStreet1.Text = dr["Street1"].ToString();
                lblStreet2.Text = dr["Street2"].ToString();
                lblCity.Text = dr["City"].ToString();
                lblState.Text = dr["State"].ToString();
                lblZip.Text = dr["Zip"].ToString();

                btnView.CommandArgument = dr["AddressID"].ToString();
                btnEdit.CommandArgument = dr["AddressID"].ToString();
                btnDelete.CommandArgument = dr["AddressID"].ToString();
            }
        }


        protected void gvEmail_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a conversoin.   Cast this as a data row view, we have to cast this. 
                DataRow dr = (DataRow)drv.Row;
                Label lblEmailAddressID = (Label)e.Row.FindControl("lblEmailAddressID");
                Label lblAddress = (Label)e.Row.FindControl("lblAddress");
                Label lblPersonID = (Label)e.Row.FindControl("lblPersonID");
               
                LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");

                lblEmailAddressID.Text = dr["EmailAddressID"].ToString();
                lblAddress.Text = dr["Address"].ToString();
                lblPersonID.Text = dr["PersonID"].ToString();

                btnView.CommandArgument = dr["EmailAddressID"].ToString();
                btnEdit.CommandArgument = dr["EmailAddressID"].ToString();
                btnDelete.CommandArgument = dr["EmailAddressID"].ToString();
            }
        }


        protected void gvPersonPhoneNumber_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            gvPersonPhoneNumber.PageIndex = e.NewPageIndex;
            DataManager.DataAccess da = new DataManager.DataAccess();
            DataSet dsPersons = new DataSet();

            dsPersons = da.FetchPerson(txtFirstName.Text.Trim(), txtLastName.Text.Trim());
            gvPersonPhoneNumber.DataSource = dsPersons;
            gvPersonPhoneNumber.DataBind();
        }

        protected void gvPersonPhoneNumber_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Edit":

                    //  int Phone i.....
                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    Response.Redirect("EditPersonPhoneNumber.aspx?Mode=Edit&PersonID=" + this.txtID.Text + "&PhoneID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditPersonPhoneNumber.aspx?Mode=View&PersonID=" + this.txtID.Text + "&PhoneID=" + e.CommandArgument);
                    break;

                case "Delete":

                    //  Call the method to sort the list.
                    Response.Redirect("EditPersonPhoneNumber.aspx?Mode=Delete&PersonID=" + this.txtID.Text + "&PhoneID=" + e.CommandArgument);
                    break;

                default:

                    break;
            }
        }

        protected void gvPersonAddresses_RowCommand(Object sender, GridViewCommandEventArgs e) 
        {

            switch (e.CommandName)
            {
                case "Edit":

                    // int Phone i.....
                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    //Response.Redirect("EditPersonAddress.aspx?Mode=Edit&PersonID=" + this.txtID.Text + "&AddressID=" + e.CommandArgument);
                    Response.Redirect("EditPersonAddress.aspx?Mode=Edit&PersonID=" + this.txtID.Text + "&AddressID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditPersonAddress.aspx?Mode=View&PersonID=" + this.txtID.Text + "&AddressID=" + e.CommandArgument);
                    break;

                case "Delete":

                    // Call the method to sort the list.
                    Response.Redirect("EditPersonAddress.aspx?Mode=Delete&PersonID=" + this.txtID.Text + "&AddressID=" + e.CommandArgument);
                    break;

                default:

                    break;
            }
        }


        protected void gvEmail_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Edit":

                    //  int Phone i.....
                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    Response.Redirect("EditEmail.aspx?Mode=Edit&PersonID=" + this.txtID.Text + "&EmailAddressID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditEmail.aspx?Mode=View&PersonID=" + this.txtID.Text + "&EmailAddressID=" + e.CommandArgument);
                    break;

                case "Delete":

                    //  Call the method to sort the list.
                    Response.Redirect("EditEmail.aspx?Mode=Delete&PersonID=" + this.txtID.Text + "&EmailAddressID=" + e.CommandArgument);
                    break;

                default:

                    break;
            }
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchPerson.aspx");
        }

        protected void btnAddPhoneNum_Click(object sender, EventArgs e)
        {
            object PersonID = txtID.Text;
            Response.Redirect("EditPersonPhoneNumber.aspx?PersonID=" +
                this.txtID.Text + "&Mode=New");
        }
        // This code is the btnDisplay click Event Page load fillPhoneGrid() replaces this click event
        //protected void btnDisplay_Click(object sender, EventArgs e)
        //{
        //    DataManager.DataAccess da = new DataManager.DataAccess();
        //    DataSet ds = new DataSet();

        //    int PersonID = Convert.ToInt32(txtID.Text);
        //    ds = da.FetchPersonPhonesGrid(PersonID);
        //    gvPersonPhoneNumber.DataSource = ds;
        //    gvPersonPhoneNumber.DataBind();
        //}


        protected void fillPhoneGrid()
        {
            DataManager.DataAccess da = new DataManager.DataAccess();
            DataSet ds = new DataSet();

            int PersonID = Convert.ToInt32(txtID.Text);
            ds = da.FetchPersonPhonesGrid(PersonID);
            gvPersonPhoneNumber.DataSource = ds;
            gvPersonPhoneNumber.DataBind();

        }

        //protected void fillAddressGrid()
        //{
        //    DataManager.DataAccess da = new DataManager.DataAccess();
        //    DataSet ds = new DataSet();

        //    int PersonID = Convert.ToInt32(txtID.Text);
        //    ds = da.FetchPersonAddressesGrid(PersonID);
        //    gvPersonPhoneNumber.DataSource = ds;
        //    gvPersonPhoneNumber.DataBind();

        //    //if (gvPersonPhoneNumber.DataSource != null)
        //    //{

        //    //}
        //    //else
        //    //{
        //    //    NameDisplayLabel.Text = "No Results Found!";
        //    //}
        //}

        protected void fillEmail()
        {

            DataManager.DataAccess da2 = new DataManager.DataAccess();
            DataSet ds2 = new DataSet();

            int EmailAddressID = Convert.ToInt32(txtID.Text);
            ds2 = da2.FetchEmailAddress(EmailAddressID);
            gvEmail.DataSource = ds2;
            gvEmail.DataBind();

            //////DataManager.DataAccess da = new DataManager.DataAccess();
            //////DataSet ds = new DataSet();

            //////int PersonID = Convert.ToInt32(txtID.Text);
            //////ds = da.FetchPersonAddressesGrid(PersonID);
            //////gvPersonPhoneNumber.DataSource = ds;
            //////gvPersonPhoneNumber.DataBind();

        }

        protected void fillAddressGrid()
        {
            DataManager.DataAccess da2 = new DataManager.DataAccess();
            DataSet ds2 = new DataSet();

            int PersonID = Convert.ToInt32(txtID.Text);
            ds2 = da2.FetchPersonAddressesGrid(PersonID);
            gvPersonAddresses.DataSource = ds2;
            gvPersonAddresses.DataBind();

        }
        protected void btnAddAddress_Click(object sender, EventArgs e)
        {
            object PersonID = txtID.Text;
            Response.Redirect("EditPersonAddress.aspx?PersonID=" +
                this.txtID.Text + "&Mode=New");
        }

        protected void btnFillAddress_Click(object sender, EventArgs e)
        {
            DataManager.DataAccess da2 = new DataManager.DataAccess();
            DataSet ds2 = new DataSet();

            int PersonID = Convert.ToInt32(txtID.Text);
            ds2 = da2.FetchPersonAddressesGrid(PersonID);
            gvPersonAddresses.DataSource = ds2;
            gvPersonAddresses.DataBind();
        }

        protected void btnFillEmail_Click(object sender, EventArgs e)
        {
            DataManager.DataAccess da2 = new DataManager.DataAccess();
            DataSet ds2 = new DataSet();

            int EmailAddressID = Convert.ToInt32(txtID.Text);
            ds2 = da2.FetchEmailAddress(EmailAddressID);
            gvEmail.DataSource = ds2;
            gvEmail.DataBind();
        }

        protected void btnAddEmail_Click(object sender, EventArgs e)
        {
              object PersonID = txtID.Text;
            Response.Redirect("EditEmail.aspx?PersonID=" +
                this.txtID.Text + "&Mode=New");
        }

       
    }
}