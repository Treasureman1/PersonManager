using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PersonManagerTest
{
    public partial class FetchPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (radioAdvanced.Checked == true)
            {
                cbAddress.Visible = true;
                cbAreaCode.Visible = true;
                cbEmail.Visible = true;
                cbName.Visible = true;
                cbPhoneNumber.Visible = true;
                cbZip.Visible = true;
            }
            if (radioSearch.Checked == true)
            {
                cbAddress.Visible = false;
                cbAreaCode.Visible = false;
                cbEmail.Visible = false;
                cbName.Visible = false;
                cbPhoneNumber.Visible = false;
                cbZip.Visible = false;
            }
            if (Request.QueryString["PersonID"] != null)
            {
                txtID.Text = Request.QueryString["PersonID"].ToString();
                //

            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {

            if (txtID.Text != "")
            {
                DataManager.DataAccess da = new DataManager.DataAccess();
                DataSet dsPersons = new DataSet();
                int PersonID = Convert.ToInt32(txtID.Text);

                dsPersons = da.FetchPerson(PersonID);
                gvPersonName.DataSource = dsPersons;
                gvPersonName.DataBind();

            }

            else
            {
                DataManager.DataAccess da = new DataManager.DataAccess();
                DataSet dsPersons = new DataSet();

                dsPersons = da.FetchPerson(txtFirstName.Text.Trim(), txtLastName.Text.Trim());
                gvPersonName.DataSource = dsPersons;
                gvPersonName.DataBind();

            }
        }

        protected void gvPersonName_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a conversoin.   Cast this as a data row view, we have to cast this. 
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

        protected void gvPersonName_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            gvPersonName.PageIndex = e.NewPageIndex;
            DataManager.DataAccess da = new DataManager.DataAccess();
            DataSet dsPersons = new DataSet();

            dsPersons = da.FetchPerson(txtFirstName.Text.Trim(), txtLastName.Text.Trim());
            gvPersonName.DataSource = dsPersons;
            gvPersonName.DataBind();
        }

        protected void gvPersonName_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //If e.CommandName.Equals("Expand") Then   ' your code.End If
            switch (e.CommandName)
            {
                case "Edit":

                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditPerson.aspx?Mode=View&PersonID=" + e.CommandArgument);
                    break;


                case "Delete":

                    // Call the method to sort the list.
                    Response.Redirect("EditPerson.aspx?Mode=Delete&PersonID=" + e.CommandArgument);
                    break;

                default:

                    break;

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            Response.Redirect("EditPerson.aspx?Mode=New");
        }



        public void SearchPersonFunction()
        {
            DataManager.DataAccess da = new DataManager.DataAccess();
            DataSet dsPersons = new DataSet();
            int PersonID = Convert.ToInt32(txtID.Text);

            dsPersons = da.FetchPerson(PersonID);
            gvPersonName.DataSource = dsPersons;
            gvPersonName.DataBind();
        }

        protected void btnSearchPersonKeywords_Click(object sender, EventArgs e)
        {
            //if search site is checked then I need to do similar to what is already being done
            //if advanced search is checked, but no boxes are checked, I need to do what is being done here

            if (txtPersonKeywords.Text != "")
            {
                if (radioSearch.Checked == true)
                {
                    DataManager.DataAccess da = new DataManager.DataAccess();
                    DataSet dsPersons = new DataSet();
                    // int CompanyID = Convert.ToInt32(txtID.Text);

                    String KeywordValue = txtPersonKeywords.Text;
                    dsPersons = da.FetchPersonKeywords(KeywordValue);
                    gvPersonName.DataSource = dsPersons;
                    gvPersonName.DataBind();
                }

                if (radioAdvanced.Checked == true)
                {
                    String KeywordValue = txtPersonKeywords.Text;
                    bool cName;
                    bool cAreaCode;
                    bool cPhoneNumber;
                    bool cAddress;
                    bool cZip;
                    bool cEmail;

                    if (cbEmail.Checked == true)
                    {
                        cEmail = true;
                    }
                    else
                    {
                        cEmail = false;
                    }
                    if (cbEmail.Checked == false)
                    {
                        cEmail = false;
                    }
                    else
                    {
                        cEmail = true;
                    }

                    if (cbName.Checked == true)
                    {
                        cName = true;
                    }
                    else
                    {
                        cName = false;
                    }
                    if (cbName.Checked == false)
                    {
                        cName = false;
                    }
                    else
                    {
                        cName = true;
                    }
                    

                    if (cbAreaCode.Checked == true)
                    {
                        cAreaCode = true;
                    }
                    else
                    {
                        cAreaCode = false;
                    }
                    if (cbAreaCode.Checked == false)
                    {
                        cAreaCode = false;
                    }
                    else
                    {
                        cAreaCode = true;
                    }

                    if (cbPhoneNumber.Checked == true)
                    {
                        cPhoneNumber = true;
                    }
                    else
                    {
                        cPhoneNumber = false;
                    }

                    if (cbPhoneNumber.Checked == false)
                    {
                        cPhoneNumber = false;
                    }

                    else
                    {
                        cPhoneNumber = true;
                    }


                    if (cbAddress.Checked == true)
                    {
                        cAddress = true;
                    }
                    else
                    {
                        cAddress = false;
                    }

                    if (cbAddress.Checked == false)
                    {
                        cAddress = false;
                    }

                    else
                    {
                        cAddress = true;
                    }


                    if (cbZip.Checked == true)
                    {
                        cZip = true;
                    }

                    else
                    {
                        cZip = false;
                    }

                    if (cbZip.Checked == false)
                    {
                        cZip = false;
                    }
                    else
                    {
                        cZip = true;
                    }

                    if (cbEmail.Checked == true)
                    {
                        cEmail = true;
                    }
                    else
                    {
                        cEmail = false;
                    }
                    if (cbEmail.Checked == false)
                    {
                        cEmail = false;
                    }
                    else
                    {
                        cEmail = true;
                    }



                    DataManager.DataAccess da = new DataManager.DataAccess();
                    DataSet ds = new DataSet();

                    // String Name = txtCompanyKeywords.Text;
                    ds = da.FetchPersonKeywords(KeywordValue, cName, cAddress, cZip, cAreaCode, cPhoneNumber, cEmail);
                    gvPersonName.DataSource = ds;
                    gvPersonName.DataBind();


                }
            }


        }
    }
}