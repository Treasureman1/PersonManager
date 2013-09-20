using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PersonManagerTest
{
    public partial class EditCompany : System.Web.UI.Page
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
                Response.Redirect("EditCompany.aspx?Mode=New");
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

                             LoadCompany();

                            txtID.Enabled = false;
                            txtName.Enabled = false;
                            txtNotes.Enabled = false;

                            fillCompanyEmail();
                         fillCompanyPhoneGrid();
                        fillCompanyAddressGrid();

                          fillCompanyPhoneGrid();
                            // fillAddressGrid();
                            ////////////////////////////  fillEmail();

                            break;

                        case "New":

                            btnDone.Visible = false;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;

                            // LoadPerson();

                            txtID.Enabled = false;
                            txtName.Enabled = true;
                            txtNotes.Enabled = true;

                            btnAddPhoneNum.Visible = false;


                            break;

                        case "Edit":

                            btnDone.Visible = true;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;

                             LoadCompany();

                            txtID.Enabled = false;
                            txtName.Enabled = true;
                            txtNotes.Enabled = true;

                            ///////////////////////////////  btnAddPhoneNum.Visible = true;
                            btnDone.Visible = false;
                           fillCompanyEmail();
                           fillCompanyPhoneGrid();
                           fillCompanyAddressGrid();


                            break;

                        case "Delete":


                            btnDone.Visible = false;
                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            //NameDisplayLabel.Visible = false;


                           LoadCompany();

                            txtID.Enabled = false;
                            txtName.Enabled = false;
                            txtNotes.Enabled = false;

                            btnAddPhoneNum.Visible = false;
                            fillCompanyEmail();
                           fillCompanyPhoneGrid();
                           fillCompanyAddressGrid();


                            break;
                    }



                }

                else
                {
                    Response.Redirect("FetchPerson.aspx");
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String Name = txtName.Text;
            String Notes = txtNotes.Text;
            DataManager.DataAccess da = new DataManager.DataAccess();
            switch (Request.QueryString["Mode"])
            {

                case "Edit":
                    txtID.Enabled = true;
                    int CompanyID = Convert.ToInt32(txtID.Text);
                    Name = txtName.Text;
                    Notes = txtNotes.Text;

                    da.UpdateCompany(CompanyID, Name, Notes);
                    Response.Redirect("EditCompany.aspx?CompanyID=" +
            this.txtID.Text + "&Mode=Edit");

                    //Response.Redirect("EditPerson.aspx?Mode=Edit");
                    btnDone.Enabled = true;
                    btnDone.Visible = true;
                    break;


                case "New":

                    Name = txtName.Text;
                    Notes = txtNotes.Text;
                    DataManager.DataAccess da2 = new DataManager.DataAccess();
                    object companyID = da2.InsertCompany2(Name, Notes);

                    txtID.Text = companyID.ToString();
                    CompanyID = Convert.ToInt32(txtID.Text);
                    txtName.Text = Name;
                    txtNotes.Text = Notes;

                    Response.Redirect("EditCompany.aspx?CompanyID=" +
          this.txtID.Text + "&Mode=Edit");
                    break;

            }
        }


        protected void gvCompanyPhoneNumber_RowDataBound(Object sender, GridViewRowEventArgs e)
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


        protected void gvCompanyAddresses_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a conversion.   Cast this as a data row view, we have to cast this. 
                DataRow dr = (DataRow)drv.Row;
                Label lblAddressID = (Label)e.Row.FindControl("lblAddressID");
                Label lblStreet1 = (Label)e.Row.FindControl("lblStreet1");
                Label lblStreet2 = (Label)e.Row.FindControl("lblStreet2");
                Label lblCity = (Label)e.Row.FindControl("lblCity");
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

        protected void gvCompanyEmail_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a conversoin.   Cast this as a data row view, we have to cast this. 
                DataRow dr = (DataRow)drv.Row;
                Label lblEmailAddressID = (Label)e.Row.FindControl("lblEmailAddressID");
                Label lblAddress = (Label)e.Row.FindControl("lblAddress");
                Label lblCompanyID= (Label)e.Row.FindControl("lblCompanyID");   //I changed the find control from lblCompanyID to lblPersonID  
               
                LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");

                lblEmailAddressID.Text = dr["EmailAddressID"].ToString();
                lblAddress.Text = dr["Address"].ToString();
                lblCompanyID.Text = dr["PersonID"].ToString();
               
                btnView.CommandArgument = dr["EmailAddressID"].ToString();
                btnEdit.CommandArgument = dr["EmailAddressID"].ToString();
                btnDelete.CommandArgument = dr["EmailAddressID"].ToString();
            }
        }


        protected void gvCompanyContacts_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a conversoin.   Cast this as a data row view, we have to cast this. 
                DataRow dr = (DataRow)drv.Row;
                Label lblCompanyID = (Label)e.Row.FindControl("lblCompanyID");
                Label lblContactID = (Label)e.Row.FindControl("lblContactID");
                Label lblDescription = (Label)e.Row.FindControl("lblDescription");
                Label lblNotes = (Label)e.Row.FindControl("lblNotes");
                LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");
                //compid contactid desc notes
                lblCompanyID.Text = dr["CompanyID"].ToString();
                lblContactID.Text = dr["ContactID"].ToString();
                lblDescription.Text = dr["Description"].ToString();
                lblNotes.Text = dr["Notes"].ToString();
               
                btnView.CommandArgument = dr["ContactID"].ToString();
                btnEdit.CommandArgument = dr["ContactID"].ToString();
                btnDelete.CommandArgument = dr["ContactID"].ToString();
            }
        }

        protected void gvCompanyPhoneNumber_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Edit":

                    //  int Phone i.....
                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    Response.Redirect("EditCompanyPhones.aspx?Mode=Edit&CompanyID=" + this.txtID.Text + "&PhoneID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditCompanyPhones.aspx?Mode=View&CompanyID=" + this.txtID.Text + "&PhoneID=" + e.CommandArgument);
                    break;

                case "Delete":

                    //  Call the method to sort the list.
                    Response.Redirect("EditCompanyPhones.aspx?Mode=Delete&CompanyID=" + this.txtID.Text + "&PhoneID=" + e.CommandArgument);
                    break;

                default:

                    break;
            }
        }

        protected void gvCompanyAddresses_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Edit":

                    //  int Phone i.....
                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    Response.Redirect("EditCompanyAddresses.aspx?Mode=Edit&CompanyID=" + this.txtID.Text + "&AddressID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditCompanyAddresses.aspx?Mode=View&CompanyID=" + this.txtID.Text + "&AddressID=" + e.CommandArgument);
                    break;

                case "Delete":

                    //  Call the method to sort the list.
                    Response.Redirect("EditCompanyAddresses.aspx?Mode=Delete&CompanyID=" + this.txtID.Text + "&AddressID=" + e.CommandArgument);
                    break;

                default:

                    break;
            }
        }

        protected void gvCompanyEmail_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Edit":

                    //  int Phone i.....
                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    Response.Redirect("EditEmail.aspx?Mode=Edit&CompanyID=" + this.txtID.Text + "&EmailAddressID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditEmail.aspx?Mode=View&CompanyID=" + this.txtID.Text + "&EmailAddressID=" + e.CommandArgument);
                    break;

                case "Delete":

                    //  Call the method to sort the list.
                    Response.Redirect("EditEmail.aspx?Mode=Delete&CompanyID=" + this.txtID.Text + "&EmailAddressID=" + e.CommandArgument);
                    break;

                default:

                    break;
            }
        }

        protected void gvCompanyContacts_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Edit":

                    //  int Phone i.....
                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    Response.Redirect("EditCompanyContacts.aspx?Mode=Edit&PersonID=" + this.txtID.Text + "&PhoneID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditCompanyContacts.aspx?Mode=View&PersonID=" + this.txtID.Text + "&PhoneID=" + e.CommandArgument);
                    break;

                case "Delete":

                    //  Call the method to sort the list.
                    Response.Redirect("EditCompanyContacts.aspx?Mode=Delete&PersonID=" + this.txtID.Text + "&PhoneID=" + e.CommandArgument);
                    break;

                default:

                    break;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchCompany.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int CompanyID = Convert.ToInt32(txtID.Text);
            String Name = txtName.Text;
            String Notes = txtNotes.Text;
            DataManager.DataAccess da = new DataManager.DataAccess();
            da.DeleteCompany(CompanyID);
            Response.Redirect("FetchCompany.aspx");
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchCompany.aspx?CompanyID=" + this.txtID.Text);
        }

        protected void btnAddPhoneNum_Click(object sender, EventArgs e)
        {
            object CompanyID = txtID.Text; 
            Response.Redirect("EditCompanyPhones.aspx?CompanyID=" +
                this.txtID.Text + "&Mode=New");
          
        }

        protected void btnAddAddress_Click(object sender, EventArgs e)
        {
            object CompanyID = txtID.Text;
            Response.Redirect("EditCompanyAddresses.aspx?CompanyID=" +
                this.txtID.Text + "&Mode=New");
        }

        protected void btnAddEmail_Click(object sender, EventArgs e)
        {
            //Person ID is not changed to company ID here because the EditEmail page requires that PersonID is passed to it. 
            object CompanyID = txtID.Text; 
            Response.Redirect("EditEmail.aspx?CompanyID=" +
                this.txtID.Text + "&Mode=New");
        }

        protected void gvCompanyPhoneNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void fillCompanyPhoneGrid()
                        
        {
            DataManager.DataAccess da = new DataManager.DataAccess();
            DataSet ds = new DataSet();

            int CompanyID = Convert.ToInt32(txtID.Text);
            ds = da.FetchCompanyPhonesGrid(CompanyID);
            gvCompanyPhoneNumber.DataSource = ds;
            gvCompanyPhoneNumber.DataBind();

        }

        protected void fillCompanyAddressGrid() 
        {
            DataManager.DataAccess da2 = new DataManager.DataAccess();
            DataSet ds2 = new DataSet();

            int CompanyID = Convert.ToInt32(txtID.Text);
            ds2 = da2.FetchCompanyAddressesGrid(CompanyID);
            gvCompanyAddresses.DataSource = ds2;
            gvCompanyAddresses.DataBind();

        }

        protected void fillCompanyEmail()
            
        {

         

          

        }

        protected void fillCompanyContacts()
        {

            //DataManager.DataAccess da2 = new DataManager.DataAccess();
            //DataSet ds2 = new DataSet();

            //int ContactID = Convert.ToInt32(txtID.Text);
            //ds2 = da2.FetchEmailAddress(EmailAddressID);
            //gvCompanyEmail.DataSource = ds2;
            //gvCompanyEmail.DataBind();



        }

        private void LoadCompany()
        {
            this.txtID.Text = Request.QueryString["CompanyID"];
            int CompanyID = Convert.ToInt32(txtID.Text);

            DataManager.DataAccess da = new DataManager.DataAccess();

            DataSet ds = da.FetchCompany(CompanyID);

            object ci = ds.Tables[0].Rows[0]["CompanyID"];
            object cn = ds.Tables[0].Rows[0]["Name"];
            object n = ds.Tables[0].Rows[0]["Notes"]; 
         
            txtID.Text = ci.ToString();
            txtName.Text = cn.ToString();
            txtNotes.Text = n.ToString();
         

            String Name = txtName.Text;
          
         
        }
    }
}