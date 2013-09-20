using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Test
{
    public partial class EmailForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Mode"] == null)
                {
                    Request.QueryString["Mode"] = "New";
                    //Response.Redirect("AddressForm.aspx?Mode=Edit");
                }
                if (Request.QueryString["PersonID"] != null)
                {
                    txtID.Text = Request.QueryString["PersonID"].ToString();
                }
                if (Request.QueryString["emailAddressID"] != null)
                {
                    txtEAID.Text = Request.QueryString["emailAddressID"].ToString();
                }

              

                if (Request.QueryString != null)
                {

                    string mode = Request.QueryString["Mode"];
                  

                    switch (mode)
                    {
                        case "View":

                            break;

                        case "New":

                            btnSave.Visible = true;
                            txtID.Enabled = false;

                            break;

                        case "Edit":

                            btnSave.Visible = true;
                             txtID.Enabled = false;
                             btnDelete.Visible = false;


                             BusinessObjects.Person person = new BusinessObjects.Person();
                             //// DataPortal.PersonData pd = new DataPortal.PersonData();
                    DataSet pds = new DataSet();
                    int id = Convert.ToInt32(txtID.Text);
                        
                            
                   person.Fetch(id);
                   lblFirstName.Text = person.FirstName;
                   lblLastName.Text = person.LastName;
                    int PersonID = Convert.ToInt32(txtID.Text);


                            //I need to do a fetch to select all from email addreaa where EmailAddressID = @EmailAddressID
                    BusinessObjects.EmailAddress email = new BusinessObjects.EmailAddress();
                    int EmailAddressID = Convert.ToInt32(txtEAID.Text);
                    DataSet ds = new DataSet();
                    ds = email.Load(EmailAddressID);
                  // txtAddress.Text = email.Address.ToString();
                   txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    //txtEAID.Text = email.EmailAddressID.ToString();
                   // email.EmailAddressID = Convert.ToInt32(txtEAID.Text);
                   // txtAddress.Text = email.Address.ToString();
                  ////  pds = pd.Fetch(PersonID);
                    //object fn = pds.Tables[0].Rows[0]["FirstName"].ToString();
                    //object ln = pds.Tables[0].Rows[0]["LastName"].ToString();
                    //lblFirstName.Text = fn.ToString();
                    //lblLastName.Text = ln.ToString();

                           
                            
                    ////DataPortal.EmailAddressesData ead = new DataPortal.EmailAddressesData();
                    

                   //// string Address = txtAddress.Text;

                   //// object eaid = ds.Tables[0].Rows[0]["EmailAddressID"].ToString();
                 ////   object a = ds.Tables[0].Rows[0]["Address"].ToString();
                    ////object pid = ds.Tables[0].Rows[0]["PersonID"].ToString();
                   // object id = ds.Tables[0].Rows[0]["IsDeleted"].ToString();

               
                            
                            break;

                        case "Delete":

                              btnSave.Visible = false;
                             txtID.Enabled = false;
                             btnDelete.Visible = true;
                           email = new BusinessObjects.EmailAddress();
                    EmailAddressID = Convert.ToInt32(txtEAID.Text);
                   
                    ds = email.Load(EmailAddressID);
                  // txtAddress.Text = email.Address.ToString();
                   txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                    //////        PersonID = Convert.ToInt32(txtID.Text);
                    //////         ead = new DataPortal.EmailAddressesData();
                    //////ds = ead.Fetch(PersonID);
                    //////a = ds.Tables[0].Rows[0]["Address"].ToString();
                  //  object id = ds.Tables[0].Rows[0]["IsDeleted"].ToString();
                  //  txtIsDeleted.Text = id.ToString();
                    
                            ////txtAddress.Text = a.ToString();

                  //           btnSave.Visible = false;
                  //           txtID.Enabled = false;
                  //           btnDelete.Visible = true;
                  //           pd = new DataPortal.PersonData();
                  //           pds = new DataSet();


                  //           PersonID = Convert.ToInt32(txtID.Text);
                  //  pds = pd.Fetch(PersonID);
                  // fn = pds.Tables[0].Rows[0]["FirstName"].ToString();
                  //ln = pds.Tables[0].Rows[0]["LastName"].ToString();
                  //  lblFirstName.Text = fn.ToString();
                  //  lblLastName.Text = ln.ToString();

                           
            
                  //int EmailAddressID = Convert.ToInt32(txtEAID.Text);
                  //  Address = txtAddress.Text;

                  //  eaid = pds.Tables[0].Rows[0]["EmailAddressID"].ToString();
                  //  a = pds.Tables[0].Rows[0]["Address"].ToString();
                  //  pid = pds.Tables[0].Rows[0]["PersonID"].ToString();

                  //  txtEAID.Text = eaid.ToString();
                  //  txtAddress.Text = a.ToString(); 

                            break;
                    }
                }

                if (txtID.Text != "")
                {
                    if (txtEAID.Text == null)
                    {
                        BusinessObjects.Person person = new BusinessObjects.Person();
                        person.id = Convert.ToInt32(txtID.Text);
                        lblFirstName.Text = person.FirstName.ToString();
                        lblLastName.Text = person.LastName.ToString();

                      
                        //////int PersonID = Convert.ToInt32(txtID.Text);
                        //////pds = pd.Fetch(PersonID);
                        //////object fn = pds.Tables[0].Rows[0]["FirstName"].ToString();
                        //////object ln = pds.Tables[0].Rows[0]["LastName"].ToString();
                        //////lblFirstName.Text = fn.ToString();
                        //////lblLastName.Text = ln.ToString();

                        ////  DataPortal.EmailAddressesData ead = new DataPortal.EmailAddressesData();

                          BusinessObjects.EmailAddress email = new BusinessObjects.EmailAddress();
                          email.EmailAddressID = Convert.ToInt32(txtEAID.Text);

                          //////DataSet ds = new DataSet();
                          //////int EmailAddressID = Convert.ToInt32(txtEAID.Text);
                          //////ds = ead.Fetch(PersonID);

                        
                        //    int emailAddressID = Convert.ToInt32(txtEAID.Text);
                        //    String Address = txtAddress.Text;

                          //////object eaid = ds.Tables[0].Rows[0]["EmailAddressID"].ToString();
                          //////object a = ds.Tables[0].Rows[0]["Address"].ToString();
                          //////object pid = ds.Tables[0].Rows[0]["PersonID"].ToString();

                          txtEAID.Text = email.EmailAddressID.ToString();
                          txtAddress.Text = email.Address.ToString();
                    }
                }

            }

                       
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           // int EmailAddressID = Convert.ToInt32(txtEAID.Text);
            ////String Address = txtAddress.Text;
            ////int PersonID = Convert.ToInt32(txtID.Text);
          ////  DataPortal.EmailAddressesData ead = new DataPortal.EmailAddressesData();
            
           
            
            DataSet ds = new DataSet();

            BusinessObjects.EmailAddress email = new BusinessObjects.EmailAddress();
            switch (Request.QueryString["Mode"])
            {

                case "Edit":
                                 
                         //email.fetch needs to be written

                    ////DataSet ds = ead.Fetch(PersonID);
                   // email.EmailAddressID = Convert.ToInt32(txtEAID.Text);
                    email.EmailAddressID = Convert.ToInt32(txtEAID.Text);
                    email.Address = txtAddress.Text;
                    email.PersonID = Convert.ToInt32(txtID.Text);

                    txtEAID.Text = email.EmailAddressID.ToString();
                   txtAddress.Text = email.Address.ToString();
                   txtID.Text = email.PersonID.ToString();

                   email.Save();



            ////   int EmailAddressID = Convert.ToInt32(txtEAID.Text);
            ////Address = txtAddress.Text;
            ////PersonID = Convert.ToInt32(txtID.Text);
            //////DataPortal.EmailAddressesData ead = new DataPortal.EmailAddressesData();
            //////DataSet ds = new DataSet();
            ////ead.Update(EmailAddressID, Address, PersonID);

            break;

                case "New":
            email.Address = txtAddress.Text;
            email.PersonID = Convert.ToInt32(txtID.Text);
            email.Save();

          //          // EmailAddressID = Convert.ToInt32(txtEAID.Text);
            ////Address = txtAddress.Text;
            //PersonID = Convert.ToInt32(txtID.Text);
            //Boolean IsDeleted = false;

            //object emailAddressID = ead.InsertEmailAddress(Address, PersonID, IsDeleted);
            //txtEAID.Text = emailAddressID.ToString();
            //EmailAddressID = Convert.ToInt32(emailAddressID.ToString());

           // ead.InsertEmailAddress(Address, PersonID);
            break;

             

            }    
     


            int x = Convert.ToInt32(txtID.Text);
           Response.Redirect("WebForm1.aspx?PersonID=" + x + "");



        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

          //  DataPortal.EmailAddressesData ead = new DataPortal.EmailAddressesData();


            BusinessObjects.EmailAddress email = new BusinessObjects.EmailAddress();
           
            //DataSet ds = new DataSet();
            int EmailAddressID = Convert.ToInt32(txtEAID.Text);


            int affectedRecords = email.Delete(EmailAddressID);

            //int x = Convert.ToInt32(txtID.Text);
            if (affectedRecords > 0)
            {
                Response.Redirect("WebForm1.aspx?PersonID=" + txtID.Text);
            }
           
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtID.Text);
            Response.Redirect("WebForm1.aspx?PersonID=" + x + "");
        }
        
    }
}