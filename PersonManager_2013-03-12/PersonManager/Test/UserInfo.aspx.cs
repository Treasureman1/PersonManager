using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjects;
using System.Data;
using System.Web.UI.HtmlControls;

namespace Test
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Mode"] == null)
                {
                     Response.Redirect("UserInfo.aspx?Mode=New");
                }
                if (Request.QueryString != null)
                {
                    txtID.Enabled = false;
                    txtUID.Enabled = false;
                   
                    string mode = Request.QueryString["Mode"];
                    switch (mode)
                    {
                        case "View":

                            break;

                        case "New":

                            btnSave.Visible = true;
                           

                            btnEdit.Visible = false;
                            break;

                        case "Edit":

                            int x = Convert.ToInt32(Request.QueryString["UserID"]);
                            loadPerson(x);
                            loadUser(x);
                            txtID.Text = x.ToString();
                  
                            break;
                    }
                    if (Request.QueryString["UserID"] != null)
                    {

                        int PersonID = Convert.ToInt32(Request.QueryString["UserID"]);
                        int UserID = Convert.ToInt32(Request.QueryString["UserID"]);
                        BusinessObjects.Person person = new BusinessObjects.Person(PersonID);
                        BusinessObjects.User user = new BusinessObjects.User(UserID);

                        txtFirstName.Enabled = false;
                        txtLastName.Enabled = false;
                        txtTitle.Enabled = false;
                        txtUsername.Enabled = false;
                        txtPassword.Enabled = false;
                        btnSave.Visible = false;

                    }

                   if (Request.QueryString["UserID"] == null)
                    {
                       //   Request.QueryString["Mode"] = "New";
                        //Response.Redirect("UserInfo.aspx?Mode=New");
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            //DataPortal.PersonPhoneData ppd = new DataPortal.PersonPhoneData();
            //DataSet ds = new DataSet();
            //DataPortal.PersonData pd = new DataPortal.PersonData();
            
            switch (Request.QueryString["Mode"])
            {

                case "New":                  

                   BusinessObjects.User user = new BusinessObjects.User();
                        //set all of the properties of the user object then call the user.save     
                   user.Title = txtTitle.Text;
                   user.FirstName = txtFirstName.Text;
                   user.LastName = txtLastName.Text;    
                   user.Password = txtPassword.Text;
                   user.Username = txtUsername.Text;
                   user.UserExists = true;
                  
                   user.Save();
                   txtUsername.Enabled = false;
                   txtPassword.Enabled = false;
                   txtTitle.Enabled = false;
                   txtFirstName.Enabled = false;
                   txtLastName.Enabled = false;
                   btnEdit.Visible = true;
                   btnSave.Visible = false;

                   //// txtID.Text = user.id.ToString();
                    txtUID.Text = user.ID.ToString();
                    int x = user.id;
                    Response.Redirect("UserInfo.aspx?Mode=Edit&UserID=" + x);
                    break;                    

                case "Edit":

                   // x = Convert.ToInt32(txtID.Text);
                    
                    user = new BusinessObjects.User();
                    user.id = Convert.ToInt32(txtID.Text);  
                    user.Title = txtTitle.Text;
                    user.FirstName = txtFirstName.Text;
                    user.LastName = txtLastName.Text;
                    user.Password = txtPassword.Text;
                    user.Username = txtUsername.Text;
                    user.UserExists = true;

                    user.Save();
                    btnEdit.Visible = true;
                    btnSave.Visible = false;
                    textDisable();

                  break;

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            btnEdit.Visible = false;
            btnSave.Visible = true;
             txtPassword.Enabled = true;
            txtUsername.Enabled = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtTitle.Enabled = true;          
                  
        }

        public void loadPerson(int id)
        {

            BusinessObjects.Person person = new BusinessObjects.Person(id);
            person.id = id;
            DataSet ds = new DataSet();

            txtTitle.Text = person.Title.ToString();
            txtFirstName.Text = person.FirstName.ToString();
            txtLastName.Text = person.LastName.ToString();

            
            //txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
            //txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
            //txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
           
            //DataPortal.PersonData pd = new DataPortal.PersonData();
            //DataSet pds = new DataSet();
            //int PersonID = id;
            //pds = pd.Fetch(PersonID);
            //object t = pds.Tables[0].Rows[0]["Title"].ToString();
            //object fn = pds.Tables[0].Rows[0]["FirstName"].ToString();
            //object ln = pds.Tables[0].Rows[0]["LastName"].ToString();
            //txtTitle.Text = t.ToString();
            //txtFirstName.Text = fn.ToString();
            //txtLastName.Text = ln.ToString();
            //txtID.Text = PersonID.ToString();

        }

        public void loadUser(int id)
        {
            BusinessObjects.User user = new BusinessObjects.User(id);
            DataSet ds = new DataSet();

            user.id = id;
            txtUID.Text = user.id.ToString();
            txtUsername.Text = user.Username.ToString();
            txtPassword.Text = user.Password.ToString();


            //txtUID.Text = ds.Tables[0].Rows[0]["UserID"].ToString();
            //txtUsername.Text = ds.Tables[0].Rows[0]["Username"].ToString();
            //txtPassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
           
            
            
            
            
            
            
            //DataPortal.UserData ud = new DataPortal.UserData();
            //DataSet ds = new DataSet();
            //int UserID = id;
            //ds = ud.Fetch(UserID);

            //object uid = ds.Tables[0].Rows[0]["UserID"].ToString();
            //object un = ds.Tables[0].Rows[0]["Username"].ToString();
            //object pw = ds.Tables[0].Rows[0]["Password"].ToString();

            //txtUID.Text = uid.ToString();
            //txtUsername.Text = un.ToString();
            //txtPassword.Text = pw.ToString();

        }

        public void textDisable()
        {

            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtTitle.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;

        }
    }
}