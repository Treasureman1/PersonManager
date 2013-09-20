Public Class FindPersonAddresses
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

        Protected Sub lnkNewPerson_Click(sender As Object, e As EventArgs) Handles lnkNewPerson.Click

        Response.Redirect("EditPersonAddresses.aspx?Mode=New")

        End Sub

        Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

            'Dim da As New DataAccess_OLD
            Dim da As New DataManager.DataAccess()
        Dim dsPersonAddresses As DataSet

            'dsPersons = da.FindPersons(txtFirstName.Text.Trim, txtLastName.Text.Trim)
        dsPersonAddresses = da.FetchPersonAddresses()   'txtPersonID.Text.Trim, txtAddressID.Text.Trim

        gvPersonAddresses.DataSource = dsPersonAddresses
        gvPersonAddresses.DataBind()

        End Sub

        Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'txtFirstName.Text = ""
        'txtLastName.Text = ""
        txtPersonID.Text = ""
        txtAddressID.Text = ""
        txtAddressTypeID.Text = ""
        txtDescription.Text = ""
        txtNotes.Text = ""

        gvPersonAddresses.DataSource = Nothing
        gvPersonAddresses.DataBind()

        End Sub

    Private Sub gvPersonAddresses_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPersonAddresses.RowCommand

        Select Case e.CommandName

            Case "View"

                Response.Redirect("EditPersonAddresses.aspx?Mode=View&PersonID=" & e.CommandArgument)

            Case "Edit"

                Response.Redirect("EditPersonAddresses.aspx?Mode=Edit&PersonID=" & e.CommandArgument)

            Case "Delete"

                Response.Redirect("EditPersonAddresses.aspx?Mode=Delete&PersonID=" & e.CommandArgument)

        End Select

    End Sub

    Private Sub gvPersonAddresses_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPersonAddresses.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim dr As DataRow = CType(CType(e.Row.DataItem, DataRowView).Row, DataRow)
            Dim lblPersonID As Label = e.Row.FindControl("lblPersonID")
            Dim lblAddressID As Label = e.Row.FindControl("lblAddressID")
            Dim lblAddressTypeID As Label = e.Row.FindControl("lblAddressTypeID")
            Dim lblDescription As Label = e.Row.FindControl("lblDescription")
            Dim lblNotes As Label = e.Row.FindControl("lblNotes")
            Dim btnView As LinkButton = e.Row.FindControl("btnView")
            Dim btnEdit As LinkButton = e.Row.FindControl("btnEdit")
            Dim btnDelete As LinkButton = e.Row.FindControl("btnDelete")

            lblPersonID.Text = dr("PersonID")
            lblAddressID.Text = dr("AddressID")
            lblAddressTypeID.Text = dr("AddressTypeID")
            lblDescription.Text = dr("Description")
            lblNotes.Text = dr("Notes")

            btnView.CommandArgument = dr("PersonID")
            btnEdit.CommandArgument = dr("PersonID")
            btnDelete.CommandArgument = dr("PersonID")

        End If

    End Sub


    Protected Sub gvPersonAddresses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvPersonAddresses.SelectedIndexChanged

    End Sub
End Class