using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Test
{
    public partial class TelephoneForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataManager.DataAccess da = new DataManager.DataAccess();

                DataSet dsPhoneTypes = da.FetchPhoneTypes();

                ddlPhoneTypeID.DataSource = dsPhoneTypes.Tables[0];

              // ddlPhoneTypeID.Items.Add(New ListItem("", ""));
               
                 ddlPhoneTypeID.DataTextField = "Name";

                ddlPhoneTypeID.DataValueField = "PhoneTypeID";

                ddlPhoneTypeID.DataBind();
         //       ddlPhoneTypeID.Items.Add(new ListItem("Please Select Phone Type", ""));
               
               ddlPhoneTypeID.Items.Insert(0, new ListItem("PLEASE SELECT PHONE TYPE", string.Empty));

          //      DataPortal.PersonPhoneData ppd = new DataPortal.PersonPhoneData();

                BusinessObjects.PersonPhone pp = new BusinessObjects.PersonPhone();
                DataSet ds2 = new DataSet();
                                              
                if (Request.QueryString["Mode"] == null)
                {
                    Request.QueryString["Mode"] = "New";                   
                }

                if (Request.QueryString["PersonID"] != null)
                {
                    txtID.Text = Request.QueryString["PersonID"].ToString();
                    lblID.Text = Request.QueryString["PersonID"].ToString();
                }

                if (Request.QueryString["phoneID"] != null)
                {

                    txtPHID.Text = Request.QueryString["phoneID"].ToString();
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
                            txtPHTID.Visible = false;
                            btnDelete.Visible = false;
                            break;

                        case "Edit":

                            btnSave.Visible = true;
                            txtID.Enabled = false;
                            int id = Convert.ToInt32(txtID.Text);
                            BusinessObjects.Person person = new BusinessObjects.Person(id);
                          
                            DataSet ds = new DataSet();
                          //  id = Convert.ToInt32(txtID.ToString());
                             person.Fetch(id);
                             person.id = id;
                             object t = person.Title.ToString();
                            object fn = person.FirstName.ToString();
                            object ln = person.LastName.ToString();

                            lblFirstName.Text = fn.ToString();
                            lblLastName.Text = ln.ToString();

                            int PhoneID = Convert.ToInt32(txtPHID.Text);
                            BusinessObjects.PersonPhone personPhone = new BusinessObjects.PersonPhone(id, PhoneID);
                            id = Convert.ToInt32(lblID.Text);
                            int PersonID = id;
                            

                           ds = personPhone.Fetch(PersonID, PhoneID);
                         // object pid = personPhone.PhoneID.ToString();
   //                  object ac = personPhone.AreaCode.ToString();
                     object ac = ds.Tables[0].Rows[0]["AreaCode"].ToString();
                     object pn = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                     object ex = ds.Tables[0].Rows[0]["Extension"].ToString();

                     object d = ds.Tables[0].Rows[0]["Description"].ToString();
                     object n = ds.Tables[0].Rows[0]["Notes"].ToString();
                     object ptid = ds.Tables[0].Rows[0]["PhoneTypeID"].ToString();
                       txtAreaCode.Text = ac.ToString();
                       txtPhoneNumber.Text = pn.ToString();
                       txtExtension.Text = ex.ToString();
                       txtDescription.Text = d.ToString();
                       txtNotes.Text = n.ToString();
                       txtPHTID.Text = ptid.ToString();
                   ddlPhoneTypeID.Text = ptid.ToString();
                object dc = ds.Tables[0].Rows[0]["DoNotCall"].ToString();
                object dt = ds.Tables[0].Rows[0]["DoNotText"].ToString();

                   cbDNT.Checked = Convert.ToBoolean(dt.ToString());
                    cbDNC.Checked = Convert.ToBoolean(dc.ToString());

                    btnDelete.Visible = false;


                            //                    txtDescription.Text = d.ToString();
                            //                    txtNotes.Text = n.ToString();

                            //                    cbDNT.Checked = Convert.ToBoolean(dt.ToString());
                            //                    cbDNC.Checked = Convert.ToBoolean(dc.ToString());
                            //                   // ddlPhoneTypeID.SelectedIndex = 0;
                            //                    btnDelete.Visible = false;


                            //First create a DataSet that returns, equals person.Fetch(PersonID) as 

                            
/////////////////////////////////OLD CODE Start
//                            DataPortal.PersonData pd = new DataPortal.PersonData();
//                    DataSet pds = new DataSet();
//        O            int PersonID = Convert.ToInt32(txtID.Text);   ///
//        L            pds = pd.Fetch(PersonID);
//        D            object fn = pds.Tables[0].Rows[0]["FirstName"].ToString();
//                    object ln = pds.Tables[0].Rows[0]["LastName"].ToString();
//        C            lblFirstName.Text = fn.ToString();  ///
//         O           lblLastName.Text = ln.ToString();  ///
          //D
//           E         ppd = new DataPortal.PersonPhoneData();
//                    DataSet ds = new DataSet();
//                    int PhoneID = Convert.ToInt32(txtPHID.Text);  ///
//                    ds = ppd.Fetch(PersonID, PhoneID);
//                    object pid = ds.Tables[0].Rows[0]["PhoneID"].ToString();
//                    object ac = ds.Tables[0].Rows[0]["AreaCode"].ToString();
//                    object pn = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
//                    object ex = ds.Tables[0].Rows[0]["Extension"].ToString();
//                    object ptid = ds.Tables[0].Rows[0]["PhoneTypeID"].ToString();
                    
//                    txtPHID.Text = pid.ToString();
//                    txtAreaCode.Text = ac.ToString();
//                    txtPhoneNumber.Text = pn.ToString();
//                    txtExtension.Text = ex.ToString();
//                    txtPHTID.Text = ptid.ToString();
//                    txtPHTID.Visible = false;
//                    ddlPhoneTypeID.Text = ptid.ToString();

//                    object d = ds.Tables[0].Rows[0]["Description"].ToString();
//                    object n = ds.Tables[0].Rows[0]["Notes"].ToString();
//                    object dc = ds.Tables[0].Rows[0]["DoNotCall"].ToString();
//                    object dt = ds.Tables[0].Rows[0]["DoNotText"].ToString();
//                    txtDescription.Text = d.ToString();
//                    txtNotes.Text = n.ToString();

//                    cbDNT.Checked = Convert.ToBoolean(dt.ToString());
//                    cbDNC.Checked = Convert.ToBoolean(dc.ToString());
//                   // ddlPhoneTypeID.SelectedIndex = 0;
//                    btnDelete.Visible = false;
/////////////////////////////////////////OLD CODE Stop
                            break;

                        case "Delete":

                         btnSave.Visible = false;
                            txtID.Enabled = true;


                             btnSave.Visible = true;
                            txtID.Enabled = false;
                             id = Convert.ToInt32(txtID.Text);
                            person = new BusinessObjects.Person(id);
                          
                           ds = new DataSet();
                          //  id = Convert.ToInt32(txtID.ToString());
                             person.Fetch(id);
                             person.id = id;
                              t = person.Title.ToString();
                           fn = person.FirstName.ToString();
                           ln = person.LastName.ToString();

                            lblFirstName.Text = fn.ToString();
                            lblLastName.Text = ln.ToString();

                            PhoneID = Convert.ToInt32(txtPHID.Text);
                          personPhone = new BusinessObjects.PersonPhone(id, PhoneID);
                            id = Convert.ToInt32(lblID.Text);
                           PersonID = id;
                            

                           ds = personPhone.Fetch(PersonID, PhoneID);
                         // object pid = personPhone.PhoneID.ToString();
   //                  object ac = personPhone.AreaCode.ToString();
                     ac = ds.Tables[0].Rows[0]["AreaCode"].ToString();
                     pn = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    ex = ds.Tables[0].Rows[0]["Extension"].ToString();

                      d = ds.Tables[0].Rows[0]["Description"].ToString();
                      n = ds.Tables[0].Rows[0]["Notes"].ToString();
                    ptid = ds.Tables[0].Rows[0]["PhoneTypeID"].ToString();
                       txtAreaCode.Text = ac.ToString();
                       txtPhoneNumber.Text = pn.ToString();
                       txtExtension.Text = ex.ToString();
                       txtDescription.Text = d.ToString();
                       txtNotes.Text = n.ToString();
                       txtPHTID.Text = ptid.ToString();
                   ddlPhoneTypeID.Text = ptid.ToString();
                 dc = ds.Tables[0].Rows[0]["DoNotCall"].ToString();
                dt = ds.Tables[0].Rows[0]["DoNotText"].ToString();

                   cbDNT.Checked = Convert.ToBoolean(dt.ToString());
                    cbDNC.Checked = Convert.ToBoolean(dc.ToString());

                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    disableForm();

                    //////        pd = new DataPortal.PersonData();
                    //////pds = new DataSet();
                    //////PersonID = Convert.ToInt32(txtID.Text);
      //Fix later              //////pds = pd.Fetch(PersonID);
                    ////// fn = pds.Tables[0].Rows[0]["FirstName"].ToString();
                    //////ln = pds.Tables[0].Rows[0]["LastName"].ToString();
                    //////lblFirstName.Text = fn.ToString();
                    //////lblLastName.Text = ln.ToString();

                    //////ds = new DataSet();
                    ////// PhoneID = Convert.ToInt32(txtPHID.Text);
                    //////ds = ppd.Fetch(PersonID, PhoneID);
                    ////// pid = ds.Tables[0].Rows[0]["PhoneID"].ToString();
                    ////// ac = ds.Tables[0].Rows[0]["AreaCode"].ToString();
                    ////// pn = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    ////// ex = ds.Tables[0].Rows[0]["Extension"].ToString();
                    ////// ptid = ds.Tables[0].Rows[0]["PhoneTypeID"].ToString();
                    
                    //txtPHID.Text = pid.ToString();
                    //txtAreaCode.Text = ac.ToString();
                    //txtPhoneNumber.Text = pn.ToString();
                    //txtExtension.Text = ex.ToString();
                    //txtPHTID.Text = ptid.ToString();
                    //txtPHTID.Visible = false;
                    //ddlPhoneTypeID.Text = ptid.ToString();

                    //txtAreaCode.Enabled = false;
                    //txtPhoneNumber.Enabled = false;
                    //txtExtension.Enabled = false;
                    //txtPHTID.Enabled = false;
                    //ddlPhoneTypeID.Enabled = false;
                    //cbDNC.Enabled = false;
                    //cbDNT.Enabled = false;
                    //txtDescription.Enabled = false;
                    //txtNotes.Enabled = false;

                    // d = ds.Tables[0].Rows[0]["Description"].ToString();
                    // n = ds.Tables[0].Rows[0]["Notes"].ToString();
                    // dc = ds.Tables[0].Rows[0]["DoNotCall"].ToString();
                    //dt = ds.Tables[0].Rows[0]["DoNotText"].ToString();
                    //txtDescription.Text = d.ToString();
                    //txtNotes.Text = n.ToString();

                    //cbDNT.Checked = Convert.ToBoolean(dt.ToString());
                    //cbDNC.Checked = Convert.ToBoolean(dc.ToString());
                            break;

                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
             /////   DataPortal.PersonPhoneData ppd = new DataPortal.PersonPhoneData();
                BusinessObjects.PersonPhone pp = new BusinessObjects.PersonPhone();
                BusinessObjects.Phone ph = new BusinessObjects.Phone();
                BusinessObjects.Person person = new BusinessObjects.Person();

                DataSet ds = new DataSet();
            
            switch (Request.QueryString["Mode"])
            {
                case "Edit":

                   // pp = new BusinessObjects.PersonPhone();
                   pp.PhoneID = Convert.ToInt32(txtPHID.Text);
                        pp.AreaCode = txtAreaCode.Text;
                    pp.PhoneNumber = txtPhoneNumber.Text;
                    pp.Extension = txtExtension.Text;
                    if (ddlPhoneTypeID.SelectedIndex == 0)
                    {
                        ddlPhoneTypeID.SelectedIndex = 1;
                    }
                    pp.PhoneTypeID = Convert.ToInt32(ddlPhoneTypeID.Text);   /// change this to ddlPHoneTypeID
                   // object pid = ph.Save();
                    BusinessObjects.PersonPhone p = new BusinessObjects.PersonPhone();
    
                    pp.PersonID = Convert.ToInt32(lblID.Text);
                    pp.Description = txtDescription.Text;
                    pp.Notes = txtNotes.Text;
                    pp.DoNotCall = cbDNC.Checked;
                    pp.DoNotText = cbDNT.Checked;
                   // PhoneID = Convert.ToInt32(pid.ToString());
                    int PhoneID = Convert.ToInt32(txtPHID.Text);
                    pp.SavePhone();
                    




           // pp.PhoneTypeID = Convert.ToInt32(ddlPhoneTypeID.Text);
            txtPHTID.Enabled = false;
                  


          // pp.PhoneID = Convert.ToInt32(txtPHID.Text);
          // pp.AreaCode = txtAreaCode.Text;
          // pp.PhoneNumber = txtPhoneNumber.Text;
          // pp.Extension = txtExtension.Text;
          // pp.PersonID = Convert.ToInt32(txtID.Text);

          // if (ddlPhoneTypeID.SelectedIndex == 0)
          // {
          //     ddlPhoneTypeID.SelectedIndex = 1;
          // }

          // pp.PhoneTypeID = Convert.ToInt32(ddlPhoneTypeID.Text);

          //          if (cbDNC.Checked == false)
          //  {
          //      cbDNC.Checked = false;  
          //  }
          //  if (cbDNC.Checked == true)
          //  {
          //      cbDNC.Checked = true;
          //  }
          //  if (cbDNT.Checked == false)
          //  {
          //      cbDNT.Checked = false;
          //  }
          //  if (cbDNT.Checked == true)
          //  {
          //      cbDNT.Checked = true;
          //  }

          //  pp.Description = txtDescription.Text;
          //  pp.Notes = txtNotes.Text;
          //pp.DoNotCall = cbDNC.Checked;
          //pp.DoNotText = cbDNT.Checked;
          //int id = Convert.ToInt32(lblID.Text);
          //int PhoneID = Convert.ToInt32(txtPHID.Text);
          //pp.Save();

  ///////                  ppd.UpdatePhoneNumber(PhoneID, AreaCode, PhoneNumber, Extension, PhoneTypeID);
 ////////           ppd.UpdatePersonPhones(PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText);
                    break;

                case "New":
                    //first, try setting all of the values, and then calling the base
                    //.save on the PersonPhone, that will save the base, and the PersonPhones table as well??

                    pp.AreaCode = txtAreaCode.Text;
                    pp.PhoneNumber = txtPhoneNumber.Text;
                    pp.Extension = txtExtension.Text;
                    pp.PhoneTypeID = Convert.ToInt32(ddlPhoneTypeID.Text);   /// change this to ddlPHoneTypeID
                   // object pid = ph.Save();
                   // BusinessObjects.PersonPhone p = new BusinessObjects.PersonPhone();



                   // pp.PersonID = Convert.ToInt32(lblID.Text);
                   // pp.PhoneID = Convert.ToInt32(pid);
                    //pp.phoneID = 
                    pp.PersonID = Convert.ToInt32(lblID.Text);
                    pp.Description = txtDescription.Text;
                    pp.Notes = txtNotes.Text;
                    pp.DoNotCall = cbDNC.Checked;
                    pp.DoNotText = cbDNT.Checked;
                   // PhoneID = Convert.ToInt32(pid.ToString());
                    pp.SavePhone();
                    

            pp.AreaCode = txtAreaCode.Text;
            pp.PhoneNumber = txtPhoneNumber.Text;
            pp.Extension = txtExtension.Text;
            ph.PhoneNumber = txtPhoneNumber.Text;


            if (ddlPhoneTypeID.SelectedIndex == 0)
            {
                ddlPhoneTypeID.SelectedIndex = 1;
            }

           // pp.PhoneTypeID = Convert.ToInt32(ddlPhoneTypeID.Text);
            txtPHTID.Enabled = false;
                    break;

            }

            int x = Convert.ToInt32(txtID.Text);
            
           Response.Redirect("WebForm1.aspx?PersonID=" + x + "");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
            int x = Convert.ToInt32(txtID.Text);
            Response.Redirect("WebForm1.aspx?PersonID=" + x + "");
           
        }

        

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            /////I changed this section, and I am not sure if it is done correctly
            BusinessObjects.PersonPhone pp = new BusinessObjects.PersonPhone();
            int PhoneID = Convert.ToInt32(txtPHID.Text);
            int affectedRecords = pp.Delete(PhoneID);
            //DataPortal.PersonPhoneData ppd = new DataPortal.PersonPhoneData();
            //int PhoneID = Convert.ToInt32(txtPHID.Text);
            //int affectedRecords = ppd.Delete(PhoneID);
            if (affectedRecords > 0)
            {
              //  btnDelete.Attributes.Add("onclick", "if(confirm('Are you sure that you want to delete this comment?'))");
                Response.Redirect("WebForm1.aspx?PersonID=" + txtID.Text);
            }
        }

        private void disableForm()
        {
            txtAreaCode.Enabled = false;
            txtPhoneNumber.Enabled = false;
            txtExtension.Enabled = false;
            txtPHTID.Enabled = false;
            ddlPhoneTypeID.Enabled = false;
            txtNotes.Enabled = false;
            txtDescription.Enabled = false;

        }
    }
}