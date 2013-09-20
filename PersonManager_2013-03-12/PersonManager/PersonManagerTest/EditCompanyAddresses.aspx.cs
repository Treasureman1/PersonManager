using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PersonManagerTest
{
    public partial class EditCompanyAddresses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["Mode"] == null)
            {
                // Request.QueryString["Mode"] = "New"; Try to adjust this right
                Response.Redirect("EditCompanyAddress.aspx?Mode=New");


            }

            if (!IsPostBack)
            {
                string ModeStatus = Request.QueryString["Mode"];
                switch (ModeStatus)
                {
                    case "New":
                        lblModeStatus.Text = "Add New Address";
                        break;

                    case "View":
                        lblModeStatus.Text = "View Address";
                        break;

                    case "Edit":
                        lblModeStatus.Text = "Edit Address";
                        break;

                    case "Delete":
                        lblModeStatus.Text = "Delete Address";
                        break;
                }

                DataManager.DataAccess da = new DataManager.DataAccess();
                DataSet ds = new DataSet();
                ds = da.FetchAddressTypes();
                ddlAddressTypeID.DataSource = ds.Tables[0];

                //The DataTextField is the value of what will show in the ddl
                // the DataValueField is the Value of the
                ddlAddressTypeID.DataTextField = "Name";
                ddlAddressTypeID.DataValueField = "AddressTypeID";
                ddlAddressTypeID.DataBind();
                //object phoneTypeID = da5.FetchPhoneTypes();

                if (Request.QueryString != null)
                {

                    if (Request.QueryString["CompanyID"] != null)
                    {
                        this.txtID.Text = Request.QueryString["CompanyID"].ToString();
                    }
                    string Mode = Request.QueryString["Mode"];

                    switch (Mode)
                    {

                        case "View":
                            btnDone.Visible = true;
                            btnSave.Visible = false;
                            btnDelete.Visible = false;
                            btnCancel.Visible = false;


                            LoadCompanyAddress();

                            txtID.Enabled = false;
                            txtAID.Enabled = false;
                            ddlAddressTypeID.Enabled = false;
                            txtCompanyName.Enabled = false;
                            txtStreet1.Enabled = false;
                            txtStreet2.Enabled = false;
                            txtCity.Enabled = false;
                            txtState.Enabled = false;
                            txtZip.Enabled = false;
                            txtDescription.Enabled = false;
                            txtNotes.Enabled = false;


                            break;

                        case "New":

                            btnDone.Visible = false;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;

                           ////  LoadCompany(); 
                            txtID.Enabled = false;
                            txtAID.Enabled = false;
                            ddlAddressTypeID.Enabled = true;
                            txtCompanyName.Enabled = true;
                            txtStreet1.Enabled = true;
                            txtStreet2.Enabled = true;
                            txtCity.Enabled = true;
                            txtState.Enabled = true;
                            txtZip.Enabled = true;
                            txtDescription.Enabled = true;
                            txtNotes.Enabled = true;
                            break;

                        case "Edit":

                            txtID.Enabled = false;
                            btnDone.Visible = true;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;
                            btnCancel.Visible = true;

                            txtID.Enabled = false;
                            txtAID.Enabled = false;
                            ddlAddressTypeID.Enabled = true;
                            txtCompanyName.Enabled = false;
                            txtStreet1.Enabled = true;
                            txtStreet2.Enabled = true;
                            txtCity.Enabled = true;
                            txtState.Enabled = true;
                            txtZip.Enabled = true;
                            txtDescription.Enabled = true;
                            txtNotes.Enabled = true;
                            object AddressID = Convert.ToInt32(Request.QueryString["AddressID"]);

                            txtAID.Text = AddressID.ToString();
                           LoadCompanyAddress();
                            btnDone.Visible = false;

                            break;

                        case "Delete":

                            btnDone.Visible = false;
                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            //NameDisplayLabel.Visible = false;

                           LoadCompanyAddress();

                            txtID.Enabled = false;
                            txtAID.Enabled = false;
                            ddlAddressTypeID.Enabled = false;
                            txtCompanyName.Enabled = false;
                            txtStreet1.Enabled = false;
                            txtStreet2.Enabled = false;
                            txtCity.Enabled = false;
                            txtState.Enabled = false;
                            txtZip.Enabled = false;
                            txtDescription.Enabled = false;
                            txtNotes.Enabled = false;
                            txtNotes.ReadOnly = true;
                            txtDescription.ReadOnly = true;
                            txtDescription.Enabled = false;
                            txtNotes.Enabled = false;
                            txtID.Enabled = false;

                            break;

                        //Request.QueryString["PersonID"] = "New";
                        default:

                            break;
                    }
                }
                else
                {
                    Response.Redirect("FetchCompany.aspx");
                }
            }

        }


        private void LoadCompanyAddress()
        {

            this.txtID.Text = Request.QueryString["CompanyID"];
           
            int CompanyID = Convert.ToInt32(txtID.Text);
            // if (Request.QueryString["AddressID"] != null)

            this.txtAID.Text = Request.QueryString["AddressID"];
            int AddressID = Convert.ToInt32(txtAID.Text);
            //I should make a line of code for every text box, converting the value to the string .


            DataManager.DataAccess da = new DataManager.DataAccess();


           // DataSet ds = da.FetchPersonsAddresses(PersonID, AddressID);
         //  DataSet ds2 = da.FetchPersonAddresses(PersonID);
            DataSet ds = da.FetchCompaniesAddresses(CompanyID, AddressID);
            DataSet ds2 = da.FetchCompanyAddresses(CompanyID, AddressID);

            //////////DataSet ds = da.FetchPhoneNumber(PhoneID);
            //////////DataSet ds2 = da.FetchPersonPhone(PhoneID);
            //  DataSet ds2 = da.FetchPersonPhones(PersonID);

            // txtID.Text = ds.Tables[0].Rows[0]["PersonID"].ToString();
            //txtPhID.Text = ds.Tables[0].Rows[0]["PhoneID"].ToString();
            //  object fpa = da.FetchPersonAddresses();
            object ai = ds.Tables[0].Rows[0]["AddressID"];   // PhoneID, AreaCode, PhoneNumber, Extension, PhoneType
            object s1 = ds.Tables[0].Rows[0]["Street1"];
            object s2 = ds.Tables[0].Rows[0]["Street2"];
            object ci = ds.Tables[0].Rows[0]["City"];
            object st = ds.Tables[0].Rows[0]["State"];
            object zi = ds.Tables[0].Rows[0]["Zip"];
            //txtID.Text = pi.ToString();
            txtStreet1.Text = s1.ToString();
            txtStreet2.Text = s2.ToString();
            txtCity.Text = ci.ToString();
            txtState.Text = st.ToString();
            txtZip.Text = zi.ToString();



            // object pid = ds2.Tables[0].Rows[0]["PersonID"];
            // object aid = ds2.Tables[0].Rows[0]["AddressID"];
            //  object atid = ds2.Tables[0].Rows[0]["AddressTypeID"]; 
            object EPAn = ds2.Tables[0].Rows[0]["Notes"];
            object EPAd = ds2.Tables[0].Rows[0]["Description"];

            txtDescription.Text = EPAd.ToString();
            txtNotes.Text = EPAn.ToString();



        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCompany.aspx?CompanyID=" + this.txtID.Text + "&Mode=Edit");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int CompanyID = Convert.ToInt32(txtID.Text);
            int AddressID = Convert.ToInt32(txtAID.Text);
            DataManager.DataAccess da = new DataManager.DataAccess();
            da.DeleteCompanyAddress(CompanyID, AddressID);
            //Response.Redirect("FetchPerson.aspx");
            Response.Redirect("EditCompany.aspx?Mode=Edit&CompanyID=" + this.txtID.Text);
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCompany.aspx?CompanyID=" + this.txtID.Text + "&Mode=Edit");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String Street1 = txtStreet1.Text;
            String Street2 = txtStreet2.Text;
            String City = txtCity.Text;
            String State = txtState.Text;
            String Zip = txtZip.Text;
            int AddressTypeID = Convert.ToInt32(ddlAddressTypeID.Text);

            //bool DoNotText;
            //bool DoNotCall;
            // int PhoneID = Convert.ToInt32(txtPhID.Text);
            int AddressID;

            DataManager.DataAccess da = new DataManager.DataAccess();
            switch (Request.QueryString["Mode"])
            {
                case "Edit":

                    this.txtAID.Text = Request.QueryString["AddressID"];
                    txtAID.Enabled = true;
                    AddressID = Convert.ToInt32(txtAID.Text);
                    Street1 = txtStreet1.Text;
                    Street2 = txtStreet2.Text;
                    City = txtCity.Text;
                    State = txtState.Text;
                    Zip = txtZip.Text;
                    AddressTypeID = Convert.ToInt32(ddlAddressTypeID.Text);
                    int CompanyID = Convert.ToInt32(txtID.Text);
                    String Description = txtDescription.Text;
                    String Notes = txtNotes.Text;


                    // da.UpdateAddress(AddressID, Street1, Street2, City, State, Zip); //UpdatePhone(int PhoneID, int AreaCode, int PhoneNumber, String Extension, int PhoneTypeID)
                    //da.UpdatePersonAddress(PersonID, AddressID, AddressTypeID, Description, Notes);
                    da.UpdateAddress(AddressID, Street1, Street2, City, State, Zip); //UpdatePhone(int PhoneID, int AreaCode, int PhoneNumber, String Extension, int PhoneTypeID)
                    da.UpdateCompanyAddresses(CompanyID, AddressID, AddressTypeID, Description, Notes);
                    Response.Redirect("EditCompany.aspx?Mode=Edit&CompanyID=" + this.txtID.Text);

                    btnDone.Enabled = true;

                    btnDone.Visible = false;




                    // Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + this.txtID.Text);

                    break;


                case "New":

                    Street1 = txtStreet1.Text;
                    Street2 = txtStreet2.Text;
                    City = txtCity.Text;
                    State = txtState.Text;
                    Zip = txtZip.Text;
                   // AddressTypeID = Convert.ToInt32(ddlAddressTypeID.SelectedValue);

                    //PersonID = Convert.ToInt32(txtID.Text);
                    // PhoneID = Convert.ToInt32(txtPhID.Text);

                    Description = txtDescription.Text;
                    Notes = txtNotes.Text;



                    CompanyID = Convert.ToInt32(txtID.Text);

                    object oAddressID = da.InsertAddress(Street1, Street2, City, State, Zip);
                    txtAID.Text = oAddressID.ToString();

                    AddressID = Convert.ToInt32(oAddressID.ToString());


                    //da.InsertPhoneNumber(AreaCode, PhoneNumber, Extension, PhoneTypeID);
                    //txtPhID.Text = phoneNumberID.ToString();
                    //AddressID = Convert.ToInt32(txtAID.Text.ToString());
                    // txtNotes.Text = PhoneID.ToString();
                    da.InsertCompanyAddress(CompanyID, AddressID, Description, Notes);

                    // I need to send the PersonID and the PhoneID to the Edit Page

                    Response.Redirect("EditCompany.aspx?Mode=Edit&CompanyID=" + this.txtID.Text);
                    //           Response.Redirect("EditPersonPhoneNumber.aspx?PersonID=" +
                    //this.txtID.Text + "&Mode=Edit&PhoneID=" + this.txtPhID.Text);

                    break;

            }
        }
    }
}