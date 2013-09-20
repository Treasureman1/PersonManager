using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

#region "DataManager"

namespace DataManager
{
    public class DataAccess
    {
       // String _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\BegASPNET\\PersonManager\\PersonManager\\PersonManager\\DataManager\\App_Data\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
        //String _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\BegASPNET\\PersonManager\\PersonManager\\PersonManager\\DataManager\\App_Data\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
        string _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
      
        //Persons Functions
        #region "Person"


        public DataSet FetchPersons()
        {
            DataSet personsDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM Person";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personsDataSet);  //15

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personsDataSet;
        }

        //Fetch person by personID
        public DataSet FetchPerson(int PersonID)
        {
            DataSet personDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM Person WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personDataSet);  //16

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personDataSet;
        }
        //oveloaded function, having 2 interfaces,  accepts 2 parameters                             
        public DataSet FetchPerson(String FirstName, String LastName)
        {
            DataSet personDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM Person ";

            if (FirstName.Length > 0 || LastName.Length > 0)
                sqlStatementString += "WHERE ";

            if (FirstName.Length > 0)
            {
                sqlStatementString += "FirstName = @FirstName ";
                if (LastName.Length > 0)
                    sqlStatementString += " AND ";

            }

            if (LastName.Length > 0)
            {
                sqlStatementString += "LastName = @LastName";
            }

            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            if (FirstName.Length > 0)
            {
                dbCommand.Parameters.AddWithValue("@FirstName", FirstName);
            }

            if (LastName.Length > 0)
            {
                dbCommand.Parameters.AddWithValue("@LastName", LastName);
            }

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personDataSet);

