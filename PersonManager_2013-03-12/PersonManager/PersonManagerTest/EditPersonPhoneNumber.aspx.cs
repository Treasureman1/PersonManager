using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PersonManagerTest
{
    public partial class EditPhoneNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            String data;
            if (Request.QueryString["Mode"] != null)
            {
                //
            }
            else
            {
                data = Request.QueryString["Mode"].ToString();
            }

            //   ////////// Response.Redirect("EditPersonPhoneNumber.aspx?Mode=New");


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
                ddlPhoneTypeID.DataSource = ds.Tables[0];

                //The DataTextField is the value of what will show in the ddl
                // the DataValueField is the Value of the
                ddlPhoneTypeID.DataTextField = "Name";
                ddlPhoneTypeID.DataValueField = "PhoneTypeID";
                ddlPhoneTypeID.DataBind();
                //object phoneTypeID = da5.FetchPhoneTypes();

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


                            LoadPersonPhone();

                            txtPhID.Enabled = false;
                            txtAreaCode.Enabled = false;
                            txtPhoneNumber.Enabled = false;
                            txtExtension.Enabled = false;
                            ddlPhoneTypeID.Enabled = false;
                            txtDescription.Enabled = false;
                            txtNotes.Enabled = false;
                            cbDNC.Enabled = false;
                            cbDNT.Enabled = false;
                            txtID.Enabled = false;
                            txtPhID.Enabled = false;

                            break;

                        case "New":

                            btnDone.Visible = false;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;

                            // LoadPerson();
                            txtPhID.Enabled = false;
                            txtAreaCode.Enabled = true;
                            txtPhoneNumber.Enabled = true;
                            txtExtension.Enabled = true;
                            ddlPhoneTypeID.Enabled = true;

                            break;

                        case "Edit":

                            txtID.Enabled = false;
                            btnDone.Visible = true;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;
                            btnCancel.Visible = false;

                            txtPhID.Enabled = false;
                            txtAreaCode.Enabled = true;
                            txtPhoneNumber.Enabled = true;
                            txtExtension.Enabled = true;
                            ddlPhoneTypeID.Enabled = true;
                            object PhoneID = Convert.ToInt32(Request.QueryString["PhoneID"]);

                            txtPhID.Text = PhoneID.ToString();
                            LoadPersonPhone();
                            btnDone.Visible = false;

                            break;

                        case "Delete":

                            btnDone.Visible = false;
                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            //NameDisplayLabel.Visible = false;

                            LoadPersonPhone();

                            txtPhID.Enabled = false;
                            txtAreaCode.Enabled = false;
                            txtPhoneNumber.Enabled = false;
                            txtExtension.Enabled = false;
                            ddlPhoneTypeID.Enabled = false;
                            txtNotes.ReadOnly = true;
                            txtDescription.ReadOnly = true;
                            txtDescription.Enabled = false;
                            txtNotes.Enabled = false;
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

        private void LoadPersonPhone()
        {

            this.txtID.Text = Request.QueryString["PersonID"];
            int PersonID = Convert.ToInt32(txtID.Text);

            this.txtPhID.Text = Request.QueryString["PhoneID"];
            int PhoneID = Convert.ToInt32(txtPhID.Text);
            //I should make a line of code for every text box, converting the value to the string .

            DataManager.DataAccess da = new DataManager.DataAccess();

            DataSet ds = da.FetchPhoneNumber(PhoneID);
            DataSet ds2 = da.FetchPersonPhone(PhoneID);
            //  DataSet ds2 = da.FetchPersonPhones(PersonID);

            // txtID.Text = ds.Tables[0].Rows[0]["PersonID"].ToString();
            //txtPhID.Text = ds.Tables[0].Rows[0]["PhoneID"].ToString();

            object pi = ds.Tables[0].Rows[0]["PhoneID"];  // PhoneID, AreaCode, PhoneNumber, Extension, PhoneType
            object ac = ds.Tables[0].Rows[0]["AreaCode"];
            object pn = ds.Tables[0].Rows[0]["PhoneNumber"];
            object ex = ds.Tables[0].Rows[0]["Extension"];
            object pt = ds.Tables[0].Rows[0]["PhoneTypeID"];
            // txtID.Text = pi.ToString();
            txtAreaCode.Text = ac.ToString();
            txtPhoneNumber.Text = pn.ToString();
            txtExtension.Text = ex.ToString();
            ddlPhoneTypeID.Text = pt.ToString();

            //DoNotCall, DoNotText, Description, Notes
            object dnc = ds2.Tables[0].Rows[0]["DoNotCall"];
            object dnt = ds2.Tables[0].Rows[0]["DoNotText"];

            object EPPn = ds2.Tables[0].Rows[0]["Notes"];
            object EPPd = ds2.Tables[0].Rows[0]["Description"];

            txtDescription.Text = EPPd.ToString();
            txtNotes.Text = EPPn.ToString();


            cbDNT.Checked = Convert.ToBoolean(dnt.ToString());
            cbDNC.Checked = Convert.ToBoolean(dnc.ToString());

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String AreaCode = txtAreaCode.Text;
            String PhoneNumber = txtPhoneNumber.Text;
            String Extension = txtExtension.Text;
            int PhoneTypeID = Convert.ToInt32(ddlPhoneTypeID.Text);
            bool DoNotText;
            bool DoNotCall;
            // int PhoneID = Convert.ToInt32(txtPhID.Text);
            int PhoneID;

            DataManager.DataAccess da = new DataManager.DataAccess();
            switch (Request.QueryString["Mode"])
            {
                case "Edit":

                    this.txtPhID.Text = Request.QueryString["PhoneID"];
                    txtPhID.Enabled = true;
                    PhoneID = Convert.ToInt32(txtPhID.Text);
                    AreaCode = txtAreaCode.Text;
                    PhoneNumber = txtPhoneNumber.Text;
                    Extension = txtExtension.Text;
                    PhoneTypeID = Convert.ToInt32(ddlPhoneTypeID.Text);
                    int PersonID = Convert.ToInt32(txtID.Text);
                    String Description = txtDescription.Text;
                    String Notes = txtNotes.Text;
                    if (cbDNC.Checked == false)
                    {
                        cbDNC.Checked = false;
                    }
                    if (cbDNC.Checked == true)
                    {
                        cbDNC.Checked = true;
                    }
                    if (cbDNT.Checked == false)
                    {
                        cbDNT.Checked = false;
                    }
                    if (cbDNT.Checked == true)
                    {
                        cbDNT.Checked = true;
                    }

                    DoNotCall = cbDNC.Checked;
                    DoNotText = cbDNT.Checked;
                    da.UpdatePhone(PhoneID, AreaCode, PhoneNumber, Extension, PhoneTypeID); //UpdatePhone(int PhoneID, int AreaCode, int PhoneNumber, String Extension, int PhoneTypeID)
                    da.UpdatePersonPhoneNumber(PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText);
                    Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + this.txtID.Text);

                    btnDone.Enabled = true;

                    btnDone.Visible = false;




                    // Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + this.txtID.Text);

                    break;


                case "New":

                    AreaCode = txtAreaCode.Text;
                    PhoneNumber = txtPhoneNumber.Text;
                    Extension = txtExtension.Text;
                    PhoneTypeID = Convert.ToInt32(ddlPhoneTypeID.SelectedValue);

                    //PersonID = Convert.ToInt32(txtID.Text);
                    // PhoneID = Convert.ToInt32(txtPhID.Text);

                    Description = txtDescription.Text;
                    Notes = txtNotes.Text;


                    DoNotCall = cbDNC.Checked;
                    DoNotText = cbDNT.Checked;

                    PersonID = Convert.ToInt32(txtID.Text);

                    object phoneNumberID = da.InsertPhoneNumber(AreaCode, PhoneNumber, Extension, PhoneTypeID);
                    txtPhID.Text = phoneNumberID.ToString();
                    
                    // da.InsertPhoneNumber(AreaCode, PhoneNumber, Extension, PhoneTypeID);
                    //txtPhID.Text = phoneNumberID.ToString();
                    PhoneID = Convert.ToInt32(txtPhID.Text.ToString());
                    // txtNotes.Text = PhoneID.ToString();
                    da.InsertPersonPhone(PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText);

                    // I need to send the PersonID and the PhoneID to the Edit Page

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
            int PhoneID = Convert.ToInt32(txtPhID.Text);
            DataManager.DataAccess da = new DataManager.DataAccess();
            da.DeletePersonPhoneNumber(PersonID, PhoneID);
            //Response.Redirect("FetchPerson.aspx");
            Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + this.txtID.Text);
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditPerson.aspx?PersonID=" + this.txtID.Text + "&Mode=Edit");
        }
    }
}