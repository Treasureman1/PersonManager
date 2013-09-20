Public Class EditPerson
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Request.QueryString.HasKeys Then

                Select Case Request.QueryString.Item("Mode")

                    Case "View"

                        btnDone.Visible = True
                        btnSave.Visible = False
                        btnDelete.Visible = False

                        LoadPerson()

                        txtPersonID.Enabled = False
                        txtFirstName.Enabled = False
                        txtLastName.Enabled = False

                    Case "New"

                        btnDone.Visible = False
                        btnSave.Visible = True
                        btnDelete.Visible = False

                        txtPersonID.Enabled = False
                        txtFirstName.Enabled = True
                        txtLastName.Enabled = True

                        txtPersonID.Text = ""
                        txtFirstName.Text = ""
                        txtLastName.Text = ""

                    Case "Edit"

                        btnDone.Visible = False
                        btnSave.Visible = True
                        btnDelete.Visible = False

                        LoadPerson()

                        txtPersonID.Enabled = False
                        txtFirstName.Enabled = True
                        txtLastName.Enabled = True

                    Case "Delete"

                        btnDone.Visible = False
                        btnSave.Visible = False
                        btnDelete.Visible = True

                        LoadPerson()

                        txtPersonID.Enabled = False
                        txtFirstName.Enabled = False
                        txtLastName.Enabled = False

                End Select

            Else

                Response.Redirect("FindPerson.aspx")

            End If

        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Select Case Request.QueryString.Item("Mode")

            Case "New"

                Dim firstName As String = txtFirstName.Text
                Dim lastName As String = txtLastName.Text

                'Dim da As New DataAccess_OLD
                Dim da As New DataManager.DataAccess()

                da.InsertPerson(firstName, lastName)

                Response.Redirect("FindPerson.aspx")

            Case "Edit"

                Dim personID As Integer = CInt(txtPersonID.Text)
                Dim firstName As String = txtFirstName.Text
                Dim lastName As String = txtLastName.Text

                'Dim da As New DataAccess_OLD
                Dim da As New DataManager.DataAccess()

                da.UpdatePerson(personID, firstName, lastName)

                Response.Redirect("FindPerson.aspx")

        End Select

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Response.Redirect("FindPerson.aspx")

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim personID As Integer = CInt(txtPersonID.Text)
        'Dim da As New DataAccess_OLD
        Dim da As New DataManager.DataAccess()

        da.DeletePerson(personID)

        Response.Redirect("FindPerson.aspx")

    End Sub

    Protected Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click

        Response.Redirect("FindPerson.aspx")

    End Sub

    Private Sub LoadPerson()

        Dim personID As Integer = CInt(Request.QueryString.Item("PersonID"))
        'Dim da As New DataAccess_OLD
        Dim da As New DataManager.DataAccess()
        Dim ds As DataSet

        ds = da.FetchPerson(personID)

        txtPersonID.Text = ds.Tables(0).Rows(0).Item("PersonID")
        txtFirstName.Text = ds.Tables(0).Rows(0).Item("FirstName")
        txtLastName.Text = ds.Tables(0).Rows(0).Item("LastName")

    End Sub

End Class