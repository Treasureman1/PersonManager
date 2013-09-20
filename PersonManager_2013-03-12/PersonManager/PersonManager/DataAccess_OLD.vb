Public Class DataAccess_OLD

    Private _connectionString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=""|DataDirectory|\InventoryDatabase.mdf"";Integrated Security=True;User Instance=True"

#Region "Person"

    Public Function FetchPersons() As DataSet

        Dim ds As New DataSet
        Dim sql As String = "SELECT * FROM Person"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                da.Fill(ds)

            End Using

        End Using

        Return ds

    End Function

    Public Function FetchPerson(PersonID As Integer) As DataSet

        Dim ds As New DataSet
        Dim sql As String = "SELECT * FROM Person WHERE PersonID = @PersonID"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@PersonID", PersonID)

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                da.Fill(ds)

            End Using

        End Using

        Return ds

    End Function

    Public Function FindPersons(FirstName As String, LastName As String) As DataSet

        Dim ds As New DataSet
        Dim sql As String = "SELECT * FROM Person"
        Dim where As String = ""

        If FirstName.Length > 0 OrElse LastName.Length > 0 Then

            If FirstName.Length > 0 Then

                If where.Length > 0 Then

                    where = where & " AND "

                End If

                where = where & "FirstName = @FirstName"

            End If

            If LastName.Length > 0 Then

                If where.Length > 0 Then

                    where = where & " AND "

                End If

                where = where & "LastName = @LastName"

            End If

            If where.Length > 0 Then

                sql = sql & " WHERE " & where

            End If

        End If

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                If sql.Contains("FirstName") Then

                    cmd.Parameters.AddWithValue("@FirstName", FirstName)

                End If

                If sql.Contains("LastName") Then

                    cmd.Parameters.AddWithValue("@LastName", LastName)

                End If

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                da.Fill(ds)

            End Using

        End Using

        Return ds

    End Function

    Public Sub InsertPerson(FirstName As String, LastName As String)

        Dim personID As Integer = 0
        Dim sql As String = "INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName)"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@FirstName", FirstName)
                cmd.Parameters.AddWithValue("@LastName", LastName)
                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

    Public Sub UpdatePerson(PersonID As Integer, FirstName As String, LastName As String)

        Dim sql As String = "UPDATE Person SET FirstName = @FirstName, LastName = @LastName WHERE PersonID = @PersonID"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@FirstName", FirstName)
                cmd.Parameters.AddWithValue("@LastName", LastName)
                cmd.Parameters.AddWithValue("@PersonID", PersonID)

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

    Public Sub DeletePerson(PersonID As Integer)

        Dim sql As String = "DELETE FROM Person WHERE PersonID = @PersonID"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@PersonID", PersonID)

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

#End Region

#Region "Address"

    Public Function FetchAddresses() As DataSet

        Dim ds As New DataSet
        Dim sql As String = "SELECT * FROM Address"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                da.Fill(ds)

            End Using

        End Using

        Return ds

    End Function

    Public Function FetchAddress(AddressID As Integer) As DataSet

        Dim ds As New DataSet
        Dim sql As String = "SELECT * FROM Address WHERE AddressID = @AddressID"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@AddressID", AddressID)

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                da.Fill(ds)

            End Using

        End Using

        Return ds

    End Function

    Public Function FindAddresss(City As String, State As String, Zip As String) As DataSet

        Dim ds As New DataSet
        Dim sql As String = "SELECT * FROM Address"
        Dim where As String = ""

        If City.Length > 0 OrElse State.Length > 0 OrElse Zip.Length > 0 Then

            If City.Length > 0 Then

                If where.Length > 0 Then

                    where = where & " AND "

                End If

                where = where & "City = @City"

            End If

            If State.Length > 0 Then

                If where.Length > 0 Then

                    where = where & " AND "

                End If

                where = where & "State = @State"

            End If

            If Zip.Length > 0 Then

                If where.Length > 0 Then

                    where = where & " AND "

                End If

                where = where & "Zip = @Zip"

            End If

            If where.Length > 0 Then

                sql = sql & " WHERE " & where

            End If

        End If

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                If sql.Contains("City") Then

                    cmd.Parameters.AddWithValue("@City", City)

                End If

                If sql.Contains("State") Then

                    cmd.Parameters.AddWithValue("@State", State)

                End If

                If sql.Contains("Zip") Then

                    cmd.Parameters.AddWithValue("@Zip", Zip)

                End If

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                da.Fill(ds)

            End Using

        End Using

        Return ds

    End Function

    Public Sub InsertAddress(Street1 As String, Street2 As String, City As String, State As String, Zip As String)

        Dim AddressID As Integer = 0
        Dim sql As String = "INSERT INTO Address (Street1, Street2, City, State, Zip) VALUES (@Street1, @Stree2, @City, @State, @Zip)"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@Street1", Street1)
                cmd.Parameters.AddWithValue("@Street2", Street2)
                cmd.Parameters.AddWithValue("@City", City)
                cmd.Parameters.AddWithValue("@State", State)
                cmd.Parameters.AddWithValue("@Zip", Zip)
                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

    Public Sub UpdateAddress(AddressID As Integer, Street1 As String, Street2 As String, City As String, State As String, Zip As String)

        Dim sql As String = "UPDATE Address SET Street1 = @Street1, Street2 = @Street2, City = @City, State = @State, Zip = @Zip WHERE AddressID = @AddressID"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@Street1", Street1)
                cmd.Parameters.AddWithValue("@Street2", Street2)
                cmd.Parameters.AddWithValue("@City", City)
                cmd.Parameters.AddWithValue("@State", State)
                cmd.Parameters.AddWithValue("@Zip", Zip)
                cmd.Parameters.AddWithValue("@AddressID", AddressID)

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

    Public Sub DeleteAddress(AddressID As Integer)

        Dim sql As String = "DELETE FROM Address WHERE AddressID = @AddressID"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@AddressID", AddressID)

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

