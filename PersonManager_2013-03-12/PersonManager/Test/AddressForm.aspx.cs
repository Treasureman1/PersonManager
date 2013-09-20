using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Test 
    
{
    public partial class AddressForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                txtATID.Visible = false;
                ddlAddressTypeID.Enabled = true;
                DataManager.DataAccess da2 = new DataManager.DataAccess();
                DataSet ds3 = new DataSet();
                ds3 = da2.FetchAddressTypes();
                ddlAddressTypeID.DataSource = ds3.Tables[0];

                //The DataTextField is the value of what will show in the ddl
                // the DataValueField is the Value of the
                ddlAddressTypeID.DataTextField = "Name";
                ddlAddressTypeID.DataValueField = "AddressTypeID";
                ddlAddressTypeID.DataBind();

                ddlAddressTypeID.Items.Insert(0, new ListItem("PLEASE SELECT ADDRESS TYPE", string.Empty));


                if (Request.QueryString["Mode"] == null)
                {
                    Request.QueryString["Mode"] = "New";
                    //Response.Redirect("AddressForm.aspx?Mode=Edit");
                }
                if (Request.QueryString["PersonID"] != null)
                {
                    txtID.Text = Request.QueryString["PersonID"].ToString();
                    //

                }

                if (Request.QueryString["addressID"] != null)
                {
                    txtAID.Text = Request.QueryString["addressID"].ToString();
                }

                if (Request.QueryString != null)
                {

                    string mode = Request.QueryString["Mode"];
                    // if mode = null then mode = new
                    //one other way would be to get rid of the test and in the switch statement  view edit delete and instead of case new
                    // change that so that you are doing it to false      whenmode is new, view,   a default case   would be new
                    switch (mode)
                    {

                        case "View":
                            //btnDone.Visible = true;
                            //btnSave.Visible = false;
                            btnDelete.Visible = false;
                            
                            //LoadPerson();

                            //txtID.Enabled = false;
                            //txtFirstName.Enabled = false;
                            //txtLastName.Enabled = false;
                            //btnCancel.Visible = false;
                            //fillPhoneGrid();
                            //fillAddressGrid();
                            //fillEmail();

                            break;

                        case "New":

                            //btnDone.Visible = false;
                            btnSave.Visible = true;
                            //btnDelete.Visible = false;

                            // LoadPerson();

                            txtID.Enabled = false;
                            ddlAddressTypeID.Visible = true;
                            btnDelete.Visible = false;
                            //txtFirstName.Enabled = true;
                            //txtLastName.Enabled = true;
                            //btnAddPhoneNum.Visible = false;
                            ddlAddressTypeID.SelectedIndex = 0;

                            break;

                        case "Edit":

                            //btnDone.Visible = true;
                            btnSave.Visible = true;
                            //btnDelete.Visible = false;
                            btnDelete.Visible = false;
                            //LoadPerson();

                            txtID.Enabled = false;
                            ddlAddressTypeID.Visible = true;
                            ddlAddressTypeID.Enabled = true;

                            int id = Convert.ToInt32(txtID.Text);

                            loadPerson(id);
                           

                    //                 DataPortal.PersonData pd = new DataPortal.PersonData();
                    //        DataSet pds = new DataSet();
                    //        int PersonID = Convert.ToInt32(txtID.Text);
                    //        pds = pd.Fetch(PersonID);
                    //        object fn = pds.Tables[0].Rows[0]["FirstName"].ToString();
                    //        object ln = pds.Tables[0].Rows[0]["LastName"].ToString();
                    //        ////////txtFirstName.Text = fn.ToString();
                    //        ////////txtLastName.Text = ln.ToString();
                    //        lblFirstName.Text = fn.ToString();
                    //        lblLastName.Text = ln.ToString();

                    //DataPortal.PersonAddressData pad = new DataPortal.PersonAddressData();
                    //DataSet ds = new DataSet();

                            int AddressID = Convert.ToInt32(txtAID.Text);
                            BusinessObjects.PersonAddress personAddress = new BusinessObjects.PersonAddress();

                            DataSet ds = new DataSet();

                            ds = personAddress.LoadAddress(id, AddressID);

                            txtStreet1.Text = ds.Tables[0].Rows[0]["Street1"].ToString();
                            txtStreet2.Text = ds.Tables[0].Rows[0]["Street2"].ToString();

                            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                            txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                            txtZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
                            txtNotes.Text = ds.Tables[0].Rows[0]["Notes"].ToString();
                            txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();


                    //int AddressID = Convert.ToInt32(txtAID.Text);
                    //ds = pad.Fetch(PersonID, AddressID);
                    //object s1 = ds.Tables[0].Rows[0]["Street1"].ToString();
                    //object s2 = ds.Tables[0].Rows[0]["Street2"].ToString();
                    //object ci = ds.Tables[0].Rows[0]["City"].ToString();
                    //object st = ds.Tables[0].Rows[0]["State"].ToString();
                    //object zi = ds.Tables[0].Rows[0]["Zip"].ToString();
                    //object atid = ds.Tables[0].Rows[0]["AddressTypeID"].ToString();
                    //object d = ds.Tables[0].Rows[0]["Description"].ToString();
                    //object n = ds.Tables[0].Rows[0]["Notes"].ToString();
                    //txtStreet1.Text = s1.ToString();
                    //txtStreet2.Text = s2.ToString();
                    //txtCity.Text = ci.ToString();
                    //txtState.Text = st.ToString();
                    //txtZip.Text = zi.ToString();
                    //ddlAddressTypeID.Text = atid.ToString();
                    //txtATID.Text = atid.ToString();
                    //txtDescription.Text = d.ToString();
                    //txtNotes.Text = n.ToString();
                    
                           


                            break;

                        case "Delete":


                             btnSave.Visible = false;
                            //btnDelete.Visible = false;
                            btnDelete.Visible = true;
                            //LoadPerson();

                            txtID.Enabled = false;
                            ddlAddressTypeID.Visible = true;
                            ddlAddressTypeID.Enabled = true;
                   //         pd = new DataPortal.PersonData();
                   //  pds = new DataSet();
                   //   PersonID = Convert.ToInt32(txtID.Text);      
                   
                   // pds = pd.Fetch(PersonID);
                   //fn = pds.Tables[0].Rows[0]["FirstName"].ToString();
                   //ln = pds.Tables[0].Rows[0]["LastName"].ToString();
                  
                   // lblFirstName.Text = fn.ToString();
                   // lblLastName.Text = ln.ToString();

                   // pad = new DataPortal.PersonAddressData();
                   // ds = new DataSet();
                   // AddressID = Convert.ToInt32(txtAID.Text);
                   // ds = pad.Fetch(PersonID, AddressID);
                   // s1 = ds.Tables[0].Rows[0]["Street1"].ToString();
                   // s2 = ds.Tables[0].Rows[0]["Street2"].ToString();
                   //  ci = ds.Tables[0].Rows[0]["City"].ToString();
                   //  st = ds.Tables[0].Rows[0]["State"].ToString();
                   //  zi = ds.Tables[0].Rows[0]["Zip"].ToString();
                   //  atid = ds.Tables[0].Rows[0]["AddressTypeID"].ToString();
                   //  d = ds.Tables[0].Rows[0]["Description"].ToString();
                   //  n = ds.Tables[0].Rows[0]["Notes"].ToString();
                   // txtStreet1.Text = s1.ToString();
                   // txtStreet2.Text = s2.ToString();
                   // txtCity.Text = ci.ToString();
                   // txtState.Text = st.ToString();
                   // txtZip.Text = zi.ToString();
                   // ddlAddressTypeID.Text = atid.ToString();
                   // txtATID.Text = atid.ToString();
                   // txtDescription.Text = d.ToString();
                   // txtNotes.Text = n.ToString();

                   // txtStreet1.Enabled = false;
                   //         //city state zip notes description
                   // txtStreet2.Enabled = false;
                   // txtCity.Enabled = false;
                   // txtState.Enabled = false;
                   // txtZip.Enabled = false;
                   // txtNotes.Enabled = false;
                   // txtDescription.Enabled = false;
                   // ddlAddressTypeID.Enabled = false;

                            break;
                    }



                }

                if (txtID.Text != "")
                {
                    if (txtAID.Text == null)
                    {
                        //DataPortal.PersonData pd = new DataPortal.PersonData();
                        //DataSet pds = new DataSet();
                        //int PersonID = Convert.ToInt32(txtID.Text);
                        //pds = pd.Fetch(PersonID);
                        //object fn = pds.Tables[0].Rows[0]["FirstName"].ToString();
                        //object ln = pds.Tables[0].Rows[0]["LastName"].ToString();
                     
                        int id = Convert.ToInt32(txtID.Text);
                        loadPerson(id);

                      //  DataPortal.PersonAddressData pad = new DataPortal.PersonAddressData();
                      //  DataSet ds = new DataSet();

                      //  int AddressID = Convert.ToInt32(txtAID.Text);

                      //  ds = pad.Fetch(PersonID, AddressID);
                      //  object s1 = ds.Tables[0].Rows[0]["Street1"].ToString();
                      //  object s2 = ds.Tables[0].Rows[0]["Street2"].ToString();
                      //  object ci = ds.Tables[0].Rows[0]["City"].ToString();
                      //  object st = ds.Tables[0].Rows[0]["State"].ToString();
                      //  object zi = ds.Tables[0].Rows[0]["Zip"].ToString();
                      //  object atid = ds.Tables[0].Rows[0]["AddressTypeID"].ToString();

                      //  object d = ds.Tables[0].Rows[0]["Description"].ToString();
                      //  object n = ds.Tables[0].Rows[0]["Notes"].ToString();
                       
                      //  txtStreet1.Text = s1.ToString();
                      //  txtStreet2.Text = s2.ToString();
                      //  txtCity.Text = ci.ToString();
                      //  txtState.Text = st.ToString();
                      //  txtZip.Text = zi.ToString();
                      //txtATID.Text = atid.ToString();
                      //  txtDescription.Text = d.ToString();
                      //  txtNotes.Text = n.ToString();

                         int AddressID = Convert.ToInt32(txtAID.Text);
                            BusinessObjects.PersonAddress personAddress = new BusinessObjects.PersonAddress();

                            DataSet ds = new DataSet();

                            ds = personAddress.LoadAddress(id, AddressID);

                            txtStreet1.Text = ds.Tables[0].Rows[0]["Street1"].ToString();
                            txtStreet2.Text = ds.Tables[0].Rows[0]["Street2"].ToString();

                            txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                            txtState.Text = ds.Tables[0].Rows[0]["State"].ToString();
                            txtZip.Text = ds.Tables[0].Rows[0]["Zip"].ToString();
                            txtNotes.Text = ds.Tables[0].Rows[0]["Notes"].ToString();
                            txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                        //DataManager.DataAccess da = new DataManager.DataAccess();
                        DataSet ds2 = new DataSet();
                        //ds2 = pad.FetchAddressTypes();
                        //ddlAddressTypeID.DataSource = ds2.Tables[0];

                        BusinessObjects.PersonAddress pa = new BusinessObjects.PersonAddress();
                      ds2 = pa.FetchDataTypes();
                      ddlAddressTypeID.DataSource = ds2.Tables[0];
                       

                        //The DataTextField is the value of what will show in the ddl
                        // the DataValueField is the Value of the
                        ddlAddressTypeID.DataTextField = "Name";
                        ddlAddressTypeID.DataValueField = "AddressTypeID";
                        ddlAddressTypeID.DataBind();


                        //  DataPortal.PersonAddressData pad = new DataPortal.PersonAddressData();
                        //  //DataManager.DataAccess da = new DataManager.DataAccess();
                        //  DataSet ds = new DataSet();
                        //  //DataSet dsPersons = new DataSet();
                        ///////  int PersonID = Convert.ToInt32(txtID.Text);
                        //  int AddressID = Convert.ToInt32(txtAID.Text);

                        //  ds = pad.Fetch(PersonID, AddressID);
                        //  //  txtFirstName.Text =
                        //  object s1 = ds.Tables[0].Rows[0]["Street1"];
                        //  object s2 = ds.Tables[0].Rows[0]["Street2"];

                        //  txtStreet1.Text = s1.ToString();
                        //  txtStreet2.Text = s2.ToString();


                        //gvPersonName.DataSource = dsPersons;
                        //gvPersonName.DataBind();

                    }
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {


            String Street1 = txtStreet1.Text;
            String Street2 = txtStreet2.Text;
            String City = txtCity.Text;
            String State = txtState.Text;
            String Zip = txtZip.Text;
          //  int PersonID = Convert.ToInt32(txtID.Text);
            //int AddressID = Convert.ToInt32(txtAID.Text);
            //int AddressTypeID = Convert.ToInt32(txtATID.Text);
            if (ddlAddressTypeID.SelectedIndex == 0)
            {
                ddlAddressTypeID.SelectedIndex = 1;
            } 
            int AddressTypeID = Convert.ToInt32(ddlAddressTypeID.Text);


            String Description = txtDescription.Text;
            String Notes = txtNotes.Text;


           // DataPortal.PersonAddressData pad = new DataPortal.PersonAddressData();

            BusinessObjects.PersonAddress pa = new BusinessObjects.PersonAddress();



           
            //DataManager.DataAccess da = new DataManager.DataAccess();
            switch (Request.QueryString["Mode"])
            {

                case "Edit":
                    pa.Street1 = txtStreet1.Text;
                    pa.Street2 = txtStreet2.Text;
                    pa.City = txtCity.Text;
                    pa.State = txtState.Text;
                    pa.Zip = txtZip.Text;
                    pa.Description = txtDescription.Text;
                    pa.Notes = txtNotes.Text;


             int PersonID = Convert.ToInt32(txtID.Text);
            int AddressID = Convert.ToInt32(txtAID.Text);
          
                    

            //if (ddlAddressTypeID.SelectedIndex == 0)
            //{
            //    ddlAddressTypeID.SelectedIndex = 1;
            //}
            
            
      //      AddressTypeID = Convert.ToInt32(ddlAddressTypeID.Text);
             Description = txtDescription.Text;
             Notes = txtNotes.Text;

             pa.Save();
          

            // pad.Update(PersonID, AddressID, AddressTypeID, Description, Notes);
            //pad.UpdateAddress(AddressID, Street1, Street2, City, State, Zip);
            //int AddressTypeID = Convert.ToInt32(txtAID);
            int x = Convert.ToInt32(txtID.Text);

            Response.Redirect("WebForm1.aspx?PersonID=" + x + "");
           
                    txtID.Enabled = true;
                    DataSet ds = new DataSet();

            //////////        pad.UpdateAddress(AddressID, Street1, Street2, City, State, Zip);
                    //////pad.Update(PersonID, AddressID, AddressTypeID, Description, Notes);
                    //da.UpdatePerson(PersonID, FirstName, LastName);
                    Response.Redirect("AddressForm.aspx?PersonID=" +
            this.txtID.Text + "&Mode=Edit");

                    break;

                case "New":
                    //BusinessObjects.Address address = new BusinessObjects.Address();

                    //// for each personAddresses object in the personAddresses Collection
                    ////persform the following step

                    //address.Street1 = txtStreet1.Text;
                    //address.Street2 = txtStreet2.Text;
                    //address.City = txtCity.Text;
                    //address.State = txtState.Text;
                    //address.Zip = txtZip.Text;
                    //address.Save();
                    
                  
                    BusinessObjects.PersonAddress personAddress = new BusinessObjects.PersonAddress();
                    personAddress.Street1 = txtStreet1.Text;
                    personAddress.Street2 = txtStreet2.Text;
                    personAddress.City = txtCity.Text;
                    personAddress.State = txtState.Text;
                    personAddress.Zip = txtZip.Text;

                   
                  
                    personAddress.PersonID = Convert.ToInt32(txtID.Text);
            //////////////        personAddress.AddressID = address.AddressID;
//Fix Later                    ///
                    
                    //personAddress.PersonID = Convert.ToInt32(txtID.Text);
                   // personAddress.AddressID = personAddress.AddressID;
                    personAddress.AddressTypeID = 1; 
                    personAddress.Description = txtDescription.Text;
                    personAddress.Notes = txtNotes.Text;                  
                   
                                       
                    personAddress.Save();   
         
                    //Street1 = txtStreet1.Text;
                    //Street2 = txtStreet2.Text;
                    //City = txtCity.Text;
                    //State = txtState.Text;
                    //Zip = txtZip.Text;
                    //Description = txtDescription.Text;
                    //Notes = txtNotes.Text;

                   // PersonID = Convert.ToInt32(txtID.Text);

                   // //Address.Save()
                   // //PersonAddress.Save()
                    
                   //// object addressID = pad.InsertAddress(Street1, Street2, City, State, Zip);
                   // txtAID.Text = addressID.ToString();

                   // if (ddlAddressTypeID.SelectedIndex == 0)
                   // {
                   //     ddlAddressTypeID.SelectedIndex = 1;
                   // }

                   // AddressTypeID = Convert.ToInt32(ddlAddressTypeID.Text);
                   // AddressID = Convert.ToInt32(addressID.ToString());
                    

                    //da.InsertPhoneNumber(AreaCode, PhoneNumber, Extension, PhoneTypeID);
                    //txtPhID.Text = phoneNumberID.ToString();
                    //AddressID = Convert.ToInt32(txtAID.Text.ToString());
                    // txtNotes.Text = PhoneID.ToString();
                   /////////////// pad.InsertPersonAddress(PersonID, AddressID, AddressTypeID, Description, Notes);
                   
                    // I need to send the PersonID and the PhoneID to the Edit Page

                 ////////  Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + this.txtID.Text);
                    //           Response.Redirect("EditPersonPhoneNumber.aspx?PersonID=" +
                    //this.txtID.Text + "&Mode=Edit&PhoneID=" + this.txtPhID.Text);

                    break;
                    
                  
            }
            int y = Convert.ToInt32(txtID.Text);
            Response.Redirect("WebForm1.aspx?PersonID=" + y + "");

            //DataPortal.PersonAddressData pad = new DataPortal.PersonAddressData();
            //DataSet ds = new DataSet();
            //pad.Update(PersonID, AddressID, AddressTypeID, Description, Notes);
            //pad.UpdateAddress(AddressID, Street1, Street2, City, State, Zip);
            ////int AddressTypeID = Convert.ToInt32(txtAID);
            //int x = Convert.ToInt32(txtID.Text);

            //Response.Redirect("WebForm1.aspx?PersonID=" + x + "");
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx?PersonID=1");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            DataPortal.EmailAddressesData ead = new DataPortal.EmailAddressesData();

            DataPortal.PersonAddressData pad = new DataPortal.PersonAddressData();

            //DataSet ds = new DataSet();
            int AddressID = Convert.ToInt32(txtAID.Text);
            
            //pad.Delete(AddressID);
            int affectedRecords = pad.Delete(AddressID);

            //int x = Convert.ToInt32(txtID.Text);
            if (affectedRecords > 0)
            {
                Response.Redirect("WebForm1.aspx?PersonID=" + txtID.Text);
            }
        }

       private DataSet loadPerson(int id)
        {
            DataSet ds = new DataSet();
            
            BusinessObjects.Person person = new BusinessObjects.Person(id);
           person.Fetch(id);
            lblFirstName.Text = person.FirstName.ToString();
            lblLastName.Text = person.LastName.ToString();

            return ds; 
        }

        private DataSet loadPersonAddress(int id, int addressID)
        {

            BusinessObjects.PersonAddress personAddress = new BusinessObjects.PersonAddress();
            DataSet ds = new DataSet();
            //////txtID.Text = id;
            
            return ds;

        }

     

   

   

    
    }
}