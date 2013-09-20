using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PersonManagerTest
{
    public partial class EditEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string ModeStatus = Request.QueryString["Mode"];
                switch (ModeStatus)
                {
                    case "New":
                        lblModeStatus.Text = "Add New Phone Number";
                        break;

                    case "View":
                        lblModeStatus.Text = "View Phone Number";
                        break;

                    case "Edit":
                        lblModeStatus.Text = "Edit Phone Number";
                        break;

                    case "Delete":
                        lblModeStatus.Text = "Delete Phone Number";
                        break;
                }

                DataManager.DataAccess da = new DataManager.DataAccess();
                DataSet ds = new DataSet();
                ds = da.FetchPhoneTypes();
              
                  
                if (Request.QueryString != null)
                {

                    if (Request.QueryString["PersonID"] != null)
                    {
                        this.txtID.Text = Request.QueryString["PersonID"].ToString();
                    }
                    string Mode = Request.QueryString["Mode"];

                    
                    switch (Mode)
                    {

                        case "View":
                            btnDone.Visible = true;
                            btnSave.Visible = false;
                            btnDelete.Visible = false;
                            btnCancel.Visible = false;


                        LoadEmailAddress();

                            txtID.Enabled = false;
                            txtEID.Enabled = false;
                            txtEmail.Enabled = false;

                            break;

                        case "New":

                            btnDone.Visible = false;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;

                          //  LoadEmailAddress();
                            txtEID.Enabled = false;
                            txtID.Enabled = false;
                            txtEmail.Enabled = true;
                      
                            break;

                        case "Edit":

                            txtID.Enabled = false;
                            btnDone.Visible = true;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;
                            btnCancel.Visible = false;

                            txtEID.Enabled = false;
                           
                          LoadEmailAddress();
                            btnDone.Visible = false;

                            break;

                        case "Delete":

                            btnDone.Visible = false;
                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                           

                        LoadEmailAddress();

                            txtEID.Enabled = false;
                            txtEmail.Enabled = false;
                            txtID.Enabled = false;

                            break;




                        //Request.QueryString["PersonID"] = "New";

                    }
                }
                else
                {
                    Response.Redirect("FetchPerson.aspx");
                }
            }
        }

        private void LoadEmailAddress()
        {

            this.txtID.Text = Request.QueryString["PersonID"];
            int PersonID = Convert.ToInt32(txtID.Text);

            object EmailID = Convert.ToInt32(Request.QueryString["EmailAddressID"]);

            DataManager.DataAccess da = new DataManager.DataAccess();
           
            DataSet ds = da.FetchEmailAddress(PersonID);
            
            object ei = ds.Tables[0].Rows[0]["EmailAddressID"];   // PhoneID, AreaCode, PhoneNumber, Extension, PhoneType
            object ea = ds.Tables[0].Rows[0]["Address"];
          //  object pid = ds.Tables[0].Rows[0]["PersonID"];

            txtEID.Text = ei.ToString();
            txtEmail.Text = ea.ToString();

            }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            String Address = txtEmail.Text;
         
            int EmailAddressID; 

            DataManager.DataAccess da = new DataManager.DataAccess();
            switch (Request.QueryString["Mode"])
            {
                case "Edit":

                    this.txtEID.Text = Request.QueryString["EmailAddressID"];
                    txtEID.Enabled = true;
                    EmailAddressID = Convert.ToInt32(txtEID.Text);
                    Address = txtEmail.Text;
                    
                    int PersonID = Convert.ToInt32(txtID.Text);
                    

                    da.UpdateEmailAddress(EmailAddressID, Address, PersonID); 
                  
                    Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + this.txtID.Text);

                    btnDone.Enabled = true;

                    btnDone.Visible = false;




                    // Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + this.txtID.Text);

                    break;


                case "New":
                    Address = txtEmail.Text;
                   
                    PersonID = Convert.ToInt32(txtID.Text);
                    object oEmailAddressID = da.InsertEmailAddress(Address, PersonID);

                   txtEID.Text = oEmailAddressID.ToString();

                    EmailAddressID = Convert.ToInt32(oEmailAddressID.ToString());



                    Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + this.txtID.Text);
                    //           Response.Redirect("EditPersonPhoneNumber.aspx?PersonID=" +
                    //this.txtID.Text + "&Mode=Edit&PhoneID=" + this.txtPhID.Text);

                    break;

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditPerson.aspx?PersonID=" + this.txtID.Text + "&Mode=Edit");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(txtID.Text);
            int EmailAddressID = Convert.ToInt32(txtEID.Text);
            DataManager.DataAccess da = new DataManager.DataAccess();
            da.DeleteEmailAddress(EmailAddressID);
            //Response.Redirect("FetchPerson.aspx");
            Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + this.txtID.Text);
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditPerson.aspx?PersonID=" + this.txtID.Text + "&Mode=Edit");
        }


    }
}



/*
 int PersonID = Convert.ToInt32(txtID.Text);
 

*/