#End Region

#Region "PersonAddress"

    Public Function FetchPersonAddresses(PersonID As Integer) As DataSet

        Dim ds As New DataSet
        Dim sql As String = "" & _
            "SELECT pa.PersonID PersonID, a.AddressID AddressID, a.Street1 Street1, a.Street2 Stree2, a.City City, " & _
            "a.State State, a.Zip Zip, pa.AddressTypeID AddressTypeID, pa.Description Description, pa.Notes Notes " & _
            "FROM PersonAddresses pa " & _
            "JOIN Address a ON a.AddressID = pa.AddressID " & _
            "WHERE a.PersonID = @PersonID"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@PersonID", PersonID)

                Dim da As New SqlClient.SqlDataAdapter(cmd)

                da.Fill(ds)

            End Using

        End Using

        Return ds

    End Function

    Public Sub InsertPersonAddress(PersonID As Integer, AddressID As Integer, AddressTypeID As Integer, Description As String, Notes As String)

        Dim sql As String = "INSERT INTO PersonAddresses (PersonID, AddressID, AddressTypeID, Description, Notes) VALUES (@PersonID, @AddressID, @AddressTypeID, @Description, @Notes)"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@PersonID", PersonID)
                cmd.Parameters.AddWithValue("@AddressID", AddressID)
                cmd.Parameters.AddWithValue("@AddressTypeID", AddressTypeID)
                cmd.Parameters.AddWithValue("@Description", Description)
                cmd.Parameters.AddWithValue("@Notes", Notes)
                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

    Public Sub UpdatePersonAddress(PersonID As Integer, AddressID As Integer, AddressTypeID As Integer, Description As String, Notes As String)

        Dim sql As String = "UPDATE PersonAddresses SET AddressTypeID = @AddressTypeID, Description = @Description, Notes = @Notes WHERE PersonID = @PersonID AND AddressID = @AddressID"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@AddressTypeID", AddressTypeID)
                cmd.Parameters.AddWithValue("@Description", Description)
                cmd.Parameters.AddWithValue("@Notes", Notes)
                cmd.Parameters.AddWithValue("@PersonID", PersonID)
                cmd.Parameters.AddWithValue("@AddressID", AddressID)

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

    Public Sub DeletePersonAddress(PersonID As Integer, AddressID As Integer)

        Dim sql As String = "DELETE FROM PersonAddresses WHERE PersonID = @PersonID AND AddressID = @AddressID"

        Using cn As New SqlClient.SqlConnection(_connectionString)

            cn.Open()

            Using cmd As SqlClient.SqlCommand = cn.CreateCommand

                cmd.CommandText = sql

                cmd.Parameters.AddWithValue("@PersonID", PersonID)
                cmd.Parameters.AddWithValue("@AddressID", AddressID)

                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

#End Region

End Class
