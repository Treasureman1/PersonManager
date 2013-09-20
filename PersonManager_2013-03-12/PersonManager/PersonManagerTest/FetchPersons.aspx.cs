using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PersonManagerTest
{
    public partial class FetchPersons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataManager.DataAccess da = new DataManager.DataAccess();
            DataSet dsPersons = new DataSet();

            dsPersons = da.FetchPersons();
            gvPersonName.DataSource = dsPersons;
            gvPersonName.DataBind();

        }

        protected void gvPersonName_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPersonName.PageIndex = e.NewPageIndex;
            gvPersonName.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertPerson.aspx");
        }
       
        protected void gvPersonName_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) //Row databound gets added for every row that gets added to the database. 
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;  //equivelent to CType this is a coonversoin.   Cast this as a data row view, we have to cast this. 
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
    }
}