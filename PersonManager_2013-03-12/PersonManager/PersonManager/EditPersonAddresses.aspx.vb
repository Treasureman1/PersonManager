Public Class EditPersonAddresses
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then

            If Request.QueryString.HasKeys Then

                Select Case Request.QueryString.Item("Mode")

                    Case "View"

                        'btnDone.Visible = True
                        'btnSave.Visible = False
                        'btnDelete.Visible = False

                        LoadPersonAddresses()

                        txtPersonID.Enabled = False
                        'txtFirstName.Enabled = False
                        'txtLastName.Enabled = False
                        txtAddressID.Enabled = False
                        txtAddressTypeID.Enabled = False
                        txtDescription.Enabled = False
                        txtNotes.Enabled = False
                    Case "New"

                        btnDone.Visible = False
                        btnSave.Visible = True
                        btnDelete.Visible = False

                        'txtPersonID.Enabled = False
                        'txtFirstName.Enabled = True
                        'txtLastName.Enabled = True

                        txtPersonID.Text = ""
                        'txtFirstName.Text = ""
                        'txtLastName.Text = ""
                        txtAddressID.Text = ""
                        txtAddressTypeID.Text = ""
                        txtDescription.Text = ""
                        txtNotes.Text = ""

                    Case "Edit"

                        btnDone.Visible = False
                        btnSave.Visible = True
                        btnDelete.Visible = False

                        LoadPersonAddresses()

                        txtPersonID.Enabled = False
                        'txtFirstName.Enabled = True
                        'txtLastName.Enabled = True
                        txtAddressID.Enabled = True
                        txtAddressTypeID.Enabled = True
                        txtDescription.Enabled = True
                        txtNotes.Enabled = True

                    Case "Delete"

                        btnDone.Visible = False
                        btnSave.Visible = False
                        btnDelete.Visible = True

                        LoadPersonAddresses()

                        txtPersonID.Enabled = False
                        'txtFirstName.Enabled = False
                        'txtLastName.Enabled = False
                        txtAddressID.Enabled = False
                        txtAddressTypeID.Enabled = False
                        txtDescription.Enabled = False
                        txtNotes.Enabled = False


                End Select

            Else

                Response.Redirect("FindPersonAddresses.aspx")

            End If

        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Select Case Request.QueryString.Item("Mode")

            Case "New"

                'Dim firstName As String = txtFirstName.Text
                'Dim lastName As String = txtLastName.Text
                Dim PersonID As Integer = txtPersonID.Text
                Dim Address As String = txtAddressID.Text
                Dim AddressType As String = txtAddressTypeID.Text
                Dim Description As String = txtDescription.Text
                Dim Notes As String = txtNotes.Text


                'Dim da As New DataAccess_OLD
                Dim da As New DataManager.DataAccess()

                da.InsertPersonAddress(PersonID, Address, AddressType, Description, Notes)

                Response.Redirect("FindPersonAddresses.aspx")

            Case "Edit"

                'Dim personID As Integer = CInt(txtPersonID.Text)
                'Dim firstName As String = txtFirstName.Text
                'Dim lastName As String = txtLastName.Text
                Dim PersonID As Integer = txtPersonID.Text
                Dim AddressID As Integer = txtAddressID.Text
                Dim AddressType As String = txtAddressTypeID.Text
                Dim Description As String = txtDescription.Text
                Dim Notes As String = txtNotes.Text

                'Dim da As New DataAccess_OLD
                Dim da As New DataManager.DataAccess()

                da.UpdatePersonAddress(PersonID, AddressID, AddressType, Description, Notes)

                Response.Redirect("FindPersonAddresses.aspx")

        End Select

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Response.Redirect("FindPersonAddresses.aspx")

    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim personID As Integer = CInt(txtPersonID.Text)
        'Dim da As New DataAccess_OLD
        Dim da As New DataManager.DataAccess()

        da.DeletePerson(personID)

        Response.Redirect("FindPersonAddresses.aspx")

    End Sub

    Protected Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click

        Response.Redirect("FindPersonAddresses.aspx")

    End Sub

    Private Sub LoadPersonAddresses()

        Dim personID As Integer = CInt(Request.QueryString.Item("PersonID"))
        'Dim da As New DataAccess_OLD
        Dim da As New DataManager.DataAccess()
        Dim ds As DataSet

        ds = da.FetchPersonAddresses(personID)

        txtPersonID.Text = ds.Tables(0).Rows(0).Item("PersonID")
        txtAddressID.Text = ds.Tables(0).Rows(0).Item("AddressID")
        txtAddressID.Text = ds.Tables(0).Rows(0).Item("AddressID")
        txtAddressTypeID.Text = ds.Tables(0).Rows(0).Item("AddressTypeID")
        txtDescription.Text = ds.Tables(0).Rows(0).Item("Description")
        txtNotes.Text = ds.Tables(0).Rows(0).Item("Notes")

        'txtFirstName.Text = ds.Tables(0).Rows(0).Item("FirstName")
        'txtLastName.Text = ds.Tables(0).Rows(0).Item("LastName")

    End Sub



End Class