            dbConnection.Close();
            /////////////////////////
            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personDataSet;
        }

        public DataSet FetchPersonKeywords(string KeywordValue)
        {
            DataSet personDataSet = new DataSet();
            //SELECT Company.CompanyID, Company.Name, Notes FROM Company WHERE Company.Name LIKE '%' + @KeywordValue + '%' OR Company.Notes LIKE '%' + @KeywordValue + '%'               1
            String sqlStatementString = "SELECT DISTINCT Person.PersonID, Person.FirstName, Person.LastName FROM Person LEFT OUTER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID LEFT OUTER JOIN Address ON PersonAddresses.AddressID = Address.AddressID LEFT OUTER JOIN PersonPhones ON Person.PersonID = PersonPhones.PersonID LEFT OUTER JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID WHERE (Person.FirstName LIKE '%' + @KeywordValue + '%') OR (Person.LastName LIKE '%' + @KeywordValue + '%') OR (Address.Street1 LIKE '%' + @KeywordValue + '%') OR (Address.Street2 LIKE '%' + @KeywordValue + '%') OR (Address.City LIKE '%' + @KeywordValue + '%') OR (Address.State LIKE '%' + @KeywordValue + '%') OR (Address.Zip LIKE '%' + @KeywordValue + '%') OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@KeywordValue", KeywordValue);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personDataSet);  //16

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personDataSet;
        }
        
        public DataSet FetchPersonKeywords(String KeywordValue, bool cName, bool cAddress, bool cZip, bool cAreaCode, bool cPhoneNumber, bool cEmail)
        {
            DataSet personDataSet = new DataSet();
            String sqlStatementString = "SELECT DISTINCT Person.PersonID, Person.FirstName, Person.LastName FROM Person ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            if (cName == true || cAddress == true || cZip == true || cAreaCode == true || cPhoneNumber == true || cEmail == true)
            {
                if (cName == true)
                {
                    sqlStatementString += "LEFT OUTER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID LEFT OUTER JOIN Address ON PersonAddresses.AddressID = Address.AddressID LEFT OUTER JOIN EmailAddress ON Person.PersonID = EmailAddress.PersonID LEFT OUTER JOIN PersonPhones ON Person.PersonID = PersonPhones.PersonID LEFT OUTER JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Person.FirstName LIKE '%' + @KeywordValue + '%') OR (Person.LastName LIKE '%' + @KeywordValue + '%') ";
                    if (cAddress == true)
                        sqlStatementString += "OR (Address.Street1 LIKE '%' + @KeywordValue + '%') OR (Address.Street2 LIKE '%' + @KeywordValue + '%') OR (Address.City LIKE '%' + @KeywordValue + '%') OR (Address.State LIKE '%' + @KeywordValue + '%') ";

                    if (cZip == true)
                    {
                        sqlStatementString += "OR (Address.Zip LIKE '%' + @KeywordValue + '%') ";
                    }

                    if (cAreaCode == true)
                    {
                        sqlStatementString += "OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') ";
                        //  OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')
                    }

                    if (cPhoneNumber == true)
                    {
                        sqlStatementString += "OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";
                    }

                    if (cEmail == true)
                    {
                        sqlStatementString += "OR (EmailAddress.Address LIKE '%' + @KeywordValue + '%') ";
                    }
                }


                if (cAddress == true && cName == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID LEFT OUTER JOIN Address ON PersonAddresses.AddressID = Address.AddressID LEFT OUTER JOIN EmailAddress ON Person.PersonID = EmailAddress.PersonID LEFT OUTER JOIN PersonPhones ON Person.PersonID = PersonPhones.PersonID LEFT OUTER JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Address.Street1 LIKE '%' + @KeywordValue + '%') OR (Address.Street2 LIKE '%' + @KeywordValue + '%') OR (Address.City LIKE '%' + @KeywordValue + '%') OR (Address.State LIKE '%' + @KeywordValue + '%') ";
                    if (cZip == true)
                    {
                        sqlStatementString += "OR (Address.Zip LIKE '%' + @KeywordValue + '%') ";
                    }

                    if (cAreaCode == true)
                    {
                        sqlStatementString += "OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') ";
                        //  OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')
                    }

                    if (cPhoneNumber == true)
                    {
                        sqlStatementString += "OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";
                    }
                    if (cEmail == true)
                    {
                        sqlStatementString += "OR (EmailAddress.Address LIKE '%' + @KeywordValue + '%') ";
                    }
                }

                if (cZip == true && cAddress == false && cName == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID LEFT OUTER JOIN Address ON PersonAddresses.AddressID = Address.AddressID LEFT OUTER JOIN EmailAddress ON Person.PersonID = EmailAddress.PersonID LEFT OUTER JOIN PersonPhones ON Person.PersonID = PersonPhones.PersonID LEFT OUTER JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Address.Zip LIKE '%' + @KeywordValue + '%') ";

                    if (cAreaCode == true)
                    {
                        sqlStatementString += "OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') ";
                        //  OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')
                    }

                    if (cPhoneNumber == true)
                    {
                        sqlStatementString += "OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";
                    }
                    if (cEmail == true)
                    {
                        sqlStatementString += "OR (EmailAddress.Address LIKE '%' + @KeywordValue + '%') ";
                    }
                }

                if (cAreaCode == true && cZip == false && cAddress == false && cName == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID LEFT OUTER JOIN Address ON PersonAddresses.AddressID = Address.AddressID LEFT OUTER JOIN EmailAddress ON Person.PersonID = EmailAddress.PersonID LEFT OUTER JOIN PersonPhones ON Person.PersonID = PersonPhones.PersonID LEFT OUTER JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Phone.AreaCode LIKE '%' + @KeywordValue + '%') ";


                    if (cPhoneNumber == true)
                    {
                        sqlStatementString += "OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";
                    }
                }


                if (cPhoneNumber == true && cAreaCode == false && cZip == false && cAddress == false && cName == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID LEFT OUTER JOIN Address ON PersonAddresses.AddressID = Address.AddressID LEFT OUTER JOIN EmailAddress ON Person.PersonID = EmailAddress.PersonID LEFT OUTER JOIN PersonPhones ON Person.PersonID = PersonPhones.PersonID LEFT OUTER JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";
                    if (cEmail == true)
                    {
                        sqlStatementString += "OR (EmailAddress.Address LIKE '%' + @KeywordValue + '%') ";
                    }

                }


                if (cEmail == true && cPhoneNumber == false && cAreaCode == false && cZip == false && cAddress == false && cName == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID LEFT OUTER JOIN Address ON PersonAddresses.AddressID = Address.AddressID LEFT OUTER JOIN EmailAddress ON Person.PersonID = EmailAddress.PersonID LEFT OUTER JOIN PersonPhones ON Person.PersonID = PersonPhones.PersonID LEFT OUTER JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(EmailAddress.Address LIKE '%' + @KeywordValue + '%') ";
                }

                //if (cPhoneNumber == false && cAreaCode == false && cZip == false && cAddress == false && cName == false)
                //{
                //    sqlStatementString += "LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID WHERE (Company.Name LIKE '%' + @KeywordValue + '%') OR (Company.Notes LIKE '%' + @KeywordValue + '%') OR (Address.Street1 LIKE '%' + @KeywordValue + '%') OR (Address.Street2 LIKE '%' + @KeywordValue + '%') OR (Address.City LIKE '%' + @KeywordValue + '%') OR (Address.State LIKE '%' + @KeywordValue + '%') OR (Address.Zip LIKE '%' + @KeywordValue + '%') OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')";



                //}LEFT OUTER JOIN EmailAddress ON Person.PersonID = EmailAddress.PersonID 



            }

            dbCommand.Parameters.AddWithValue("@KeywordValue", KeywordValue);


            if (KeywordValue.Length > 0)
            {
                //dbCommand.Parameters.AddWithValue("@KeywordValue", KeywordValue);
            }

            dbCommand.CommandText = sqlStatementString;




            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personDataSet);

            dbConnection.Close();
            ///////////////////////
            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personDataSet;
        }

        //public DataSet FetchLastPersonInserted(int personID, String FirstName, String LastName)
        //{
        //    // the method should be used using fetch persons as an example.   all will be the same except for the sql statement. 

        //    // Select Scope_identity() AS [_identity]

        //    DataSet personsDataSet = new DataSet();

        //    String sqlStatementString = "SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
        //    SqlConnection dbConnection;

        //    dbConnection = new SqlConnection(_connectionString);

        //    dbConnection.Open();
        //    //We want to      ask the database to give us a command object we can use. 
        //    SqlCommand dbCommand = dbConnection.CreateCommand();

        //    dbCommand.CommandText = sqlStatementString;

        //    SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

        //    dbDataAdapter.Fill(personsDataSet);  //15

        //    dbConnection.Close();

        //    dbDataAdapter = null;
        //    dbCommand = null;
        //    dbConnection = null;

        //    return personsDataSet;


        //}


        public void InsertPerson(String FirstName, String LastName)
        {

            String sqlStatementString = "INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@FirstName", FirstName);
            dbCommand.Parameters.AddWithValue("@LastName", LastName);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public object
          InsertPerson2(String FirstName, String LastName)
        {

            // This method inserts a new record into the Person table and returns the PersonID of the record that was inserted.

            // The SQL statement is actually two statements combined together. In the first statement we are inserting into the
            // Person table and in the second statement we are fetching the PersonID of the record that was just inserted.
            String sqlStatementString = "INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
            SqlConnection dbConnection;

            // We need a variable to hold the ID value of the record we are inserting
            object personID;

            dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@FirstName", FirstName);
            dbCommand.Parameters.AddWithValue("@LastName", LastName);

            // This next line is different from the original InsertPerson method. Instead of calling ExecuteNonQuery we are calling
            // ExecuteScalar. ExecuteScalar will execute our SQL statements and return the PersonID from the second statement
            // as an object. 
            personID = dbCommand.ExecuteScalar();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;

            // Finally, we need to return the value of personID
            return personID;
        }


        public void UpdatePerson(int PersonID, String FirstName, String LastName)
        {

            String sqlStatementString = "UPDATE Person SET FirstName = @FirstName, LastName = @LastName WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@FirstName", FirstName);
            dbCommand.Parameters.AddWithValue("@LastName", LastName);
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            dbCommand.ExecuteNonQuery();            //Execute Non Query method is used if there is not a return value for a function 

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeletePerson(int PersonID)
        {

            String sqlStatementString = "DELETE FROM Person WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        #endregion

        #region "Person Addresses"
        //Input parameter PersonID Select from the address table join the 

        public DataSet FetchPersonAddresses() 
        {
            DataSet personAddressesDataSet = new DataSet();    // INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID  

            String sqlStatementString = "SELECT PersonID, AddressID, AddressTypeID, Description, Notes FROM PersonAddresses JOIN Person on PersonAddresses.PersonID = Person.PersonID  ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personAddressesDataSet);  //1

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personAddressesDataSet;
        }

        public DataSet FetchPersonAddressesGrid(int PersonID) 
        {


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 
            //  "SELECT Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID WHERE PersonID = @PersonID"
            //  "SELECT PhoneTypes.Name Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID JOIN PhoneTypes ON Phone.PhoneTypeID = PhoneTypes.PhoneTypeID WHERE PersonID = @PersonID"
            String sqlStatementString = "SELECT Address.AddressID, Address.Street1, Address.Street2, Address.City, Address.State, Address.Zip FROM Address JOIN PersonAddresses ON Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }

        public DataSet FetchPersonAddresses(int PersonID)
        {
            DataSet personAddressesDataSet = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            String sqlStatementString = "Select * FROM PersonAddresses WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personAddressesDataSet); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personAddressesDataSet;
        }

        public void InsertPersonAddress(int PersonID, int AddressID, int AddressTypeID, String Description, String Notes)
        {
            // INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID
            String sqlStatementString = "INSERT INTO PersonAddresses (PersonID, AddressID, AddressTypeID, Description, Notes) VALUES (@PersonID, @AddressID, @AddressTypeID, @Description, @Notes)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
            dbCommand.Parameters.AddWithValue("@AddressTypeID", AddressTypeID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void UpdatePersonAddress(int PersonID, int AddressID, int AddressTypeID, String Description, String Notes)
        {

            String sqlStatementString = "UPDATE PersonAddresses SET AddressTypeID = @AddressTypeID, Description = @Description, Notes = @Notes WHERE PersonID = @PersonID AND AddressID = @AddressID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
            dbCommand.Parameters.AddWithValue("@AddressTypeID", AddressTypeID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeletePersonAddresses(int PersonID)
        {
            //DELETE FROM PersonAddresses WHERE PersonID = @PersonID AND AddressID = @AddressID
            String sqlStatementString = "DELETE FROM PersonAddresses WHERE PersonID = @PersonID AND AddressID = @AddressID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeletePersonAddress(int PersonID, int AddressID)
        {
            //DELETE FROM PersonAddresses WHERE PersonID = @PersonID AND AddressID = @AddressID
            String sqlStatementString = "DELETE FROM PersonAddresses WHERE PersonID = @PersonID AND AddressID = @AddressID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        #endregion

        #region "Address Types"

        //Address Functions
        public DataSet FetchAddressTypes() 
        {
            DataSet addressesDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM AddressTypes";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(addressesDataSet); //4

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return addressesDataSet;
        }

       
        #endregion

        #region "Address"

        public DataSet FetchAddresses() 
        {
            DataSet ds = new DataSet();

            String sqlStatementString = "SELECT * FROM Address";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds);  //6

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }

        public DataSet FetchPersonsAddresses(int PersonID, int AddressID)
        {
            DataSet ds = new DataSet();

            //PersonPhones.PersonID, 

            //SELECT PersonPhones.PersonID, PersonPhones.PhoneID, PersonPhones.Description, PersonPhones.Notes, PersonPhones.DoNotCall, PersonPhones.DoNotText FROM PersonPhones JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID WHERE PersonPhones.PersonID = @PersonID "
            String sqlStatementString = "SELECT Address.AddressID, Address.Street1, Address.Street2, Address.City, Address.State, Address.Zip FROM Address JOIN PersonAddresses ON Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);

            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds);  //6

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }

        public DataSet FetchCompaniesAddresses(int PersonID, int AddressID)
        {
            DataSet ds = new DataSet();

            //PersonPhones.PersonID, 

            //SELECT PersonPhones.PersonID, PersonPhones.PhoneID, PersonPhones.Description, PersonPhones.Notes, PersonPhones.DoNotCall, PersonPhones.DoNotText FROM PersonPhones JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID WHERE PersonPhones.PersonID = @PersonID "
            String sqlStatementString = "SELECT Address.AddressID, Address.Street1, Address.Street2, Address.City, Address.State, Address.Zip FROM Address JOIN CompanyAddresses ON Address.AddressID = CompanyAddresses.AddressID WHERE CompanyID = @CompanyID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);

            dbCommand.Parameters.AddWithValue("@CompanyID", PersonID);
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds);  //6

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }

        public object InsertAddress(String Street1, String Street2, String City, String State, String Zip)
        {
            //"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
            String sqlStatementString = "INSERT INTO Address (Street1, Street2, City, State, Zip) VALUES (@Street1, @Street2, @City, @State, @Zip) SELECT @@IDENTITY AS AddressID";
            SqlConnection dbConnection;


            object AddressID; 
            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Street1", Street1);
            dbCommand.Parameters.AddWithValue("@Street2",Street2);
            dbCommand.Parameters.AddWithValue("@City", City);
            dbCommand.Parameters.AddWithValue("@State", State);
            dbCommand.Parameters.AddWithValue("@Zip", Zip);
            //  PhoneID = dbCommand.ExecuteNonQuery();

            AddressID = dbCommand.ExecuteScalar();


            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
            return AddressID;
        }

        public void UpdateAddress(int AddressID, String Street1, String Street2, String City, String State, String Zip)
        {

            String sqlStatementString = "UPDATE Address SET Street1 = @Street1, Street2 = @Street2, City = @City, Zip = @Zip WHERE AddressID = @AddressID SELECT @@IDENTITY AS AddressID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
            dbCommand.Parameters.AddWithValue("@Street1", Street1);
            dbCommand.Parameters.AddWithValue("@Street2", Street2);
            dbCommand.Parameters.AddWithValue("@City", City);
            dbCommand.Parameters.AddWithValue("@State", State);
            dbCommand.Parameters.AddWithValue("@Zip", Zip);
            //  dbCommand.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);


            dbCommand.ExecuteNonQuery();            //Execute Non Query method is used if there is not a return value for a function 

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeleteAddress(int AddressID)
        {

            String sqlStatementString = "DELETE FROM Address WHERE AddressID = @AddressID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        #endregion

        //#region "Company Email Address"

        //public DataSet FetchCompanyEmailAddress(int CompanyID)
        //{
        //    DataSet emailAddressesDataSet = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

        //    String sqlStatementString = "SELECT EmailAddressID, Address, CompanyID FROM CompanyEmailAddress WHERE CompanyID = @CompanyID";
        //    SqlConnection dbConnection;

        //    dbConnection = new SqlConnection(_connectionString);

        //    dbConnection.Open();

        //    SqlCommand dbCommand = dbConnection.CreateCommand();

        //    dbCommand.CommandText = sqlStatementString;
        //    dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);

        //    SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

        //    dbDataAdapter.Fill(emailAddressesDataSet);

        //    dbConnection.Close();

        //    dbDataAdapter = null;
        //    dbCommand = null;
        //    dbConnection = null;

        //    return emailAddressesDataSet;
        //}

        //public object InsertCompanyEmailAddress(String Address, int CompanyID)
        //{
        //    //"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
        //    String sqlStatementString = "INSERT INTO CompanyEmailAddress (Address, CompanyID) VALUES (@Address, @CompanyID) SELECT @@IDENTITY AS CompanyEmailAddressID";
        //    SqlConnection dbConnection;


        //    object CompanyEmailAddressID;
        //    dbConnection = new SqlConnection(_connectionString);

        //    dbConnection.Open();

        //    SqlCommand dbCommand = dbConnection.CreateCommand();

        //    dbCommand.CommandText = sqlStatementString;
        //    dbCommand.Parameters.AddWithValue("@Address", Address);
        //    dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
        //    CompanyEmailAddressID = dbCommand.ExecuteScalar();


        //    dbConnection.Close();

        //    dbCommand = null;
        //    dbConnection = null;
        //    return CompanyEmailAddressID;
        //}

        //public void UpdateCompanyEmailAddress(int EmailAddressID, string Address, int CompanyID)
        //{

        //    String sqlStatementString = "UPDATE EmailAddress SET Address = @Address, CompanyID = @CompanyID WHERE EmailAddressID = @EmailAddressID ";
        //    SqlConnection dbConnection;

        //    dbConnection = new SqlConnection(_connectionString);

        //    dbConnection.Open();

        //    SqlCommand dbCommand = dbConnection.CreateCommand();

        //    dbCommand.CommandText = sqlStatementString;

        //    dbCommand.Parameters.AddWithValue("@Address", Address);
        //    dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
        //    dbCommand.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);

        //    dbCommand.ExecuteNonQuery();

        //    dbConnection.Close();

        //    dbCommand = null;
        //    dbConnection = null;
        //}

        //public void DeleteCompanyEmailAddress(int EmailAddressID)
        //{
        //    // Does the "AND PersonID = @PersonID need to be added here?
        //    String sqlStatementString = "DELETE FROM EmailAddress WHERE EmailAddressID = @EmailAddressID";
        //    SqlConnection dbConnection;

        //    dbConnection = new SqlConnection(_connectionString);

        //    dbConnection.Open();

        //    SqlCommand dbCommand = dbConnection.CreateCommand();

        //    dbCommand.CommandText = sqlStatementString;
        //    dbCommand.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);
        //    dbCommand.ExecuteNonQuery();

        //    dbConnection.Close();

        //    dbCommand = null;
        //    dbConnection = null;
        //}


        //#endregion

        #region "Email Address"




        public DataSet FetchEmailAddress(int PersonID)
        {
            DataSet emailAddressesDataSet = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            String sqlStatementString = "SELECT EmailAddressID, Address, PersonID FROM EmailAddress WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(emailAddressesDataSet);

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return emailAddressesDataSet;
        }

        public DataSet FetchPersonEmailAddresses(int PersonID)
        {
            DataSet emailAddressesDataSet = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            String sqlStatementString = "SELECT EmailAddressID, Address, PersonID FROM EmailAddress WHERE PersonID = @PersonID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(emailAddressesDataSet);

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return emailAddressesDataSet;
        }

        public object InsertEmailAddress(String Address, int PersonID)
        {
            //"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
            String sqlStatementString = "INSERT INTO EmailAddress (Address, PersonID) VALUES (@Address, @PersonID) SELECT @@IDENTITY AS EmailAddressID";
            SqlConnection dbConnection;


            object EmailAddressID;
            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Address", Address);
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            EmailAddressID = dbCommand.ExecuteScalar();


            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
            return EmailAddressID;
        }

        //public void InsertEmailAddress(int EmailAddressID, String Address, int PersonID)
        //{
        //    // INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID
        //    String sqlStatementString = "INSERT INTO EmailAddress (EmailAddressID, Address, PersonID) VALUES (@EmailAddressID, @AddressID, @PersonID)";
        //    SqlConnection dbConnection;

        //    dbConnection = new SqlConnection(_connectionString);

        //    dbConnection.Open();

        //    SqlCommand dbCommand = dbConnection.CreateCommand();

        //    dbCommand.CommandText = sqlStatementString;
        //    dbCommand.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);
        //    dbCommand.Parameters.AddWithValue("@Address", Address);
        //    dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
        //    dbCommand.ExecuteNonQuery();

        //    dbConnection.Close();

        //    dbCommand = null;
        //    dbConnection = null;
        //}

        public void UpdateEmailAddress(int EmailAddressID, string Address, int PersonID)
        {

            String sqlStatementString = "UPDATE EmailAddress SET Address = @Address, PersonID = @PersonID WHERE EmailAddressID = @EmailAddressID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@Address", Address);
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);

            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeleteEmailAddress(int EmailAddressID)
        {
            // Does the "AND PersonID = @PersonID need to be added here?
            String sqlStatementString = "DELETE FROM EmailAddress WHERE EmailAddressID = @EmailAddressID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }




        #endregion

        #region "Phone"

        public DataSet FetchPhoneNumbers()
        {
            DataSet phoneNumbersDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM Phone";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(phoneNumbersDataSet);  //6

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return phoneNumbersDataSet;
        }

        public DataSet FetchPersonPhoneNumbers(int PersonID)
        {
            DataSet phoneNumbersDataSet = new DataSet();

            //PersonPhones.PersonID, 

            //SELECT PersonPhones.PersonID, PersonPhones.PhoneID, PersonPhones.Description, PersonPhones.Notes, PersonPhones.DoNotCall, PersonPhones.DoNotText FROM PersonPhones JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID WHERE PersonPhones.PersonID = @PersonID "
            String sqlStatementString = "SELECT Phone.PhoneID, Phone.AreaCode, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(phoneNumbersDataSet);  //6

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return phoneNumbersDataSet;
        }




        //Fetch phone number by PhoneID
        public DataSet FetchPhoneNumber(int PhoneID)
        {
            DataSet phoneNumberDataSet = new DataSet();

            String sqlStatementString = "SELECT PhoneID, AreaCode, PhoneNumber, Extension, PhoneTypeID FROM Phone WHERE PhoneID = @PhoneID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(phoneNumberDataSet);  //6

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return phoneNumberDataSet;
        }


        public object InsertPhoneNumber(String AreaCode, String PhoneNumber, String Extension, int PhoneTypeID)
        {
            //"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
            String sqlStatementString = "INSERT INTO Phone (AreaCode, PhoneNumber, Extension, PhoneTypeID) VALUES (@AreaCode, @PhoneNumber, @Extension, @PhoneTypeID) SELECT @@IDENTITY AS PhoneID";
            SqlConnection dbConnection;


            object PhoneID;
            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@AreaCode", AreaCode);
            dbCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            dbCommand.Parameters.AddWithValue("@Extension", Extension);
            dbCommand.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);
            //  PhoneID = dbCommand.ExecuteNonQuery();

            PhoneID = dbCommand.ExecuteScalar();


            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
            return PhoneID;
        }

        public object InsertPersonPhoneNumber(String AreaCode, String PhoneNumber, String Extension, int PhoneTypeID)
        {
            // insert into the phone table, now ther is phoneiD    one insertphonenumber and anothre called insertPersonPhoneNumber
            //insertphonenumber is the phones table     the other   personID phoneID  dnc dnt.
            // This method inserts a new record into the Person table and returns the PersonID of the record that was inserted.

            // The SQL statement is actually two statements combined together. In the first statement we are inserting into the
            // Person table and in the second statement we are fetching the PersonID of the record that was just inserted.
            String sqlStatementString = "INSERT INTO Phone (AreaCode, PhoneNumber, Extension, PhoneTypeID) VALUES (@AreaCode, @PhoneNumber, @Extension, @PhoneTypeID) SELECT @@IDENTITY AS PhoneID";
            SqlConnection dbConnection;

            // We need a variable to hold the ID value of the record we are inserting
            object phoneID;

            dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@AreaCode", AreaCode);
            dbCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            dbCommand.Parameters.AddWithValue("@Extension", Extension);
            dbCommand.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);

            // This next line is different from the original InsertPerson method. Instead of calling ExecuteNonQuery we are calling
            // ExecuteScalar. ExecuteScalar will execute our SQL statements and return the PersonID from the second statement
            // as an object. 
            phoneID = dbCommand.ExecuteScalar();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;

            // Finally, we need to return the value of personID
            return phoneID;
        }

        public void UpdatePhone(int PhoneID, String AreaCode, String PhoneNumber, String Extension, int PhoneTypeID)
        {

            String sqlStatementString = "UPDATE Phone SET AreaCode = @AreaCode, PhoneNumber = @PhoneNumber, Extension = @Extension, PhoneTypeID = @PhoneTypeID WHERE PhoneID = @PhoneID SELECT @@IDENTITY AS PhoneID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.Parameters.AddWithValue("@AreaCode", AreaCode);
            dbCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            dbCommand.Parameters.AddWithValue("@Extension", Extension);
            dbCommand.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);
          //  dbCommand.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);
            
           
            dbCommand.ExecuteNonQuery();            //Execute Non Query method is used if there is not a return value for a function 

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeletePhone(int PhoneID)
        {

            String sqlStatementString = "DELETE FROM Phone WHERE PhoneID = @PhoneID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }


        #endregion


        #region "Person Phones"

        public DataSet FetchPersonPhones()
        {
            DataSet personPhonesDataSet = new DataSet();    // "SELECT PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText FROM PersonPhones JOIN Person ON PesonPhones.PersonID = Person.PersonID WHERE PersonPhones.PhoneID = @PhoneID ";  

            String sqlStatementString = "SELECT PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText FROM PersonPhones";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personPhonesDataSet);

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;




            return personPhonesDataSet;
        }

        public DataSet FetchPersonPhones(int PersonID)
        {
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 
            //what I want to deliver here is all of the fields for personPhones, and Area, and all of the fields from the phone table. 
            String sqlStatementString = "SELECT PersonPhones.PersonID, PersonPhones.PhoneID, PersonPhones.Description, PersonPhones.Notes, PersonPhones.DoNotCall, PersonPhones.DoNotText FROM PersonPhones JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID WHERE PersonPhones.PersonID = @PersonID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }



        //public DataSet FetchPersonPhoneNumber(int PersonID, int PhoneID)
        //{
        //    DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

        //    String sqlStatementString = "SELECT PersonPhones.PersonID, PersonPhones.PhoneID, PersonPhones.Description, PersonPhones.Notes, PersonPhones.DoNotCall, PersonPhones.DoNotText FROM PersonPhones JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID WHERE PersonPhones.PersonID = @PersonID AND PersonPhones.PhoneID = @PhoneID ";
        //    SqlConnection dbConnection;

        //    dbConnection = new SqlConnection(_connectionString);

        //    dbConnection.Open();

        //    SqlCommand dbCommand = dbConnection.CreateCommand();

        //    dbCommand.CommandText = sqlStatementString;
        //    dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
        //    dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
        //    SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

        //    dbDataAdapter.Fill(ds); //2

        //    dbConnection.Close();

        //    dbDataAdapter = null;
        //    dbCommand = null;
        //    dbConnection = null;

        //    return ds;
        //}


        public DataSet FetchPersonPhonesGrid(int PersonID) 
        {


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 
            //  "SELECT Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID WHERE PersonID = @PersonID"
            //  "SELECT PhoneTypes.Name Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID JOIN PhoneTypes ON Phone.PhoneTypeID = PhoneTypes.PhoneTypeID WHERE PersonID = @PersonID"
            String sqlStatementString = "SELECT Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

           return ds;
        }
        public DataSet FetchPersonPhone(int PhoneID)
        {
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            String sqlStatementString = "SELECT * FROM PersonPhones WHERE PhoneID = @PhoneID";
            SqlConnection dbConnection;
            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            // dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }

        public DataSet FetchPersonPhoneNumbers2(int PersonID)
        {
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            String sqlStatementString = "SELECT Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM PersonPhones JOIN Phone ON PersonPhones.PhoneID = Phone.PhoneID WHERE PersonPhones.PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
           // dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }


        public object InsertPersonPhone(int PersonID, int PhoneID, String Description, String Notes, bool DoNotCall, bool DoNotText)
        {
            // INNER JOIN PersonAddresses  ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID
            String sqlStatementString = "INSERT INTO PersonPhones (PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText) VALUES (@PersonID, @PhoneID, @Description, @Notes, @DoNotCall, @DoNotText)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.Parameters.AddWithValue("@DoNotCall", DoNotCall);
            dbCommand.Parameters.AddWithValue("@DoNotText", DoNotText);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;

            return PersonID;
        }


        public void InsertPersonPhone2(int PersonID, int PhoneID, String Description, String Notes)
        {
            // INNER JOIN PersonAddresses  ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID
            String sqlStatementString = "INSERT INTO PersonPhones (PersonID, PhoneID, Description, Notes) VALUES (@PersonID, @PhoneID, @Description, @Notes)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);

            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void UpdatePersonPhoneNumber(int PersonID, int PhoneID, String Description, String Notes, bool DoNotCall, bool DoNotText)
        {

            String sqlStatementString = "UPDATE PersonPhones SET Description = @Description, Notes = @Notes, DoNotCall = @DoNotCall, DoNotText = @DoNotText WHERE PersonID = @PersonID AND PhoneID = @PhoneID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.Parameters.AddWithValue("@DoNotCall", DoNotCall);
            dbCommand.Parameters.AddWithValue("@DoNotText", DoNotText);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeletePersonPhoneNumber(int PersonID, int PhoneID)
        {
            //DELETE FROM PersonAddresses WHERE PersonID = @PersonID AND AddressID = @AddressID
            String sqlStatementString = "DELETE FROM PersonPhones WHERE PersonID = @PersonID AND PhoneID = @PhoneID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }


        #endregion

        #region "Brand"

        public DataSet FetchBrands()
        {
            DataSet brandsDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM Brand";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(brandsDataSet);  //8

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return brandsDataSet;
        }

        //Fetch person by personID
        public DataSet FetchBrand(int BrandID)
        {
            DataSet brandDataSet = new DataSet();

            String sqlStatementString = "SELECT BrandID, Name, Description, Notes, ManufacturerID FROM Brand WHERE BrandID = @BrandID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@BrandID", BrandID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(brandDataSet);  //9

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return brandDataSet;
        }

        //Fetch person by personID
        public DataSet FetchBrand(string Name)
        {
            DataSet brandDataSet = new DataSet();

            String sqlStatementString = "SELECT BrandID, Name, Description, Notes, ManufacturerID FROM Brand WHERE Name = @Name";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Name", @Name);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(brandDataSet);  //10

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return brandDataSet;
        }


        public void InsertBrand(String Name, String Description, String Notes, int ManufacturerID)
        {

            String sqlStatementString = "INSERT INTO Brand (Name, Description, Notes, ManufacturerID) VALUES (@Name, @Description, @Description, @ManufacturerID)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.Parameters.AddWithValue("@ManufacturerID", ManufacturerID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void UpdateBrand(int BrandID, String Name, String Description, String Notes, String ManufacturerID)
        {

            String sqlStatementString = "UPDATE Brand SET Name = @Name, Description = @Description, Notes = @Notes, ManufacturerID = @ManufacturerID WHERE BrandID = @BrandID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.Parameters.AddWithValue("@ManufacturerID", ManufacturerID);

            dbCommand.Parameters.AddWithValue("@BrandID", BrandID);
            dbCommand.ExecuteNonQuery();            //Execute Non Query method is used if there is not a return value for a function 

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeleteBrand(int BrandID)
        {                                                          //AND ManufacturerID = @ManufacturerID /// This is one othre possible code I could use

            String sqlStatementString = "DELETE FROM Brand WHERE BrandID = @BrandID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@BrandID", BrandID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        #endregion

        #region "Product"

        public DataSet FetchProducts()
        {
            DataSet productsDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM Product";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //Ask the database to give us a command object. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(productsDataSet); //11

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return productsDataSet;
        }


        //Fetch product by productID
        public DataSet FetchProduct(int ProductID)
        {
            DataSet productsDataSet = new DataSet();

            String sqlStatementString = "SELECT ProductID, Name, Description, ModelNumber, SerialNumber, UPC, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued, Notes, CategoryID, SupplierID, ManufacturerID FROM Product WHERE ProductID = @ProductID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@ProductID", ProductID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(productsDataSet);  //12

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return productsDataSet;
        }


        public void InsertProduct(String Name, String Description, String ModelNumber, String SerialNumber, String UPC, Decimal UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, bool Discontinued, String Notes, int CategoryID, int SupplierID, int ManufacturerID)
        {

            String sqlStatementString = "INSERT INTO Product (Name, Description, ModelNumber, SerialNumber, UPC, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued, Notes, CategoryID, SupplierID, ManufacturerID) VALUES (@Name, @ModelNumber, @SerialNumber, @UPC, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued, @Notes, @CategoryID, @SupplierID, @ManufacturerID)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@ModelNumber", ModelNumber);
            dbCommand.Parameters.AddWithValue("@SerialNumber", SerialNumber);
            dbCommand.Parameters.AddWithValue("@UPC", UPC);
            dbCommand.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            dbCommand.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
            dbCommand.Parameters.AddWithValue("@UnitsOnOrder", UnitsOnOrder);
            dbCommand.Parameters.AddWithValue("@ReorderLevel", ReorderLevel);
            dbCommand.Parameters.AddWithValue("@Discontinued", Discontinued);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
            dbCommand.Parameters.AddWithValue("@SupplierID", SupplierID);
            dbCommand.Parameters.AddWithValue("@ManufacturerID", ManufacturerID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void UpdateProduct(int ProductID, String Name, String Description, String ModelNumber, String SerialNumber, String UPC, Decimal UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, bool Discontinued, String Notes, int CategoryID, int SupplierID, int ManufacturerID)
        {
            //Should I add the rest of the Product information?
            String sqlStatementString = "UPDATE Product SET Name = @Name, Description = @Description, ModelNumber = @ModelNumber, SerialNumber = @SerialNumber, UPC = @UPC, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued, Notes = @Notes, CategoryID = @CategoryID, SupplierID = @SupplierID, ManufacturerID = @ManufacturerID WHERE ProductID = @ProductID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();



            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@Description", Description);  //Check the order. 
            dbCommand.Parameters.AddWithValue("@ModelNumber", ModelNumber);
            dbCommand.Parameters.AddWithValue("@SerialNumber", SerialNumber);  //Check the order. 
            dbCommand.Parameters.AddWithValue("@UPC", UPC);
            dbCommand.Parameters.AddWithValue("@UnitPrice", UnitPrice);  //Check the order. 
            dbCommand.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
            dbCommand.Parameters.AddWithValue("@UnitsOnOrder", UnitsOnOrder);  //Check the order. 
            dbCommand.Parameters.AddWithValue("@ReorderLevel", ReorderLevel);  //Check the order. 
            dbCommand.Parameters.AddWithValue("@Discontinued", Discontinued);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);  //Check the order. 
            dbCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
            dbCommand.Parameters.AddWithValue("@SupplierID", SupplierID);
            dbCommand.Parameters.AddWithValue("@ManufacturerID", ManufacturerID);
            dbCommand.Parameters.AddWithValue("@ProductID", ProductID);


            dbCommand.ExecuteNonQuery();
            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeleteProduct(int ProductID)
        {

            String sqlStatementString = "DELETE FROM Product WHERE ProductID = @ProductID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@ProductID", ProductID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }


        #endregion

        #region "Company"

        public DataSet FetchCompany()
        {
            DataSet companyDataSet = new DataSet();

            String sqlStatementString = "SELECT CompanyID, Name, Notes FROM Company";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(companyDataSet);  //15

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return companyDataSet;
        }


        public DataSet FetchCompany(int CompanyID)
        {
            DataSet companyDataSet = new DataSet();

            String sqlStatementString = "SELECT CompanyID, Name, Notes FROM Company WHERE CompanyID = @CompanyID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(companyDataSet);  //16

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return companyDataSet;
        }


        public DataSet FetchCompany(String Name)
        {
            DataSet personDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM Company ";

            if (Name.Length > 0)
                sqlStatementString += "WHERE ";

            if (Name.Length > 0)
            {
                sqlStatementString += "Name = @Name ";
                

            }

            //public DataSet FetchPersonAddresses(int PersonID)
            //{
            //    DataSet personAddressesDataSet = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            //    String sqlStatementString = "Select * FROM PersonAddresses WHERE PersonID = @PersonID";
            //    SqlConnection dbConnection;

            //    dbConnection = new SqlConnection(_connectionString);

            //    dbConnection.Open();

            //    SqlCommand dbCommand = dbConnection.CreateCommand();

            //    dbCommand.CommandText = sqlStatementString;
            //    dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            //    SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            //    dbDataAdapter.Fill(personAddressesDataSet); //2

            //    dbConnection.Close();

            //    dbDataAdapter = null;
            //    dbCommand = null;
            //    dbConnection = null;

            //    return personAddressesDataSet;
            //}

           

            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            if (Name.Length > 0)
            {
                dbCommand.Parameters.AddWithValue("@Name", Name);
            }

           

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personDataSet);

            dbConnection.Close();
            /////////////////////////
            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personDataSet;
        }

        public DataSet FetchCompanyKeywords(string KeywordValue)
        {
            DataSet companyDataSet = new DataSet();
            //SELECT Company.CompanyID, Company.Name, Notes FROM Company WHERE Company.Name LIKE '%' + @KeywordValue + '%' OR Company.Notes LIKE '%' + @KeywordValue + '%'
            String sqlStatementString = "SELECT Company.CompanyID, Company.Name, Company.Notes FROM Company LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID WHERE (Company.Name LIKE '%' + @KeywordValue + '%') OR (Company.Notes LIKE '%' + @KeywordValue + '%') OR (Address.Street1 LIKE '%' + @KeywordValue + '%') OR (Address.Street2 LIKE '%' + @KeywordValue + '%') OR (Address.City LIKE '%' + @KeywordValue + '%') OR (Address.State LIKE '%' + @KeywordValue + '%') OR (Address.Zip LIKE '%' + @KeywordValue + '%') OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@KeywordValue", KeywordValue);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(companyDataSet);  //16

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return companyDataSet;
        }

        //, bool cSearch, bool cAdvancedSearch

        public DataSet FetchCompanyKeywords(String KeywordValue, bool cCompany, bool cAddress, bool cZip, bool cAreaCode, bool cPhoneNumber)
        {
            DataSet personDataSet = new DataSet();
            String sqlStatementString = "SELECT Company.CompanyID, Company.Name, Company.Notes FROM Company ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();


            //if (cSearch == true)
            //{
            //    sqlStatementString += "LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID WHERE (Company.Name LIKE '%' + @KeywordValue + '%') OR (Company.Notes LIKE '%' + @KeywordValue + '%') OR (Address.Street1 LIKE '%' + @KeywordValue + '%') OR (Address.Street2 LIKE '%' + @KeywordValue + '%') OR (Address.City LIKE '%' + @KeywordValue + '%') OR (Address.State LIKE '%' + @KeywordValue + '%') OR (Address.Zip LIKE '%' + @KeywordValue + '%') OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')";
            //    dbCommand.CommandText = sqlStatementString;

            //}


            //////sqlStatementString += "LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID ";
            //////sqlStatementString += "WHERE ";
            if (cCompany == true || cAddress == true || cZip == true || cAreaCode == true || cPhoneNumber == true)
            {




                //(Company.Name LIKE '%' + @KeywordValue + '%') OR (Company.Notes LIKE '%' + @KeywordValue + '%')
                if (cCompany == true)
                {
                    sqlStatementString += "LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Company.Name LIKE '%' + @KeywordValue + '%') OR (Company.Notes LIKE '%' + @KeywordValue + '%') ";
                    if (cAddress == true)
                        sqlStatementString += "OR (Address.Street1 LIKE '%' + @KeywordValue + '%') OR (Address.Street2 LIKE '%' + @KeywordValue + '%') OR (Address.City LIKE '%' + @KeywordValue + '%') OR (Address.State LIKE '%' + @KeywordValue + '%') ";

                    if (cZip == true)
                    {
                        sqlStatementString += "OR (Address.Zip LIKE '%' + @KeywordValue + '%') ";
                    }

                    if (cAreaCode == true)
                    {
                        sqlStatementString += "OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') ";
                        //  OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')
                    }

                    if (cPhoneNumber == true)
                    {
                        sqlStatementString += "OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";
                    }
                }


                if (cAddress == true && cCompany == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Address.Street1 LIKE '%' + @KeywordValue + '%') OR (Address.Street2 LIKE '%' + @KeywordValue + '%') OR (Address.City LIKE '%' + @KeywordValue + '%') OR (Address.State LIKE '%' + @KeywordValue + '%') ";
                    if (cZip == true)
                    {
                        sqlStatementString += "OR (Address.Zip LIKE '%' + @KeywordValue + '%') ";
                    }

                    if (cAreaCode == true)
                    {
                        sqlStatementString += "OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') ";
                        //  OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')
                    }

                    if (cPhoneNumber == true)
                    {
                        sqlStatementString += "OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";
                    }
                }

                if (cZip == true && cAddress == false && cCompany == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Address.Zip LIKE '%' + @KeywordValue + '%') ";

                    if (cAreaCode == true)
                    {
                        sqlStatementString += "OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') ";
                        //  OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')
                    }

                    if (cPhoneNumber == true)
                    {
                        sqlStatementString += "OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";
                    }
                }

                if (cAreaCode == true && cZip == false && cAddress == false && cCompany == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Phone.AreaCode LIKE '%' + @KeywordValue + '%') ";


                    if (cPhoneNumber == true)
                    {
                        sqlStatementString += "OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";
                    }
                }


                if (cPhoneNumber == true && cAreaCode == false && cZip == false && cAddress == false && cCompany == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID ";
                    sqlStatementString += "WHERE ";
                    sqlStatementString += "(Phone.PhoneNumber LIKE '%' + @KeywordValue + '%') ";


                }

                if (cPhoneNumber == false && cAreaCode == false && cZip == false && cAddress == false && cCompany == false)
                {
                    sqlStatementString += "LEFT OUTER JOIN CompanyAddresses ON Company.CompanyID = CompanyAddresses.CompanyID LEFT OUTER JOIN Address ON CompanyAddresses.AddressID = Address.AddressID LEFT OUTER JOIN CompanyPhones ON Company.CompanyID = CompanyPhones.CompanyID LEFT OUTER JOIN Phone ON CompanyPhones.PhoneID = Phone.PhoneID WHERE (Company.Name LIKE '%' + @KeywordValue + '%') OR (Company.Notes LIKE '%' + @KeywordValue + '%') OR (Address.Street1 LIKE '%' + @KeywordValue + '%') OR (Address.Street2 LIKE '%' + @KeywordValue + '%') OR (Address.City LIKE '%' + @KeywordValue + '%') OR (Address.State LIKE '%' + @KeywordValue + '%') OR (Address.Zip LIKE '%' + @KeywordValue + '%') OR (Phone.AreaCode LIKE '%' + @KeywordValue + '%') OR (Phone.PhoneNumber LIKE '%' + @KeywordValue + '%')";



                }



            }

            dbCommand.Parameters.AddWithValue("@KeywordValue", KeywordValue);


            if (KeywordValue.Length > 0)
            {
                //dbCommand.Parameters.AddWithValue("@KeywordValue", KeywordValue);
            }

            dbCommand.CommandText = sqlStatementString;




            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personDataSet);

            dbConnection.Close();
            ///////////////////////
            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personDataSet;
        }



        // this method is put here as a placeholder until I incorporate the keyword search on the page. 
        //public DataSet FetchCompany(String Name, String Notes)
        //{
        //    DataSet personDataSet = new DataSet();

        //    String sqlStatementString = "SELECT * FROM Person ";

        //    if (FirstName.Length > 0 || LastName.Length > 0)
        //        sqlStatementString += "WHERE ";

        //    if (FirstName.Length > 0)
        //    {
        //        sqlStatementString += "FirstName = @FirstName ";
        //        if (LastName.Length > 0)
        //            sqlStatementString += " AND ";

        //    }

        //    if (LastName.Length > 0)
        //    {
        //        sqlStatementString += "LastName = @LastName";
        //    }

        //    SqlConnection dbConnection;

        //    dbConnection = new SqlConnection(_connectionString);

        //    dbConnection.Open();

        //    SqlCommand dbCommand = dbConnection.CreateCommand();

        //    dbCommand.CommandText = sqlStatementString;

        //    if (FirstName.Length > 0)
        //    {
        //        dbCommand.Parameters.AddWithValue("@FirstName", FirstName);
        //    }

        //    if (LastName.Length > 0)
        //    {
        //        dbCommand.Parameters.AddWithValue("@LastName", LastName);
        //    }

        //    SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

        //    dbDataAdapter.Fill(personDataSet);

        //    dbConnection.Close();
        //    /////////////////////////
        //    dbDataAdapter = null;
        //    dbCommand = null;
        //    dbConnection = null;

        //    return personDataSet;
        //}



        public void InsertCompany(String Name, String Notes)
        {

            String sqlStatementString = "INSERT INTO Company (Name, Notes) VALUES (@Name, @Notes)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public object
         InsertCompany2(String Name, String Notes)
        {

            // This method inserts a new record into the Person table and returns the PersonID of the record that was inserted.

            // The SQL statement is actually two statements combined together. In the first statement we are inserting into the
            // Person table and in the second statement we are fetching the PersonID of the record that was just inserted.
            String sqlStatementString = "INSERT INTO Company (Name, Notes) VALUES (@Name, @Notes) SELECT @@IDENTITY AS CompanyID";
            SqlConnection dbConnection;

            // We need a variable to hold the ID value of the record we are inserting
            object companyID;

            dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);

            // This next line is different from the original InsertPerson method. Instead of calling ExecuteNonQuery we are calling
            // ExecuteScalar. ExecuteScalar will execute our SQL statements and return the PersonID from the second statement
            // as an object. 
            companyID = dbCommand.ExecuteScalar();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;

            // Finally, we need to return the value of personID
            return companyID;
        }

        public void UpdateCompany(int CompanyID, String Name, String Notes)
        {

            String sqlStatementString = "UPDATE Company SET Name = @Name, Notes = @Notes WHERE CompanyID = @CompanyID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.ExecuteNonQuery();            //Execute Non Query method is used if there is not a return value for a function 

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeleteCompany(int CompanyID)
        {

            String sqlStatementString = "DELETE FROM Company WHERE CompanyID = @CompanyID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }


        #endregion

        #region "CompanyPhones"



        public DataSet FetchCompanyPhones()
        {

            DataSet personAddressesDataSet = new DataSet();    //"SELECT CompanyID, PhoneID, Description, Notes FROM CompanyPhones JOIN Company ON CompanyPhones.CompanyID=Company.CompanyID WHERE Phones ON CompanyPhones.PhoneID=Phones.PhoneID ";
            String sqlStatementString = "SELECT CompanyID, PhoneID, Description, Notes FROM CompanyPhones  ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personAddressesDataSet);  //1

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personAddressesDataSet;
        }

        public DataSet FetchCompanyPhones(int CompanyID)
        {
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            String sqlStatementString = "SELECT CompanyPhones.CompanyID, CompanyPhones.PhoneID, CompanyPhones.Description, CompanyPhones.Notes FROM CompanyPhones JOIN Company ON Company.CompanyID = CompanyPhones.CompanyID WHERE CompanyPhones.CompanyID = @CompanyID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds);

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }


        public DataSet FetchCompanyPhone(int PhoneID)
        {
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            String sqlStatementString = "SELECT * FROM CompanyPhones WHERE PhoneID = @PhoneID";
            SqlConnection dbConnection;
            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            // dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }

        public DataSet FetchCompanyPhonesGrid(int CompanyID)
        {


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 
            //  "SELECT Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID WHERE PersonID = @PersonID"
            //  "SELECT PhoneTypes.Name Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID JOIN PhoneTypes ON Phone.PhoneTypeID = PhoneTypes.PhoneTypeID WHERE PersonID = @PersonID"
            String sqlStatementString = "SELECT Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN CompanyPhones ON Phone.PhoneID = CompanyPhones.PhoneID WHERE CompanyID = @CompanyID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }

        public DataSet FetchCompanyPhones(int CompanyID, int PhoneID)
        {
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            String sqlStatementString = "SELECT CompanyPhones.CompanyID, CompanyPhones.PhoneID, CompanyPhones.Description, CompanyPhones.Notes FROM CompanyPhones JOIN Company ON Company.CompanyID = CompanyPhones.CompanyID WHERE CompanyPhones.CompanyID = @CompanyID AND CompanyPhones.PhoneID = @PhoneID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }



        public void InsertCompanyPhones(int CompanyID, int PhoneID, String Description, String Notes)
        {
            // INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID
            String sqlStatementString = "INSERT INTO CompanyPhones (CompanyID, PhoneID, Description, Notes) VALUES (@CompanyID, @PhoneID, @Description, @Notes)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public object InsertCompanyPhone(int CompanyID, int PhoneID, String Description, String Notes)
        {
            // INNER JOIN PersonAddresses  ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID
            String sqlStatementString = "INSERT INTO CompanyPhones (CompanyID, PhoneID, Description, Notes) VALUES (@CompanyID, @PhoneID, @Description, @Notes)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;

            return CompanyID;
        }

        public void UpdateCompanyPhones(int CompanyID, int PhoneID, String Description, String Notes)
        {

            String sqlStatementString = "UPDATE CompanyPhones SET Description = @Description, Notes = @Notes WHERE CompanyID = @CompanyID AND PhoneID = @PhoneID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeleteCompanyPhones(int CompanyID, int PhoneID)
        {
            //DELETE FROM PersonAddresses WHERE PersonID = @PersonID AND AddressID = @AddressID
            String sqlStatementString = "DELETE FROM CompanyPhones WHERE CompanyID = @CompanyID AND PhoneID = @PhoneID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }



        #endregion

        #region "CompanyAddresses"

        public DataSet FetchCompanyAddresses()
        {
            DataSet personAddressesDataSet = new DataSet();    // INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID  

            String sqlStatementString = "SELECT CompanyID, AddressID, Description, Notes FROM CompanyAddresses JOIN Company on CompanyAddresses.CompanyID = Company.CompanyID  ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personAddressesDataSet);

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personAddressesDataSet;
        }

        public DataSet FetchCompanyAddresses(int CompanyID, int AddressID)
        {
            DataSet personAddressesDataSet = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 

            String sqlStatementString = "SELECT CompanyID, AddressID, Description, Notes FROM CompanyAddresses WHERE CompanyID = @CompanyID AND AddressID = @AddressID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personAddressesDataSet); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personAddressesDataSet;
        }

        public DataSet FetchCompanyAddressesGrid(int CompanyID)
        {


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataSet ds = new DataSet();        //INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID  AND Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID 
            //  "SELECT Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID WHERE PersonID = @PersonID"
            //  "SELECT PhoneTypes.Name Phone.PhoneID, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM Phone JOIN PersonPhones ON Phone.PhoneID = PersonPhones.PhoneID JOIN PhoneTypes ON Phone.PhoneTypeID = PhoneTypes.PhoneTypeID WHERE PersonID = @PersonID"
            String sqlStatementString = "SELECT Address.AddressID, Address.Street1, Address.Street2, Address.City, Address.State, Address.Zip FROM Address JOIN CompanyAddresses ON Address.AddressID = CompanyAddresses.AddressID WHERE CompanyID = @CompanyID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return ds;
        }

        public void InsertCompanyAddress(int CompanyID, int AddressID, String Description, String Notes)
        {
            // INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID
            String sqlStatementString = "INSERT INTO CompanyAddresses (CompanyID, AddressID, Description, Notes) VALUES (@CompanyID, @AddressID, @Description, @Notes)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
          
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void UpdateCompanyAddresses(int CompanyID, int AddressID, int AddressTypeID, String Description, String Notes)
        {

            String sqlStatementString = "UPDATE CompanyAddresses SET Description = @Description, Notes = @Notes WHERE CompanyID = @CompanyID AND AddressID = @AddressID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
            dbCommand.Parameters.AddWithValue("@AddressTypeID", AddressTypeID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeleteCompanyAddresses(int CompanyID)
        {
            //DELETE FROM PersonAddresses WHERE PersonID = @PersonID AND AddressID = @AddressID
            String sqlStatementString = "DELETE FROM CompanyAddresses WHERE CompanyID = @CompanyID AND AddressID = @AddressID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeleteCompanyAddress(int CompanyID, int AddressID)
        {
            //DELETE FROM PersonAddresses WHERE PersonID = @PersonID AND AddressID = @AddressID
            String sqlStatementString = "DELETE FROM CompanyAddresses WHERE CompanyID = @CompanyID AND AddressID = @AddressID ";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }


        #endregion

        #region "Company Contacts"

        #endregion

        #region "Supplier"


        public DataSet FetchSupplier()
        {
            DataSet supplierDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM Supplier";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(supplierDataSet);  //15

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return supplierDataSet;
        }

        public DataSet FetchSupplier(int SupplierID)
        {
            DataSet personDataSet = new DataSet();

            String sqlStatementString = "SELECT CustomerNumber, Notes FROM Supplier WHERE SupplierID = @SupplierID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@SupplierID", SupplierID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(personDataSet);

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return personDataSet;
        }

        public void InsertSupplier(String CustomerNumber, String Notes)
        {

            String sqlStatementString = "INSERT INTO Supplier (CustomerNumber, Notes) VALUES (@CustomerNumber, @Notes)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CustomerNumber", Notes);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void UpdateSupplier(int SupplierID, String CustomerNumber, String Notes)
        {

            String sqlStatementString = "UPDATE Supplier SET CustomerNumber = @CustomerNumber, Notes = @Notes WHERE SupplierID = @SupplierID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@CustomerNumber", CustomerNumber);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.Parameters.AddWithValue("@SupplierID", SupplierID);
            dbCommand.ExecuteNonQuery();            //Execute Non Query method is used if there is not a return value for a function 

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeleteSupplier(int SupplierID)
        {

            String sqlStatementString = "DELETE FROM Supplier WHERE SupplierID = @SupplierID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@SupplierID", SupplierID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }


        #endregion

        #region "PhoneTypes"

        public DataSet FetchPhoneTypes()
        {
            DataSet phoneTypesDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM PhoneTypes";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(phoneTypesDataSet);  //15

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return phoneTypesDataSet;
        }

        public DataSet FetchPhoneType(int PhoneTypeID)
        {
            DataSet phoneTypesDataSet = new DataSet();

            String sqlStatementString = "SELECT Name, Description FROM PhoneTypes WHERE PhoneTypeID = @PhoneTypeID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(phoneTypesDataSet);  //16

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return phoneTypesDataSet;
        }

        public void InsertPhoneTypes(String Name, String Description)
        {

            String sqlStatementString = "INSERT INTO PhoneTypes (Name, Description) VALUES (@Name, @Description";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void UpdatePhoneType(int PhoneTypeID, String Name, String Description)
        {

            String sqlStatementString = "UPDATE Person SET FirstName = @FirstName, LastName = @LastName WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);
            dbCommand.ExecuteNonQuery();            //Execute Non Query method is used if there is not a return value for a function 

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void DeletePhoneType(int PhoneTypeID)
        {

            String sqlStatementString = "DELETE FROM PhoneTypes WHERE PhoneTypeID = @PhoneTypeID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        #endregion

        #region "Categories"


        #endregion

        //Phone Types, and Company Phones, Category 
        // The Manufacturer and Supplier Notes could contain all of the information about the supplier and manufactureres,
        //and Is added automatically when a product is added with a new manufacturer name.

    }
}
#endregion
