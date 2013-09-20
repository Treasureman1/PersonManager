Public Class FindPerson
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub lnkNewPerson_Click(sender As Object, e As EventArgs) Handles lnkNewPerson.Click

        Response.Redirect("EditPerson.aspx?Mode=New")

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        'Dim da As New DataAccess_OLD
        Dim da As New DataManager.DataAccess()
        Dim dsPersons As DataSet

        'dsPersons = da.FindPersons(txtFirstName.Text.Trim, txtLastName.Text.Trim)
        dsPersons = da.FetchPerson(txtFirstName.Text.Trim, txtLastName.Text.Trim)

        gvPersons.DataSource = dsPersons
        gvPersons.DataBind()

    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        txtFirstName.Text = ""
        txtLastName.Text = ""

        gvPersons.DataSource = Nothing
        gvPersons.DataBind()

    End Sub

    Private Sub gvPersons_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPersons.RowCommand

        Select Case e.CommandName

            Case "View"

                Response.Redirect("EditPerson.aspx?Mode=View&PersonID=" & e.CommandArgument)

            Case "Edit"

                Response.Redirect("EditPerson.aspx?Mode=Edit&PersonID=" & e.CommandArgument)

            Case "Delete"

                Response.Redirect("EditPerson.aspx?Mode=Delete&PersonID=" & e.CommandArgument)

        End Select

    End Sub

    Private Sub gvPersons_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPersons.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim dr As DataRow = CType(CType(e.Row.DataItem, DataRowView).Row, DataRow)
            Dim lblPersonID As Label = e.Row.FindControl("lblPersonID")
            Dim lblFirstName As Label = e.Row.FindControl("lblFirstName")
            Dim lblLastName As Label = e.Row.FindControl("lblLastName")
            Dim btnView As LinkButton = e.Row.FindControl("btnView")
            Dim btnEdit As LinkButton = e.Row.FindControl("btnEdit")
            Dim btnDelete As LinkButton = e.Row.FindControl("btnDelete")

            lblPersonID.Text = dr("PersonID")
            lblFirstName.Text = dr("FirstName")
            lblLastName.Text = dr("LastName")

            btnView.CommandArgument = dr("PersonID")
            btnEdit.CommandArgument = dr("PersonID")
            btnDelete.CommandArgument = dr("PersonID")

        End If

    End Sub

   
    
End Class