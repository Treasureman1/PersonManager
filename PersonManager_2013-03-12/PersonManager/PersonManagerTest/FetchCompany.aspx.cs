using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PersonManagerTest
{
    public partial class FetchCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            keywordSearch();

            if (!IsPostBack)
            {


                if (Request.QueryString["CompanyID"] != null)
                {
                    txtID.Text = Request.QueryString["CompanyID"].ToString();
                    //
                }
            }
        }
        protected void gvCompanyKeywords_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a conversoin.   Cast this as a data row view, we have to cast this. 
                DataRow dr = (DataRow)drv.Row;
                Label lblCompanyID = (Label)e.Row.FindControl("lblCompanyID");
                Label lblName = (Label)e.Row.FindControl("lblName");
                LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");

                lblCompanyID.Text = dr["CompanyID"].ToString();
                lblName.Text = dr["Name"].ToString();


                btnView.CommandArgument = dr["CompanyID"].ToString();
                btnEdit.CommandArgument = dr["CompanyID"].ToString();
                btnDelete.CommandArgument = dr["CompanyID"].ToString();
            }
        }

        protected void gvCompanyKeywords_PageIndexChanging3(object sender, GridViewPageEventArgs e)
        {
            gvCompanyName.PageIndex = e.NewPageIndex;
            gvCompanyName.DataBind();
        }

        protected void gvCompanyKeywords_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //If e.CommandName.Equals("Expand") Then   ' your code.End If
            switch (e.CommandName)
            {
                case "Edit":

                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    Response.Redirect("EditCompany.aspx?Mode=Edit&CompanyID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditCompany.aspx?Mode=View&CompanyID=" + e.CommandArgument);
                    break;


                case "Delete":

                    // Call the method to sort the list.
                    Response.Redirect("EditCompany.aspx?Mode=Delete&CompanyID=" + e.CommandArgument);
                    break;

                default:

                    break;

            }
        }

        protected void gvCompanyName_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a conversoin.   Cast this as a data row view, we have to cast this. 
                DataRow dr = (DataRow)drv.Row;
                Label lblCompanyID = (Label)e.Row.FindControl("lblCompanyID");
                Label lblName = (Label)e.Row.FindControl("lblName");
                LinkButton btnView = (LinkButton)e.Row.FindControl("btnView");
                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
                LinkButton btnDelete = (LinkButton)e.Row.FindControl("btnDelete");

                lblCompanyID.Text = dr["CompanyID"].ToString();
                lblName.Text = dr["Name"].ToString();


                btnView.CommandArgument = dr["CompanyID"].ToString();
                btnEdit.CommandArgument = dr["CompanyID"].ToString();
                btnDelete.CommandArgument = dr["CompanyID"].ToString();
            }
        }

        protected void gvCompanyName_PageIndexChanging2(object sender, GridViewPageEventArgs e)
        {
            gvCompanyName.PageIndex = e.NewPageIndex;

            gvCompanyName.DataBind();
        }

        protected void gvCompanyName_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            //If e.CommandName.Equals("Expand") Then   ' your code.End If
            switch (e.CommandName)
            {
                case "Edit":

                    // Call the method to sort the list.Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)
                    Response.Redirect("EditCompany.aspx?Mode=Edit&CompanyID=" + e.CommandArgument);
                    break;

                case "View":

                    // Call the method to sort the list.
                    Response.Redirect("EditCompany.aspx?Mode=View&CompanyID=" + e.CommandArgument);
                    break;


                case "Delete":

                    // Call the method to sort the list.
                    Response.Redirect("EditCompany.aspx?Mode=Delete&CompanyID=" + e.CommandArgument);
                    break;

                default:

                    break;

            }
        }

        private void keywordSearch()
        {
            if (radioSearch.Checked == true)
            {
                cbAddress.Visible = false;
                cbAreaCode.Visible = false;
                cbCompany.Visible = false;
                cbPhone.Visible = false;
                cbZip.Visible = false;
            }
            if (radioAdvanced.Checked == true)
            {
                cbAddress.Visible = true;
                cbAreaCode.Visible = true;
                cbCompany.Visible = true;
                cbPhone.Visible = true;
                cbZip.Visible = true;
            }
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                DataManager.DataAccess da = new DataManager.DataAccess();
                DataSet dsCompanies = new DataSet();
                int CompanyID = Convert.ToInt32(txtID.Text);

                dsCompanies = da.FetchCompany(CompanyID);
                gvCompanyName.DataSource = dsCompanies;
                gvCompanyName.DataBind();

            }

            else
            {
                DataManager.DataAccess da = new DataManager.DataAccess();
                DataSet dsCompanies = new DataSet();

                String Name = txtName.Text;
                dsCompanies = da.FetchCompany(Name);
                gvCompanyName.DataSource = dsCompanies;
                gvCompanyName.DataBind();

                //dsPersons = da.FetchPerson(txtFirstName.Text.Trim(), txtLastName.Text.Trim());
                //gvPersonName.DataSource = dsPersons;
                //gvPersonName.DataBind();

            }
        }

        protected void btnAddCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCompany.aspx?Mode=New");
        }

        protected void btnSearchCompanyKeywords_Click(object sender, EventArgs e)
        {
            if (txtCompanyKeywords.Text != "")
            {

                if (radioSearch.Checked == true)
                {
                    DataManager.DataAccess da = new DataManager.DataAccess();
                    DataSet dsCompanies = new DataSet();
                    // int CompanyID = Convert.ToInt32(txtID.Text);
                   

                    string KeywordValue = txtCompanyKeywords.Text;
                    dsCompanies = da.FetchCompanyKeywords(KeywordValue);
                    gvCompanyName.DataSource = dsCompanies;
                    gvCompanyName.DataBind();

                }

            
            if (radioAdvanced.Checked == true)
            {
                String KeywordValue = txtCompanyKeywords.Text;
                bool cCompany;
                bool cAddress;
                bool cZip;
                bool cPhoneNumber;
                bool cAreaCode;

                if (cbPhone.Checked == true)
                {
                    cPhoneNumber = true;
                }
                else
                {
                    cPhoneNumber = false;
                }
                if (cbPhone.Checked == false)
                {
                    cPhoneNumber = false;
                }
                else
                {
                    cPhoneNumber = true;
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
                    cPhoneNumber = false;
                }
                else
                {
                    cAreaCode = true;
                }

                if (cbCompany.Checked == true)
                {
                    cCompany = true;
                }
                else
                {
                    cCompany = false;
                }

                if (cbCompany.Checked == false)
                {
                    cCompany = false;
                }
                else
                {
                    cCompany = true;
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
                        cCompany = true;
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
                        DataManager.DataAccess da = new DataManager.DataAccess();
                        DataSet dsCompanies = new DataSet();

                        // String Name = txtCompanyKeywords.Text;
                        dsCompanies = da.FetchCompanyKeywords(KeywordValue, cCompany, cAddress, cZip, cAreaCode, cPhoneNumber);
                        gvCompanyName.DataSource = dsCompanies;
                        gvCompanyName.DataBind();
                    }
            }
        

                    if (txtCompanyKeywords.Text == "")
                    {
                        //I have to make the search
                        // I have to make the advancedSearch
                        if (radioSearch.Checked == true)
                        {
                            DataManager.DataAccess da = new DataManager.DataAccess();
                            DataSet dsCompanies = new DataSet();

                            String KeywordValue = txtCompanyKeywords.Text;
                            dsCompanies = da.FetchCompanyKeywords(KeywordValue);
                            gvCompanyName.DataSource = dsCompanies;
                            gvCompanyName.DataBind();
                        }

                        if (radioAdvanced.Checked == true)
                        {
                            DataManager.DataAccess da = new DataManager.DataAccess();
                            DataSet dsCompanies = new DataSet();
                            bool cCompany;
                            bool cAddress;
                            String KeywordValue = txtCompanyKeywords.Text;
                            bool cZip;
                            bool cAreaCode;
                            bool cPhoneNumber;


                            if (cbPhone.Checked == true)
                            {
                                cPhoneNumber = true;
                            }
                            else
                            {
                                cPhoneNumber = false;
                            }
                            if (cbPhone.Checked == false)
                            {
                                cPhoneNumber = false;
                            }
                            else
                            {
                                cPhoneNumber = true;
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
                                cPhoneNumber = false;
                            }
                            else
                            {
                                cAreaCode = true;
                            }

                            if (cbCompany.Checked == true)
                            {
                                cCompany = true;
                            }
                            else
                            {
                                cCompany = false;
                            }
                            if (cbAddress.Checked == true)
                            {
                                cAddress = true;
                            }
                            else
                            {

                                cAddress = false;
                            }

                            if (cbZip.Checked == true)
                            {
                                cZip = true;
                            }
                            else
                            {
                                cZip = false;
                            }


                          
                        
                            dsCompanies = da.FetchCompanyKeywords(KeywordValue, cCompany, cAddress, cZip, cAreaCode, cPhoneNumber);
                            gvCompanyName.DataSource = dsCompanies;
                            gvCompanyName.DataBind();
   
                        }
                    }

                 
                }






            }
        }
    
//I want the notes of the company to use a wildcard "*/JVC/"" so the it will search the notepad for any of the keywords in the notes
//for instance say you sell a "widget" and you need to re order one, but you want a list of all of the companies that have the word widget
// in the notes (this is under the assumption that you include all of the name brands, or model numbers that you sell from that company
// in the notes section. 